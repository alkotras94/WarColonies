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

        float progressPercent = (float)quest.current / quest.goal;
        progressBar.value = progressPercent;
        progressText.text = $"{quest.current}/{quest.goal}";

        rewardButton.interactable = quest.isCompleted;
        rewardButton.gameObject.SetActive(!quest.isCompleted); // скрываем кнопку после получения
    }

    private void ClaimReward()
    {
        if (quest == null || !quest.isCompleted) return;

        // Выдача награды (можно расширить)
        Debug.Log($"Квест '{quest.questName}' завершён! Награда выдана.");

        rewardButton.interactable = false;
        rewardButton.gameObject.SetActive(false);

        // Можно здесь проигрывать звук или вызывать уведомление
        // AudioManager.Play("QuestComplete");
        // NotificationSystem.Show("Квест завершён!");

        // Можно сбросить квест или отметить его навсегда завершённым
    }
}
