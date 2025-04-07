using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementTransition : MonoBehaviour
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private CollectTransition _collectTransition;
    [SerializeField] private MoveCastleTransition _moveCastleTransition;

    public void Initialize()
    {
        _moveCastleTransition.Initialize();
    }
    public void Enter(Hit hitData)
    {
        _moveTransition.Enter(hitData);
    }

    public void Exit()
    {
        if (_moveTransition != null)
        {
            _moveTransition.Exit();
        }
        if (_moveCastleTransition != null)
        {
            _moveCastleTransition.Exit();
        }
        if (_collectTransition != null)
        {
            _collectTransition.Exit();
        }
    }

}
