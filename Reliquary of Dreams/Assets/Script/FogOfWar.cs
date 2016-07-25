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
	//public List<Cell> reachable = new List<Cell>();
	public List<Vector3> pathList = new List<Vector3>();
	public List<Cell> pathProva = new List<Cell>();

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

        

        
		ReachableCells (vista, destroyCell);
		foreach (var cell in destroyCell) {
			cell.refMyTile.color = Color.green;
			cell.isFree = true;
            
            if (cell.GetComponentInChildren<Enemy>())
            {
                cell.isFree = false;
                cell.refMyTile.color = Color.red;
            }
		}
        


    }
    // NON E' ASTAR  ma ricolora le celle in bianco e le rende di nuovo non libere
    public void AStar()
    {
                
        foreach (var cell in destroyCell)
        {
            
            if (cell.myI < 0)
                continue;
            if (cell.myJ < 0)
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



    public void RefreshEnemyList()
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
            Debug.Log(enemy);
            enemyCell.Add(enemy.GetComponentInParent<Cell>());
        }
    }

    public bool GetEnemyNearPlayer(int newI,int newJ)
    {
        //int newI = GetComponentInParent<Cell>().myI;
        //int newJ = GetComponentInParent<Cell>().myJ;
        
        if (refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Enemy>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI + 1, newJ].gameObject;
            refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Enemy>().isNear = true;
            return true;
                
        }

        if (refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Enemy>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI - 1, newJ].gameObject;
            refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Enemy>().isNear = true;
            return true;

        }

        if (refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Enemy>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI, newJ + 1].gameObject;
            refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Enemy>().isNear = true;
            return true;

        }

        if (refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Enemy>())
        {
            //refGC.enemyCell = refGrid.cellMat[newI, newJ - 1].gameObject;
            refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Enemy>().isNear = true;
            return true;

        }
        return false;
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

    public bool isPlayerNearEnemy(int newI, int newJ)
    {

        bool find = false;
        if (refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Player>())
        {
            find = true;

        }

        if (refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Player>())
        {
            find = true;

        }

        if (refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Player>())
        {
            find = true;

        }

        if (refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Player>())
        {
            find = true;

        }

        return find;

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
        int vista = GetComponent<Player>().per;
        int _x = GetComponentInParent<Cell>().myI;
        int _y = GetComponentInParent<Cell>().myJ;

        ClearLight();
        ReachableCells(vista, lightCell);

       

        foreach (var cell in lightCell) {
            if (cell.refMyTile != null)
            {


                cell.refMyTile.color = Color.white;
                if (cell.GetComponentInChildren<Enemy>())
                {
                    cell.GetComponentInChildren<Enemy>().gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    cell.isFree = false;
                    
                }
            }

		}


    }

    public void ClearLight()
    {
		

		foreach (var cell in lightCell) {
			cell.refMyTile.color = Color.grey;
			if (cell.GetComponentInChildren<Enemy>())
			{
				cell.GetComponentInChildren<Enemy>().gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
			}
		}



        lightCell.Clear();
        
    }

	public void ReachableCells(int range, List<Cell> reachable )
	{
		reachable.Clear ();
		Apri (GetComponentInParent<Cell> (), range , reachable);
	}

	void Apri(Cell c, int range , List<Cell> reachable)
	{
        refGrid = FindObjectOfType<Grid>();
        
		reachable.Add (c);
		int playerX = reachable [0].myI;
		int playerY = reachable [0].myJ;

		if (!reachable.Contains(refGrid.cellMat[c.myI + 1, c.myJ]) && IsAdjacent(c,1,0) && InManhattan(range, c.myI + 1 , c.myJ , playerX, playerY) ) 
		{
			Apri(refGrid.cellMat[c.myI + 1, c.myJ], range, reachable);
		}
		if (!reachable.Contains(refGrid.cellMat[c.myI - 1, c.myJ]) && IsAdjacent(c,-1,0) && InManhattan(range, c.myI -1 , c.myJ , playerX, playerY)) {
			Apri(refGrid.cellMat[c.myI - 1, c.myJ], range, reachable);
		}
		if (!reachable.Contains(refGrid.cellMat[c.myI, c.myJ + 1]) && IsAdjacent(c,0,1) && InManhattan(range, c.myI , c.myJ + 1 , playerX, playerY)) {
			Apri(refGrid.cellMat[c.myI, c.myJ + 1], range, reachable);
		}
		if (!reachable.Contains(refGrid.cellMat[c.myI, c.myJ - 1]) && IsAdjacent(c,0,-1) && InManhattan(range, c.myI , c.myJ - 1 , playerX, playerY)) {
			Apri(refGrid.cellMat[c.myI, c.myJ - 1], range, reachable);
		}
	}

	bool IsAdjacent(Cell c, int posI, int posJ)
	{
        refGrid = FindObjectOfType<Grid>();
        int newI = c.myI;
		int newJ = c.myJ;
		bool isFind = false;
		if (!refGrid.cellMat[newI + posI, newJ + posJ].isWall)
		{
			isFind = true;
			
		}
        if (refGrid.cellMat[newI + posI, newJ + posJ].GetComponentInChildren<Enemy>())
        {
            isFind = true;
        }

		return isFind;
	}

	bool InManhattan (int range , int xDest , int yDest, int xStart, int yStart)
	{
		bool inMan = false;
		if (Mathf.Abs(xStart - xDest) + Mathf.Abs(yStart - yDest) <= (range)) {
			inMan = true;
		}

		return inMan;
	}

	public void Pathfinding(int _myI,int _myJ)
	{
		
		int destX = _myI;
		int destY = _myJ;
		int startX = GetComponentInParent<Cell> ().myI;
		int startY = GetComponentInParent<Cell> ().myJ;
		int count = 0;
		
		pathList.Clear ();
		
		Vector3 destinationPoint = new Vector3(destX,destY,count);
		Vector3 startPoint = new Vector3 (startX, startY, count);

		Apri (pathList,destinationPoint,startX,startY);

		
	}
	
	void Apri(List<Vector3> pathList,Vector3 v,int startX, int startY)
	{
		Grid refGrid = FindObjectOfType<Grid> ();
		pathList.Add (v);
		//Debug.Log("X : "+startX+" Y : "+startY);
		//Debug.Log("VX : "+v.x+" VY : "+v.y);
		Vector3 tempVUp = new Vector3 (v.x + 1, v.y, v.z + 1);
		Vector3 tempVDown = new Vector3 (v.x - 1, v.y, v.z + 1);
		Vector3 tempVRight = new Vector3 (v.x, v.y + 1, v.z + 1);
		Vector3 tempVLeft = new Vector3 (v.x, v.y - 1, v.z + 1);

		if (v.x != startX || v.y != startY) 
		{
			if (v.z < 15) {
				
				
				if (refGrid.cellMat [(int)v.x + 1, (int)v.y].isFree && !IsContainedInList(tempVUp)) {
					//CleanPathList(tempVUp);
					Apri (pathList, tempVUp,startX,startY);
				}

				if (refGrid.cellMat [(int)v.x - 1, (int)v.y].isFree && !IsContainedInList(tempVDown)) {
					//CleanPathList(tempVDown);
					Apri (pathList, tempVDown,startX,startY);
				}
				if (refGrid.cellMat [(int)v.x , (int)v.y + 1].isFree && !IsContainedInList(tempVRight)) {
					//CleanPathList(tempVRight);
					Apri (pathList, tempVRight,startX,startY);
				}
				if (refGrid.cellMat [(int)v.x , (int)v.y - 1].isFree && !IsContainedInList(tempVLeft)) {
					//CleanPathList(tempVLeft);
					Apri (pathList, tempVLeft,startX,startY);
				}
			}

		}
	}

	bool IsContainedInList(Vector3 v)
	{
		bool isContained = false;

		foreach (var item in pathList) {
			if (item.x == v.x && item.y == v.y) {
				if (v.z >= item.z) {
					isContained = true;
				}
			}
		}

		return isContained;
	}

	void CleanPathList(Vector3 v)
	{
		for (int i = pathList.Count - 1; i > 1; i--) {
			if (pathList[i].x == v.x && pathList[i].y == v.y) {
				if (v.z < pathList[i].z) {
					pathList.RemoveAt(i);
					Debug.Log(v);
					Debug.Log(pathList[i]);
				}
			}
		}
	}

	public void ChooseMinPath()
	{

		int startX = GetComponentInParent<Cell> ().myI; 
		int startY = GetComponentInParent<Cell> ().myJ;
		int countStart = 0;
		foreach (var item in pathList) {
			if (item.x == startX && item.y == startY) {

				countStart = (int)item.z;

			}
		}
		int tempCount = countStart;
		foreach (var item in pathProva) {
			item.sBox.color = Color.clear;
		}
		pathProva.Clear ();
		for (int i = 0; i < countStart; i++) 
		{

			foreach (var item in pathList) {
				if (startX + 1 == item.x  && startY == item.y && item.z == tempCount - 1) {

					startX = (int)item.x;
					startY = (int)item.y;
					tempCount--;
					pathProva.Add(refGrid.cellMat[startX,startY]);

					
				}
				if (startX - 1 == item.x && startY == item.y && item.z == tempCount - 1) {
					startX = (int)item.x;
					startY = (int)item.y;
					tempCount--;
					pathProva.Add(refGrid.cellMat[startX,startY]);
				}
				if (startX == item.x && startY + 1 == item.y && item.z == tempCount - 1) {
					startX = (int)item.x;
					startY = (int)item.y;
					tempCount--;
					pathProva.Add(refGrid.cellMat[startX,startY]);
				}
				if (startX == item.x && startY - 1 == item.y && item.z == tempCount - 1) {
					startX = (int)item.x;
					startY = (int)item.y;
					tempCount--;
					pathProva.Add(refGrid.cellMat[startX,startY]);
				}
			}
		}
		foreach (var item in pathProva) {
			item.sBox.color = Color.yellow;
		}
        
    }

    public void ClearPath()
    {
        foreach (var item in pathProva)
        {
            item.sBox.color = Color.clear;
        }

        pathProva.Clear();
    }


}







