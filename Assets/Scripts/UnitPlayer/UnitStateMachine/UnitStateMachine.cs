using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    private List<State> _states;
    private State _currentState;

    public void Initialize(Movement movement, Health health, ManagementTransition managementTransition, InitTransition initTransition, PartManager partManager, FoodStorage foodStorage)
    {
        if (movement == null)
            throw new NullReferenceException();

        if(health == null)
            throw new NullReferenceException();

        _states = new List<State>()
        {
            new InitState(initTransition),
            new WaitingState(movement,this),
            new MoveState(movement, this),
            new CollectionResourcesState(managementTransition),
            new CreateNewUnitState(movement,this,partManager,foodStorage),
        };
    }

    public void Init()
    {
        ChangeState<InitState>(null);
    }
    public void Wait()
    {
        ChangeState<WaitingState>(null);
    }

    public void Move(Hit hitData)
    {
        ChangeState<MoveState>(hitData);
    }

    public void CollectingResources(Hit hitData)
    {
        ChangeState<CollectionResourcesState>(hitData);
    }

    public void CreateNewUnit()
    {
        ChangeState<CreateNewUnitState>(null);
    }

    private void ChangeState<T>(Hit hitData) where T : State
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }  

        _currentState = _states.FirstOrDefault(state => state is T);

        if (_currentState == null)
        {
            return;
        }
        _currentState.Enter(hitData);
    }

    public Coroutine StartStaticCoroutine(IEnumerator coroutine) //Запускает для нe Mono объектов
    {
        return StartCoroutine(coroutine);
    }

    public void StopStaticCoroutine(Coroutine coroutine) //Останавливает для нe Mono объектов
    {
        StopCoroutine(coroutine);
    }

}

