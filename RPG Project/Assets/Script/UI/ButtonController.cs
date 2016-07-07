using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public Button bttnAtt;
    public Button bttnWait;
    public Button bttnUse;
    public Button bttnItem;

    public Enemy[] enemies;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            if (enemy.isNear)
            {
                bttnAtt.interactable = true;
                break;
            }
            else
            {
                bttnAtt.interactable = false;
            }
        }
    }
    void OnDisable()
    {
        enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            if (enemy.isNear)
            {
                bttnAtt.interactable = true;
                break;
            }
            else
            {
                bttnAtt.interactable = false;
            }
        }
    }
}