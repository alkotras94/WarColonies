using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateNewUnitState : State
{
    private Movement _movement;
    private UnitStateMachine _stateMachine;
    private bool _hasFood;

    public CreateNewUnitState(Movement movement, UnitStateMachine stateMachine)
    {
        _movement = movement;
        _stateMachine = stateMachine;
    }

    public override void Enter(Hit hitData)
    {
        Debug.Log("Unit moving food in the reception area");
        
    }

    public override void Exit()
    {
        
    }

    IEnumerator CarryFoodLoop()
    {
        while (true)
        {
            // 1. Идём к еде
            // Идём за едой
            yield return WaitForPoint(() => _movement.AddTarget(ServiceLocator.Instance.StoragePointFood.position));

            // 2. Берём еду
            yield return new WaitForSeconds(2);
            _hasFood = true;
            Debug.Log("Picked up food!");

            // 3. Идём к точке доставки
            yield return WaitForPoint(() => _movement.AddTarget(ServiceLocator.Instance.ReceptionFirstPoint.position));

            // 4. Выгружаем
            yield return new WaitForSeconds(2);
            _hasFood = false;
            Debug.Log("Dropped food!");

            // 5. Повторяем
        }
    }

    private IEnumerator WaitForPoint(System.Action sendTarget)
    {
        bool arrived = false;
        System.Action onArrived = () => arrived = true;

        _movement.PointCame += onArrived;
        sendTarget.Invoke();

        yield return new WaitUntil(() => arrived);
        _movement.PointCame -= onArrived;
    }
}
