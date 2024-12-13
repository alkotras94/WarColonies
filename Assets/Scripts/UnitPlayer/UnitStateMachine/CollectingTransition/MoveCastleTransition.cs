using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private Movement _movement;
    [SerializeField] private DetectionCastle _detectionCastle;

    private Transform _pointStorage;
    private Hit _hitData;
    private int _resours = 1;

    public void Initialize()
    {
        
    }
    public override void Enter(Hit hitData)
    {
        _hitData = hitData;
        _detectionCastle.Enable();
        Visit(hitData.Resours);
        _movement.AddTarget(_pointStorage.position);
        _detectionCastle.ExitTrigger += OnExitTrigger;
    }

    public override void Exit()
    {
        _detectionCastle.Disable();
    }

    public void OnExitTrigger()
    {
        _detectionCastle.ExitTrigger -= OnExitTrigger;
        _moveTransition.Enter(_hitData);
    }

    public void Visit(ResoursView resoursView)
    {
        Debug.Log("Визит");
        Visit((dynamic)resoursView);
    }

    public void Visit(Wood wood)
    {
        Debug.Log("Визит дерева");
        _pointStorage = ServiceLocator.Instance.StoragePointWood;
        
    }

    public void Visit(Stone stone)
    {
        Debug.Log("Визит камня");
        _pointStorage = ServiceLocator.Instance.StoragePointStone;
    }

    public void Visit(Food food)
    {
        Debug.Log("Визит еды");
        _pointStorage = ServiceLocator.Instance.StoragePointFood;
    }
}
