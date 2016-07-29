using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MenuPopUp : MonoBehaviour {
    public GameObject menuPanel;
    public GameObject levelUpPanel;
    public GameObject equipStat;

    public bool isActiveCons = false;
    bool isActiveEquip = false;
    public Image inventory;
    public Text dialoghi;
    public GameObject panelDialoghi;
    public GameObject Equip;

    

    
	// Use this for initialization
    void Awake ()
    {
        
    }

	void Start () {

        

    }
    
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        menuPanel.SetActive(true);
    }

    public void Deactivate()
    {
        menuPanel.SetActive(false);
    }

    public void ConsumableInventory()
    {
        // BUG
        if (!isActiveCons)
        {
            inventory.gameObject.SetActive(true);
            equipStat.SetActive(true);
            isActiveCons = true;
        }
        else
        {
            inventory.gameObject.SetActive(false);
            equipStat.SetActive(false);
            isActiveCons = false;
        }
        
    }

    public void EquipMenu()
    {
        if (!isActiveEquip)
        {
            Equip.SetActive(true);
            isActiveEquip = true;
        }
        else
        {
            Equip.gameObject.SetActive(false);
            isActiveEquip = false;
        }
    }
}
