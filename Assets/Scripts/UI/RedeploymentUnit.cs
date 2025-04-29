using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeploymentUnit
{
    public void Redistribute(SliderInstance slider, FreeSquad freeSquad, Squad squad, ref int savedValue)
    {
        int currentValue = (int)slider.slider.value;
        int delta = currentValue - savedValue;

        if (delta > 0) // Нанимаем новых юнитов из FreeSquad
        {
            for (int i = 0; i < delta; i++)
            {
                if (freeSquad.UnitList.Count == 0) break;

                Unit unit = freeSquad.UnitList[0];
                squad.Add(unit);
                freeSquad.Remove(unit);
            }
        }
        else if (delta < 0) // Возвращаем юнитов обратно в FreeSquad
        {
            for (int i = 0; i < -delta; i++)
            {
                if (squad.UnitList.Count == 0) break;

                Unit unit = squad.UnitList[0];
                squad.Remove(unit);
                freeSquad.Add(unit);
                unit.SendWaitingState();
            }
        }

        savedValue = currentValue; // Обновляем сохраненное значение
    }


    /*public void AddFreeList(int saveUnit, SliderInstance slider, FreeSquad freeSquad, Squad squad)
    {
        if (saveUnit > slider.slider.value)
        {
            for (int i = 0; i < saveUnit - slider.slider.value; i++)
            {
                Unit unit = squad.UnitList[0];
                freeSquad.Add(unit);
                squad.Remove(unit);
                unit.SendWaitingState();
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
    }*/
}
