using UnityEngine;
using System.Collections;

public class FinalScore : MonoBehaviour {
    public GUIText scoreText;
    public static int score;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<GUIText>();

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per fraem
	void Update () {
        scoreText.text = "Final Score: " + score;
	}
}
