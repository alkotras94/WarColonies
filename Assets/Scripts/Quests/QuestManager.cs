using UnityEngine;
using System.Collections.Generic;
using YG;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject questUIPrefab;
    public Transform questListParent;

    public List<QuestSO> activeQuests = new List<QuestSO>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadAllQuestsFromResources();
        CreateQuestUI();
    }

    void LoadAllQuestsFromResources()
    {
        QuestSO[] quests = Resources.LoadAll<QuestSO>("Quests");

        activeQuests.Clear();

        foreach (var quest in quests)
        {
            if (!quest.isCompleted)
                activeQuests.Add(quest);
        }

        // Сортируем квесты по приоритету
        activeQuests.Sort((a, b) => a.priority.CompareTo(b.priority));
    }

    void CreateQuestUI()
    {
        foreach (var quest in activeQuests)
        {
            GameObject obj = Instantiate(questUIPrefab, questListParent);
            QuestUIItem item = obj.GetComponent<QuestUIItem>();
            item.Setup(quest);
        }
    }

    public void AddProgress(QuestType type, int amount = 1)
    {
        foreach (var quest in activeQuests)
        {
            if (quest.questType == type && !quest.isCompleted)
            {
                quest.current += amount;
                quest.CheckComplete();
            }
        }
        YG2.SaveProgress();
        UpdateAllUI();
    }

    public void OnQuestCompleted(QuestSO quest)
    {
        // Выдача награды
        switch (quest.rewardType)
        {
            case RewardType.Gold:
                Debug.Log($"+{quest.rewardAmount} золота");
                break;
            case RewardType.Wood:
                Debug.Log($"+{quest.rewardAmount} дерева");
                break;
            case RewardType.Experience:
                Debug.Log($"+{quest.rewardAmount} опыта");
                break;
            case RewardType.Item:
                Debug.Log("Игрок получил предмет");
                break;
            case RewardType.Custom:
                Debug.Log("Вызов кастомной награды");
                break;
        }

        // Здесь можно вызвать дополнительные эффекты, например, проигрывание звука
        // AudioManager.Play("QuestComplete");
        // NotificationSystem.Show("Квест завершён!");

        // Помечаем квест как завершённый в системе
        quest.isCompleted = true;
        //SaveProgress(); // Если используется сохранение прогресса
    }

    void UpdateAllUI()
    {
        foreach (var item in questListParent.GetComponentsInChildren<QuestUIItem>())
        {
            item.UpdateUI();
        }
    }

    public void ClaimQuests()
    {
        QuestManager.instance.AddProgress(QuestType.CollectWood, 1);
    }
}
