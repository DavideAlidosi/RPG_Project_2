﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public IEnumerator EnemyTurn()
    {
        enemies = FindObjectsOfType<Enemy>();
        refFog = FindObjectOfType<FogOfWar>();
        
        
        foreach (var enemy in enemies)
        {

            Pathfind path = enemy.GetComponent<Pathfind>();
            enemy.refMyCell = enemy.GetComponentInParent<Cell>();
            if (enemy.refMyCell == null)
                continue;
            refGC.enemyCell = enemy.refMyCell.gameObject;
            
            
            refGrid.CreateGridEnemy(enemy.refMyCell.myI, enemy.refMyCell.myJ);
            enemy.ManhattanSearch();
            if (enemy.isPlayerVisible)
            {
                path.ReachableCells(enemy.vista, enemy.moveCell);
                path.Pathfinding(enemy.SearchPlayer().myI, enemy.SearchPlayer().myJ);
                path.ChooseMinPath(enemy.canMoveCell);
                StartCoroutine(moveEnemy(enemy));
            }
            

            
            
            //enemy.MoveEnemy();

            //
            

            refFog.GetPlayerNearEnemy(enemy.refMyCell.myI, enemy.refMyCell.myJ);
            
            if (enemy.isNear)
            {
                refGC.CombatEnemy(enemy);
                
            }
            yield return new WaitForSeconds(0.5f);
        }
        refGrid.CreateGrid();
        refGC.phase = GamePhase.Selezione;
    }

    public IEnumerator moveEnemy(Enemy other)
    {
        List<Cell> cellToMove = other.GetComponent<Pathfind>().pathCell;
        for (int i = cellToMove.Count -1 ; i >= 0; i--)
        {
            other.refMyCell = refGrid.cellMat[cellToMove[i].myI, cellToMove[i].myJ];
            other.transform.parent = refGrid.cellMat[cellToMove[i].myI, cellToMove[i].myJ].transform;
            other.transform.localPosition = new Vector3(0, 0, 1);
            yield return new WaitForSeconds(0.2f);
        }
        
    }


}
