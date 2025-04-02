using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    private Movement _movement;
    private UnitStateMachine _stateMachine;

    public WaitingState(Movement movement, UnitStateMachine unitStateMachine)
    {
        _movement = movement;
        _stateMachine = unitStateMachine;
    }
    public override void Enter(Hit hitData)
    {
        Debug.Log("Unit send wait state");
        _movement.AddTarget(ServiceLocator.Instance.PointFreeWorkers.position);
    }

    public override void Exit()
    {
        Debug.Log("Exit Unit wait state");
    }
}
