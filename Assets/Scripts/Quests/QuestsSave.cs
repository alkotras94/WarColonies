using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public List<QuestData> quests = new List<QuestData>();

        public void AddQuestData(List<QuestSO> activeQuests)
        {
            // Заполняем список квестами
            foreach (var quest in activeQuests)
            {
                quests.Add(new QuestData
                {
                    questName = quest.questName,
                    current = quest.current,
                    isCompleted = quest.isCompleted
                });
            }

            Debug.Log($"Данные квестов сохранены");
        }

        public void SyncQuestDataWithDictionary(List<QuestData> target, List<QuestData> source)
        {
            // Преобразуем target в словарь для быстрого доступа по questName
            Dictionary<string, QuestData> targetDict = new Dictionary<string, QuestData>();
            foreach (var quest in target)
            {
                targetDict[quest.questName] = quest; // Если questName одинаковое, обновляем в словаре
            }

            foreach (var sourceItem in source)
            {
                if (targetDict.ContainsKey(sourceItem.questName))
                {
                    // Если квест уже есть в target, обновляем его
                    targetDict[sourceItem.questName].current = sourceItem.current;
                    targetDict[sourceItem.questName].isCompleted = sourceItem.isCompleted;
                }
                else
                {
                    // Если квеста нет в target, добавляем новый
                    targetDict.Add(sourceItem.questName, sourceItem);
                }
            }

            // Преобразуем словарь обратно в список
            target.Clear();
            target.AddRange(targetDict.Values);
        }


        public void LoadQuestData(List<QuestSO> activeQuests)
        {
                // Обновляем квесты на основе загруженных данных
                foreach (var questData in quests)
                {
                    QuestSO quest = activeQuests.Find(q => q.questName == questData.questName);
                    if (quest != null)
                    {
                        quest.current = questData.current;
                        quest.isCompleted = questData.isCompleted;
                    }
                }

                Debug.Log($"Данные квестов загружены");
        }
    }

    [System.Serializable]
    public class QuestData
    {
        public string questName;
        public int current;
        public bool isCompleted;
    }
}
