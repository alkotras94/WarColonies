using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using YG;

public class FoodStorage : Storage
{
    public FoodModel FoodModel { get; private set; }
    [SerializeField] private TMP_Text _uiCountResourc;

    public void Initialize()
    {
        FoodModel = new FoodModel(0);
        FoodModel.Changed += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _uiCountResourc.text = FoodModel.Resours.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PartFood food))
        {
            FoodModel.Add(1);
            QuestManager.instance.AddProgress(QuestType.CollectFood, 1);
            //YG2.saves.Food += 1;
            //YG2.SaveProgress();
        }
    }
}
