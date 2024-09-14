using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private CollectTransition _collectTransition;
    [SerializeField] private Movement _movement;
    [SerializeField] private DetectionMove _detectionMove;

    private Hit _hitData;

    public override void Enter(Hit hitData)
    {
        _detectionMove.Enable();
        _hitData = hitData;
        _movement.AddTarget(hitData.Target);
        _detectionMove.EnteredTrigger += OnEnteredTrigger;
    }

    public override void Exit()
    {
        _detectionMove.Disable();
    }

    private void OnEnteredTrigger(ResoursView resoursView)
    {
        if (_hitData.Resours == resoursView)
        {
            _collectTransition.Enter(_hitData);
            _movement.StopMovement();
            _detectionMove.EnteredTrigger -= OnEnteredTrigger;
        }
    }


}
