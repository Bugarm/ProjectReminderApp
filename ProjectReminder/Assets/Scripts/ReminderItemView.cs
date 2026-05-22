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

    private ReminderData _reminder;
    private ReminderListController _listController;

    public void Setup(ReminderData data, ReminderListController controller)
    {
        _reminder = data;
        _listController = controller;

        nameText.text = _reminder.name; // Reminder name is required
        memoText.text = string.IsNullOrWhiteSpace(_reminder.memo)
            ? "No memo set" : _reminder.memo;
        dateText.text = string.IsNullOrWhiteSpace(_reminder.date) || !_reminder.timeSet
            ? "No date set" : _reminder.date;
        timeText.text = string.IsNullOrWhiteSpace(_reminder.time) || !_reminder.timeSet
            ? "No time set" : _reminder.time;
        
        completedToggle.isOn = _reminder.completed;
        
        completedToggle.onValueChanged.RemoveAllListeners();
        completedToggle.onValueChanged.AddListener(OnToggleChanged);
        
        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(OnDeleteClicked);

        if (!_reminder.timeSet)
        {
            dontRepeatGo.SetActive(false);
            ringOnceGo.SetActive(false);
            return;
        }
        
        dontRepeatImage.sprite = _reminder.dontRepeat ? dontRepeatSprite : repeatSprite;
        ringOnceImage.sprite = _reminder.ringOnce ? ringOnceSprite : ringSprite;
    }

    private void OnToggleChanged(bool value)
    {
        _reminder.completed = value;
        ReminderStorage.Save();
    }

    private void OnDeleteClicked()
    {
        _listController.DeleteReminder(_reminder.id);
    }
}
