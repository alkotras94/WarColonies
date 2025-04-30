using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateNewUnitState : State
{
    private Movement _movement;
    private UnitStateMachine _stateMachine;
    private bool _hasFood;
    private Coroutine _coroutine;
    private PartManager _partManager;
    private FoodStorage _foodStorage;

    public CreateNewUnitState(Movement movement, UnitStateMachine stateMachine, PartManager partManager, FoodStorage foodStorage)
    {
        _movement = movement;
        _stateMachine = stateMachine;
        _partManager = partManager;
        _foodStorage = foodStorage;
    }

    public override void Enter(Hit hitData)
    {
        Debug.Log("Unit moving food in the reception area");
        _coroutine = _stateMachine.StartStaticCoroutine(CarryFoodLoop());
    }

    public override void Exit()
    {
        if (_coroutine != null)
        {
            _stateMachine.StopStaticCoroutine(_coroutine);
        }
        _partManager.GetAxe();
    }

    IEnumerator CarryFoodLoop()
    {
        while (_foodStorage.FoodModel.Resours > 0)
        {
            // 1. Идём к еде
            yield return WaitForPoint(() => _movement.AddTarget(ServiceLocator.Instance.StoragePointFood.position));

            // 2. Берём еду
            yield return new WaitForSeconds(2);
            _partManager.GetProcessedFood();
            _foodStorage.FoodModel.Spend(1);
            _hasFood = true;
            Debug.Log("Picked up food!");

            // 3. Идём к точке доставки
            yield return WaitForPoint(() => _movement.AddTarget(ServiceLocator.Instance.ReceptionFirstPoint.position));

            // 4. Выгружаем
            yield return new WaitForSeconds(2);
            _partManager.GetAxe();
            _hasFood = false;
            Debug.Log("Dropped food!");

            // 5. Повторяем
        }

        _stateMachine.Wait();
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
