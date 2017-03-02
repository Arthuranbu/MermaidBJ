using UnityEngine;
using System.Collections;

public class StartQuit : MonoBehaviour
{
    public GameObject ScoreKeeper;
    public GameObject credits;
    public GameObject creditholder;


    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickStart()
    {
        ScoreKeeper = GameObject.Find("ScoreKeeper");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Destroy (ScoreKeeper);
    }
    public void onClickCredits()
    {
        credits = creditholder.transform.Find ("CreditsScreen").gameObject;
        credits.SetActive(true);
    }
    public void onClickBack()
    {
        credits = GameObject.Find("CreditsScreen");
        credits.SetActive(false);
    } 
}