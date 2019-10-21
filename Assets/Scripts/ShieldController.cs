using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {


    public ParticleSystem shield, smallDrops, dropsDown, drops;
    public Light lighter;

    // Function responsible for switching on shield.
    public void Enable()
    {
        if(shield.isPlaying == false)
        {
            shield.Play();
            lighter.enabled = true;
        }
        if (smallDrops.isPlaying == false)
        {
            smallDrops.Play();
        }
        if (dropsDown.isPlaying == false)
        {
            dropsDown.Play();
        }
        if (drops.isPlaying == false)
        {
            drops.Play();
        }
    }

    // Function responsible for switching off shield.
    public void Disable()
    {
        if (shield.isPlaying == true)
        {
            shield.Stop();
            lighter.enabled = false;
        }
        if (smallDrops.isPlaying == true)
        {
            smallDrops.Stop();
        }
        if (dropsDown.isPlaying == true)
        {
            dropsDown.Stop();
        }
        if (drops.isPlaying == true)
        {
            drops.Stop();
        }
    }
    
}
