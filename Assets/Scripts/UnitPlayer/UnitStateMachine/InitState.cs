
using System.Collections;
using UnityEngine;

public class InitState : State
{
    private InitTransition _initTransition;

    public InitState(InitTransition initTransition)
    {
        _initTransition = initTransition;
    }
    public override void Enter(Hit hitData)
    {
        _initTransition.Enter();
    }

    public override void Exit()
    {
        _initTransition.Exit();
    }

}