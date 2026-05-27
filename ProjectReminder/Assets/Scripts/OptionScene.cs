using UnityEngine;

public class OptionScene : MonoBehaviour
{
    private void SwitchScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void SwitchToHome()
    {
        SwitchScene("MainApp");
    }

    public void SwitchToSettings()
    {
        SwitchScene("Settings");
    }
    
    public void SwitchToProfile()
    {
        SwitchScene("Profile");
    }

    public void SwitchToAddReminder()
    {
        SwitchScene("NewReminder");
    }

}
