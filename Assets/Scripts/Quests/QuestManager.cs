using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject questUIPrefab;
    public Transform questListParent;

    public List<QuestSO> questList = new List<QuestSO>(); // Список для хранения всех квестов

    private string saveFilePath;

    private void Awake()
    {
        instance = this;
        saveFilePath = Application.persistentDataPath + "/quests.json";
    }

    private void Start()
    {
        LoadProgress();  // Загружаем прогресс при старте игры
        CreateTestQuests(); // Создаем тестовые квесты
    }

    void CreateTestQuests()
    {
        // Добавляем квесты из списка, созданные через Unity Editor
        foreach (var questSO in questList)
        {
            // Отображаем квесты в UI
            GameObject obj = Instantiate(questUIPrefab, questListParent);
            QuestUIItem item = obj.GetComponent<QuestUIItem>();
            item.Setup(questSO);
        }
    }

    public void AddProgress(QuestType type, int amount = 1)
    {
        foreach (var quest in questList)
        {
            if (quest.questType == type && !quest.isCompleted)
            {
                quest.current += amount;
                quest.CheckComplete();
                SaveProgress(); // Сохраняем прогресс после изменения
            }
        }

        UpdateAllUI();
    }

    void SaveProgress()
    {
        // Сохраняем все квесты в JSON
        string json = JsonUtility.ToJson(new QuestList { quests = questList }, true);
        File.WriteAllText(saveFilePath, json);
    }

    void LoadProgress()
    {
        if (File.Exists(saveFilePath))
        {
            // Загружаем данные из JSON
            string json = File.ReadAllText(saveFilePath);
            QuestList loadedData = JsonUtility.FromJson<QuestList>(json);

            questList = loadedData.quests;

            foreach (var quest in questList)
            {
                GameObject obj = Instantiate(questUIPrefab, questListParent);
                QuestUIItem item = obj.GetComponent<QuestUIItem>();
                item.Setup(quest);
            }
        }
        else
        {
            Debug.Log("Сохранений не найдено.");
        }
    }

    void UpdateAllUI()
    {
        foreach (var item in questListParent.GetComponentsInChildren<QuestUIItem>())
        {
            item.UpdateUI();
        }
    }
}

[System.Serializable]
public class QuestList
{
    public List<QuestSO> quests;
}
