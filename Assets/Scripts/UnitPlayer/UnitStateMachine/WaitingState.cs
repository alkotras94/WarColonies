using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public override void Enter(Hit hitData)
    {
        Debug.Log("Вошли в состояние ожидания");
    }

    public override void Exit()
    {
        
    }
}
