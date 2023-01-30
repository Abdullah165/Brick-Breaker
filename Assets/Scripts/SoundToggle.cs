using UnityEngine.UI;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] Button soundToggle;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;

    Music music;

    private void Awake()
    {
        music = GameObject.FindObjectOfType<Music>();
        UpdateSoundIcon();
    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateSoundIcon();
    }

    void UpdateSoundIcon()
    {
        if (PlayerPrefs.GetInt("Muted") == 0)
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
