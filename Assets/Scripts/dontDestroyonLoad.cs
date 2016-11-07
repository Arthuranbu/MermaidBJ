using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dontDestroyonLoad : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public GameManager gameController;
    GameObject gameControllerObject;
    public GameObject ScoreKeeper;
    public int myScore;


    void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
        DontDestroyOnLoad(ScoreKeeper.gameObject);
        gameControllerObject = GameObject.FindWithTag("background");
}

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>();
        if (scoreText == null)
        {

        }
        else scoreText.text = "Final Score: " + myScore;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per fraem
    void Update()
    {
        myScore = GameManager.finalscore;
    }
}
