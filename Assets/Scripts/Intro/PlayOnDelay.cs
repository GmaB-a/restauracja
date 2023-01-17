using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnDelay : MonoBehaviour
{
    public AudioSource riser;

    // Update is called once per frame
    void Start()
    {
        riser.PlayDelayed(3);
        
    }

    public void StopPlaying()
    {
        riser.Pause();
    }

    public void StartPlaying()
    {
        riser.UnPause();
    }
}
