using System;

[Serializable]
public class ReminderData
{
    public string id;
    public string name;
    public string memo;
    public string date;
    public string time;
    public bool timeSet;
    public bool dontRepeat;
    public bool ringOnce;
    public bool completed;
}