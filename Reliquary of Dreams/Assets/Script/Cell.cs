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
    public GameControl gcRef;
    public Player playerRef;

    public List<SpriteRenderer> myTile = new List<SpriteRenderer>();


   




    // Use this for initialization
    void Start () {
        //gcRef = FindObjectOfType<GameControl>();
        //playerRef = FindObjectOfType<Player>();
        //refFog = FindObjectOfType<FogOfWar>();

        //refMPU = FindObjectOfType<MenuPopUp>();


    }
	
	// Update is called once per frame
	void Update () {
        

        

        
    }
    // Start cell selecting code
    void OnMouseExit()
    {
        if (gcRef != null)
        {
            if (gcRef.phase == GamePhase.Movimento)
            {
                gcRef.enemyCell = null;
            }
        }
        //gcRef = FindObjectOfType<GameControl>();
        
        
    }
    void OnMouseEnter()
    {
        //refFog = FindObjectOfType<FogOfWar>();
        //gcRef = FindObjectOfType<GameControl>();
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
            }
        }
    }

    

    void OnMouseUp()
    {

        //gcRef = FindObjectOfType<GameControl>();
        playerRef = FindObjectOfType<Player>();
        //refFog = FindObjectOfType<FogOfWar>();
        enemyRef = FindObjectOfType<EnemyController>();
        //refMPU = FindObjectOfType<MenuPopUp>();
        if (gcRef != null)
        {


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
                    refFog.Fog(pos, playerRef.agi);
                    refFog.AStar();
                    gcRef.movementCell.Add(this.gameObject);
                    ////gcRef.Adjacent(this.gameObject);
                    //this.isMove = true;
                }


            }
            else if (gcRef.phase == GamePhase.Movimento)
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



                }
                if (GetComponent<Door>())
                {
                    

                    if (gcRef.cellCombat != null)
                    {
                        gcRef.EndPlayerPhase(myI, myJ);

                        GetComponent<Door>().FindMyAdjacent(myI, myJ);
                        isWall = false;
                        GetComponent<Door>().adjacent.isWall = false;
                        GetComponent<Door>().adjacent_2.isWall = false;
                        GetComponent<Door>().adjacent_1.isWall = false;



                    }

                }
                if (GetComponentInChildren<NextScene>())
                {
                    Debug.Log("Ciao");
                    FindObjectOfType<NextScene>().NextLevel();
                }
                if (GetComponentInChildren<ItemLoader>())
                {
                    //Destroy(GetComponent<SpriteRenderer>());
                    playerRef.itemPlayer.Add(GetComponentInChildren<Item>().gameObject);
                    if (GetComponentInChildren<ItemLoader>().tag == "GameObject")
                    {
                        Destroy(GetComponentInChildren<ItemLoader>().gameObject);
                    }
                    if (GetComponentInChildren<Item>().tag == "Untagged")
                    {
                        //playerRef.itemPlayer.Add(GetComponentInChildren<Item>().gameObject);
                    }
                    //
                    
                }

            }
        }   
    }




}
