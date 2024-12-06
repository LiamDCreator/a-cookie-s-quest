using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class soundEffectsMuteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource playerDiesSoundeffect;
    public AudioSource pointSoundEffectt;
    public AudioSource changeDirectionSoundeffect;

    public void ToggleMute()
    {
        playerDiesSoundeffect.mute = !playerDiesSoundeffect.mute;
        pointSoundEffectt.mute = !pointSoundEffectt.mute;
        changeDirectionSoundeffect.mute = !changeDirectionSoundeffect.mute;
    }
}