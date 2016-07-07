using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
    * Tests the tile loader.
    */
public class TileTester : MonoBehaviour
{
    Grid refGrid;
    public void Awake()
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("Tile");
        string s = "";
        foreach (TileData td in allTileDatas)
        {
            td.go.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        Debug.Log(s);
    }

    public void Inserisci(int x, int y)
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("Tile");
        refGrid = FindObjectOfType<Grid>();
        foreach (TileData td in allTileDatas)
        {
            
            if (td.cell_x == y && td.cell_y == x)
            {
                if (td.go.GetComponent<SpriteRenderer>().sprite == null)
                {
                    refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = null;
                    Debug.Log("Ciao");
                }
                refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = td.go.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}

