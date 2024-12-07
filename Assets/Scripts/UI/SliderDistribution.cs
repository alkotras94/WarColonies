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
    private int curUnits; // ������� �����

    [SerializeField] private TMP_Text unitsText; // ����� ������������ ������� ������

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // �������� �� ����� � ��� �� 3

    private RedeploymentUnit _redeploymentUnit;

    private FreeSquad _freeSquad;
    private WoodSquad _woodSquad;
    private StoneSquad _stoneSquad;
    private FoodSquad _foodSquad;

    private int _saveFood;
    private int _saveWood;
    private int _saveStone;

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
        allUnits = _freeSquad.CountUnit;
        curUnits = allUnits;
        TotalNumberUnits = _freeSquad.CountUnit + _woodSquad.CountUnit + _stoneSquad.CountUnit + _foodSquad.CountUnit;

        foreach (var slider in sliders) // ������ ���� ��������� ����. ��������, ������ ����� ������
        {
            slider.slider.maxValue = TotalNumberUnits;
        }

        unitsText.text = curUnits.ToString();
    }

    public void AssignUnits()
    {
        _redeploymentUnit.Recalculate(_saveFood, sliders[0], _freeSquad, _foodSquad);
        _saveFood = (int)sliders[0].slider.value;
        _redeploymentUnit.Recalculate(_saveWood, sliders[1], _freeSquad, _woodSquad);
        _saveWood = (int)sliders[1].slider.value;
        _redeploymentUnit.Recalculate(_saveStone, sliders[2], _freeSquad, _stoneSquad);
        _saveStone = (int)sliders[2].slider.value;

        Debug.Log("��������� " + _freeSquad.CountUnit + " �� ��� " + _foodSquad.CountUnit + " �� ������ " + _woodSquad.CountUnit + " �� ������ " + _stoneSquad.CountUnit);
    }

    public void OnSliderChanged(int sliderID) // �������� ��� ��������� �������� � ��������� ��� ID � �������
    {
        if ((curUnits + sliders[sliderID].oldValue) - (int)sliders[sliderID].slider.value >= 0) // �������� �� ������� ������ (��� ����� �������� ��������) ��� ����� ��������
        {
            sliders[sliderID].oldValue = (int)sliders[sliderID].slider.value;
        }
        else // ���� ��� ����� �������� �������� ����� ������ <0 - �������� ��������� � ���������� �������� ������ ��������
        {
            sliders[sliderID].slider.value = sliders[sliderID].oldValue;
        }
        RecalculateUnits();
        sliders[sliderID].sliderCountText.text = sliders[sliderID].slider.value.ToString(); // ����� �������� �������� ��������
        unitsText.text = curUnits.ToString();
    }

    public void RecalculateUnits()
    {
        int sum = 0; // ����� �������� ���� ���������

        foreach(var slider in sliders)
        {
            sum += slider.oldValue;
        }

        curUnits = allUnits - sum;
        unitsText.text = curUnits.ToString();
    }
    
}
