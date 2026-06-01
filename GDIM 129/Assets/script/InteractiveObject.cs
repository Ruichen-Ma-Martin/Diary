using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private GameObject _interactiveUI;
    [SerializeField] private int _requiredDay;
    [SerializeField] private GameObject _ObjectHuD;
     private Dialogue_SO _currentDialogue;
     public Dialogue_SO _StartDialogue;
     private bool _isDialogueStarted;

     private int _currentLine;


    void Update()
    {
        if (DaytimeControl.Instance._Daytime == _requiredDay)
        {
            checkinteractiveStart();
        }
    }

    void checkinteractiveStart()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < 1.5f)
        {
            _interactiveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                OpenInteractiveHUD();
            }
        }
        else
        {
            _interactiveUI.SetActive(false);
        }
    }

    void OpenInteractiveHUD()
    {
        PlayerController.Instance._isPlayerCanMove = false;
        Debug.Log("interact");
        _ObjectHuD.SetActive(true);
    }
    void ClickAbleObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDialogue();
        }
    }
    void StartDialogue()
    {
        _isDialogueStarted = true;
        if(_currentLine < _currentDialogue._dialogueLines.Count)
        {
            _currentLine++;
        }
        else
        {
        }
    }
}
