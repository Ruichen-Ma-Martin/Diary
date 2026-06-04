using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaytimeControl : Singleton<DaytimeControl>
{
    //public int _Daytime = 1;
    public static event Action OnDaytimeChanged;
    public int _ActionNumber = 0;
    public Dialogue_SO[] _dialoguelist;
    [SerializeField] private Dialogue_SO[] _Daydialoguelist;
    [SerializeField]private GameObject _dialogueHUD;
    [SerializeField] private Dialogue_SO _GameStartDialogue;
    
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
        GlobalData._Day += 1;
        
        OnDaytimeChanged?.Invoke();
    }
    private void Start()
    {
        
        DialogueLog.Instance._StartDialogues = _Daydialoguelist[GlobalData._Day - 1];
            _dialogueHUD.SetActive(true);
        
        
        _DayText.text = "Day " + GlobalData._Day;
        _timeText.text = _timeList[_ActionNumber];
        
    }
    private void Update()
    {
        NextDay();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextAction();
        }
    }

    void NextDay()
    {
        if (_ActionNumber >= 4)
        { 
            
          
          
           AddDay();
           SceneManager.LoadScene(GlobalData._SceneList[GlobalData._Day - 1]);

        }
        
      
    }

    public void NextAction()
    {
        _ActionNumber++;
        _timeText.text = _timeList[_ActionNumber];
    }

}

