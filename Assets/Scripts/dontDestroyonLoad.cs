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
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        gameControllerObject = GameObject.FindWithTag("background");
        {

            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameManager>();
            }
            if (gameController == null)
            {
                Debug.Log("CannotFind'GameController' script");
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per fraem
    void Update()
    {
        myScore = GameManager.finalscore;
        scoreText = GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>();
        if (scoreText == null)
        {

        }
        else scoreText.text = "Final Score: " + myScore;
    }
}
