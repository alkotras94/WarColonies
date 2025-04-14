using UnityEngine;

public enum QuestType
{
    CollectWood,
    CollectStone,
    CollectFood,
    KillEnemies,
    UpgradeCastle,
    // Добавь другие типы по мере необходимости
}

public enum RewardType
{
    Gold,
    Wood,
    Stone,
    Experience,
    Item,
    Custom
}

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class QuestSO : ScriptableObject
{
    public string questName;
    public string description;
    public QuestType questType;
    public int goal;
    public int priority = 0;
    public int current;
    public bool isCompleted;

    [Header("Reward")]
    public RewardType rewardType;
    public int rewardAmount;

    public void CheckComplete()
    {
        if (current >= goal && !isCompleted)
        {
            isCompleted = true;
            QuestManager.instance?.OnQuestCompleted(this); // Автоматический вызов
        }
    }
}
