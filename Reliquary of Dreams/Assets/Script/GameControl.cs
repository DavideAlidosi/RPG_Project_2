using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GamePhase {Selezione, Movimento,Azione,Combattimento,TurnoNemici,Dialoghi }
public class GameControl : MonoBehaviour
{
    public GamePhase phase = GamePhase.Selezione;
    public GameObject firstCell;
    public GameObject playerCell;
    public GameObject enemyCell;
    public GameObject potion;

    public TextMesh enemyTxt;
    public TextMesh playerTxt;

    public GameObject cellCombat;

    public List<GameObject> queueMoveCell = new List<GameObject>();


    public List<GameObject> movementCell = new List<GameObject>();

    public int potionTurnStr = 0;
    public int potionTurnAgi = 0;
    public int potionTurnFor = 0;

    Player plRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;
    Grid refGrid;
    EnemyController refEnemyC;


    // Use this for initialization
    void Start()
    {
        plRef = FindObjectOfType<Player>();
        fogRef = FindObjectOfType<FogOfWar>();
        refMPU = FindObjectOfType<MenuPopUp>();
        refGrid = FindObjectOfType<Grid>();
        refEnemyC = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (phase == GamePhase.Azione || phase == GamePhase.Movimento)
        {
            if (Input.GetMouseButtonUp(1))
            {
                plRef.MovePlayer(firstCell.GetComponent<Cell>().myI, firstCell.GetComponent<Cell>().myJ);
                phase = GamePhase.Selezione;
                ResetToSelectionPhase();
                foreach (var enemyCell in fogRef.enemyCell)
                {
                    if (enemyCell == null)
                    {
                        continue;
                    }
                    enemyCell.GetComponentInParent<Cell>().refMyTile.color = Color.white;
                }
                fogRef.ClearPath();
                fogRef.enemyCell.Clear();

            }
        }*/

    }

