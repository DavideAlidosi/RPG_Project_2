using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
    // This pubblic variables can live between scene because are connected to Menu Scene > Audio Source Audio Source
    public int numeroFisso = 1;

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