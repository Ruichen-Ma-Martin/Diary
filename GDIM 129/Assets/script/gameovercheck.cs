using UnityEngine;
using UnityEngine.SceneManagement;

public class gameovercheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject _gameoverUI;

    void Awake()
    {
        if(GlobalData._Day >= 5 && GlobalData._SanValue <= 20)
        {
            _gameoverUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void Restart()
    {
        GlobalData._Day = 1;
        SceneManager.LoadScene(GlobalData._SceneList[GlobalData._Day - 1]);
        GlobalData._SanValue = 100;
    }


}
