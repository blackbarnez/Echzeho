using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public Slider theMusicSlider;
    public AudioSource theMusic;
    public Slider theSoundsSlider;
    public AudioSource theSoundB;
    public AudioSource theSoundD;



    void Update()
    {
        theMusic.volume = theMusicSlider.value;
        theSoundB.volume = theSoundsSlider.value;
        theSoundD.volume = theSoundsSlider.value;

    }

}
