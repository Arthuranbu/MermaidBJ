using UnityEngine;
using Spine.Unity;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public ParticleSystem bubbler;
    private Rigidbody2D myRigidbody;
    public float braking = 1;
    public float accel   = 1;
    public bool lookingLeft = true;
    public SkeletonAnimation swimAnim;
    public GameObject harpoon;
    public Transform fireDistance; 

    public float idleAnimSpeed = 2;
    public float swimAnimSpeed = 4;

    // Use this for initialization
    void Start()
    {
        bubbler.simulationSpace = ParticleSystemSimulationSpace.World;
        bubbler.Play();
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update ()
    {
       if ( Input.GetButtonDown("fire"))
        {
            FireHarpoon();
        }
        var x = Input.GetAxisRaw("Horizontal") * 2.0f;
        var y = Input.GetAxisRaw("Vertical") * 2.5f;

        float xSpeed = x == 0 ? braking : accel;
        float ySpeed = y == 0 ? braking : accel;
        
            myRigidbody.velocity = new Vector3(
            Mathf.Lerp(myRigidbody.velocity.x, x, Time.deltaTime * xSpeed),
            Mathf.Lerp(myRigidbody.velocity.y, y, Time.deltaTime * ySpeed)
            );
        SpriteFlip();

        //if swimming
        if( x != 0 || y != 0)
        {
            swimAnim.timeScale = swimAnimSpeed;
        }
        else
        {
            swimAnim.timeScale = idleAnimSpeed;
        }

    }
	void SpriteFlip()
    {
        if (myRigidbody.velocity.x > 0 && lookingLeft == true)
        {
            lookingLeft = false;
            transform.localScale = Vector3.Reflect(transform.localScale, Vector3.right);
        }

        if (myRigidbody.velocity.x < 0 && lookingLeft == false)
        {
            lookingLeft = true;
            transform.localScale = Vector3.Reflect(transform.localScale, Vector3.right);
        }

        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "wall")
        {
            GameManager.instance.ResetGame();
        }
    }
    void FireHarpoon()
    {
        if (lookingLeft)
        {
            Instantiate(harpoon, fireDistance.position, Quaternion.Euler(0,0,0));
        }
        else
        {
            Instantiate(harpoon, fireDistance.position, Quaternion.Euler(0, 180, 0));
        }
        
    }




}
