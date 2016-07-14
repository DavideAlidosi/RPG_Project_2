using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour {

    private Grid refGrid;
    GameControl refGC;
    //private int vista = 4;
    public List<Cell> enemyCell = new List<Cell>();
    public List<Cell> destroyCell = new List<Cell>();
    public List<Cell> lightCell = new List<Cell>();

    //Cell enemyCell;

    void Start()
    {
        refGrid = FindObjectOfType<Grid>();
        refGC = FindObjectOfType<GameControl>();
        //RefreshEnemyList();
        //LightRadius();
    }

    public void Fog(Vector2 pos,int vista)
    {
        int _x = (int)pos.x;
        int _y = (int)pos.y;

        Vector2[] directions = new Vector2[4];

        /*directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);*/

        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {


                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > Grid.COL-1)
                    continue;
                if (y > Grid.ROW-1)
                    continue;

                if (refGrid.cellMat[i,y].isWall)
                {
                    continue;
                }
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista))
                {
                    SpriteRenderer sr = refGrid.cellMat[i, y].refMyTile;
                    if (sr != null)
                    {
                        sr.color = Color.green;
                    }
                    
                    refGrid.cellMat[i, y].isFree = true;
                    destroyCell.Add(refGrid.cellMat[i, y]);

                    //coloring the enemy cell and toggle the status free
                    if (refGrid.cellMat[i,y].GetComponentInChildren<Enemy>())
                    {
                        
                        //enemyCell = grid.cellMat[i, y];
                        refGrid.cellMat[i, y].isFree = false;
                        refGrid.cellMat[i, y].refMyTile.color = Color.yellow;
                    }
                    
                }
                //Per rendere le celle meno visibili
                /*if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista / 2))
                {
                    SpriteRenderer sr = refGrid.cellMat[i, y].refMyTile;
                    sr.color = Color.green;
                }*/


            }
        }

        //Coloring the adjacent of enemy
        RefreshEnemyList();
        if (enemyCell.Count > 0)
        {         
            GetEnemy();
            
        }

        //remove all cell from this list for optimization

        //enemyCell.Clear();


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
            //if (cell.myI > 18)
                
            //if (cell.myJ > 18)
                

            if (refGrid.cellMat[cell.myI+1,cell.myJ].isFree)            
                continue;
            if (refGrid.cellMat[cell.myI, cell.myJ+1].isFree)            
                continue;
            if (refGrid.cellMat[cell.myI - 1, cell.myJ].isFree)
                continue;
            if (refGrid.cellMat[cell.myI, cell.myJ - 1].isFree)
                continue;

            
            
            cell.isFree = false;
            
            cell.refMyTile.color = Color.white;
            

        }
    }

    public void CleanMove()
    {
        foreach (var cell in destroyCell)
        {
            cell.isFree = false;
            if (cell.refMyTile.color == null)
            {
                continue;
                
            }
            cell.refMyTile.color = Color.white;

        }
        destroyCell.Clear();        
    }

    
    //Coloring the cell in the edge of player movement 
    void GetEnemy()
    {
        
        foreach (var cell in enemyCell)
        {
            int newI = cell.myI;
            int newJ = cell.myJ;
            if (refGrid.cellMat[newI + 1, newJ] != null && refGrid.cellMat[newI + 1, newJ].isFree)
            {
                //refGrid.cellMat[newI + 1, newJ].isCombat = true;
                refGrid.cellMat[newI , newJ].refMyTile.color = Color.red;
            }

            if (refGrid.cellMat[newI - 1, newJ] != null && refGrid.cellMat[newI - 1, newJ].isFree)
            {
                //refGrid.cellMat[newI - 1, newJ].isCombat = true;
                refGrid.cellMat[newI, newJ].refMyTile.color = Color.red;
            }

            if (refGrid.cellMat[newI, newJ + 1] != null && refGrid.cellMat[newI, newJ + 1].isFree)
            {
                //refGrid.cellMat[newI, newJ + 1].isCombat = true;
                refGrid.cellMat[newI, newJ].refMyTile.color = Color.red;
            }

            if (refGrid.cellMat[newI, newJ - 1] != null && refGrid.cellMat[newI, newJ - 1].isFree)
            {
                //refGrid.cellMat[newI, newJ - 1].isCombat = true;
                refGrid.cellMat[newI, newJ].refMyTile.color = Color.red;
            }
        }
    }



    void RefreshEnemyList()
    {
        
        int playerX = refGrid.playerLinking.GetComponentInParent<Cell>().myI;
        int playerY = refGrid.playerLinking.GetComponentInParent<Cell>().myJ;
        /*for (int i = (playerX - range); i < (playerX + range); i++)
        {
            for (int j = (playerY - range); j < (playerY + range); j++)
            {
                if (i < 0)
                    continue;
                if (j < 0)
                    continue;
                if (i > Grid.COL - 1)
                    continue;
                if (j > Grid.ROW - 1)
                    continue;
                if (refGrid.cellMat[i, j].GetComponentInChildren<Enemy>())
                {
                    enemyCell.Add(refGrid.cellMat[i, j]);
                }
            }
        }   */
        Enemy[] tmpEnemy = FindObjectsOfType<Enemy>();
        foreach (var enemy in tmpEnemy)
        {
            enemyCell.Add(enemy.GetComponentInParent<Cell>());
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
        

        if (refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Player>())
        {
            refGrid.cellMat[newI , newJ].GetComponentInChildren<Enemy>().isNear = true;

        }

        if (refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Player>())
        {
            refGrid.cellMat[newI , newJ].GetComponentInChildren<Enemy>().isNear = true;

        }

        if (refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Player>())
        {
            refGrid.cellMat[newI, newJ ].GetComponentInChildren<Enemy>().isNear = true;

        }

        if (refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Player>())
        {
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

    public void LightRadius()
    {
        int vista = 6;
        int _x = GetComponentInParent<Cell>().myI;
        int _y = GetComponentInParent<Cell>().myJ;
        refGrid.cellMat[_x,_y].refMyTile.color = Color.white;
        ClearLight();
        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {


                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > Grid.COL - 1)
                    continue;
                if (y > Grid.ROW - 1)
                    continue;

                if (refGrid.cellMat[i, y] == null  || refGrid.cellMat[i, y].isWall)
                {
                    continue;
                }
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista))
                {
                    refGrid.cellMat[i, y].refMyTile.color = Color.white;
                    lightCell.Add(refGrid.cellMat[i, y]);
                    if (refGrid.cellMat[i,y].GetComponentInChildren<Enemy>())
                    {
                        refGrid.cellMat[i, y].GetComponentInChildren<Enemy>().gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }

            }
        }

    }

    public void ClearLight()
    {
        if (lightCell != null)
        {
            foreach (var cell in lightCell)
            {
                cell.refMyTile.color = Color.grey;
                if (cell.GetComponentInChildren<Enemy>())
                {
                    cell.GetComponentInChildren<Enemy>().gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
                }
               
            }

        }
        lightCell.Clear();
        
    }

}
