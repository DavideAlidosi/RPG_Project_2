using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
    * Tests the tile loader.
    */
public class TileTester : MonoBehaviour
{
    Grid refGrid;
    public Sprite free;
    public Sprite free2;

    List<TileData> allTileDatas;
    public void Awake()
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        allTileDatas = tl.LoadAllTilesInScene("Wall");
        
        foreach (TileData td in allTileDatas)
        {
            
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }
            
        }
        allTileDatas = tl.LoadAllTilesInScene("Floor");
        foreach (TileData td in allTileDatas)
        {
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }

        }

        
        //Debug.Log(s);
    }

    public void Inserisci(int x, int y)
    {   
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("Floor");
        refGrid = FindObjectOfType<Grid>();
        foreach (TileData td in allTileDatas)
        {
            //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = null;
            if (td.cell_x == y && td.cell_y == x)
            {
                //if (td.go.GetComponent<SpriteRenderer>().sprite == free || td.go.GetComponent<SpriteRenderer>().sprite == free2)
                {
                    //Debug.Log(td.go);
                    refGrid.cellMat[x, y].isWall = false;
                }
                //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = td.go.GetComponent<SpriteRenderer>().sprite;
                td.go.GetComponent<SpriteRenderer>().color = Color.gray ;
                refGrid.cellMat[x, y].refMyTile = td.go.GetComponent<SpriteRenderer>();
            }
        }
    }
    public void InsertWall(int x, int y)
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("Wall");
        refGrid = FindObjectOfType<Grid>();
        foreach (TileData td in allTileDatas)
        {
            //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = null;
            if (td.cell_x == y && td.cell_y == x)
            {
                //if (td.go.GetComponent<SpriteRenderer>().sprite == free || td.go.GetComponent<SpriteRenderer>().sprite == free2)
                {
                    //Debug.Log(td.go);
                    refGrid.cellMat[x, y].isWall = true;
                }


                //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = td.go.GetComponent<SpriteRenderer>().sprite;
                td.go.GetComponent<SpriteRenderer>().color = Color.white;
                refGrid.cellMat[x, y].refMyTile = td.go.GetComponent<SpriteRenderer>();
            }
        }
    }

    public Vector2 InsertPlayerGameObject()
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("GameObject");
        
        refGrid = FindObjectOfType<Grid>();
        foreach (var td in allTileDatas)
        {
            if (td.go.GetComponent<Player>())
            {
                return new Vector2(td.cell_y, td.cell_x);
            }

           
        }
        return new Vector2(0, 0);
    }

    public void InsertEnemyGO(int x, int y)
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("GameObject");

        refGrid = FindObjectOfType<Grid>();
        foreach (var td in allTileDatas)
        {
            if (td.go.GetComponent<Enemy>())
            {
                if (td.cell_x == y && td.cell_y == x)
                {
                    Debug.Log(td.cell_y + " " + td.cell_x);
                    td.go.GetComponent<SpriteRenderer>().color = Color.clear;

                    
                        //newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                        //newEnemy.SetActive(false);
                   

                    td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;



                    td.go.transform.localPosition = new Vector3(0, 0, 1);
                    //cellMat[i, j].spawned = true;
                    //td.go.GetComponent<Enemy>().refMyCell = refGrid.cellMat[td.cell_y, td.cell_x];
                }
            }
        }
        
    }
    public void InsertDoor(int x, int y)
    {
        TileLoader tl = FindObjectOfType<TileLoader>();
        List<TileData> allTileDatas = tl.LoadAllTilesInScene("Door");
        refGrid = FindObjectOfType<Grid>();

        foreach (var td in allTileDatas)
        {
            if (td.cell_x == y && td.cell_y == x)
            {
                
                    
                    refGrid.cellMat[x, y].isWall = true;
                    refGrid.cellMat[x, y].isDoor = true;
                    refGrid.cellMat[x, y].gameObject.AddComponent<Door>();
                    
                


                //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = td.go.GetComponent<SpriteRenderer>().sprite;
                td.go.GetComponent<SpriteRenderer>().color = Color.white;
                refGrid.cellMat[x, y].refMyTile = td.go.GetComponent<SpriteRenderer>();

            }
        }
      
    }


}

