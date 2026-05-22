using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ReminderDataList
{
    public List<ReminderData> reminders = new List<ReminderData>();
}

public static class ReminderStorage
{
    public static ReminderDataList Data = new ReminderDataList();

    private static string SavePath =>
        Path.Combine(Application.persistentDataPath, "reminders.json");

    public static void Load()
    {
        if (!File.Exists(SavePath))
        {
            Data = new ReminderDataList();
            return;
        }

        var json = File.ReadAllText(SavePath);
        Data = JsonUtility.FromJson<ReminderDataList>(json) ?? new ReminderDataList();
    }

    public static void Save()
    {
        var json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(SavePath, json);

        Debug.Log("Saved reminders to: " + SavePath);
    }

    public static void AddReminder(ReminderData reminder)
    {
        Load();
        Data.reminders.Add(reminder);
        Save();
    }

    public static void DeleteReminder(string id)
    {
        Load();
        Data.reminders.RemoveAll(r => r.id == id);
        Save();
    }
}