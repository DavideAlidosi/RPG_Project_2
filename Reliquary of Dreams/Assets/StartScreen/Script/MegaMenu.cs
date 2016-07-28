using UnityEngine;
using System.Collections;

public class MegaMenu : MonoBehaviour
{
    public GameObject canvasCrediti;
    public GameObject canvasMenu;
    public GameObject canvasOpzioni;
    public GameObject canvasClassi;

    void Awake()
    {
        canvasCrediti.SetActive(false);
        canvasMenu.SetActive(true);
        canvasOpzioni.SetActive(false);
        canvasClassi.SetActive(false);
    } 

    public void Crediti ()
    {
        canvasCrediti.SetActive(true);
        canvasMenu.SetActive(false);
        canvasOpzioni.SetActive(false);
        canvasClassi.SetActive(false);
    }
    public void Menu()
    {
        canvasCrediti.SetActive(false);
        canvasMenu.SetActive(true);
        canvasOpzioni.SetActive(false);
        canvasClassi.SetActive(false);
    }
    public void Opzioni()
    {
        canvasCrediti.SetActive(false);
        canvasMenu.SetActive(false);
        canvasOpzioni.SetActive(true);
        canvasClassi.SetActive(false);
    }
    public void Classi()
    {
        canvasCrediti.SetActive(false);
        canvasMenu.SetActive(false);
        canvasOpzioni.SetActive(false);
        canvasClassi.SetActive(true);
    }
}
