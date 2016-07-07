using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
    public int myI, myJ;
    public bool isSpawnCell = false;
    public SpriteRenderer sBox;
    public bool isFree = false;
    Vector2 pos;
    public bool isWall = false;
    public bool isCombat = false;

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
        if (isWall)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }

        
    }
    // Start cell selecting code
    void OnMouseEnter()
    {
        if (this.isFree && !GetComponentInChildren<Player>())
        {
            if (gcRef.phase == GamePhase.Movimento)
            {
                sBox.color = Color.yellow;
                gcRef.movementCell.Add(this.gameObject);
            }
        }
    }

    // End cell highlight code

    void OnMouseUp()
    {

        
        if (gcRef.phase == GamePhase.Selezione)
        {
            
            if (GetComponentInChildren<Player>())
            {

                sBox.color = Color.green;
                gcRef.phase++;

                gcRef.firstCell = this.gameObject;
                pos = new Vector2(myI, myJ);
                refFog.Fog(pos,4);
                refFog.AStar();
            }
            

        }
        else if(gcRef.phase == GamePhase.Movimento)
        {
            if (isFree)
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
