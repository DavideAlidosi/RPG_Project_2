using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Button prefab;
    Player refPlayer;
    // Use this for initialization
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }

    void OnEnable()
    {
        refPlayer = FindObjectOfType<Player>();
        foreach (var item in refPlayer.itemPlayer)
        {
            Button newButton = Instantiate(prefab);
            newButton.transform.SetParent(this.gameObject.transform);

             
        }
        
        
        
    }

    void OnDisable()
    {
        foreach (Transform item in this.gameObject.transform)
        {
            Destroy(item.gameObject);
        }   
    }
}
