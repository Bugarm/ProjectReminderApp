using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NewReminderController : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private TMP_InputField reminderNameInput;
    [SerializeField] private TMP_InputField memoInput;
    [SerializeField] private TMP_InputField dateInput;
    [SerializeField] private TMP_InputField timeInput;
    [SerializeField] private Toggle timeToggle;
    [SerializeField] private Toggle dontRepeatToggle;
    [SerializeField] private Toggle ringOnceToggle;

    [Header("Scene")]
    [SerializeField] private string remindersSceneName = "RemindersScenes";

    public void SubmitReminder()
    {
        if (string.IsNullOrWhiteSpace(reminderNameInput.text))
        {
            Debug.LogWarning("Reminder name is empty.");
            return;
        }

        var newReminder = new ReminderData
        {
            id = Guid.NewGuid().ToString(),
            name = reminderNameInput.text,
            memo = memoInput.text,
            date = dateInput.text,
            time = timeInput.text,
            timeSet = timeToggle != null && timeToggle.isOn,
            dontRepeat = timeToggle.isOn && dontRepeatToggle != null && dontRepeatToggle.isOn,
            ringOnce = timeToggle.isOn && ringOnceToggle != null && ringOnceToggle.isOn,
            completed = false
        };

        ReminderStorage.AddReminder(newReminder);

        SceneManager.LoadScene(remindersSceneName);
    }
}