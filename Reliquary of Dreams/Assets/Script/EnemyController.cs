using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    GameControl refGC;
    public Grid refGrid;
    public FogOfWar refFog;
    public Enemy[] enemies;
    // Use this for initialization
    void Start () {
        refGC = FindObjectOfType<GameControl>();
        refGrid = FindObjectOfType<Grid>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnemyTurn()
    {
        enemies = FindObjectsOfType<Enemy>();
        refFog = FindObjectOfType<FogOfWar>();
        
        foreach (var enemy in enemies)
        {
            
            
            enemy.refMyCell = enemy.GetComponentInParent<Cell>();
            if (enemy.refMyCell == null)
                continue;
            refGC.enemyCell = enemy.refMyCell.gameObject;
            Debug.Log(enemy.GetComponentInParent<Cell>());
            
            refGrid.CreateGridEnemy(enemy.refMyCell.myI, enemy.refMyCell.myJ);
            enemy.ManhattanSearch();
            enemy.SearchPlayer();
            enemy.MoveEnemy();
            
            refFog.GetPlayerNearEnemy(enemy.refMyCell.myI, enemy.refMyCell.myJ);
            
            if (enemy.isNear)
            {
                refGC.CombatEnemy(enemy);
                
            }
        }
        refGrid.CreateGrid();
        refGC.phase = GamePhase.Selezione;
    }

    
}
