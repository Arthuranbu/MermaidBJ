using UnityEngine;
using System.Collections;

public class Mermaid : MonoBehaviour {

    public GameObject Treasure;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")

        {
            UnityEngine.Animation.Play("");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
