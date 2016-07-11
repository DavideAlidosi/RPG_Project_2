using UnityEngine;
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

    public Enemy enemyRef;
    public FogOfWar refFog;
    GameControl gcRef;
    public Player playerRef;
    public MenuPopUp refMPU;

    // Use this for initialization
    void Start () {
        gcRef = FindObjectOfType<GameControl>();
        playerRef = FindObjectOfType<Player>();
        refFog = FindObjectOfType<FogOfWar>();
        enemyRef = FindObjectOfType<Enemy>();
        refMPU = FindObjectOfType<MenuPopUp>();
        
        
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

        gcRef = FindObjectOfType<GameControl>();
        playerRef = FindObjectOfType<Player>();
        refFog = FindObjectOfType<FogOfWar>();
        enemyRef = FindObjectOfType<Enemy>();
        refMPU = FindObjectOfType<MenuPopUp>();
        if (gcRef.phase == GamePhase.Selezione)
        {
            
            if (GetComponentInChildren<Player>())
            {

                sBox.color = Color.green;
                gcRef.phase++;

                gcRef.queueMoveCell.Clear();
                gcRef.firstCell = this.gameObject;
                pos = new Vector2(myI, myJ);
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
                refFog.ResetEnemyStatus();
                gcRef.phase = GamePhase.Azione;
                playerRef.MovePlayer(myI,myJ);
                refFog.GetEnemyNearPlayer(this.myI,this.myJ);
                refMPU.Activate();
                gcRef.playerCell = this.gameObject;
               
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
    }
}
