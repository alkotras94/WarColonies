using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UnitsCountUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textFreeUnits;
    [SerializeField] private Slider _sliderFood;
    [SerializeField] private Slider _sliderWood;
    [SerializeField] private Slider _sliderStone;

    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        _textFreeUnits.text = _player.FreeSquad.UnitList.Count.ToString();
    }
}
