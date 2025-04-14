using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIItem : MonoBehaviour
{
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI descriptionText;
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public Button rewardButton;

    private QuestSO quest;

    public void Setup(QuestSO questData)
    {
        quest = questData;
        rewardButton.onClick.AddListener(ClaimReward);
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (quest == null) return;

        questNameText.text = quest.questName;
        descriptionText.text = quest.description;

        // Обновление прогресса квеста
        float progressPercent = (float)quest.current / quest.goal;
        progressBar.value = progressPercent;
        progressText.text = $"{quest.current}/{quest.goal}";

        // Активируем кнопку, если квест завершён
        rewardButton.interactable = quest.isCompleted;
        // rewardButton.gameObject.SetActive(!quest.isCompleted); // Если нужно скрыть кнопку после получения награды
    }

    private void ClaimReward()
    {
        if (quest == null || !quest.isCompleted) return;

        // Выдача награды в зависимости от типа награды
        QuestManager.instance.OnQuestCompleted(quest); // Выдача награды

        // Отключаем кнопку награды, как только она была нажата
        rewardButton.interactable = false;
        gameObject.SetActive(false);  // Скрыть кнопку после получения награды

        // Здесь также можно добавить звуковые эффекты или анимации
        // AudioManager.Play("QuestComplete");
        // NotificationSystem.Show("Квест завершён!");
    }
}
