using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] GameObject Settings;

    public void openSettingWindow()
    {
        Settings.SetActive(true);
    }
    public void closeSettingWindow()
    {
        Settings.SetActive(false);
    }
}
