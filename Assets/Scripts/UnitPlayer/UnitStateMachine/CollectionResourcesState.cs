using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionResourcesState : State
{
    private ManagementTransition _managementTransition;

    public CollectionResourcesState(ManagementTransition managementTransition)
    {
        _managementTransition = managementTransition;
    }
    public override void Enter(Hit hitData)
    {
        Debug.Log("The unit entered the resource gathering state.");
        _managementTransition.Enter(hitData);
    }

    public override void Exit()
    {
        _managementTransition.Exit();
    }
}

