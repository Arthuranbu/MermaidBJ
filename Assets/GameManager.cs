using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform spawnpoint;
    public GameObject player;
    public List<GameObject> fishes;
    public List<GameObject> sfishes;
    // Use this for initialization
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


    }

    // Update is called once per frame
  

        void OnTriggerExit2D (Collider2D fish)
        {


            if (fish.gameObject.CompareTag("fish") || fish.gameObject.CompareTag("sfish"))
            {
                fish.GetComponent<FishMovement>().ChangeDirection();
            }
        }

    


     public void ResetGame ()
    {
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
        player.transform.position = spawnpoint.position;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
        
    }
}

        

