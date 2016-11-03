using UnityEngine;
using System.Collections;

public class LightRotation : MonoBehaviour
{

    public Transform target;
    private float distance;
    public float dropDistance =40;
    public float smooth;
    public float intensity;
    public float maxIntensity = 1.56f;
    private Light sunLightCharacters;
    void Start()
    {
        sunLightCharacters = GetComponent<Light>();
    }
    void Update()
    {
        distance = Mathf.Round(Vector3.Distance(transform.position, target.position));
        if (distance > dropDistance)
        {
            intensity = 0;
        }
        else
        {
            intensity = (1.0f - distance / dropDistance) * maxIntensity;
        }
        sunLightCharacters.intensity = Mathf.Lerp(sunLightCharacters.intensity, intensity, smooth * Time.deltaTime);
    }
}