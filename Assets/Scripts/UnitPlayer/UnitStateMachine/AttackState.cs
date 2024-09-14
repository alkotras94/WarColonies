using UnityEngine;
public class AttackState : State
{
    private Health _health;

    public AttackState(Health health)
    {
        _health = health;
    }

    public override void Enter(Hit hitData)
    {
       
    }

    public override void Exit()
    {
        
    }

}
