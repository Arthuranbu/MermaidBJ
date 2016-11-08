using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int Lives = 5;
    public static int Score = 0;
    public static GameManager instance;
    public Transform spawnpoint;
    public Transform mermaidspawnpoint;
    public GameObject player;
    public List<GameObject> fishes;
    public List<GameObject> sfishes;
    public float timeLeft;
    public float MaxTimeLeft;
    public GUIText scoreText;
    public static int score;
    public GameObject treasure;
    public GameObject Life3;
    public GameObject Life2;
    public GameObject Life1;
    public GameObject Mermaid;
    private static bool isProgressing = false;
    public static int finalscore;
    // Use this for initialization
   

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<GUIText>();

    }
    void Start()
    {

        sfishes = new List<GameObject>();
        foreach (GameObject sfish in GameObject.FindGameObjectsWithTag("sfish"))
        {

            sfishes.Add(sfish);

        }
        fishes = new List<GameObject>();
        foreach (GameObject fish in GameObject.FindGameObjectsWithTag("fish"))
        {
            fishes.Add(fish);

        }
        instance = this;
        ResetGame();

        
        ScoreManager();

    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            ResetGame();
        }
    }

    // Update is called once per frame


    void OnTriggerExit2D(Collider2D fish)
    {


        if (fish.gameObject.CompareTag("fish") || fish.gameObject.CompareTag("sfish"))
        {
            fish.GetComponent<FishMovement>().ChangeDirection();
        }
    }




    public void ResetGame()
    {
        timeLeft = MaxTimeLeft;
        Mermaid.transform.position = mermaidspawnpoint.position;
        Mermaid.SetActive(false);
        foreach (GameObject sfish in sfishes)
        {
            sfish.SetActive(false);
            sfish.GetComponent<FishMovement>().ResetPosition();
        }
        foreach (GameObject fish in fishes)
        {
            fish.SetActive(true);
            fish.GetComponent<FishMovement>().ResetPosition();

        }
        treasure.SetActive(true);
        player.transform.position = spawnpoint.position;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
        Lives -= 1;
        if (Lives == 0)
        {
                if (isProgressing)
                {
                    isProgressing = false;

                }
                else
                {
                Lives = 4;
                finalscore = score;
                    score = 0;
                }
                scoreText.text = "Score: " + score;
                Life3.SetActive(true);
                Life2.SetActive(true);
                Life1.SetActive(true);
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        player.GetComponent<PlayerController>().bubbler.Clear();
        if (Lives == 3)
        {
            Life3.SetActive(false);
        }
        if (Lives == 2)
        {
            Life2.SetActive(false);
        }
        if (Lives == 1)
        {
            Life1.SetActive(false);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score+= newScoreValue;
        ScoreManager ();
    }
   void ScoreManager()
    {
        scoreText.text = "Score: " + score;

    }
    public void TreasureDisable()
    {
        gameObject.SetActive(false);
    }
}



