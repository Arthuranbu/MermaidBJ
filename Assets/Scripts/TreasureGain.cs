﻿using UnityEngine;
using System.Collections;

public class TreasureGain : MonoBehaviour {
    public GameManager gameController;
    public int scoreValue;
    GameObject gameControllerObject;
    public GameObject Mermaid;
    void Awake()
    {
        gameControllerObject = GameObject.FindWithTag("background");
   
    }
    void Start()
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
    void OnTriggerStay2D(Collider2D other)
            {


        
        if (other.gameObject.tag == "Player")
        {
            Mermaid.SetActive(true);
            gameObject.SetActive(false);
            gameController.AddScore(scoreValue);
        }
       

    } 
}
