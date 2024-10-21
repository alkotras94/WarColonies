using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Squad
{
    public List<Unit> UnitList = new List<Unit>();

    public void Add(Unit unit)
    {
        UnitList.Add(unit);
    }

    public void Remove(int value)
    {
        
    }

    public void Count()
    {
        
    }

    
}

