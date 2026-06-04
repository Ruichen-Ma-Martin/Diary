using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButton : MonoBehaviour
{
    [SerializeField] private int ButtonID;
    private Button _button;
    public GameObject _DialogueHUD;
    private Image targetImage;

    


    private void Awake()
    {
        if(targetImage == null)
        {
            targetImage = GetComponent<Image>();
        }
        _button = GetComponent<Button>();

        if(_button != null )
        {
            _button.onClick.AddListener(OnButtonClick);
        }
    }
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        DialogueLog.Instance._StartDialogues = DaytimeControl.Instance._dialoguelist[ButtonID];
        _DialogueHUD.SetActive(true);
        targetImage.material = null;
        _button.interactable = false;


    }
}
