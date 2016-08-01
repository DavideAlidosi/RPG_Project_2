using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Pathfind : MonoBehaviour {

    Grid refGrid;
    public List<Vector3> pathList = new List<Vector3>();
    public List<Cell> pathCell = new List<Cell>();

    void Start()
    {
        refGrid = FindObjectOfType<Grid>();
    }

    public void ReachableCells(int range, List<Cell> reachable)
    {
        reachable.Clear();
        Apri(GetComponentInParent<Cell>(), range, reachable);
    }

    void Apri(Cell c, int range, List<Cell> reachable)
    {
        reachable.Add(c);
        int playerX = reachable[0].myI;
        int playerY = reachable[0].myJ;
       

        if (!reachable.Contains(refGrid.cellMat[c.myI + 1, c.myJ]) && IsAdjacent(c, 1, 0) && InManhattan(range, c.myI + 1, c.myJ, playerX, playerY))
        {
            Apri(refGrid.cellMat[c.myI + 1, c.myJ], range, reachable);
        }
        if (!reachable.Contains(refGrid.cellMat[c.myI - 1, c.myJ]) && IsAdjacent(c, -1, 0) && InManhattan(range, c.myI - 1, c.myJ, playerX, playerY))
        {
            Apri(refGrid.cellMat[c.myI - 1, c.myJ], range, reachable);
        }
        if (!reachable.Contains(refGrid.cellMat[c.myI, c.myJ + 1]) && IsAdjacent(c, 0, 1) && InManhattan(range, c.myI, c.myJ + 1, playerX, playerY))
        {
            Apri(refGrid.cellMat[c.myI, c.myJ + 1], range, reachable);
        }
        if (!reachable.Contains(refGrid.cellMat[c.myI, c.myJ - 1]) && IsAdjacent(c, 0, -1) && InManhattan(range, c.myI, c.myJ - 1, playerX, playerY))
        {
            Apri(refGrid.cellMat[c.myI, c.myJ - 1], range, reachable);
        }
    }

    bool IsAdjacent(Cell c, int posI, int posJ)
    {
        int newI = c.myI;
        int newJ = c.myJ;
        bool isFind = false;
        if (!refGrid.cellMat[newI + posI, newJ + posJ].isWall)
        {
            isFind = true;
            refGrid.cellMat[newI + posI, newJ + posJ].isFree = true;
           
        }
        if (refGrid.cellMat[newI + posI, newJ + posJ].GetComponentInChildren<Enemy>())
        {
            isFind = false;
            refGrid.cellMat[newI + posI, newJ + posJ].isFree = false; 

        }

        return isFind;
    }

    bool InManhattan(int range, int xDest, int yDest, int xStart, int yStart)
    {
        
        bool inMan = false;
        if (Mathf.Abs(xStart - xDest) + Mathf.Abs(yStart - yDest) <= (range))
        {
            inMan = true;
        }

        return inMan;
    }

    public void Pathfinding(int _myI, int _myJ)
    {

        int destX = GetComponentInParent<Cell>().myI;  
        int destY = GetComponentInParent<Cell>().myJ;  
        int startX = _myI;
        int startY = _myJ;
        int count = 0;
        

        pathList.Clear();

        Vector3 destinationPoint = new Vector3(destX, destY, count);
        Vector3 startPoint = new Vector3(startX, startY, count);

        Apri(pathList, destinationPoint, startX, startY);


    }

    void Apri(List<Vector3> pathList, Vector3 v, int startX, int startY)
    {
        
        pathList.Add(v);
        //Debug.Log("X : "+startX+" Y : "+startY);
        //Debug.Log("VX : "+v.x+" VY : "+v.y);
        Vector3 tempVUp = new Vector3(v.x + 1, v.y, v.z + 1);
        Vector3 tempVDown = new Vector3(v.x - 1, v.y, v.z + 1);
        Vector3 tempVRight = new Vector3(v.x, v.y + 1, v.z + 1);
        Vector3 tempVLeft = new Vector3(v.x, v.y - 1, v.z + 1);

        if (v.x != startX || v.y != startY)
        {
            if (v.z < 10)
            {


                if (refGrid.cellMat[(int)v.x + 1, (int)v.y].isFree && !IsContainedInList(tempVUp))
                {
                    //CleanPathList(tempVUp);
                    Apri(pathList, tempVUp, startX, startY);
                }

                if (refGrid.cellMat[(int)v.x - 1, (int)v.y].isFree && !IsContainedInList(tempVDown))
                {
                    //CleanPathList(tempVDown);
                    Apri(pathList, tempVDown, startX, startY);
                }
                if (refGrid.cellMat[(int)v.x, (int)v.y + 1].isFree && !IsContainedInList(tempVRight))
                {
                    //CleanPathList(tempVRight);
                    Apri(pathList, tempVRight, startX, startY);
                }
                if (refGrid.cellMat[(int)v.x, (int)v.y - 1].isFree && !IsContainedInList(tempVLeft))
                {
                    //CleanPathList(tempVLeft);
                    Apri(pathList, tempVLeft, startX, startY);
                }
            }

        }
    }

    bool IsContainedInList(Vector3 v)
    {
        bool isContained = false;

        foreach (var item in pathList)
        {
            if (item.x == v.x && item.y == v.y)
            {
                if (v.z >= item.z)
                {
                    isContained = true;
                }
            }
        }

        return isContained;
    }

    void CleanPathList(Vector3 v)
    {
        for (int i = pathList.Count - 1; i > 1; i--)
        {
            if (pathList[i].x == v.x && pathList[i].y == v.y)
            {
                if (v.z < pathList[i].z)
                {
                    pathList.RemoveAt(i);
                    
                }
            }
        }
    }

    public void ChooseMinPath(List<Cell> _moveCell)
    {
        Cell cellNearest = GetComponent<Enemy>().SearchPlayer();
        int startX = cellNearest.myI;
        int startY = cellNearest.myJ;
        
        int countStart = 0;
        foreach (var item in pathList)
        {
            if (item.x == startX && item.y == startY)
            {

                countStart = (int)item.z;

            }
        }
        int tempCount = countStart;
        foreach (var item in pathCell)
        {
            item.sBox.color = Color.clear;
        }
        pathCell.Clear();
        for (int i = 0; i < countStart; i++)
        {

            foreach (var item in pathList)
            {
                if (startX + 1 == item.x && startY == item.y && item.z == tempCount - 1)
                { 

                    startX = (int)item.x;
                    startY = (int)item.y;
                    tempCount--;
                    pathCell.Add(refGrid.cellMat[startX, startY]);
                    refGrid.cellMat[startX, startY].sBox.color = Color.gray;


                }
                if (startX - 1 == item.x && startY == item.y && item.z == tempCount - 1)
                {
                    startX = (int)item.x;
                    startY = (int)item.y;
                    tempCount--;
                    pathCell.Add(refGrid.cellMat[startX, startY]);
                    refGrid.cellMat[startX, startY].sBox.color = Color.gray;
                }
                if (startX == item.x && startY + 1 == item.y && item.z == tempCount - 1)
                {
                    startX = (int)item.x;
                    startY = (int)item.y;
                    tempCount--;
                    pathCell.Add(refGrid.cellMat[startX, startY]);
                    refGrid.cellMat[startX, startY].sBox.color = Color.gray;
                }
                if (startX == item.x && startY - 1 == item.y && item.z == tempCount - 1)
                {
                    startX = (int)item.x;
                    startY = (int)item.y;
                    tempCount--;
                    pathCell.Add(refGrid.cellMat[startX, startY]);
                    refGrid.cellMat[startX, startY].sBox.color = Color.gray;
                }
            }
        }
        foreach (var cell in _moveCell)
        {
            cell.isFree = false;
        }

    }
}
