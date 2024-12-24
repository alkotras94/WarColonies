using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[Serializable]
public class SliderInstance
{
    public Slider slider; // ��� �������
    public TMP_Text sliderCountText; // ���-�� ������������ ��� ���������
    public int sliderMaxValue = 20; // ������������ �������� ��������
    [HideInInspector] public int oldValue = 0; // �������� �������� ����� ����������
}


public class SliderDistribution : MonoBehaviour
{
    public int TotalNumberUnits; //����� ���������� ������
    public int allUnits; // ��� ����� ��� �������������
    public int freeUnits; //��������� �����

    [SerializeField] private TMP_Text unitsFreeText; // ����� ������������ ��������� ������
    [SerializeField] private TMP_Text alUnitsText; // ����� ������������ ���� ������

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // �������� �� ����� � ��� �� 3

    private RedeploymentUnit _redeploymentUnit;

    private FreeSquad _freeSquad;
    private WoodSquad _woodSquad;
    private StoneSquad _stoneSquad;
    private FoodSquad _foodSquad;

    public int _saveFood;
    public int _saveWood;
    public int _saveStone;

    public void Initialize(FreeSquad freeSquad, WoodSquad woodSquad, StoneSquad stoneSquad, FoodSquad foodSquad )
    {
        _freeSquad = freeSquad;
        _woodSquad = woodSquad;
        _stoneSquad = stoneSquad;
        _foodSquad = foodSquad;

        _redeploymentUnit = new RedeploymentUnit();

        UpdateSlider();
    }

    public void UpdateSlider()
    {
        allUnits = TotalNumberUnits;
        freeUnits = _freeSquad.CountUnit;
        TotalNumberUnits = _freeSquad.CountUnit + _woodSquad.CountUnit + _stoneSquad.CountUnit + _foodSquad.CountUnit;

        foreach (var slider in sliders) // ������ ���� ��������� ����. ��������, ������ ����� ������
        {
            slider.slider.maxValue = TotalNumberUnits;
        }

        UpdateUI();
    }

    public void AssignUnits()
    {
        _redeploymentUnit.AddFreeList(_saveFood, sliders[0], _freeSquad, _foodSquad);
        _redeploymentUnit.AddFreeList(_saveWood, sliders[1], _freeSquad, _woodSquad);
        _redeploymentUnit.AddFreeList(_saveStone, sliders[2], _freeSquad, _stoneSquad);

        _redeploymentUnit.Recalculate(_saveFood, sliders[0], _freeSquad, _foodSquad);
        _saveFood = (int)sliders[0].slider.value;
        _redeploymentUnit.Recalculate(_saveWood, sliders[1], _freeSquad, _woodSquad);
        _saveWood = (int)sliders[1].slider.value;
        _redeploymentUnit.Recalculate(_saveStone, sliders[2], _freeSquad, _stoneSquad);
        _saveStone = (int)sliders[2].slider.value;

        UpdateUI();
        Debug.Log("��������� " + _freeSquad.CountUnit + " �� ��� " + _foodSquad.CountUnit + " �� ������ " + _woodSquad.CountUnit + " �� ������ " + _stoneSquad.CountUnit);
    }

    public void OnSliderChanged(int sliderID) // �������� ��� ��������� �������� � ��������� ��� ID � �������
    {
        if ((freeUnits + sliders[sliderID].oldValue) - (int)sliders[sliderID].slider.value >= 0) // �������� �� ������� ������ (��� ����� �������� ��������) ��� ����� ��������
        {
            sliders[sliderID].oldValue = (int)sliders[sliderID].slider.value;
        }
        else // ���� ��� ����� �������� �������� ����� ������ <0 - �������� ��������� � ���������� �������� ������ ��������
        {
            sliders[sliderID].slider.value = sliders[sliderID].oldValue;
        }
        RecalculateUnits();
        sliders[sliderID].sliderCountText.text = sliders[sliderID].slider.value.ToString(); // ����� �������� �������� ��������
        UpdateUI();
    }

    public void RecalculateUnits()
    {
        int sum = 0; // ����� �������� ���� ���������

        foreach(var slider in sliders)
        {
            sum += slider.oldValue;
        }

        freeUnits = allUnits - sum;
        UpdateUI();
    }

    private void UpdateUI()
    {
        unitsFreeText.text = "��������� " + freeUnits.ToString();
        alUnitsText.text = "����� ������� " + allUnits.ToString();
    }
}
