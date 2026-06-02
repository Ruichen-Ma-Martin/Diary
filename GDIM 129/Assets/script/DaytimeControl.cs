using System;
using TMPro;
using UnityEngine;

public class DaytimeControl : Singleton<DaytimeControl>
{
    public int _Daytime = 1;
    public static event Action OnDaytimeChanged;
    public int _ActionNumber = 0;
    public Dialogue_SO[] _dialoguelist;
    [SerializeField] private Dialogue_SO[] _Daydialoguelist;
    [SerializeField]private GameObject _dialogueHUD;
    
    [SerializeField] private string[] _timeList =
    {
        "8:00 AM",
        "12:00 PM",
        "4:00 PM",
        "8:00 PM",
        "0:00 AM"
    };
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _DayText;
   

    public void AddDay()
    {
        _Daytime++;
        Debug.Log("Daytime increased. Current daytime: " + _Daytime);
         OnDaytimeChanged?.Invoke();
    }
    private void Start()
    {   
        AddDay();
        _DayText.text = "Day " + _Daytime;
        _timeText.text = _timeList[_ActionNumber];
        
    }
    private void Update()
    {
        NextDay();
    }

    void NextDay()
    {
        if (_ActionNumber >= 4)
        { 
            _ActionNumber = 0;
           DialogueLog.Instance._StartDialogues = _Daydialoguelist[_Daytime - 1];
          _dialogueHUD.SetActive(true);
           AddDay();
          _DayText.text = "Day " + _Daytime;
          _timeText.text = _timeList[_ActionNumber];

        }
        
      
    }

    public void NextAction()
    {
        _ActionNumber++;
        _timeText.text = _timeList[_ActionNumber];
    }

}

