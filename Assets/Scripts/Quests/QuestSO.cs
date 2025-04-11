using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class QuestSO : ScriptableObject
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
