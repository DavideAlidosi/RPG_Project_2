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
    List<TileData> allTileDatasFloor;
    List<TileData> allTileDatasWall;
    List<TileData> allTileDatasDoor;
    List<TileData> allTileDatasGO;
    FogOfWar refFog;
    GameControl refGC;
    public void Awake()
    {
        refFog = FindObjectOfType<FogOfWar>();
        refGC = FindObjectOfType<GameControl>();
        TileLoader tl = FindObjectOfType<TileLoader>();
        allTileDatas = tl.LoadAllTilesInScene("Enviroment");
        foreach (TileData td in allTileDatas)
        {
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }

        }
        
        allTileDatasGO = tl.LoadAllTilesInScene("GameObject");
        foreach (TileData td in allTileDatasGO)
        {
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                //td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }

        }

        allTileDatasWall = tl.LoadAllTilesInScene("Wall");
        
        foreach (TileData td in allTileDatasWall)
        {
            
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }
            
        }
        allTileDatasFloor = tl.LoadAllTilesInScene("Floor");
        foreach (TileData td in allTileDatasFloor)
        {
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }

        }

        /*allTileDatas = tl.LoadAllTilesInScene("Env_Floor");
        foreach (TileData td in allTileDatas)
        {
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }

        }
        /*allTileDatas = tl.LoadAllTilesInScene("Env_Wall");
        foreach (TileData td in allTileDatas)
        {
            if (td.go.GetComponent<SpriteRenderer>().color != null)
            {
                td.go.GetComponent<SpriteRenderer>().color = Color.clear;
            }

        }*/
        allTileDatasDoor = tl.LoadAllTilesInScene("Door");
        foreach (TileData td in allTileDatasDoor)
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
        
        refGrid = FindObjectOfType<Grid>();
        foreach (TileData td in allTileDatasFloor)
        {
            
            //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = null;
            if (td.cell_x == y && td.cell_y == x)
            {
                //if (td.go.GetComponent<SpriteRenderer>().sprite == free || td.go.GetComponent<SpriteRenderer>().sprite == free2)
                {
                    
                    refGrid.cellMat[x, y].isWall = false;
                }

                //refGrid.cellMat[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = td.go.GetComponent<SpriteRenderer>().sprite;
                //td.go.transform.position = Vector3.zero;
                //refGrid.cellMat[x, y].refMyTileGO = Instantiate(td.go);
                //refGrid.cellMat[x, y].refMyTileGO.transform.parent = refGrid.cellMat[x, y].sBox.gameObject.transform;
                //refGrid.cellMat[x, y].refMyTileGO.transform.localPosition = Vector3.zero;
                td.go.GetComponent<SpriteRenderer>().color = Color.gray ;
                refGrid.cellMat[x, y].refMyTile = td.go.GetComponent<SpriteRenderer>();

                
                
                //Destroy(td.go);
            }
        }

    }
    public void InsertWall(int x, int y)
    {
        
        refGrid = FindObjectOfType<Grid>();
        foreach (TileData td in allTileDatasWall)
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
        
        
        refGrid = FindObjectOfType<Grid>();
        foreach (var td in allTileDatasGO)
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
        

        refGrid = FindObjectOfType<Grid>();
        foreach (var td in allTileDatasGO)
        {
            if (td.go.GetComponent<Enemy>())
            {
                if (td.cell_x == y && td.cell_y == x)
                {
                    
                    td.go.GetComponent<SpriteRenderer>().color = Color.clear;

                    
                        //newEnemy.GetComponent<Enemy>().str = Random.Range(2, 6);
                        //newEnemy.SetActive(false);
                   

                    td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;

                    td.go.GetComponent<Enemy>().refMyCell = refGrid.cellMat[x, y];

                    td.go.transform.localPosition = new Vector3(0, 0, 1);
                    //cellMat[i, j].spawned = true;
                    //td.go.GetComponent<Enemy>().refMyCell = refGrid.cellMat[td.cell_y, td.cell_x];
                }
            }
            if (td.go.GetComponent<NextScene>())
            {
                if (td.cell_x == y && td.cell_y == x)
                {
                    td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;
                    td.go.transform.localPosition = new Vector3(0, 0, 1);
                }
            }
        }
        
    }
    public GameObject InsertText(int x, int y)
    {
        
        GameObject textIt = null;
        refGrid = FindObjectOfType<Grid>();
        foreach (var td in allTileDatasGO)
        {
            if (td.go.GetComponent<StoryText>())
            {
                if (td.cell_x == y && td.cell_y == x)
                {
                    
                    td.go.GetComponent<SpriteRenderer>().color = Color.clear;
                    textIt = td.go;
                }
            }
        }
        return textIt;

    }
    public void InsertDoor(int x, int y)
    {
        
        refGrid = FindObjectOfType<Grid>();

        foreach (var td in allTileDatasDoor)
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

    public void NewInsert()
    {
        refGrid = FindObjectOfType<Grid>();

        foreach (var td in allTileDatasFloor)
        {
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile = td.go.GetComponent<SpriteRenderer>();
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile.color = Color.gray;
            refGrid.cellMat[td.cell_y, td.cell_x].myTile.Add(td.go.GetComponent<SpriteRenderer>());
            refGrid.cellMat[td.cell_y, td.cell_x].isWall = false;
            refGrid.cellMat[td.cell_y, td.cell_x].refFog = refFog;
            refGrid.cellMat[td.cell_y, td.cell_x].gcRef = refGC;
        }
        foreach (var td in allTileDatasWall)
        {
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile = td.go.GetComponent<SpriteRenderer>();
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile.color = Color.white;
            refGrid.cellMat[td.cell_y, td.cell_x].myTile.Add(td.go.GetComponent<SpriteRenderer>());
            refGrid.cellMat[td.cell_y, td.cell_x].isWall = true;
        }

        foreach (var td in allTileDatas)
        {
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile = td.go.GetComponent<SpriteRenderer>();
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile.color = Color.white;
            refGrid.cellMat[td.cell_y, td.cell_x].myTile.Add(td.go.GetComponent<SpriteRenderer>());
            refGrid.cellMat[td.cell_y, td.cell_x].isWall = true;
        }

        foreach (var td in allTileDatasDoor)
        {
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile = td.go.GetComponent<SpriteRenderer>();
            refGrid.cellMat[td.cell_y, td.cell_x].refMyTile.color = Color.white;
            refGrid.cellMat[td.cell_y, td.cell_x].myTile.Add(td.go.GetComponent<SpriteRenderer>());
            refGrid.cellMat[td.cell_y, td.cell_x].gameObject.AddComponent<Door>();
            refGrid.cellMat[td.cell_y, td.cell_x].isDoor = true;
            refGrid.cellMat[td.cell_y, td.cell_x].refFog = refFog;
            refGrid.cellMat[td.cell_y, td.cell_x].gcRef = refGC;
        }
        
        foreach (var td in allTileDatasGO)
        {
            
            if (td.go.GetComponent<Player>())
            {
                
                continue;
            }
            

            
            if (td.go.GetComponent<Enemy>())
            {
                td.go.GetComponent<Enemy>().refMyCell = refGrid.cellMat[td.cell_y, td.cell_x];
                td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;
                td.go.transform.localPosition = new Vector3(0, 0, 1);
            }

            if (td.go.GetComponent<NextScene>())
            {                
                td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;
                td.go.transform.localPosition = new Vector3(0, 0, 1);
            }

            if (td.go.GetComponent<StoryText>())
            {
                td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;
                td.go.transform.localPosition = new Vector3(0, 0, 1);
            }

            if (td.go.GetComponent<ItemLoader>())
            {
                td.go.transform.parent = refGrid.cellMat[td.cell_y, td.cell_x].transform;
                td.go.transform.localPosition = new Vector3(0, 0, 1);
                td.go.GetComponent<ItemLoader>().x = td.cell_y;
                td.go.GetComponent<ItemLoader>().y = td.cell_x;
            }


        }
        
    }


}

