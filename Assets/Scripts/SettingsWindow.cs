using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] GameObject Settings;

    public void openSettingWindow()
    {
        Time.timeScale = 0;
        Settings.SetActive(true);
    }
    public void closeSettingWindow()
    {
        Time.timeScale = 1;
        Settings.SetActive(false);
    }
}
