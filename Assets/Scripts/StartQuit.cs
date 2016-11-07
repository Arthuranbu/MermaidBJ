using UnityEngine;
using System.Collections;

public class StartQuit : MonoBehaviour
{
    public GameObject ScoreKeeper;
    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickStart()
    {
        ScoreKeeper = GameObject.Find("ScoreKeeper");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        Destroy (ScoreKeeper);
    }
}