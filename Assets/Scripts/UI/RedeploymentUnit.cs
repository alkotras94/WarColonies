using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeploymentUnit
{
    public void AddFreeList(int saveUnit, SliderInstance slider, FreeSquad freeSquad, Squad squad)
    {
        if (saveUnit > slider.slider.value)
        {
            for (int i = 0; i < saveUnit - slider.slider.value; i++)
            {
                Unit unit = squad.UnitList[0];
                freeSquad.Add(unit);
                squad.Remove(unit);
            }
        }
    }

    public void Recalculate(int saveUnit, SliderInstance slider, FreeSquad freeSquad, Squad squad)
    {
        if (saveUnit < slider.slider.value)
        {
            for (int i = 0; i < slider.slider.value - saveUnit; i++)
            {
                Unit unit = freeSquad.UnitList[0];
                squad.Add(unit);
                freeSquad.Remove(unit);
            }
        }
    }
}
