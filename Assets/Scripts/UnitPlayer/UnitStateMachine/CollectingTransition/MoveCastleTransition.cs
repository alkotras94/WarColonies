using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private Movement _movement;
    [SerializeField] private DetectionCastle _detectionCastle;

    [SerializeField] private PartManager _partManager;

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
        if (_detectionCastle != null && _detectionCastle.gameObject != null)
        {
            _detectionCastle.Disable();
            _detectionCastle.ExitTrigger -= OnExitTrigger;
        }

        _partManager.GetAxe();
    }

    public void OnExitTrigger()
    {
        _detectionCastle.ExitTrigger -= OnExitTrigger;
        _moveTransition.Enter(_hitData);
        _partManager.GetAxe();
    }

    public void Visit(ResoursView resoursView)
    {
        Debug.Log("Visit");
        Visit((dynamic)resoursView);
    }

    public void Visit(Wood wood)
    {
        Debug.Log("Visit Wood");
        _pointStorage = ServiceLocator.Instance.StoragePointWood;
        _partManager.GetWood();
        
    }

    public void Visit(Stone stone)
    {
        Debug.Log("Visit Stone");
        _pointStorage = ServiceLocator.Instance.StoragePointStone;
        _partManager.GetStone();
    }

    public void Visit(Food food)
    {
        Debug.Log("Visit food");
        _pointStorage = ServiceLocator.Instance.StoragePointFood;
        _partManager.GetFood();
    }
}
