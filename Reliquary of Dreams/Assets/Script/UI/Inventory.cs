﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Button prefab;
    Player refPlayer;
    MenuPopUp refMenu;
    // Use this for initialization
    bool isEnable = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (isEnable)
        {
            
        }
    }

    void OnEnable()
    {
        
        isEnable = true;
        refPlayer = FindObjectOfType<Player>();
        refPlayer.gcRef.phase = GamePhase.Azione;
        int n = 0;
        foreach (var item in refPlayer.itemPlayer)
        {

            item.GetComponent<Item>().n = n;
            item.GetComponent<Item>().inventoryPanel = this.gameObject;
            
            n++;
            Button newButton = Instantiate(prefab);
            newButton.name = item.name;
            newButton.transform.SetParent(this.gameObject.transform);
            newButton.GetComponentInChildren<Text>().text = ""+item.gameObject.name;
            if (item.name == "Potion")
            {
                newButton.onClick.AddListener(() => item.GetComponent<Item>().Drink());
                
            }
            if (item.name == "PotionMax")
            {
                newButton.onClick.AddListener(() => item.GetComponent<Item>().Drink());
            }
            if (item.name == "LuckyPotion")
            {
                newButton.onClick.AddListener(() => item.GetComponent<Item>().Drink());
            }
            if (item.name == "StrengthPotion")
            {
                newButton.onClick.AddListener(() => item.GetComponent<Item>().Drink());
            }
            if (item.name == "AgilityPotion")
            {
                newButton.onClick.AddListener(() => item.GetComponent<Item>().Drink());
            }



        }
        
        
        
    }

    void OnDisable()
    {
        refPlayer.gcRef.phase = GamePhase.Movimento;
        refMenu = FindObjectOfType<MenuPopUp>();
        refMenu.isActiveCons = false;
        isEnable = false;
        foreach (Transform item in this.gameObject.transform)
        {
            Destroy(item.gameObject);
        }   
    }

    
}
