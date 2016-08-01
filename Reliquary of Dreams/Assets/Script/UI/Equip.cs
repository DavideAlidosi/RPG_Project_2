using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Equip : MonoBehaviour {


    public Image weaponSprite;
    public Image armorSprite;

    public Text classText;

    public Text forza;
    public Text agilita;
    public Text costituzione;
    public Text percezione;
    public Text fortuna;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        Player refPlayer = FindObjectOfType<Player>();
        Singleton stat = FindObjectOfType<Singleton>();

        weaponSprite.sprite = stat.weaponSprite;
        armorSprite.sprite = stat.armorSprite;

        classText.text = stat.className;

        forza.text = "" + stat.forza;
        agilita.text = "" + stat.agilita;
        costituzione.text = "" + stat.cost;
        percezione.text = "" + stat.perc;
        fortuna.text = "" + stat.fortuna;

        foreach (var item in refPlayer.itemPlayer)
        {
            item.GetComponent<Item>().equipPanel = this.gameObject;
        }
    }
}
