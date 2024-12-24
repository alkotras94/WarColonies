using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoneStorage : Storage, IHitble
{
    private StoneModel _stoneModel;
    [SerializeField] private TMP_Text _uiCountResourc;

    public void Initialize()
    {
        _stoneModel = new StoneModel();
        _stoneModel.Changed += UpdateUI;
    }

    private void UpdateUI()
    {
        _uiCountResourc.text = _stoneModel.Resours.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Тригер склада камня");
        if (collision.gameObject.TryGetComponent(out PartStone stone))
        {
            Debug.Log("Аляндр");
            _stoneModel.Add(1);
        }
        else
        {
            Debug.Log("Не Аляндр");
        }
    }
}
