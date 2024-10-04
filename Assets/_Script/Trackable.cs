using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trackable : DefaultObserverEventHandler
{
    public AudioSource suaraVoiceOver;
    void Awake()
    {
        suaraVoiceOver = GetComponent<AudioSource>();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        suaraVoiceOver.Play();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        suaraVoiceOver.Stop();
    }
}