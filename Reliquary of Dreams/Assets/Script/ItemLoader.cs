using UnityEngine;
using System.Collections;

public class ItemLoader : MonoBehaviour {
    public int x;
    public int y;
    
    // Use this for initialization
    void Start () {
        
        int whatPotion = Random.Range(0, 101);
        int nPotion = 0;
        if (whatPotion < 30 && whatPotion > 20)
            nPotion = 2;

        if (whatPotion < 20 && whatPotion > 10)
            nPotion = 3;

        if (whatPotion < 10 && whatPotion > 0)
            nPotion = 4;

        if (whatPotion < 60 && whatPotion > 30)
            nPotion = 0;

        if (whatPotion < 100 && whatPotion > 60)
            nPotion = 1;
        GameObject newPotion = Instantiate(new GameObject());
        Grid refGrid = FindObjectOfType<Grid>();
        
        switch (nPotion)
        {

            case 0:
                newPotion.transform.parent = refGrid.cellMat[x, y].transform;
                newPotion.gameObject.AddComponent<Potion>();
                newPotion.gameObject.name = "Potion";
                break;
            case 1:
                newPotion.transform.parent = refGrid.cellMat[x, y].transform;
                newPotion.gameObject.AddComponent<PotionMax>();
                newPotion.gameObject.name = "PotionMax";
                break;
            case 2:
                newPotion.transform.parent = refGrid.cellMat[x, y].transform;
                newPotion.gameObject.AddComponent<LuckPotion>();
                newPotion.gameObject.name = "LuckyPotion";
                break;
            case 3:
                newPotion.transform.parent = refGrid.cellMat[x, y].transform;
                newPotion.gameObject.AddComponent<StrPotion>();
                newPotion.gameObject.name = "StrengthPotion";
                break;
            case 4:
                newPotion.transform.parent = refGrid.cellMat[x, y].transform;
                newPotion.gameObject.AddComponent<AgiPotion>();
                newPotion.gameObject.name = "AgilityPotion";
                break;
            default:
                break;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    
    
}
