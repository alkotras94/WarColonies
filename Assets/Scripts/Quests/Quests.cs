public enum QuestType
{
    CollectWood,
    KillEnemies,
    UpgradeCastle
}

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public QuestType questType;
    public int goal;
    public int current;
    public bool isCompleted;

    public void CheckComplete()
    {
        if (current >= goal && !isCompleted)
        {
            isCompleted = true;
        }
    }
}
