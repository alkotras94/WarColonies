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
    public int allUnits; // Все юниты для распределения
    private int curUnits; // Текущие юниты

    [SerializeField] private TMP_Text unitsText; // Текст отображающий текущих юнитов

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // Слайдеры на сцене

    void Start()
    {
        curUnits = allUnits; 

        foreach (var slider in sliders) // Задаем всем слайдерам макс. значение, указанное в инспекторе
        {
            slider.slider.maxValue = slider.sliderMaxValue;
        }
    }

    void Update()
    {
        unitsText.text = curUnits.ToString(); //Показываем оставшихся юнитов
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
    }

    public void RecalculateUnits()
    {
        int sum = 0; // Сумма значений всех слайдеров

        foreach(var slider in sliders)
        {
            sum += slider.oldValue;
        }

        curUnits = allUnits - sum;
    }
    
}
