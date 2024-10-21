using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : IHitVisitor
{
    private Squad _squad;

    public SelectionHandler()
    {
        //_squad = new Squad();
    }

    public void SelectUnits(Collider2D[] collider2DArray)
    {
        List<Unit> units = new List<Unit>();

        foreach (Collider2D collider2D in collider2DArray)
            if (collider2D.TryGetComponent(out Unit unit))
                units.Add(unit);

       // _squad.Add(units);
    }

    public void Visit(IHitble hit, Vector2 target)
    {
        Visit((dynamic)hit, (dynamic)target);
    }

    public void Visit(Ground groundHit, Vector2 target)
    {
       // _squad.AddTarget(target);
    }

    public void Visit(ResoursView resourcesHit, Vector2 point)
    {
        //_squad.TransferUnit(resourcesHit,point);
    }
}

public interface IHitVisitor
{
    void Visit(IHitble hit, Vector2 target);
    void Visit(Ground groundHit, Vector2 target);
    void Visit(ResoursView resourcesHit, Vector2 target);
}