using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionSquad : Squad
{
    public ReceptionSquad(DetectionResourc detectionResourc) : base(detectionResourc)
    {
    }

    public void CarryFoodReception()
    {
        if (UnitList.Count == 0)
        {
            Debug.Log("Not unit");
        }
        else
        {
            UnitList[0].CarryFoodReception();
            Debug.Log("Idle unit food");
        }
    }
}
