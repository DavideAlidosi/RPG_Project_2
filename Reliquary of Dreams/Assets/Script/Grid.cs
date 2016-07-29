using UnityEngine;
using System.Collections;



public class Grid : MonoBehaviour {

    public GameObject cell;
    public Player playerLinking;

    Vector2 posPlayer;

    public Cell[,] cellMat;
    GameControl refGC;
    EnemyController refEC;
    public TileTester refTT;


    

    public const int ROW = 100;
    public const int COL = 100;

    public GameObject enemy;

	// Use this for initialization
    
	void Awake () {

        cellMat = new Cell[ROW, COL];

        
        refTT = FindObjectOfType<TileTester>();
        refEC = FindObjectOfType<EnemyController>();
        refGC = FindObjectOfType<GameControl>();
        playerLinking = FindObjectOfType<Player>(); ;
        
        
        // alla fine della creazione della matrice inizializzata a null prendiamo il tile con tag gameobject troviamo la X e la Y
        // corrispondenti alla posizione scelta e creiamo una cella inserendola nella matrice
        posPlayer = refTT.InsertPlayerGameObject();


        int cellX = (int)posPlayer.x;
        int cellY = (int)posPlayer.y;

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                
                cellMat[i, j] = null;
                GameObject newCellGO = Instantiate(cell);
                
                //newCellGO.AddComponent<PopUp>();
                //newCellGO.AddComponent<BoxCollider2D>();
                //newCellGO.AddComponent<BoxCollider2D>();
                //newCellGO.AddComponent<PopUp>();
                cellMat[i, j] = newCellGO.GetComponent<Cell>();
                cellMat[i, j].myI = i;
                cellMat[i, j].myJ = j;
                newCellGO.name = i + " " + j;
                newCellGO.transform.position = new Vector3(j, i, 0);
            }
        }
        /*GameObject newCellGO = Instantiate(cell);
        cellMat[cellX, cellY] = newCellGO.GetComponent<Cell>();
        cellMat[cellX, cellY].myI = cellX;
        cellMat[cellX, cellY].myJ = cellY;
        newCellGO.transform.position = new Vector3(cellY, cellX, 0);
        newCellGO.name = cellX + " " + cellY;
        cellMat[cellX, cellY].isSpawnCell = true;*/


        // una volta data la posizione del player si creerà la griglia attorno a se
        //cellMat[cellX, cellY].gameObject.AddComponent<BoxCollider2D>();
        
        playerLinking.SpawnPlayer(posPlayer);
        CreateGrid();
       
        
        
        

        //playerLinking.GetComponentInChildren<FogOfWar>().LightRadius();
        //playerLinking.GetComponentInChildren<FogOfWar>().RefreshEnemyList();


    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void Start()
    {
        playerLinking.GetComponent<FogOfWar>().LightRadius();
    }

    // Crea la griglia logica attorno al player ad ogni click di range caselle
    // TESTING
    public void CreateGrid()
    {
        /*int range = 9;
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
            }
        }

        
        refTT.Inserisci(playerX, playerY);*/
        refTT.NewInsert();
        

        
        
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
