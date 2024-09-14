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
        Debug.Log("Вошли в состояние сбора ресурсов");
        _managementTransition.Enter(hitData);
    }

    public override void Exit()
    {
        _managementTransition.Exit();
    }
}

