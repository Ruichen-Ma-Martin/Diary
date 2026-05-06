using UnityEngine;

public class gameController: MonoBehaviour
{
    public static gameController instance;
    public playercontrol playercontrol;
    public bool isDiaryOpen = true;
    private void Awake()
    {
        instance = this;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        } 
    }
}
