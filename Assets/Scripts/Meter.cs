using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Meter : MonoBehaviour {
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;
    public float inMax;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}
    private void HandleBar()
    {
        content.fillAmount = Map(GameManager.instance.timeLeft,0,inMax,0,1);
    }

    private float  Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //adjusting numbers to the fill amount
     }
}
