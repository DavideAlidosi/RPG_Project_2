using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour {

    private Grid refGrid;
    GameControl refGC;
    //private int vista = 4;
    public List<Cell> enemyCell = new List<Cell>();
    public List<Cell> destroyCell = new List<Cell>();

    //Cell enemyCell;

    void Start()
    {
        refGrid = FindObjectOfType<Grid>();
        refGC = FindObjectOfType<GameControl>();
        RefreshEnemyList();
    }

    public void Fog(Vector2 pos,int vista)
    {
        int _x = (int)pos.x;
        int _y = (int)pos.y;

        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {


                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > 19)
                    continue;
                if (y > 19)
                    continue;

                if (refGrid.cellMat[i,y].isWall)
                {
                    continue;
                }
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista))
                {
                    SpriteRenderer sr = refGrid.cellMat[i, y].gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.blue;
                    refGrid.cellMat[i, y].isFree = true;
                    destroyCell.Add(refGrid.cellMat[i, y]);

                    //coloring the enemy cell and toggle the status free
                    if (refGrid.cellMat[i,y].GetComponentInChildren<Enemy>())
                    {
                        
                        //enemyCell = grid.cellMat[i, y];
                        refGrid.cellMat[i, y].isFree = false;
                        refGrid.cellMat[i, y].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    
                }
                //Per rendere le celle meno visibili
                /*if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista / 2))
                {
                    SpriteRenderer sr = grid.cellMat[i, y].gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.clear;
                }*/


            }
        }

        //Coloring the adjacent of enemy
        if (enemyCell != null)
        {
            RefreshEnemyList();
            GetEnemy();
        }
        
        //remove all cell from this list for optimization

        enemyCell.Clear();
        
        
    }
    // NON E' ASTAR  ma ricolora le celle in bianco e le rende di nuovo non libere
    public void AStar()
    {
        List<Cell> controlled = new List<Cell>();
        
        foreach (var cell in destroyCell)
        {
            
            if (cell.myI < 0)
                continue;
            if (cell.myJ < 0)
                continue;
            if (cell.myI > 18)
                continue;
            if (cell.myJ > 18)
                continue;

            if (refGrid.cellMat[cell.myI+1,cell.myJ].isFree)            
                continue;
            if (refGrid.cellMat[cell.myI, cell.myJ+1].isFree)            
                continue;
            if (refGrid.cellMat[cell.myI - 1, cell.myJ].isFree)
                continue;
            if (refGrid.cellMat[cell.myI, cell.myJ - 1].isFree)
                continue;

            
            
            cell.isFree = false;
            
            cell.GetComponent<SpriteRenderer>().color = Color.white;
            

        }
    }

    public void CleanMove()
    {
        foreach (var cell in destroyCell)
        {
            cell.isFree = false;
            cell.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        destroyCell.Clear();        
    }

    void GetEnemy()
    {
        
        foreach (var cell in enemyCell)
        {
            int newI = cell.myI;
            int newJ = cell.myJ;
            if (refGrid.cellMat[newI + 1, newJ].isFree)
            {
                //refGrid.cellMat[newI + 1, newJ].isCombat = true;
                refGrid.cellMat[newI + 1, newJ].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (refGrid.cellMat[newI - 1, newJ].isFree)
            {
                //refGrid.cellMat[newI - 1, newJ].isCombat = true;
                refGrid.cellMat[newI - 1, newJ].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (refGrid.cellMat[newI, newJ + 1].isFree)
            {
                //refGrid.cellMat[newI, newJ + 1].isCombat = true;
                refGrid.cellMat[newI, newJ + 1].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (refGrid.cellMat[newI, newJ - 1].isFree)
            {
                //refGrid.cellMat[newI, newJ - 1].isCombat = true;
                refGrid.cellMat[newI, newJ - 1].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    void RefreshEnemyList()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (refGrid.cellMat[i, j].GetComponentInChildren<Enemy>())
                {
                    enemyCell.Add(refGrid.cellMat[i, j]);
                }
            }
        }
    }

    public void GetEnemyNearPlayer(int newI,int newJ)
    {
        //int newI = GetComponentInParent<Cell>().myI;
        //int newJ = GetComponentInParent<Cell>().myJ;
        
        if (refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Enemy>())
        {
            refGC.enemyCell = refGrid.cellMat[newI + 1, newJ].gameObject;
            refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Enemy>().isNear = true;
                
        }

        if (refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Enemy>())
        {
            refGC.enemyCell = refGrid.cellMat[newI - 1, newJ].gameObject;
            refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Enemy>().isNear = true;
                
        }

        if (refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Enemy>())
        {
            refGC.enemyCell = refGrid.cellMat[newI, newJ + 1].gameObject;
            refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Enemy>().isNear = true;
                
        }

        if (refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Enemy>())
        {
            refGC.enemyCell = refGrid.cellMat[newI, newJ - 1].gameObject;
            refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Enemy>().isNear = true;

        }
        
    }

    public void GetPlayerNearEnemy(int newI, int newJ)
    {
        //int newI = GetComponentInParent<Cell>().myI;
        //int newJ = GetComponentInParent<Cell>().myJ;

        if (refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Player>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI + 1, newJ].gameObject;
            refGrid.cellMat[newI , newJ].GetComponentInChildren<Enemy>().isNear = true;

        }

        if (refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Player>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI - 1, newJ].gameObject;
            refGrid.cellMat[newI , newJ].GetComponentInChildren<Enemy>().isNear = true;

        }

        if (refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Player>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI, newJ + 1].gameObject;
            refGrid.cellMat[newI, newJ ].GetComponentInChildren<Enemy>().isNear = true;

        }

        if (refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Player>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI, newJ - 1].gameObject;
            refGrid.cellMat[newI, newJ ].GetComponentInChildren<Enemy>().isNear = true;

        }

    }

    public void ResetEnemyStatus()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.isNear = false;
        }
    }




}
