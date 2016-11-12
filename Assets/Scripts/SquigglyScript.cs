using UnityEngine;
using System.Collections;

public class SquigglyScript : MonoBehaviour {
    float elevation;
    public float peroid;
    public float amplitude;

    // Use this for initialization
    void Start () {
        elevation = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, 
            elevation + amplitude * Mathf.Sin (Time.time * ((2 * Mathf.PI)/peroid )));
     
	
	}
}
