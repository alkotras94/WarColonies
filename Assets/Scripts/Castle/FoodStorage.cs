using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;

public class FoodStorage : Storage
{
    private FoodModel _foodModel;
    [SerializeField] private TMP_Text _uiCountResourc;

    public void Initialize()
    {
        _foodModel = new FoodModel(YG2.saves.Food);
        _foodModel.Changed += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _uiCountResourc.text = _foodModel.Resours.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PartFood food))
        {
            _foodModel.Add(1);
            QuestManager.instance.AddProgress(QuestType.CollectFood, 1);
            YG2.saves.Food += 1;
            YG2.SaveProgress();
        }
    }
}
