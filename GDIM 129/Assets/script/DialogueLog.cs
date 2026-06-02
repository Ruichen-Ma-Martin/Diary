using TMPro;
using UnityEngine;

public class DialogueLog : Singleton<DialogueLog>
{
    public Dialogue_SO _StartDialogues;
    private Dialogue_SO _currentDialogue;
    private int _currentLine;
    public TMP_Text _dialogueText;
    private bool _isDialogueActive;

    void Start()
    {
        _currentDialogue = _StartDialogues;
        _currentLine = 0;
    }

    void OnEnable()
    {
       _currentDialogue = _StartDialogues;
        _currentLine = 0;
       
    }


     void Update()
    {
        if (Input.GetMouseButton(0))
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
        else
        {
            DialogueEnd();
        }

    }
    void DialogueEnd()
    {
        _isDialogueActive = false;
        _dialogueText.text = "";
        gameObject.SetActive(false);
    }
}
