using UnityEngine;
using UnityEditor;

public class QuestEditorWindow : EditorWindow
{
    private QuestSO currentQuest;

    [MenuItem("Tools/Quest Editor")]
    public static void OpenWindow()
    {
        GetWindow<QuestEditorWindow>("Quest Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Квестовый редактор", EditorStyles.boldLabel);
        GUILayout.Space(10);

        currentQuest = (QuestSO)EditorGUILayout.ObjectField("Выбранный квест", currentQuest, typeof(QuestSO), false);

        if (currentQuest != null)
        {
            DrawQuestEditor(currentQuest);

            GUILayout.Space(10);
            if (GUILayout.Button("Сохранить квест"))
            {
                EditorUtility.SetDirty(currentQuest);
                AssetDatabase.SaveAssets();
            }

            if (GUILayout.Button("Удалить квест"))
            {
                string path = AssetDatabase.GetAssetPath(currentQuest);
                AssetDatabase.DeleteAsset(path);
                currentQuest = null;
            }
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Создать новый квест"))
        {
            CreateNewQuest();
        }
    }

    void DrawQuestEditor(QuestSO quest)
    {
        quest.questName = EditorGUILayout.TextField("Название", quest.questName);
        quest.description = EditorGUILayout.TextField("Описание", quest.description);
        quest.questType = (QuestType)EditorGUILayout.EnumPopup("Тип квеста", quest.questType);
        quest.goal = EditorGUILayout.IntField("Цель", quest.goal);
        quest.current = EditorGUILayout.IntField("Прогресс", quest.current);
        quest.isCompleted = EditorGUILayout.Toggle("Завершён", quest.isCompleted);
    }

    void CreateNewQuest()
    {
        QuestSO newQuest = ScriptableObject.CreateInstance<QuestSO>();
        string path = EditorUtility.SaveFilePanelInProject("Сохранить новый квест", "New Quest", "asset", "Выбери место для сохранения");
        if (path.Length > 0)
        {
            AssetDatabase.CreateAsset(newQuest, path);
            AssetDatabase.SaveAssets();
            currentQuest = newQuest;
        }
    }
}
