using UnityEngine;
using UnityEngine.UI;

public class MuteControl : MonoBehaviour
{
    public Toggle muteToggle;
    private float previousVolume;

    void Start()
    {
        // Initialize the toggle state based on the current volume
        muteToggle.isOn = AudioListener.volume == 0;

        // Add listener for when the toggle value changes
        muteToggle.onValueChanged.AddListener(delegate { ToggleMute(muteToggle.isOn); });
    }

    // Method to mute or unmute the audio
    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            previousVolume = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = previousVolume;
        }
    }
}
