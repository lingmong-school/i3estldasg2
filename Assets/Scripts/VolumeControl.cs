using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Set the slider's value to the current volume
        volumeSlider.value = AudioListener.volume;

        // Add listener for when the value of the slider changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Method to set the volume based on the slider value
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}