using System;
using TMPro;
using UnityEngine;

public class DialogueLog : Singleton<DialogueLog>
{
    public Dialogue_SO _StartDialogues;
    private Dialogue_SO _currentDialogue;
    private int _currentLine;
    public TMP_Text _dialogueText;
    public bool _isDialogueActive;
    public int _currentSanValue;
    public static event Action OnDialogueEnd;
    private bool _WaitForAnswer;
    [SerializeField] private GameObject _PlayerOptions;
    [SerializeField] private TMP_Text _playerOption1;
    [SerializeField] private TMP_Text _playerOption2;


    void Start()
    {
        _currentDialogue = _StartDialogues;
        _currentLine = 0;
    }

    void OnEnable()
    {
       _currentDialogue = _StartDialogues;
        _currentLine = 0;
       StartDialogue();
    }


     void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!_WaitForAnswer)
        {
            StartDialogue();
        }

    }

    void StartDialogue()
    {
       _isDialogueActive = true;
        if(_currentLine <_currentDialogue._lines.Length)
        {
            _dialogueText.text = _currentDialogue._lines[_currentLine];
            _currentLine++;
        }
        else if (_currentDialogue._playerReplyOptions != null && _currentDialogue._playerReplyOptions.Length>0)
        {
            _WaitForAnswer = true;
            _PlayerOptions.SetActive(true);
            _playerOption1.text = _currentDialogue._playerReplyOptions[0];
            if (_currentDialogue._playerReplyOptions.Length > 1)
            {
                _playerOption2.transform.parent.gameObject.SetActive(true);
                _playerOption2.text = _currentDialogue._playerReplyOptions[1];
            }
            else
            {
                _playerOption2.transform.parent.gameObject.SetActive(true);
                _playerOption2.text = "";
            }
        }
        else
        {
            DialogueEnd();
        }

    }
    void DialogueEnd()
    {
        _currentSanValue = _currentDialogue._SanNumber;
        OnDialogueEnd?.Invoke();
        _isDialogueActive = false;
        _dialogueText.text = "";
        gameObject.SetActive(false);
    }
    public void AnswerSelection( int Option)
    {
        _currentLine = 0;
        _WaitForAnswer = false;
        _currentDialogue = _currentDialogue._npcReplies[Option];
        StartDialogue();
        _PlayerOptions.SetActive(false);
    }
}
