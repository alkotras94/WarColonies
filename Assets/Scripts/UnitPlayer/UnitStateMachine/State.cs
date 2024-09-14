using UnityEngine;

public abstract class State 
{ 
    public abstract void Enter(Hit hitData);

    public abstract void Exit();

    protected bool TryConvert<T>(IHitble hit, out T concretHit) where T : class
    {
        concretHit = hit as T;

        return concretHit != null;
    }
}
