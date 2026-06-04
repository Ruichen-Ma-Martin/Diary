using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(GlobalData._SceneList[GlobalData._Day - 1]);
        GlobalData._SanValue = GlobalData._SanStock;
       
    }
}
