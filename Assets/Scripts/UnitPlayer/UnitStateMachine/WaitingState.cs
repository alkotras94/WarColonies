using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    private Movement _movement;
    private UnitStateMachine _stateMachine;
    private Transform _pointFreeWorkersPosition;

    public WaitingState(Movement movement, UnitStateMachine unitStateMachine)
    {
        _movement = movement;
        _stateMachine = unitStateMachine;
        _pointFreeWorkersPosition = ServiceLocator.Instance.PointFreeWorkers;
    }
    public override void Enter(Hit hitData)
    {
        if (_pointFreeWorkersPosition != null && _movement != null)
        {
            _movement.AddTarget(_pointFreeWorkersPosition.position);
        }
        else
        {
            Debug.Log("PointFreeWorkers position destroy");
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Unit wait state");
    }
}
