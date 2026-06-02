using UnityEngine;

public class DaytimeControl: Singleton<DaytimeControl>
{
    public int _Daytime = 0; 
    public event System.Action OnDaytimeChanged;
    public Dialogue_SO[]  _dialoguelist;

    public void AddDay()
    {
        _Daytime++;
        Debug.Log("Daytime increased. Current daytime: " + _Daytime);
        OnDaytimeChanged?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddDay();
        }
    }
}

