using UnityEngine;

public class ReminderListController : MonoBehaviour
{
    [SerializeField] private Transform reminderContent;
    [SerializeField] private ReminderItemView reminderPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        LoadRemindersIntoUI();
    }

    private void LoadRemindersIntoUI()
    {
        ReminderStorage.Load();

        foreach (Transform child in reminderContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var reminder in ReminderStorage.Data.reminders)
        {
            var item = Instantiate(reminderPrefab, reminderContent);
            item.Setup(reminder, this);
        }
    }

    public void DeleteReminder(string id)
    {
        ReminderStorage.DeleteReminder(id);
        LoadRemindersIntoUI();
    }
}
