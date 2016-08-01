using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public SpriteRenderer sr;
    Grid gridRef;
    public GameControl gcRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;
    Singleton stat;

    public List<GameObject> itemPlayer = new List<GameObject>();

    public int exp = 0;
    public int expForLevel = 1000;
    public int str;
    public int cos;
    public int hp;
    public int agi;
    public int intS;
    public int per;
    public int forS;
    public int level = 1;

    public int hpMax;
    public int strMax;
    public int agiMax;
    public int forMax;


    // Use this for initialization
    void Awake()
    {
        stat = FindObjectOfType<Singleton>();
        str = stat.forza;
        cos = stat.cost;
        hp = cos*4;
        agi = stat.agilita;
        intS = stat.intel;
        per = stat.perc;
        forS = stat.fortuna;

<<<<<<< HEAD

       /*str = 7;
        str = 7;
=======
        /*str = 7;
>>>>>>> ae753390c050630820b6c92bef2c36e4c96734ab
        cos = 100;
        hp = cos * 4;
        agi = 10;
        intS = 7;
        per = 10;
        forS = 7;*/

        hpMax = hp;
        strMax = str;
        agiMax = agi;
        forMax = forS;
        
    }
	void Start () {
        gcRef = FindObjectOfType<GameControl>();
        fogRef = FindObjectOfType<FogOfWar>();
        refMPU = FindObjectOfType<MenuPopUp>();

        


    }
	
	// Update is called once per frame
	void Update () {
        if (exp > expForLevel)
        {
            level++;
            expForLevel += 1000;
            refMPU.levelUpPanel.SetActive(true);
        }
	}

    public void SpawnPlayer(Vector2 posPlayer)
    {
        gridRef = FindObjectOfType<Grid>();

        /*for (int i = 0; i < Grid.COL; i++)
        {
            for (int j = 0; j < Grid.ROW; j++)
            {
                if (gridRef.cellMat[i, j] == null) continue;
                
                if (gridRef.cellMat[i, j].isSpawnCell)
                {          */    
                         
        this.transform.parent = gridRef.cellMat[(int)posPlayer.x, (int)posPlayer.y].transform;
        this.transform.localPosition = new Vector3(0, 0, 1);
        

                /*)
            }
        }*/
    }

    public void MovePlayer(int iCell, int jCell)
    {
        this.transform.parent = gridRef.cellMat[iCell, jCell].transform;
        this.transform.localPosition = new Vector3(0, 0, 1);
    }

    void OnMouseUp()
    {
        
    }

    public IEnumerator MovePlayer()
    {
        Grid refGrid = FindObjectOfType<Grid>();
        
        foreach (var item in GetComponentInChildren<FogOfWar>().pathProva)
        {
            int iCell = item.myI;
            int jCell = item.myJ;
            this.transform.parent = gridRef.cellMat[iCell, jCell].transform;
            this.transform.localPosition = new Vector3(0, 0, 1);
            

            yield return new WaitForSeconds(0.2f);
        }
        gcRef.playerCell = GetComponentInParent<Cell>().gameObject;
        
    }
    
}
