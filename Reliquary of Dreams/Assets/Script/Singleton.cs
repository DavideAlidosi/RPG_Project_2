using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
    // This pubblic variables can live between scene because are connected to Menu Scene > Audio Source Audio Source
    public int forza = 1;
    public int agilita = 1;
    public int cost = 1;
    public int intel = 1;
    public int perc = 1;
    public int fortuna = 1;
    
    // Define of sigleton, it store if the audio source exist and manain it alivi between the scene
    private static Singleton instance = null;
    public static Singleton Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null & instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}