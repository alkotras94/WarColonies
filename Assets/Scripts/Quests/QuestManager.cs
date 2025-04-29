using UnityEngine;
using System.Collections.Generic;
//using YG;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject questUIPrefab;
    public Transform questListParent;

    public List<QuestSO> activeQuests = new List<QuestSO>(); //Сюда методом DragAndDrop я переношу квесты

    public void Initialize()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        LoadAllQuests();
        CreateQuestUI();
        //YG2.saves.AddQuestData(activeQuests);
        UpdateAllUI();
    }

    private void LoadAllQuests()
    {
        GameProgress progress = SaveManager.LoadGameQuests();

        foreach (QuestSO quest in activeQuests)
        {
            QuestData saved = progress.activeQuests.Find(q => q.questName == quest.questName);

            if (saved != null)
            {
                quest.current = saved.currentProgress;
                quest.isCompleted = saved.isCompleted;
                quest.isRewardIssued = saved.isRewardIssued;
            }
            else
            {
                quest.current = 0;
                quest.isCompleted = false;
                quest.isRewardIssued = false;
            }
        }

        Debug.Log("Save path: " + Application.persistentDataPath);
    }

    void CreateQuestUI()
    {
        foreach (var quest in activeQuests)
        {
            if (quest.isRewardIssued == false)
            {
                GameObject obj = Instantiate(questUIPrefab, questListParent);
                QuestUIItem item = obj.GetComponent<QuestUIItem>();
                item.Setup(quest);
            }
            else
            {
                Debug.Log("Reward issued");
            }
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
        Save();
        UpdateAllUI();
    }

    public void Save()
    {
        GameProgress progress = new GameProgress();

        foreach (var quest in activeQuests)
        {
            progress.activeQuests.Add(new QuestData
            {
                questName = quest.questName,
                currentProgress = quest.current,
                isCompleted = quest.isCompleted,
                isRewardIssued = quest.isRewardIssued
            });
        }

        SaveManager.SaveGameQuests(progress);
    }

    public void SaveYG()
    {
        //YG2.saves.SaveQuestData(activeQuests);
        //YG2.SaveProgress();
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
        Save();
        UpdateAllUI();
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

    public void ResetSaveQuests()
    {
        SaveManager.ResetSaveQuests();
    }
}
