using UnityEngine;
using System.Collections;



public class Grid : MonoBehaviour {

    public GameObject cell;
    public Player playerLinking;

    Vector2 posPlayer;

    public Cell[,] cellMat;
    GameControl refGC;
    EnemyController refEC;
    TileTester refTT;


    

    public const int ROW = 100;
    public const int COL = 100;

    public GameObject enemy;

	// Use this for initialization
	void Start () {


        refTT = FindObjectOfType<TileTester>();
        refEC = FindObjectOfType<EnemyController>();
        refGC = FindObjectOfType<GameControl>();
        playerLinking = FindObjectOfType<Player>(); ;
        
        cellMat = new Cell[ROW, COL];

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                cellMat[i, j] = null;
                
            }
        }
        // alla fine della creazione della matrice inizializzata a null prendiamo il tile con tag gameobject troviamo la X e la Y
        // corrispondenti alla posizione scelta e creiamo una cella inserendola nella matrice
        posPlayer = refTT.InsertPlayerGameObject();
        int cellX = (int)posPlayer.x;
        int cellY = (int)posPlayer.y;
        GameObject newCellGO = Instantiate(cell);
        cellMat[cellX, cellY] = newCellGO.GetComponent<Cell>();
        cellMat[cellX, cellY].myI = cellX;
        cellMat[cellX, cellY].myJ = cellY;
        newCellGO.transform.position = new Vector3(cellY, cellX, 0);
        newCellGO.name = cellX + " " + cellY;
        cellMat[cellX, cellY].isSpawnCell = true;


        // una volta data la posizione del player si creerà la griglia attorno a se
        Debug.Log(posPlayer);
        Debug.Log(Time.realtimeSinceStartup);
        playerLinking.SpawnPlayer(posPlayer);
        CreateGrid();
        playerLinking.GetComponentInChildren<FogOfWar>().LightRadius();
        playerLinking.GetComponentInChildren<FogOfWar>().RefreshEnemyList();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    // Crea la griglia logica attorno al player ad ogni click di range caselle

    public void CreateGrid()
    {
        int range = 10;
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
                    refTT.InsertWall(i, j);
                    refTT.InsertDoor(i, j);
                    refTT.InsertEnemyGO(i,j);
                    if (refTT.InsertText(i, j) != null)
                    {
                        refTT.InsertText(i, j).GetComponent<StoryText>().SpamText();
                    } 
                    if (i == playerX && j == playerY)
                    {
                        cellMat[i, j].refMyTile.color = Color.white;
                        continue;
                    }
                }
                /*if (i == 20 && j == 29 && !cellMat[i, j].spawned)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                    //newEnemy.SetActive(false);
                    newEnemy.GetComponent<SpriteRenderer>().color = Color.clear;
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                    cellMat[i, j].spawned = true;

                }*/
            }
        }

        
        refTT.Inserisci(playerX, playerY);
        

    }

    // Crea la griglia logica attorno al nemico ad ogni click di range caselle
    public void CreateGridEnemy(int enemyX, int enemyY)
    {
        int range = 10;

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
                    refTT.InsertWall(i, j);
                    refTT.InsertDoor(i, j);
                    refTT.InsertEnemyGO(i, j);
                    if (refTT.InsertText(i, j) != null)
                    {
                        refTT.InsertText(i, j).GetComponent<StoryText>().SpamText();
                    }
                }
            }
        }
    }

    

}
