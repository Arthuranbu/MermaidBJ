using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {
    public  int direction = -1;
    public  const float leftLimit=-5.5f;
    public  const float rightLimit=5.5f;
    public float targetRangeSqr = 20;
    public float minRange = 2;
    public GameObject sfish;
    public float speed;
    public GameObject visuals;

    // Use this for initialization
    public void ResetPosition () {
        
        if (gameObject.tag == "sfish")
        {
            bool isLeft = Random.value < 0.5;
            transform.position = new Vector2(isLeft ? leftLimit - 4 : rightLimit + 4, transform.position.y);
            if ((isLeft && direction == -1) || (!isLeft && direction == 1 ))
            {
                ChangeDirection();
            }

        }
        else
        {
            transform.position = new Vector2(Random.Range(leftLimit, rightLimit), transform.position.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 rangeVector = GameManager.instance.player.transform.position - transform.position;

        
        if (rangeVector.sqrMagnitude < targetRangeSqr && Mathf.Abs(rangeVector.x) > minRange)
        {

            if (GameManager.instance.player.transform.position.x < transform.position.x && direction == 1)
            {
                ChangeDirection();
            }
            if (GameManager.instance.player.transform.position.x > transform.position.x && direction == -1)
            {
                ChangeDirection();
            }
        }
        
        transform.Translate(transform.right * direction * Time.deltaTime * speed);
        

    }
    //this flips the sprite to face opposite direction
    public void ChangeDirection()
    {
        direction *= -1;
        visuals.GetComponent<SpriteRenderer>().flipX = !visuals.GetComponent<SpriteRenderer>().flipX;
    }
    //trigger for when the fish collide with player to reset the game
    void OnTriggerStay2D (Collider2D other)
    {
        if  (other.tag == "Player")
        {
            GameManager.instance.ResetGame();
        }
    }

    public void KillFish()
    {
        gameObject.SetActive(false);
        sfish.SetActive(true);
        sfish.GetComponent<FishMovement>().ResetPosition();
    }

    
}
