using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GamePhase {Selezione, Movimento,Azione,Combattimento,TurnoNemici,FineTurno }
public class GameControl : MonoBehaviour {
    public GamePhase phase = GamePhase.Selezione;
    public GameObject firstCell;
    public GameObject playerCell;
    public GameObject enemyCell;

    public TextMesh enemyTxt;
    public TextMesh playerTxt;

    public GameObject cellCombat;

    public List<GameObject> queueMoveCell = new List<GameObject>();


    public List<GameObject> movementCell = new List<GameObject>();

    Player plRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;
    Grid refGrid;


    // Use this for initialization
    void Start () {
        plRef = FindObjectOfType<Player>();
        fogRef = FindObjectOfType<FogOfWar>();
        refMPU = FindObjectOfType<MenuPopUp>();
        refGrid = FindObjectOfType<Grid>();
    }
	
	// Update is called once per frame
	void Update () {
        if (phase == GamePhase.Azione || phase == GamePhase.Movimento)
        {
            if (Input.GetMouseButtonUp(1))
            {
                plRef.MovePlayer(firstCell.GetComponent<Cell>().myI, firstCell.GetComponent<Cell>().myJ);
                phase = GamePhase.Selezione;
                ResetToSelectionPhase();
                foreach (var enemyCell in fogRef.enemyCell)
                {
                    enemyCell.GetComponentInParent<Cell>().refMyTile.color = Color.white;
                }
                fogRef.enemyCell.Clear();

            }
        }

        if (phase == GamePhase.TurnoNemici)
        {
            /*Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
                enemy.ManhattanSearch();
                enemy.SearchPlayer();
                enemy.MoveEnemy();
            }*/
            //phase = GamePhase.Selezione;
        }
        
    }

    public void ResetToSelectionPhase()
    {
        fogRef.CleanMove();
        refMPU.Deactivate();
        firstCell.GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;

        //Clear Movment Cell
        for (int i = 0; i < movementCell.Count; i++)
        {
            movementCell[i].GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        movementCell.Clear();
    }

    public void CombatPlayer ()
    {
        int strAtt = playerCell.GetComponentInChildren<Player>().str;
        int agiDef = enemyCell.GetComponentInChildren<Enemy>().agi;

        int totale = 50 + (strAtt * 5) - (agiDef * 2);

        int dice = Random.Range(1, 101);
        if (dice < totale)
        {
            Debug.Log("Player "+playerCell+ " Colpo andato a segno");

            
            playerTxt.text = "-"+(strAtt * 2).ToString()+" HP"; 
            playerTxt.transform.parent = enemyCell.transform;
            playerTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            playerTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            playerTxt.transform.localPosition = new Vector3(0, 1, 1);


            enemyCell.GetComponentInChildren<Enemy>().hp -= strAtt * 2;
            if (enemyCell.GetComponentInChildren<Enemy>().hp <= 0)
            {
                Destroy(enemyCell.GetComponentInChildren<Enemy>().gameObject);
                
            }
        }
        else
        {
            playerTxt.text = "MISS";
            playerTxt.transform.parent = enemyCell.transform;
            playerTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            playerTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            playerTxt.transform.localPosition = new Vector3(0, 1, 1);
            Debug.Log("Player " +playerCell +" ha missato");
        }
        Invoke("SetTextToNull", 1.5f);
    }

    public void CombatEnemy()
    {
        int strAtt = enemyCell.GetComponentInChildren<Enemy>().str;
        int agiDef = playerCell.GetComponentInChildren<Player>().agi;

        int totale = 50 + (strAtt * 5) - (agiDef * 2);
        int dice = Random.Range(1, 101);

        if (dice < totale)
        {

            enemyTxt.text = "-" + (strAtt * 2).ToString() + " HP";
            enemyTxt.transform.parent = playerCell.transform;
            enemyTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            enemyTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            enemyTxt.transform.localPosition = new Vector3(0, 1f, 1);


            Debug.Log("Enemy "+enemyCell+" Colpo andato a segno");
            playerCell.GetComponentInChildren<Player>().hp -= strAtt * 2;
            if (playerCell.GetComponentInChildren<Player>().hp <= 0)
            {
                Destroy(playerCell.GetComponentInChildren<Player>().gameObject);
            }
        }
        else
        {
            Debug.Log("Enemy "+enemyCell+" ha missato");
            enemyTxt.text = "MISS";
            enemyTxt.transform.parent = playerCell.transform;
            enemyTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            enemyTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            enemyTxt.transform.localPosition = new Vector3(0, 1f, 1);
        }
        Invoke("SetTextToNull", 1.5f);
    }

    void SetTextToNull()
    {
        playerTxt.text = "";
        enemyTxt.text = "";
    }

    public void Adjacent(GameObject cell)
    {
        int i = cell.GetComponent<Cell>().myI;
        int j = cell.GetComponent<Cell>().myJ;
        if (refGrid.cellMat[i + 1, j].isFree)
        {
            queueMoveCell.Add(refGrid.cellMat[i + 1, j].gameObject);
            refGrid.cellMat[i + 1, j].isMove = true;
        }
        if (refGrid.cellMat[i - 1, j].isFree)
        {
            queueMoveCell.Add(refGrid.cellMat[i - 1, j].gameObject);
            refGrid.cellMat[i - 1, j].isMove = true;
        }
        if (refGrid.cellMat[i, j + 1].isFree)
        {
            queueMoveCell.Add(refGrid.cellMat[i, j + 1].gameObject);
            refGrid.cellMat[i, j + 1].isMove = true;
        }
        if (refGrid.cellMat[i, j - 1].isFree)
        {
            queueMoveCell.Add(refGrid.cellMat[i, j - 1].gameObject);
            refGrid.cellMat[i, j - 1].isMove = true;
        }
    }

    public bool CheckCombat(GameObject cellToCheck)
    {
        int i = cellToCheck.GetComponent<Cell>().myI;
        int j = cellToCheck.GetComponent<Cell>().myJ;
        if (refGrid.cellMat[i + 1, j].GetComponentInChildren<Enemy>())
        {
            Debug.Log("puttana di tua madre");
            return true;
        }
        if (refGrid.cellMat[i - 1, j].GetComponentInChildren<Enemy>())
        {
            Debug.Log("porcoddio");
            return true;
        }
        if (refGrid.cellMat[i, j + 1].GetComponentInChildren<Enemy>())
        {
            Debug.Log("nicholas merda");
            return true;
        }
        if (refGrid.cellMat[i, j - 1].GetComponentInChildren<Enemy>())
        {
            Debug.Log("vi ammazzo tutti e due");
            return true;
        }
        return false;
    }
}
