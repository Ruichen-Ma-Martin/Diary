using UnityEngine;

public class InteractiveObject : Singleton<InteractiveObject>
{
    [SerializeField] private GameObject _interactiveUI;
    [SerializeField] private int _requiredDay;
    [SerializeField] private GameObject _ObjectHuD;
    
    
    
    private bool _isHUDOpen = false;

    


    void Update()
    {
        if(_requiredDay == GlobalData._Day)
        {
            checkinteractiveStart();
        }
        else
            {
                _interactiveUI.SetActive(false);
        }

    }

    void checkinteractiveStart()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < 2f)
        {
            _interactiveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && _isHUDOpen == false )
            {
                OpenInteractiveHUD();
            }
            else if (Input.GetKeyDown(KeyCode.E) && _isHUDOpen == true&& DialogueLog.Instance._isDialogueActive == false)
            {
                CloseInteractiveHUD();
                DaytimeControl.Instance.NextAction();
            }
            
        }
        else
        {
            _interactiveUI.SetActive(false);
        }
        void OpenInteractiveHUD()
        {
            _isHUDOpen = true;
            //PlayerController.Instance._isPlayerCanMove = false;
            _ObjectHuD.SetActive(true);
        }

        void CloseInteractiveHUD()
        {
            _isHUDOpen = false;
            //PlayerController.Instance._isPlayerCanMove = true;
            _ObjectHuD.SetActive(false);
        }

    }
}
    
