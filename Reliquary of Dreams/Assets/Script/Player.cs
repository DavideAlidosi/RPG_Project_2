﻿using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
    public SpriteRenderer sr;
    Grid gridRef;
    GameControl gcRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;

    public int str;
    public int cos;
    public int hp;
    public int agi;


    // Use this for initialization
    void Awake()
    {
        str = 5;
        cos = 9;
        hp = cos*4;
        agi = 5;
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

    public void TestCombat()
    {
        gcRef.CombatPlayer();
        if (gcRef.enemyCell.GetComponentInChildren<Enemy>().hp > 0)
        {
            gcRef.CombatEnemy();
        }
        gcRef.phase = GamePhase.Selezione;
        gcRef.ResetToSelectionPhase();
        fogRef.LightRadius();
    }

    public void TestWait()
    {
        Debug.Log("aspetto");
        gcRef.phase = GamePhase.TurnoNemici;
        gcRef.ResetToSelectionPhase();
        fogRef.LightRadius();
    }

    public void TestUse()
    {
        Debug.Log("usa usa");
        gcRef.phase = GamePhase.Selezione;
        gcRef.ResetToSelectionPhase();
    }
    public void TestItem()
    {
        Debug.Log("Lista oggetti");
        gcRef.phase = GamePhase.Selezione;
        gcRef.ResetToSelectionPhase();
    }
    
}
