using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GamePhase {Selezione, Movimento,Azione,Combattimento,TurnoNemici,FineTurno }
public class GameControl : MonoBehaviour {
    public GamePhase phase = GamePhase.Selezione;
    public GameObject firstCell;
    public GameObject playerCell;
    public GameObject enemyCell;

    public List<GameObject> movementCell = new List<GameObject>();

    Player plRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;


    // Use this for initialization
    void Start () {
        plRef = FindObjectOfType<Player>();
        fogRef = FindObjectOfType<FogOfWar>();
        refMPU = FindObjectOfType<MenuPopUp>();
    }
	
	// Update is called once per frame
	void Update () {
        if (phase == GamePhase.Azione)
        {
            if (Input.GetMouseButtonUp(1))
            {
                plRef.MovePlayer(firstCell.GetComponent<Cell>().myI, firstCell.GetComponent<Cell>().myJ);
                phase = GamePhase.Selezione;
                ResetToSelectionPhase();

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
            enemyCell.GetComponentInChildren<Enemy>().hp -= strAtt * 2;
            if (enemyCell.GetComponentInChildren<Enemy>().hp <= 0)
            {
                Destroy(enemyCell.GetComponentInChildren<Enemy>().gameObject);
                
            }
        }
        else
        {
            Debug.Log("Player " +playerCell +" ha missato");
        }
        
    }

    public void CombatEnemy()
    {
        int strAtt = enemyCell.GetComponentInChildren<Enemy>().str;
        int agiDef = playerCell.GetComponentInChildren<Player>().agi;

        int totale = 50 + (strAtt * 5) - (agiDef * 2);
        int dice = Random.Range(1, 101);

        if (dice < totale)
        {
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
        }
    }
}
