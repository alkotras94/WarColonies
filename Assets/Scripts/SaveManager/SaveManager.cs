using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YG;

//Сохраняет только данные квестов
[System.Serializable]
public class GameProgress
{
    public List<QuestData> activeQuests = new List<QuestData>();
}

[System.Serializable]
public class QuestData
{
    public string questName;
    public int currentProgress;
    public bool isCompleted;
    public bool isRewardIssued;
    public int rewardAmount;
}

public static class SaveManager
{
    private const string SaveFileName = "saveQuest.json";

    private static string pathSaveQuests => Path.Combine(Application.persistentDataPath, SaveFileName);

    public static void SaveGameQuests(GameProgress progress)
    {
        string json = JsonUtility.ToJson(progress, true);
        File.WriteAllText(pathSaveQuests, json);
    }

    public static GameProgress LoadGameQuests()
    {
        if (File.Exists(pathSaveQuests))
        {
            string json = File.ReadAllText(pathSaveQuests);
            return JsonUtility.FromJson<GameProgress>(json);
        }
        else
        {
            return new GameProgress(); // Возвращаем пустое сохранение
        }
    }

    public static void ResetSaveQuests()
    {
        if (File.Exists(pathSaveQuests))
        {
            File.Delete(pathSaveQuests);
            Debug.Log("Сохранения сброшены.");
        }
        else
        {
            Debug.Log("Файл сохранений не найден.");
        }
    }
}
