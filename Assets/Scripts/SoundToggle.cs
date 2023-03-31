using UnityEngine.UI;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] Button soundToggle;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;

    private void Start()
    {
        UpdateSoundIcon();
    }

    public void PauseMusic()
    {
        Music.Get().ToggleSound();
        UpdateSoundIcon();
    }

    void UpdateSoundIcon()
    {
        if (PlayerPrefs.GetInt(Music.Get().GetMute()) == 0)
        {
            soundToggle.GetComponent<Image>().sprite = soundOn;
            AudioListener.volume = 1;
        }
        else
        {
            soundToggle.GetComponent<Image>().sprite = soundOff;
            AudioListener.volume = 0;
        }
    }

}
