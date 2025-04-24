using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    [Header("Вкладки (CanvasGroup)")]
    public CanvasGroup[] tabs;

    [Header("Кнопки вкладок")]
    public Button[] tabButtons;

    [Header("Цвета кнопок")]
    public Color activeColor = Color.white;
    public Color inactiveColor = Color.gray;

    private int currentTab = 0;

    void Start()
    {
        ShowTab(currentTab);
    }

    public void ShowTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            bool isActive = (i == index);
            SetTabState(tabs[i], isActive);
        }

        for (int i = 0; i < tabButtons.Length; i++)
        {
            Image img = tabButtons[i].GetComponent<Image>();
            if (img != null)
            {
                img.color = (i == index) ? activeColor : inactiveColor;
            }
        }


        currentTab = index;
    }

    private void SetTabState(CanvasGroup group, bool visible)
    {
        group.alpha = visible ? 1f : 0f;
        group.interactable = visible;
        group.blocksRaycasts = visible;
    }
}
