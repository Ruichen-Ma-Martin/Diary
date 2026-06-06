using UnityEngine;
using UnityEngine.SceneManagement;

public class gameovercheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject _gameoverUI;
    [SerializeField] private GameObject _dialogueUI;
    [SerializeField] private Dialogue_SO _Day4Dialogue;
    [SerializeField] private Dialogue_SO _gameover;
    [SerializeField] private Dialogue_SO _win;

    void Awake()
    {
        DialogueLog.Instance._StartDialogues = _Day4Dialogue;
        _dialogueUI.SetActive(true);

        
    }

    private void Start()
    {
        if (GlobalData._Day >= 5 && GlobalData._SanValue <= 20&&DialogueLog.Instance._isDialogueActive == false)
        {
            _gameoverUI.SetActive(true);
            DialogueLog.Instance._StartDialogues = _gameover;
            _dialogueUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(GlobalData._Day >= 5 && GlobalData._SanValue > 20 && DialogueLog.Instance._isDialogueActive == false)
        {
            _gameoverUI.SetActive(false);
            DialogueLog.Instance._StartDialogues = _win;
            _dialogueUI.SetActive(true);
        }
    }
    public void Restart()
    {
        GlobalData._Day = 1;
        SceneManager.LoadScene(GlobalData._SceneList[GlobalData._Day - 1]);
        GlobalData._SanValue = 100;
    }


}
