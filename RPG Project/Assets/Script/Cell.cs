﻿using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
    public int myI, myJ;
    public bool isSpawnCell = false;
    public SpriteRenderer sBox;
    public bool isFree = false;
    Vector2 pos;
    public bool isWall = true;
    public bool isCombat = false;
    public bool isMove = false;

    public SpriteRenderer refMyTile;

    public bool spawned = false;

    public EnemyController enemyRef;
    public FogOfWar refFog;
    GameControl gcRef;
    public Player playerRef;
    public MenuPopUp refMPU;

    // Use this for initialization
    void Start () {
        gcRef = FindObjectOfType<GameControl>();
        //playerRef = FindObjectOfType<Player>();
        //refFog = FindObjectOfType<FogOfWar>();
        
        //refMPU = FindObjectOfType<MenuPopUp>();
        
        
    }
	
	// Update is called once per frame
	void Update () {
        /*if (isWall)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }*/

        

        
    }
    // Start cell selecting code
    void OnMouseEnter()
    {
        if (this.isFree && !GetComponentInChildren<Player>())
        {
            if (gcRef.phase == GamePhase.Movimento)
            {
                if (gcRef.queueMoveCell.Contains(this.gameObject))
                {


                    if (!gcRef.movementCell.Contains(this.gameObject))
                    {
                        gcRef.movementCell.Add(this.gameObject);
                        GameObject temp =  gcRef.movementCell[gcRef.movementCell.Count - 1];
                        if (gcRef.CheckCombat(temp))
                        {
                            gcRef.cellCombat = temp;
                        }
                        sBox.color = Color.yellow;
                        gcRef.queueMoveCell.Clear();
                        gcRef.Adjacent(this.gameObject);
                    }
                }
            }
        }
    }

    // End cell highlight code

    void OnMouseUp()
    {

        
        playerRef = FindObjectOfType<Player>();
        refFog = FindObjectOfType<FogOfWar>();
        enemyRef = FindObjectOfType<EnemyController>();
        //refMPU = FindObjectOfType<MenuPopUp>();
        if (gcRef.phase == GamePhase.Selezione)
        {
            
            if (GetComponentInChildren<Player>())
            {

                sBox.color = Color.green;
                gcRef.phase++;

                gcRef.queueMoveCell.Clear();
                gcRef.firstCell = this.gameObject;
                pos = new Vector2(myI, myJ);
                refFog.LightRadius();
                refFog.Fog(pos,4);
                refFog.AStar();
                gcRef.movementCell.Add(this.gameObject);
                gcRef.Adjacent(this.gameObject);
                this.isMove = true;
            }
            

        }
        else if(gcRef.phase == GamePhase.Movimento)
        {
            int countList = gcRef.movementCell.Count;
            
            
            if (isFree && gcRef.movementCell.Contains(this.gameObject))
            {
                /*refFog.ResetEnemyStatus();
                gcRef.phase = GamePhase.Selezione;
                gcRef.ResetToSelectionPhase();
                
                playerRef.MovePlayer(myI,myJ);
                refFog.GetEnemyNearPlayer(this.myI,this.myJ);
                //refMPU.Activate();
                gcRef.playerCell = this.gameObject;
                refFog.LightRadius();
                enemyRef.EnemyTurn();
                refFog.enemyCell.Clear();*/
                gcRef.EndPlayerPhase(myI, myJ);

            }
            if (GetComponentInChildren<Enemy>())
            {
                
                
                if (gcRef.cellCombat != null)
                {
                    playerRef.MovePlayer(gcRef.cellCombat.GetComponent<Cell>().myI, gcRef.cellCombat.GetComponent<Cell>().myJ);
                    gcRef.playerCell = gcRef.cellCombat;
                }
                gcRef.phase = GamePhase.Selezione;
                refFog.ResetEnemyStatus();
                gcRef.ResetToSelectionPhase();
                refFog.GetEnemyNearPlayer(this.myI, this.myJ);
                refFog.LightRadius();
                refFog.enemyCell.Clear();
                gcRef.CombatPlayer();
                enemyRef.EnemyTurn();

            }
        }
        else if (gcRef.phase == GamePhase.Combattimento)
        {
            
            if (GetComponentInChildren<Enemy>() && GetComponentInChildren<Enemy>().isNear)
            {
                
                Destroy(GetComponentInChildren<Enemy>().gameObject);
                gcRef.phase = GamePhase.Selezione;
                refMPU.Deactivate();
            }
        }
        gcRef.cellCombat = null;
    }
}
