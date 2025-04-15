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
            //quests == null || quests.Count == 0)

            if (activeQuests.Count > quests.Count )
            {

                    for (int i = quests.Count; i < activeQuests.Count; i++)
                    {
                        quests.Add(new QuestData
                        {
                            questName = activeQuests[i].questName,
                            current = activeQuests[i].current,
                            isCompleted = activeQuests[i].isCompleted
                        });
                    }


                Debug.Log($"Данные квестов добавлены");
                YG2.SaveProgress();
            }
            else
            {
                LoadQuestData(activeQuests);
                Debug.Log("Квесты уже есть");
            }

        }

        public void SaveQuestData(List<QuestSO> activeQuests)
        {
            for (int i = 0; i < quests.Count; i++)
            {

                quests[i].questName = activeQuests[i].questName;
                quests[i].current = activeQuests[i].current;
                quests[i].isCompleted = activeQuests[i].isCompleted;
                quests[i].isRewardIssued = activeQuests[i].isRewardIssued;
            }
            Debug.Log($"Данные квестов сохранены");
        }

        public void LoadQuestData(List<QuestSO> activeQuests)
        {
            for (int i = 0; i < quests.Count; i++)
            {

                activeQuests[i].questName = quests[i].questName;
                activeQuests[i].current = quests[i].current;
                activeQuests[i].isCompleted = quests[i].isCompleted;
                activeQuests[i].isRewardIssued = quests[i].isRewardIssued;
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
        public bool isRewardIssued;
    }
}
