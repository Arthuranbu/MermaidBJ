using UnityEngine;
using System.Collections;

public class HarpoonSound : MonoBehaviour {
    public AudioSource harpoonSound;
    public float soundDelay = .08f;
	// Use this for initialization
	void Start () {
        harpoonSound.time = soundDelay;
        harpoonSound.Play();
	}
    
	
	// Update is called once per frame
	void Update () {
	
	}
}
