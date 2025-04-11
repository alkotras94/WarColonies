// QuestUIController.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIController : MonoBehaviour
{
    public GameObject questPanelUI;           // Панель с квестами
    public Button toggleButton;               // Кнопка показать/скрыть
    public TextMeshProUGUI toggleButtonText;  // Текст на кнопке

    private bool isVisible = false;

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleQuestUI);
        questPanelUI.SetActive(isVisible);
        UpdateButtonText();
    }

    public void ToggleQuestUI()
    {
        isVisible = !isVisible;
        questPanelUI.SetActive(isVisible);
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (toggleButtonText != null)
            toggleButtonText.text = isVisible ? "Скрыть квесты" : "Показать квесты";
    }
}

// UI prefab setup (описание)
// В Canvas:
// QuestPanelUI (GameObject)
// ├── Panel (с Image, layout и CanvasGroup, можно добавить заголовок)
// │   ├── TextMeshPro: "Квесты"
// │   ├── Button: "Закрыть" (вешается метод ToggleQuestUI)
// │   └── Scroll View (Unity UI → Scroll View prefab)
// │       └── Viewport
// │           └── Content (Vertical Layout Group, ContentSizeFitter)
// └── ToggleButton (UI Button где-то в углу экрана)
//     └── TextMeshProUGUI ("Показать квесты")

// Подключи компоненты:
// - QuestPanelUI → `questPanelUI`
// - ToggleButton → `toggleButton`
// - Текст внутри ToggleButton → `toggleButtonText`

// В QuestManager.cs
// Убедись, что questListParent указывает на Content в Scroll View
// Все квесты добавляются туда через Instantiate(questUIPrefab, questListParent)

// Теперь при нажатии на кнопку панель квестов будет показываться/скрываться, а список будет скроллиться!
