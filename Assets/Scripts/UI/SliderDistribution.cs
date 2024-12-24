using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[Serializable]
public class SliderInstance
{
    public Slider slider; // Сам слайдер
    public TMP_Text sliderCountText; // Кол-во отображаемое под слайдером
    public int sliderMaxValue = 20; // Максимальное значение слайдера
    [HideInInspector] public int oldValue = 0; // Значение слайдера перед изменением
}


public class SliderDistribution : MonoBehaviour
{
    public int TotalNumberUnits; //Общее количество юнитов
    public int allUnits; // Все юниты для распределения
    public int freeUnits; //Свободные юниты

    [SerializeField] private TMP_Text unitsFreeText; // Текст отображающий свободных юнитов
    [SerializeField] private TMP_Text alUnitsText; // Текст отображающий всех юнитов

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // Слайдеры на сцене у нас их 3

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

        foreach (var slider in sliders) // Задаем всем слайдерам макс. значение, общего числа юнитов
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
        Debug.Log("Свободные " + _freeSquad.CountUnit + " На еду " + _foodSquad.CountUnit + " На дерево " + _woodSquad.CountUnit + " На камень " + _stoneSquad.CountUnit);
    }

    public void OnSliderChanged(int sliderID) // Вызываем при изменении слайдера и указываем его ID в массиве
    {
        if ((freeUnits + sliders[sliderID].oldValue) - (int)sliders[sliderID].slider.value >= 0) // Вычитаем из текущих юнитов (без учёта текущего слайдера) его новое значение
        {
            sliders[sliderID].oldValue = (int)sliders[sliderID].slider.value;
        }
        else // Если при новом значении слайдера сумма юнитов <0 - отменяем изменение и возвращаем слайдеру старое значение
        {
            sliders[sliderID].slider.value = sliders[sliderID].oldValue;
        }
        RecalculateUnits();
        sliders[sliderID].sliderCountText.text = sliders[sliderID].slider.value.ToString(); // Задаём значение текущего слайдера
        UpdateUI();
    }

    public void RecalculateUnits()
    {
        int sum = 0; // Сумма значений всех слайдеров

        foreach(var slider in sliders)
        {
            sum += slider.oldValue;
        }

        freeUnits = allUnits - sum;
        UpdateUI();
    }

    private void UpdateUI()
    {
        unitsFreeText.text = "Свободные " + freeUnits.ToString();
        alUnitsText.text = "Всего рабочих " + allUnits.ToString();
    }
}
