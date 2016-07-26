using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    public int str;
    public int cos;
    public int hp;
    public int agi;
    public int intS;
    public int per;
    public int forS;

    public bool isNear = false;
    public bool isPlayerVisible = false;
    Grid refGrid;
    public int vista;
    
    public int move;
    GameControl refGC;
    public Cell refMyCell;
    public Cell nearestCell;
    public List<Cell> moveCell = new List<Cell>();
    public List<Cell> lookCell = new List<Cell>();
    public List<Cell> canMoveCell = new List<Cell>();

    // Use this for initialization
    void Start()
    {

        refGrid = FindObjectOfType<Grid>();
        
        refGC = FindObjectOfType<GameControl>();        
        hp = cos * 4;      
        //vista = 4;
        //move = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManhattanSearch()
    {
        int myI = refMyCell.myI;
        int myJ = refMyCell.myJ;
        moveCell.Clear();
        
        isPlayerVisible = false;
        
        foreach (var cell in lookCell)
        {
            if (cell.GetComponentInChildren<Enemy>())
            {
                continue;
            }
            if (Mathf.Abs(cell.myI - myI) + Mathf.Abs(cell.myJ - myJ) <= (per))
            {
                if (refGrid.cellMat[cell.myI, cell.myJ].GetComponentInChildren<Player>())
                {
                    isPlayerVisible = true;


                }

            }
        }
        if (isPlayerVisible)
        {
            moveCell.Clear();
        }
    }

    void RangeMove()
    {
        int myI = refMyCell.myI;
        int myJ = refMyCell.myJ;
        moveCell.Clear();

       
        for (int i = (myI - per); i <= (myI + per); i++)
        {
            for (int j = (myJ - per); j <= (myJ + per); j++)
            {
                if (i < 0)
                    continue;
                if (j < 0)
                    continue;
                if (i > Grid.COL-1)
                    continue;
                if (j > Grid.ROW-1)
                    continue;

                if (refGrid.cellMat[i, j].isWall)
                {
                    continue;
                }
                if (refGrid.cellMat[i, j].GetComponentInChildren<Player>())
                {
                    continue;
                }
                if (refGrid.cellMat[i, j].GetComponentInChildren<Enemy>())
                {
                    continue;
                }
                if (Mathf.Abs(i - myI) + Mathf.Abs(j - myJ) <= (per))
                {
                    moveCell.Add(refGrid.cellMat[i, j]);
                    refGrid.cellMat[i, j].sBox.color = Color.gray;
                }
            }
        }
    }

    public Cell SearchPlayer()
    {
        //Cell nearestCell;
        int playerX = refGC.playerCell.GetComponent<Cell>().myI;
        int playerY = refGC.playerCell.GetComponent<Cell>().myJ;
       
        int distance = 1000;
        
        canMoveCell.Clear();
        if (isPlayerVisible)
        {
            foreach (var cell in moveCell)
            {
                
                
                    
                if (distance > Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ))
                {
                        
                    distance = Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ);
                    nearestCell = cell;
                        
                        
                }
                

                
            }
        }
        
        return nearestCell;

    }

    public void MoveEnemy()
    {
        if (nearestCell != null)
        {
            int nearestI = nearestCell.myI;
            int nearestJ = nearestCell.myJ;
            this.transform.parent = refGrid.cellMat[nearestI, nearestJ].transform;
            this.transform.localPosition = new Vector3(0, 0, 1);
            refMyCell = nearestCell;
            nearestCell = null;
        }
    }

    //coloring the cell when mouse is over the enemy
    public void LookingCell()
    {
        List<Cell> enemyMoveCell = new List<Cell>();

        int myI = refMyCell.myI;
        int myJ = refMyCell.myJ;
        lookCell.Clear();

        GetComponent<Pathfind>().ReachableCells(per, lookCell);
        GetComponent<Pathfind>().ReachableCells(agi, enemyMoveCell);

        foreach (var cell in enemyMoveCell)
        {
            
            if (cell.refMyTile.color == Color.gray)
            {
                continue;
            }
            if (cell.refMyTile.color == Color.green)
            {
                cell.refMyTile.color = new Color(0, 0.2f, 0);
                
            }
            else
            {
                cell.refMyTile.color = Color.red;
                
            }
            


        }

        foreach (var cell  in lookCell)
        {
            cell.isFree = false;
            if (cell.refMyTile.color == Color.red)
            {
                continue;
            }
            if (cell.refMyTile.color == new Color(0, 0.2f, 0))
            {
                cell.isFree = true; 
                continue;
            }
            if (cell.refMyTile.color == Color.gray)
            {
                continue;
            }
            if (cell.GetComponentInChildren<Enemy>())
            {
                continue;
            }
            else if (cell.refMyTile.color == Color.green)
            {
                cell.refMyTile.color = new Color(0, 0.5f, 0);
                cell.isFree = true;

            }
            else 
            {
                cell.refMyTile.color = Color.yellow;
                
            }
            
            
        }

        
    }

    public void ResetLookingCell()
    {
        foreach (var cell in lookCell)
        {
            if (cell.GetComponentInChildren<Enemy>())
            {
                continue;
            }
            if (cell.refMyTile.color != Color.gray)
            {
                cell.refMyTile.color = Color.white;
                
            }
            
        }
    }

    
}
