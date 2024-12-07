using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Squad
{
    public List<Unit> UnitList = new List<Unit>();
    public int CountUnit { get; private set; }

    public event Action NumberUpdated;

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
}

