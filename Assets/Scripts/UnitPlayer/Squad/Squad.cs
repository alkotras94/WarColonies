using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Squad
{
    public List<Unit> UnitList = new List<Unit>();
    public int CountUnit { get; private set; }

    public ResoursView ResoursView;
    private DetectionResourc _detectionResourc;

    public event Action NumberUpdated;

    public Squad(DetectionResourc detectionResourc)
    {
        _detectionResourc = detectionResourc;
    }
    public void Add(Unit unit)
    {
        UnitList.Add(unit);
        CountUnit = UnitList.Count;
        NumberUpdated?.Invoke();
    }

    public void Remove(Unit unit)
    {
        UnitList.Remove(unit);
        CountUnit = UnitList.Count;
        NumberUpdated?.Invoke();
    }

    public void SetRecorcePoint(ResoursView resoursView)
    {
        ResoursView = resoursView;
        SendUnitsCollect();    
    }

    public void SendUnitsCollect()
    {
        Hit hitData = new Hit(ResoursView.Position, ResoursView, null);
        for (int i = 0; i < UnitList.Count; i++)
        {
            UnitList[i].TransferStateMachine(hitData);
        }
    }


}

