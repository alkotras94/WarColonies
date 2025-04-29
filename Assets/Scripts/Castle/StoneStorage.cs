using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using YG;

public class StoneStorage : Storage, IHitble
{
    private StoneModel _stoneModel;
    [SerializeField] private TMP_Text _uiCountResourc;

    public void Initialize()
    {
        _stoneModel = new StoneModel(0);
        _stoneModel.Changed += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _uiCountResourc.text = _stoneModel.Resours.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("The trigger of the stone warehouse");
        if (collision.gameObject.TryGetComponent(out PartStone stone))
        {
            _stoneModel.Add(1);
            QuestManager.instance.AddProgress(QuestType.CollectStone, 1);
            //YG2.saves.Stone += 1;
            //YG2.SaveProgress();
        }
    }
}