    public void ResetToSelectionPhase()
    {
        
        
        firstCell.GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;

        Vector2 pos;
        
        
        cellCombat = null;
        queueMoveCell.Clear();
        firstCell = playerCell;
        pos = new Vector2(plRef.GetComponentInParent<Cell>().myI, plRef.GetComponentInParent<Cell>().myJ);

        fogRef.Fog(pos, plRef.agi);
        fogRef.AStar();
        //fogRef.LightRadius();
        movementCell.Add(plRef.GetComponentInParent<Cell>().gameObject);

        //Clear Movment Cell
        for (int i = 0; i < movementCell.Count; i++)
        {
            //movementCell[i].GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        movementCell.Clear();

        if (potionTurnStr > 0)
        {
            potionTurnStr--;
            
        }
        if (potionTurnStr == 0)
        {
            plRef.str = plRef.strMax;
        }
        if (potionTurnAgi > 0)
        {
            potionTurnAgi--;
            
        }
        if (potionTurnAgi == 0)
        {
            plRef.agi = plRef.agiMax;
        }
        if (potionTurnFor > 0)
        {
            potionTurnFor--;
            
        }
        if (potionTurnFor == 0)
        {
            plRef.forS = plRef.forMax;
        }

        if (phase != GamePhase.Dialoghi)
        {
            phase = GamePhase.Movimento;
        }
    }

    public void CombatPlayer()
    {
        int strAtt = playerCell.GetComponentInChildren<Player>().str;
        int agiDef = enemyCell.GetComponentInChildren<Enemy>().agi;
        int cosDef = enemyCell.GetComponentInChildren<Enemy>().cos;
        int forAtt = playerCell.GetComponentInChildren<Player>().forS;

        int totale = 50 + (strAtt * 5) - (agiDef * 2);

        int dice = Random.Range(1, 101);
        if (dice < totale)
        {
            int molt = 1;
            Debug.Log("Player " + playerCell + " Colpo andato a segno");
            int damage = (strAtt * 2) - cosDef;
            if (damage < 1)
            {
                damage = 1;
            }
            int crit = Mathf.FloorToInt(forAtt * 2.5f);
            if (Random.Range(1, 101) < crit)
            {
                molt = 2;
            }
            playerTxt.text = "-" + (damage * molt).ToString() + " HP";

            playerTxt.transform.parent = enemyCell.transform;
            playerTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            playerTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            playerTxt.transform.localPosition = new Vector3(0, 1, 1);


            enemyCell.GetComponentInChildren<Enemy>().hp -= damage;
            if (enemyCell.GetComponentInChildren<Enemy>().hp <= 0)
            {
                Destroy(enemyCell.GetComponentInChildren<Enemy>().gameObject);
                playerCell.GetComponentInChildren<Player>().exp += 100;

            }
        }
        else
        {
            playerTxt.text = "MISS";
            playerTxt.transform.parent = enemyCell.transform;
            playerTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            playerTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            playerTxt.transform.localPosition = new Vector3(0, 1, 1);
            Debug.Log("Player " + playerCell + " ha missato");
        }
        Invoke("SetTextToNull", 1.5f);
    }

    public void CombatEnemy(Enemy e)
    {
        int strAtt = e.str;
        int agiDef = playerCell.GetComponentInChildren<Player>().agi;
        int cosDef = playerCell.GetComponentInChildren<Player>().cos;
        int forAtt = e.forS;

        int totale = 50 + (strAtt * 5) - (agiDef * 2);
        int dice = Random.Range(1, 101);

        if (dice < totale)
        {
            int damage = (strAtt * 2) - cosDef;
            int molt = 1;
            if (damage < 1)
            {
                damage = 1;
            }


            int crit = Mathf.FloorToInt(forAtt * 2.5f);
            if (Random.Range(1, 101) < crit)
            {
                molt = 2;
            }
            enemyTxt.text = "-" + (damage * molt).ToString() + " HP";
            enemyTxt.transform.parent = playerCell.transform;
            enemyTxt.GetComponent<MeshRenderer>().sortingLayerName = "Default";
            enemyTxt.GetComponent<MeshRenderer>().sortingOrder = 99;
            enemyTxt.transform.localPosition = new Vector3(0, 1f, 1);


            Debug.Log("Enemy " + enemyCell + " Colpo andato a segno");
            playerCell.GetComponentInChildren<Player>().hp -= damage;
            if (playerCell.GetComponentInChildren<Player>().hp <= 0)
            {
                Destroy(playerCell.GetComponentInChildren<Player>().gameObject);
            }
        }
        else
        {
            Debug.Log("Enemy " + enemyCell + " ha missato");
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
        if (refGrid.cellMat[i + 1, j].GetComponentInChildren<Enemy>() || refGrid.cellMat[i + 1, j].GetComponent<Door>())
        {

            return true;
        }
        if (refGrid.cellMat[i - 1, j].GetComponentInChildren<Enemy>() || refGrid.cellMat[i - 1, j].GetComponent<Door>())
        {

            return true;
        }
        if (refGrid.cellMat[i, j + 1].GetComponentInChildren<Enemy>() || refGrid.cellMat[i, j + 1].GetComponent<Door>())
        {

            return true;
        }
        if (refGrid.cellMat[i, j - 1].GetComponentInChildren<Enemy>() || refGrid.cellMat[i, j - 1].GetComponent<Door>())
        {

            return true;
        }
        enemyCell = null;
        return false;
    }

    public void EndPlayerPhase(int _myI, int _myJ)
    {
        phase = GamePhase.Azione;
        fogRef.CleanMove();
        fogRef.ResetEnemyStatus();

        
        StartCoroutine(plRef.MovePlayer());
        StartCoroutine(CEndPlayerPhases(_myI, _myJ));

        

        //plRef.MovePlayer(_myI, _myJ);
        //fogRef.GetEnemyNearPlayer(_myI, _myJ);
        //refGrid.CreateGrid();
        //playerCell = refGrid.cellMat[_myI,_myJ].gameObject;
        //fogRef.LightRadius();


        fogRef.enemyCell.Clear();

    }
    public void EndPlayerPhaseWCombat(int _myI, int _myJ)
    {
        phase = GamePhase.Azione;
        fogRef.CleanMove();
        fogRef.ResetEnemyStatus();

        

        StartCoroutine(plRef.MovePlayer());
        StartCoroutine(CEndPlayerPhasesWCombat(_myI, _myJ));
        //plRef.MovePlayer(_myI, _myJ);
        //fogRef.GetEnemyNearPlayer(_myI, _myJ);
        //refGrid.CreateGrid();
        //playerCell = refGrid.cellMat[_myI,_myJ].gameObject;
        //fogRef.LightRadius();
        

        fogRef.enemyCell.Clear();


    }

    public IEnumerator CEndPlayerPhases(int _myI, int _myJ)
    {
        bool isMovingPlayer = true;
        bool isMovingEnemy = false;
        while (isMovingPlayer)
        {


            foreach (var cell in fogRef.pathProva)
            {
                Vector2 pos = new Vector2(0,0);
                playerCell = refGrid.cellMat[_myI, _myJ].gameObject;
                fogRef.LightRadius();
                yield return new WaitForSeconds(0.2f);
            }
            isMovingPlayer = false;
            
            if (enemyCell != null)
            {
                //CombatPlayer();

            }
            FindText(_myI, _myJ);
            fogRef.ClearPath();
            isMovingEnemy = true;
        }
        while (isMovingEnemy)
        {
            StartCoroutine(refEnemyC.EnemyTurn());


            //yield return new WaitForSeconds(0.5f);
            isMovingEnemy = false;

        }
        //fogRef.ClearPath();
        
        //phase = GamePhase.Selezione;

    }

    public IEnumerator CEndPlayerPhasesWCombat(int _myI, int _myJ)
    {
        bool isMovingPlayer = true;
        bool isMovingEnemy = false;

        while (isMovingPlayer)
        {


            foreach (var cell in fogRef.pathProva)
            {
                playerCell = refGrid.cellMat[_myI, _myJ].gameObject;
                fogRef.LightRadius();
                yield return new WaitForSeconds(0.2f);
            }
            isMovingPlayer = false;

            if (enemyCell != null)
            {
                CombatPlayer();
                yield return new WaitForSeconds(0.5f);
            }
            fogRef.ClearPath();
            isMovingEnemy = true;

        }
        while (isMovingEnemy)
        {
            StartCoroutine(refEnemyC.EnemyTurn());


            //yield return new WaitForSeconds(0.5f);
            isMovingEnemy = false;

        }

        //phase = GamePhase.Selezione;

    }

    public void FindText(int playerX, int playerY)
    {
        int range = 10;
        for (int i = (playerX - range); i < (playerX + range); i++)
        {
            for (int j = (playerY - range); j < (playerY + range); j++)
            {
                if (i<1)
                {
                    continue;
                }
                if (j < 1)
                {
                    continue;
                }
                if (refGrid.cellMat[i,j].GetComponentInChildren<StoryText>())
                {
                    if (!refGrid.cellMat[i, j].GetComponentInChildren<StoryText>().find)
                    {
                        refGrid.cellMat[i, j].GetComponentInChildren<StoryText>().find = true;
                        refGrid.cellMat[i, j].GetComponentInChildren<StoryText>().SpamText();
                    }
                    
                }
            }
        }
    }

    public void EnemyDrop(Cell c)
    {
        StartCoroutine(CDrop(c.myI,c.myJ));
    }

    IEnumerator CDrop(int x, int y)
    {
        yield return new WaitForSeconds(1f);
        GameObject pot = Instantiate(potion);
        pot.tag = "GameObject";
        pot.GetComponent<ItemLoader>().x = x;
        pot.GetComponent<ItemLoader>().y = y;
        pot.transform.parent = refGrid.cellMat[x, y].transform;
        pot.transform.localPosition = Vector3.zero;
    }
}
