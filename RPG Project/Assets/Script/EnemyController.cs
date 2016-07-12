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
        foreach (var enemy in enemies)
        {
            refGrid.CreateGridEnemy(enemy.refMyCell.myI, enemy.refMyCell.myJ);
            enemy.ManhattanSearch();
            enemy.SearchPlayer();
            enemy.MoveEnemy();
            refGC.enemyCell = enemy.refMyCell.gameObject;
            refFog.GetPlayerNearEnemy(enemy.GetComponentInParent<Cell>().myI, enemy.GetComponentInParent<Cell>().myJ);
            
            if (enemy.isNear)
            {
                refGC.CombatEnemy();
                
            }
        }
        refGrid.CreateGrid();
        refGC.phase = GamePhase.Selezione;
    }
}
