using UnityEngine;
using System.Collections;

public class HarpoonGun : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.right*(-1) * speed;
        

	}
    void OnTriggerStay2D(Collider2D other)
    {


        
        if (other.gameObject.tag == "fish" || other.gameObject.tag == "sfish")
        {
            other.gameObject.GetComponent<FishMovement>().KillFish();
        }
        if (other.gameObject.tag != "background")
        {
            Destroy(gameObject);
        }
       

    } 


}
