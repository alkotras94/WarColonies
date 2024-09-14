using System;
using UnityEngine;
public class MoveState : State
{
    private Movement _movement;
    private UnitStateMachine _stateMachine;

    public MoveState(Movement movement, UnitStateMachine unitStateMachine)
    {
        _movement = movement;
        _stateMachine = unitStateMachine;
    }

    public override void Enter(Hit hitData)
    {
        Debug.Log("Вошли в состояние передвижения");
        _movement.AddTarget(hitData.Target);
        _movement.PointCame += OnPointCame;
    }

    public override void Exit()
    {
        _movement.PointCame -= OnPointCame;
    }

    private void OnPointCame()
    {
        _stateMachine.Wait();
    }
}
