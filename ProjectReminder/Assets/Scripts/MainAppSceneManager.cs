using UnityEngine;

public class MainAppSceneManager : MonoBehaviour
{
    private void SwitchScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void SwitchToNewReminders()
    {
        SwitchScene("NewReminder");
    }

    public void SwitchToPremium()
    {
        SwitchScene("Premium");
    }

    public void SwitchToCustomizeMaple()
    {
        SwitchScene("CustomizeMaple2");
    }

    public void SwitchToGames()
    {
        SwitchScene("GameList");
    }

    public void SwitchToReminders()
    {
        SwitchScene("RemindersScenes");
    }
}
