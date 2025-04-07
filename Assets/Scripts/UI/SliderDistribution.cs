using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[Serializable]
public class SliderInstance
{
    public Slider slider; // Slider
    public TMP_Text sliderCountText; // Count display under Slider
    public int sliderMaxValue = 20; // Max value Slider
    [HideInInspector] public int oldValue = 0; // Value Slider before the change
}


public class SliderDistribution : MonoBehaviour
{
    public int TotalNumberUnits; //Total count units
    public int allUnits; // All units to be distributed
    public int freeUnits; //Free units

    [SerializeField] private TMP_Text unitsFreeText; // Text showing free units
    [SerializeField] private TMP_Text alUnitsText; // Text showing all units

    [Header("Sliders")]
    [SerializeField]public SliderInstance[] sliders; // The sliders on the stage, we have 3 of them.

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

        foreach (var slider in sliders) // Set all sliders to the max. value of the total number of units
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

        _woodSquad.SendUnitsCollect();
        _stoneSquad.SendUnitsCollect();
        _foodSquad.SendUnitsCollect();

        UpdateUI();
        Debug.Log("Freebies " + _freeSquad.CountUnit + " For food " + _foodSquad.CountUnit + " Into the tree " + _woodSquad.CountUnit + " On the rock " + _stoneSquad.CountUnit);
    }

    public void OnSliderChanged(int sliderID) // Call when changing the slider and specify its ID in the array
    {
        if ((freeUnits + sliders[sliderID].oldValue) - (int)sliders[sliderID].slider.value >= 0) // Subtract its new value from the current units (not including the current slider)
        {
            sliders[sliderID].oldValue = (int)sliders[sliderID].slider.value;
        }
        else // If at the new slider value the sum of units <0 - cancel the change and return the slider to the old value
        {
            sliders[sliderID].slider.value = sliders[sliderID].oldValue;
        }
        RecalculateUnits();
        sliders[sliderID].sliderCountText.text = sliders[sliderID].slider.value.ToString(); // Set the value of the current slider
        UpdateUI();
    }

    public void RecalculateUnits()
    {
        int sum = 0; // Sum of values of all sliders

        foreach (var slider in sliders)
        {
            sum += slider.oldValue;
        }

        freeUnits = allUnits - sum;
        UpdateUI();
    }

    private void UpdateUI()
    {
        unitsFreeText.text = "Free Units " + freeUnits.ToString();
        alUnitsText.text = "Total count units " + allUnits.ToString();
    }
}
