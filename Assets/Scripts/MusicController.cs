using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    [Header("Information")]
    public AudioSource audio_Music;
    public AudioMixer audio_Mixer;
    public AudioLowPassFilter audio_LowPass;
    public float audio_LowFadeMultiplier = 150;

    [Header("Player Information")]
    public Transform player_Transform;


    void Start () {
        player_Transform = GameObject.FindGameObjectWithTag("Player").transform;
	}


	void Update () {
        audio_LowPass.cutoffFrequency = 10000 - (player_Transform.position.y * -audio_LowFadeMultiplier);

        if (audio_LowPass.cutoffFrequency > 10000)
        {
            audio_LowPass.cutoffFrequency = 10000;
        }
	}
}
