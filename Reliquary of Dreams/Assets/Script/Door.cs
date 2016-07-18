using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public Cell adjacent;
    Grid refGrid;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FindMyAdjacent(int _x , int _y)
    {
        refGrid = FindObjectOfType<Grid>();

        if (refGrid.cellMat[_x + 1, _y].isDoor)
        {
            adjacent = refGrid.cellMat[_x + 1, _y];
        }
        if (refGrid.cellMat[_x - 1, _y].isDoor)
        {
            adjacent = refGrid.cellMat[_x - 1, _y];
        }
        if (refGrid.cellMat[_x, _y + 1].isDoor)
        {
            adjacent = refGrid.cellMat[_x, _y + 1];
        }
        if (refGrid.cellMat[_x, _y - 1].isDoor)
        {
            adjacent = refGrid.cellMat[_x, _y - 1];
        }
    }
}
