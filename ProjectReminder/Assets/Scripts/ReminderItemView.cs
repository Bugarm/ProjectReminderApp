using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReminderItemView : MonoBehaviour
{
    [Header("Toggle")]
    [SerializeField] private Toggle completedToggle;
    [Header("Text")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text memoText;
    [SerializeField] private TMP_Text dateText;
    [SerializeField] private TMP_Text timeText;
    [Header("Game Objects")]
    [SerializeField] private GameObject dontRepeatGo;
    [SerializeField] private GameObject ringOnceGo;
    [Header("Images")]
    [SerializeField] private Image dontRepeatImage;
    [SerializeField] private Sprite repeatSprite;
    [SerializeField] private Sprite dontRepeatSprite;
    [SerializeField] private Image ringOnceImage;
    [SerializeField] private Sprite ringSprite;
    [SerializeField] private Sprite ringOnceSprite;
    [Header("Buttons")]
    [SerializeField] private Button deleteButton;

    private ReminderData reminder;
    private ReminderListController listController;

    public void Setup(ReminderData data, ReminderListController controller)
    {
        reminder = data;
        listController = controller;

        nameText.text = reminder.name; // Reminder name is required
        memoText.text = string.IsNullOrWhiteSpace(reminder.memo)
            ? "No memo set" : reminder.memo;
        dateText.text = string.IsNullOrWhiteSpace(reminder.date) || !reminder.timeSet
            ? "No date set" : reminder.date;
        timeText.text = string.IsNullOrWhiteSpace(reminder.time) || !reminder.timeSet
            ? "No time set" : reminder.time;
        
        completedToggle.isOn = reminder.completed;
        
        completedToggle.onValueChanged.RemoveAllListeners();
        completedToggle.onValueChanged.AddListener(OnToggleChanged);
        
        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(OnDeleteClicked);

        if (!reminder.timeSet)
        {
            dontRepeatGo.SetActive(false);
            ringOnceGo.SetActive(false);
            return;
        }
        
        dontRepeatImage.sprite = reminder.dontRepeat ? dontRepeatSprite : repeatSprite;
        ringOnceImage.sprite = reminder.ringOnce ? ringOnceSprite : ringSprite;
    }

    private void OnToggleChanged(bool value)
    {
        reminder.completed = value;
        ReminderStorage.Save();
    }

    private void OnDeleteClicked()
    {
        listController.DeleteReminder(reminder.id);
    }
}
