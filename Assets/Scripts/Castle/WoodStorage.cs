using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using YG;

public class WoodStorage : Storage
{    private WoodModel _woodModel;
    [SerializeField] private TMP_Text _uiCountResourc;

    public void Initialize()
    {
        _woodModel = new WoodModel(0);
        _woodModel.Changed += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _uiCountResourc.text = _woodModel.Resours.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PartWood wood))
        {
            _woodModel.Add(1);
            QuestManager.instance.AddProgress(QuestType.CollectWood, 1);
            //YG2.saves.Wood += 1;
            //YG2.SaveProgress();
        }
    }}
