using UnityEngine;
using System.Collections;

public class Mermaid : MonoBehaviour {
    public string Level;
    Animator anim;
       IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(Level);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")

        {
  
            anim.Play("MermaidUp");
            StartCoroutine(Wait());
        }
    }
}
