using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    GameControl refGC;
    public Grid refGrid;
    public FogOfWar refFog;
    public Enemy[] enemies;
    bool end = false;
    // Use this for initialization
    void Start () {
        refGC = FindObjectOfType<GameControl>();
        refGrid = FindObjectOfType<Grid>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator EnemyTurn()
    {
        enemies = FindObjectsOfType<Enemy>();
        refFog = FindObjectOfType<FogOfWar>();
        
        
        foreach (var enemy in enemies)
        {
            end = false;
            Pathfind path = enemy.GetComponent<Pathfind>();
            enemy.refMyCell = enemy.GetComponentInParent<Cell>();
            if (enemy.refMyCell == null)
                continue;
            refGC.enemyCell = enemy.refMyCell.gameObject;
            
            
            //refGrid.CreateGridEnemy(enemy.refMyCell.myI, enemy.refMyCell.myJ);
            path.ReachableCells((enemy.per), enemy.lookCell);

            // Movimento nemico ricerca caselle e casella più vicino al player
            enemy.ManhattanSearch();
            if (enemy.isPlayerVisible)
            {
                path.ReachableCells((enemy.agi) +1, enemy.moveCell);

                Cell nearestToPlayer = enemy.SearchPlayer();
                path.Pathfinding(refGrid.playerLinking.GetComponentInParent<Cell>().myI, refGrid.playerLinking.GetComponentInParent<Cell>().myJ);
                path.ChooseMinPath(enemy.moveCell);
                StartCoroutine(moveEnemy(enemy));
            }
           
            yield return new WaitForSeconds(0.2f);

            
            foreach (var cell in enemy.moveCell)
            {
                cell.isFree = false;
            }
            foreach (var cell in enemy.lookCell)
            {
                cell.isFree = false;
            }
        }
        //refGrid.CreateGrid();
        refGC.phase = GamePhase.Movimento;
       
        refGC.ResetToSelectionPhase();
            
       
        
    }

    public IEnumerator moveEnemy(Enemy other)
    {
        List<Cell> cellToMove = other.GetComponent<Pathfind>().pathCell;
        for (int i = cellToMove.Count -1 ; i >= 0; i--)
        {
            other.refMyCell = refGrid.cellMat[cellToMove[i].myI, cellToMove[i].myJ];
            other.transform.parent = refGrid.cellMat[cellToMove[i].myI, cellToMove[i].myJ].transform;
            other.transform.localPosition = new Vector3(0, 0, 1);
            yield return new WaitForSeconds(0.1f);
        }

        refFog.GetPlayerNearEnemy(other.refMyCell.myI, other.refMyCell.myJ);
        if (other.isNear)
        {
            refGC.CombatEnemy(other);

        }
        end = true;
        //yield return new WaitForSeconds(0.2f);
    }


}
