using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundEffectsMuteScript : MonoBehaviour
{
    public AudioSource[] soundEffects; // Array to store all sound effects

    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public Image buttonImage;

    private const string MuteKey = "MuteState";

    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt(MuteKey, 0) == 1;
        SetMuteState(isMuted);
    }

    public void ToggleMute()
    {
        bool isMuted = !soundEffects[0].mute; // Toggle based on the first sound effect
        SetMuteState(isMuted);
        PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SetMuteState(bool isMuted)
    {
        foreach (var soundEffect in soundEffects)
        {
            soundEffect.mute = isMuted;
        }
        buttonImage.sprite = isMuted ? muteSprite : unmuteSprite;
    }
}