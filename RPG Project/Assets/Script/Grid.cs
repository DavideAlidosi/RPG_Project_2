using UnityEngine;
using System.Collections;



public class Grid : MonoBehaviour {

    public GameObject cell;
    public Player playerLinking;
    


    public Cell[,] cellMat;
    GameControl refGC;
    EnemyController refEC;
    TileTester refTT;


    Transform ciao;

    public const int ROW = 100;
    public const int COL = 100;

    public GameObject enemy;

	// Use this for initialization
	void Start () {


        refTT = FindObjectOfType<TileTester>();
        refEC = FindObjectOfType<EnemyController>();
        refGC = FindObjectOfType<GameControl>();
        playerLinking = FindObjectOfType<Player>(); ;
        int n = 1;
        cellMat = new Cell[ROW, COL];

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                cellMat[i, j] = null;
                /*GameObject newCellGO = GameObject.Find("Cell (" + n + ")");
                //GameObject newCellGO = Instantiate(cell);
                newCellGO.transform.position = new Vector3(j, i, 0);
                cellMat[i, j] = newCellGO.GetComponent<Cell>();
                cellMat[i, j].myI = i;
                cellMat[i, j].myJ = j;
                newCellGO.name = i + " " + j;
                
                */n++;

                if (n == 3668)
                {
                    GameObject newCellGO = Instantiate(cell);
                    cellMat[i, j] = newCellGO.GetComponent<Cell>();
                    cellMat[i, j].myI = i;
                    cellMat[i, j].myJ = j;
                    newCellGO.transform.position = new Vector3(j, i, 0);
                    newCellGO.name = i + " " + j;
                    cellMat[i, j].isSpawnCell = true;
                    
                    
                }
            }
        }

        Debug.Log(Time.realtimeSinceStartup);
        playerLinking.SpawnPlayer();
        CreateGrid(); 
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void CreateGrid()
    {
        int range = 9;
        int playerX = playerLinking.GetComponentInParent<Cell>().myI;
        int playerY = playerLinking.GetComponentInParent<Cell>().myJ;

        refTT = FindObjectOfType<TileTester>();
        
        for (int i = (playerX - range); i < (playerX + range); i++)
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
                
                if (cellMat[i,j] == null )
                {
                    
                    GameObject newCellGO = Instantiate(cell);
                    cellMat[i, j] = newCellGO.GetComponent<Cell>();
                    newCellGO.transform.position = new Vector3(j, i, 0);
                    cellMat[i, j].myI = i;
                    cellMat[i, j].myJ = j;
                    newCellGO.name = i + " " + j;
                    refTT.Inserisci(i, j);
                    if (i == playerX && j == playerY)
                    {
                        cellMat[i, j].refMyTile.color = Color.white;
                        continue;
                    }
                    /*if (cellMat[i,j].GetComponent<SpriteRenderer>().sprite.name != null)
                    {
                        Debug.Log(cellMat[i, j].GetComponent<SpriteRenderer>().sprite.name);
                    }
                    //if (cellMat[i,j].GetComponent<SpriteRenderer>().sprite.name == "White" )
                    {
                        
                        //cellMat[i, j].GetComponent<SpriteRenderer>().sprite = null;
                    }*/
                }
                

                if (i == 32 && j == 58 && !cellMat[i,j].spawned)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                    //newEnemy.SetActive(false);
                    newEnemy.GetComponent<SpriteRenderer>().color = Color.clear;
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                    cellMat[i, j].spawned = true;
                    
                }

                if (i == 21 && j == 64 && !cellMat[i, j].spawned)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                    //newEnemy.SetActive(false);
                    newEnemy.GetComponent<SpriteRenderer>().color = Color.clear;
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                    cellMat[i, j].spawned = true;

                }

                if (i == 54 && j == 63 && !cellMat[i, j].spawned)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                    //newEnemy.SetActive(false);
                    newEnemy.GetComponent<SpriteRenderer>().color = Color.clear;
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                    cellMat[i, j].spawned = true;

                }
                if (i == 78 && j == 64 && !cellMat[i, j].spawned)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                    //newEnemy.SetActive(false);
                    newEnemy.GetComponent<SpriteRenderer>().color = Color.clear;
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                    cellMat[i, j].spawned = true;

                }

            }
        }
        refTT.Inserisci(playerX, playerY);
    }

    public void CreateGridEnemy(int enemyX, int enemyY)
    {
        int range = 5;

        refTT = FindObjectOfType<TileTester>();
        for (int i = (enemyX - range); i < (enemyX + range); i++)
        {
            for (int j = (enemyY - range); j < (enemyY + range); j++)
            {
                if (i < 0)
                    continue;
                if (j < 0)
                    continue;
                if (i > Grid.COL - 1)
                    continue;
                if (j > Grid.ROW - 1)
                    continue;
                
                
                if (cellMat[i, j] == null)
                {
                    GameObject newCellGO = Instantiate(cell);
                    cellMat[i, j] = newCellGO.GetComponent<Cell>();
                    
                    newCellGO.transform.position = new Vector3(j, i, 0);
                    cellMat[i, j].myI = i;
                    cellMat[i, j].myJ = j;
                    newCellGO.name = i + " " + j;

                    refTT.Inserisci(i, j);

                }
            }
        }
    }

    

}
