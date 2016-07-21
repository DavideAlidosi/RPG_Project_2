using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public SpriteRenderer sr;
    Grid gridRef;
    GameControl gcRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;

    public List<Item> itemPlayer = new List<Item>();

    public int str;
    public int cos;
    public int hp;
    public int agi;
    public int intS;
    public int per;
    public int forS;


    // Use this for initialization
    void Awake()
    {
        str = 5;
        cos = 9;
        hp = cos*4;
        agi = 5;
        intS = 1;
        per = 1;
        forS = 1;
    }
	void Start () {
        gcRef = FindObjectOfType<GameControl>();
        fogRef = FindObjectOfType<FogOfWar>();
        refMPU = FindObjectOfType<MenuPopUp>();

        


    }
	
	// Update is called once per frame
	void Update () {
	    
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
            refGrid.CreateGrid();
            yield return new WaitForSeconds(0.5f);
        }
        gcRef.playerCell = GetComponentInParent<Cell>().gameObject;
    }
    
}
