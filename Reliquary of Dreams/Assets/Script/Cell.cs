using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour {
    public int myI, myJ;
    public bool isSpawnCell = false;
    public SpriteRenderer sBox;
    public bool isFree = false;
    Vector2 pos;
    public bool isWall = true;
    public bool isCombat = false;
    public bool isMove = false;
	public bool isDoor = false;

    public SpriteRenderer refMyTile;

    public bool spawned = false;

    public EnemyController enemyRef;
    public FogOfWar refFog;
    GameControl gcRef;
    public Player playerRef;
   




    // Use this for initialization
    void Start () {
        gcRef = FindObjectOfType<GameControl>();
        //playerRef = FindObjectOfType<Player>();
        refFog = FindObjectOfType<FogOfWar>();
        
        //refMPU = FindObjectOfType<MenuPopUp>();
        
        
    }
	
	// Update is called once per frame
	void Update () {
        

        

        
    }
    // Start cell selecting code
    void OnMouseExit()
    {
        if (gcRef.phase == GamePhase.Movimento)
        {
            gcRef.enemyCell = null;
        }
        
    }
    void OnMouseEnter()
    {
        if (this.GetComponentInChildren<Enemy>())
        {
            
            gcRef.enemyCell = this.gameObject;
        }
        if (this.isFree && !GetComponentInChildren<Player>())
        {
            if (gcRef.phase == GamePhase.Movimento)
            {
				refFog.Pathfinding(myI,myJ);
				refFog.ChooseMinPath();

                if (gcRef.CheckCombat(this.gameObject))
                {
                    gcRef.cellCombat = this.gameObject;
                }

                
                /*if (gcRef.queueMoveCell.Contains(this.gameObject))
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
                }*/
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
                gcRef.cellCombat = null;
                gcRef.queueMoveCell.Clear();
                gcRef.firstCell = this.gameObject;
                pos = new Vector2(myI, myJ);
                refFog.LightRadius();
                refFog.Fog(pos,playerRef.agi);
                refFog.AStar();
                gcRef.movementCell.Add(this.gameObject);
                gcRef.Adjacent(this.gameObject);
                this.isMove = true;
            }
            

        }
        else if(gcRef.phase == GamePhase.Movimento)
        {
            int countList = gcRef.movementCell.Count;
            
            
            if (isFree)
            {
                
                gcRef.EndPlayerPhase(myI, myJ);


            }
            if (GetComponentInChildren<Enemy>())
            {

                
                if (gcRef.cellCombat != null || refFog.isPlayerNearEnemy(myI, myJ))
                {
                    //playerRef.MovePlayer(gcRef.cellCombat.GetComponent<Cell>().myI, gcRef.cellCombat.GetComponent<Cell>().myJ);
                    
                    gcRef.EndPlayerPhaseWCombat(myI, myJ);
                    //gcRef.playerCell = gcRef.cellCombat;
                }
                
                /*gcRef.phase = GamePhase.Selezione;
                refFog.ResetEnemyStatus();
                gcRef.ResetToSelectionPhase();
                refFog.GetEnemyNearPlayer(this.myI, this.myJ);
                refFog.LightRadius();
                refFog.enemyCell.Clear();
                gcRef.CombatPlayer();
                enemyRef.EnemyTurn();*/

            }
            if (GetComponent<Door>())
            {

                if (gcRef.cellCombat != null)
                {
                    gcRef.EndPlayerPhase(myI, myJ);
                    playerRef.MovePlayer(gcRef.cellCombat.GetComponent<Cell>().myI, gcRef.cellCombat.GetComponent<Cell>().myJ);
                    GetComponent<Door>().FindMyAdjacent(myI, myJ);
                    isWall = false;
                    GetComponent<Door>().adjacent.isWall = false;
                    gcRef.phase = GamePhase.Selezione;
                    gcRef.ResetToSelectionPhase();
                    refFog.LightRadius();
                }
                Debug.Log("Porta");
                
                
                
               
                
                
                

            }
            
        }
        
    }




}
