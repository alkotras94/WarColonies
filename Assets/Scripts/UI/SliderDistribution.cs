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
    private int curUnits; // Текущие юниты

    [SerializeField] private TMP_Text unitsText; // Текст отображающий текущих юнитов

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // Слайдеры на сцене у нас их 3

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

        foreach (var slider in sliders) // Задаем всем слайдерам макс. значение, общего числа юнитов
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

        Debug.Log("Свободные " + _freeSquad.CountUnit + " На еду " + _foodSquad.CountUnit + " На дерево " + _woodSquad.CountUnit + " На камень " + _stoneSquad.CountUnit);
    }

    public void OnSliderChanged(int sliderID) // Вызываем при изменении слайдера и указываем его ID в массиве
    {
        if ((curUnits + sliders[sliderID].oldValue) - (int)sliders[sliderID].slider.value >= 0) // Вычитаем из текущих юнитов (без учёта текущего слайдера) его новое значение
        {
            sliders[sliderID].oldValue = (int)sliders[sliderID].slider.value;
        }
        else // Если при новом значении слайдера сумма юнитов <0 - отменяем изменение и возвращаем слайдеру старое значение
        {
            sliders[sliderID].slider.value = sliders[sliderID].oldValue;
        }
        RecalculateUnits();
        sliders[sliderID].sliderCountText.text = sliders[sliderID].slider.value.ToString(); // Задаём значение текущего слайдера
        unitsText.text = curUnits.ToString();
    }

    public void RecalculateUnits()
    {
        int sum = 0; // Сумма значений всех слайдеров

        foreach(var slider in sliders)
        {
            sum += slider.oldValue;
        }

        curUnits = allUnits - sum;
        unitsText.text = curUnits.ToString();
    }
    
}
