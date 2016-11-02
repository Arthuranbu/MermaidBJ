using UnityEngine;
using System.Collections;

public class StartQuit : MonoBehaviour
{

    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}