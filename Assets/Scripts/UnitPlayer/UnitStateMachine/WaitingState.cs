using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State
{
    public override void Enter(Hit hitData)
    {
        Debug.Log("����� � ��������� ��������");
    }

    public override void Exit()
    {
        
    }
}
