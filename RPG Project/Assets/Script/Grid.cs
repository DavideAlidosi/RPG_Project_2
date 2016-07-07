using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public GameObject cell;
    Player playerLinking;


    public Cell[,] cellMat;
    GameControl refGC;

    Transform ciao;


    public GameObject enemy;

	// Use this for initialization
	void Start () {
        refGC = FindObjectOfType<GameControl>();
        playerLinking = FindObjectOfType<Player>(); ;
        int n = 0;
        cellMat = new Cell[20, 20];

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {

                GameObject newCellGO = Instantiate(cell);
                newCellGO.transform.position = new Vector3(j-10, i-8, 0);
                cellMat[i, j] = newCellGO.GetComponent<Cell>();
                cellMat[i, j].myI = i;
                cellMat[i, j].myJ = j;
                newCellGO.name = i + " " + j;
                
                n++;

                if (n == 154)
                {
                    cellMat[i, j].isSpawnCell = true;
                    
                    
                }
                
                if (n == 250)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                }
                if (n == 254)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                    
                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                }

                if (n == 298)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);

                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                }
                if (n == 349)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);

                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                }
                if (n == 379)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);

                    newEnemy.transform.parent = cellMat[i, j].transform;
                    newEnemy.transform.localPosition = new Vector3(0, 0, 1);
                }
            }
        }
        playerLinking.SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    
}
