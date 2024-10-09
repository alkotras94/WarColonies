using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Squad
{
    private List<Unit> _selectedUnitRtsList = new List<Unit>();
    private CircleShape _circleShape = new CircleShape();

    public void Add(IEnumerable<Unit> units)
    {
        if (units == null)
            throw new NullReferenceException();

        foreach (var unit in _selectedUnitRtsList)
        {
            //unit.Diselect();
        }

        //_selectedUnitRtsList.Clear();

        foreach (var unit in units)
        {
            if (units == null)
                throw new NullReferenceException();

            //unit.Select();
            _selectedUnitRtsList.Add(unit);
        }
    }

    public void AddTarget(Vector2 point)
    {
        List<Vector2> points = SetPoinDirection(point);

        for (int i = 0; i < _selectedUnitRtsList.Count; i++)
        {
            //_selectedUnitRtsList[i].AddHit(points[i]);
        }
    }

    public void TransferUnit(ResoursView resours,Vector2 point)
    {
        for (int i = 0; i < _selectedUnitRtsList.Count; i++)
        {
            Hit hitData = new Hit(point, resours);
            _selectedUnitRtsList[i].TransferStateMachine(hitData);
        }
    }

    private List<Vector2> SetPoinDirection(Vector2 point)
    {
        List<Vector2> points = _circleShape.GetPositionListAround(point, _selectedUnitRtsList.Count);

        return points;
    }
}

