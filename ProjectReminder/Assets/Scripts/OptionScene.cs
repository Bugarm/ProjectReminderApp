using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchScene(string sceneName)
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

    public void SwitchToAddReminder()
    {
        SwitchScene("NewReminder");
    }

}
