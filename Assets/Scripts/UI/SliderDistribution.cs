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
    public int allUnits; // ��� ����� ��� �������������
    private int curUnits; // ������� �����

    [SerializeField] private TMP_Text unitsText; // ����� ������������ ������� ������

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // �������� �� �����

    void Start()
    {
        curUnits = allUnits; 

        foreach (var slider in sliders) // ������ ���� ��������� ����. ��������, ��������� � ����������
        {
            slider.slider.maxValue = slider.sliderMaxValue;
        }
    }

    void Update()
    {
        unitsText.text = curUnits.ToString(); //���������� ���������� ������
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
    }

    public void RecalculateUnits()
    {
        int sum = 0; // ����� �������� ���� ���������

        foreach(var slider in sliders)
        {
            sum += slider.oldValue;
        }

        curUnits = allUnits - sum;
    }
    
}
