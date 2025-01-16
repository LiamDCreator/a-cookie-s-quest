using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundEffectsMuteScript : MonoBehaviour
{
    // Start is called before the first frame update

      public AudioSource playerDiesSoundeffect;
    public AudioSource pointSoundEffectt;
    public AudioSource changeDirectionSoundeffect;

    // References for the mute button sprites
    public Sprite muteSprite;
    public Sprite unmuteSprite;

    // Reference to the button's image component
    public Image buttonImage;

    private const string MuteKey = "MuteState";

    void Start()
    {
        // Load the saved mute state
        bool isMuted = PlayerPrefs.GetInt(MuteKey, 0) == 1;

        // Apply the mute state
        SetMuteState(isMuted);
    }

    public void ToggleMute()
    {
        // Toggle the mute state
        bool isMuted = !playerDiesSoundeffect.mute;

        // Apply the mute state
        SetMuteState(isMuted);

        // Save the new mute state
        PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SetMuteState(bool isMuted)
    {
        // Set the mute state for all sound effects
        playerDiesSoundeffect.mute = isMuted;
        pointSoundEffectt.mute = isMuted;
        changeDirectionSoundeffect.mute = isMuted;

        // Update the button's sprite based on the mute state
        buttonImage.sprite = isMuted ? muteSprite : unmuteSprite;
    }
}