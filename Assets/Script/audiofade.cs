using System;
using UnityEngine;

public class audiofade : MonoBehaviour
{
    private AudioSource audio;
    public float target;
    private float sign = 1;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Fade_to(float level)
    {
        target = level;
        if (target > audio.volume)
            sign = 1;
        else
        {
            sign = -1;
        }
    }

    private void Update()
    {
        if (Math.Abs(audio.volume - target) > 0.05)
            audio.volume += sign * Time.deltaTime;
    }
}
