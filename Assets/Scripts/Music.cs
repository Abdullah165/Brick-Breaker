using UnityEngine;

public class Music : MonoBehaviour
{
   private static Music Instance { get; set; }

    private const string MUTE = "Muted";


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(MUTE) == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt(MUTE) == 0)
        {
            PlayerPrefs.SetInt(MUTE, 1);
        }
        else
        {
            PlayerPrefs.SetInt(MUTE, 0);
        }
    }

    public string GetMute()
    {
        return MUTE;
    }

    public static Music Get()
    {
        return Instance;
    }
}
