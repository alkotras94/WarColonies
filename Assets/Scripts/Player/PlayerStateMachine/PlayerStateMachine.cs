using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlayerStateMachine : MonoBehaviour
{
    private List<PlayerState> _states;
    private PlayerState _currentState;

    public void Initialize(Movement movement, Health health, Player player)
    {
        if (movement == null)
            throw new NullReferenceException();

        if (health == null)
            throw new NullReferenceException();

        _states = new List<PlayerState>()
        {
            new WaitPlayerState(),
            new MovePlayerState(movement, this),
            new ColectingPlayerState(player)
        };
    }

    public void Wait()
    {
        ChangeState<WaitPlayerState>(null);
    }

    public void Move(Hit hitData)
    {
        ChangeState<MovePlayerState>(hitData);
    }

    public void CollectingResources(Hit hitData)
    {
        ChangeState<ColectingPlayerState>(hitData);
    }

    private void ChangeState<T>(Hit hitData) where T : PlayerState
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter(hitData);
    }
}
