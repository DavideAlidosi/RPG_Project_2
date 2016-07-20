using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    public int str;
    public int cos;
    public int hp;
    public int agi;
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
        str = 4;
        cos = 3;
        hp = cos * 4;
        agi = Random.Range(1, 5);
        vista = 4;
        move = 2;

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

        //Color ciao = new Color(Random.value, Random.value, Random.value);
        
        for (int i = (myI - vista); i <= (myI + vista); i++)
        {
            for (int j = (myJ - vista); j <= (myJ + vista); j++)
            {
                if (i < 0)
                    continue;
                if (j < 0)
                    continue;
                if (i > Grid.COL-1)
                    continue;
                if (j > Grid.ROW-1)
                    continue;
                lookCell.Add(refGrid.cellMat[i, j]);
                if (refGrid.cellMat[i, j].isWall)
                {
                    continue;
                }

                if (refGrid.cellMat[i, j].GetComponentInChildren<Enemy>())
                {
                    continue;
                }
                if (Mathf.Abs(i - myI) + Mathf.Abs(j - myJ) <= (vista))
                {
                    if (refGrid.cellMat[i, j].GetComponentInChildren<Player>())
                    {
                        isPlayerVisible = true;


                    }
                    
                }
            }
        }

        if (isPlayerVisible)
        {
            RangeMove();
        }
    }

    void RangeMove()
    {
        int myI = refMyCell.myI;
        int myJ = refMyCell.myJ;
        moveCell.Clear();

        int rangeMove = 2;
        for (int i = (myI - vista); i <= (myI + rangeMove); i++)
        {
            for (int j = (myJ - vista); j <= (myJ + rangeMove); j++)
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
                if (Mathf.Abs(i - myI) + Mathf.Abs(j - myJ) <= (rangeMove))
                {
                    moveCell.Add(refGrid.cellMat[i, j]);
                    //refGrid.cellMat[i, j].GetComponent<SpriteRenderer>().color = Color.gray;
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
                if (Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ) >= (move))
                {
                    
                    if (distance > Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ))
                    {
                        distance = Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ);
                        nearestCell = cell;
                        
                        
                    }
                }

                
            }
        }
        Debug.Log(nearestCell);
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
        int myI = refMyCell.myI;
        int myJ = refMyCell.myJ;
        lookCell.Clear();

        for (int i = (myI - vista); i <= (myI + vista); i++)
        {
            for (int j = (myJ - vista); j <= (myJ + vista); j++)
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
                    continue;
                }
                if (refGrid.cellMat[i, j].isWall)
                {
                    continue;
                }

                if (Mathf.Abs(i - myI) + Mathf.Abs(j - myJ) <= move)
                {
                    //refGrid.cellMat[i, j].refMyTile.color = Color.red;
                    if (refGrid.cellMat[i, j].refMyTile.color != Color.yellow)
                    {
                        
                        if (refGrid.cellMat[i, j].refMyTile.color == Color.green)
                        {
                            lookCell.Add(refGrid.cellMat[i, j]);
                            refGrid.cellMat[i, j].refMyTile.color = new Color(0, 0.2f, 0);
                        }
                        else
                        {
                            lookCell.Add(refGrid.cellMat[i, j]);
                            refGrid.cellMat[i, j].refMyTile.color = Color.red;
                        }
                    }
                    continue;

                }
                if (Mathf.Abs(i - myI) + Mathf.Abs(j - myJ) <= vista)
                {
                    if (refGrid.cellMat[i, j].refMyTile.color != Color.yellow)
                    {
                        if (refGrid.cellMat[i, j].refMyTile.color == Color.green)
                        {
                            refGrid.cellMat[i, j].refMyTile.color = new Color(0, 0.5f, 0);
                            lookCell.Add(refGrid.cellMat[i, j]);

                        }
                        else
                        {
                            lookCell.Add(refGrid.cellMat[i, j]);
                            refGrid.cellMat[i, j].refMyTile.color = Color.yellow;
                        }

                    }
                }
                

            }
        }
    }

    public void ResetLookingCell()
    {
        foreach (var cell in lookCell)
        {
            
            cell.refMyTile.color = Color.white;
        }
    }

    
}
