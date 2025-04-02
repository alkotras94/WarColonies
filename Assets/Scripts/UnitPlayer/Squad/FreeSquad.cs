using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSquad : Squad
{
    //private CircleShape _circleShape = new CircleShape(); //���������� � ����
    public FreeSquad(DetectionResourc detectionResourc) : base(detectionResourc)
    {
    }

    /*public void AddTarget(Vector2 point)
    {
        List<Vector2> points = SetPoinDirection(point);

        for (int i = 0; i < UnitList.Count; i++)
        {
            UnitList[i].AddHit(points[i]);
        }
    }*/

    /*private List<Vector2> SetPoinDirection(Vector2 point)
    {
        List<Vector2> points = _circleShape.GetPositionListAround(point, UnitList.Count);

        return points;
    }*/
}
