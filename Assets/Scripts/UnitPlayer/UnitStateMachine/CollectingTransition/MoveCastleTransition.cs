using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastleTransition : Transition
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private Movement _movement;
    [SerializeField] private DetectionCastle _detectionCastle;

    [SerializeField] private GameObject _partWood;
    [SerializeField] private GameObject _partStone;
    [SerializeField] private GameObject _partFood;
    [SerializeField] private GameObject _bow;

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
        OnExitTrigger();
    }

    public void OnExitTrigger()
    {
        _detectionCastle.ExitTrigger -= OnExitTrigger;
        _moveTransition.Enter(_hitData);
        _partFood.SetActive(false);
        _partStone.SetActive(false);
        _partWood.SetActive(false);
        _bow.SetActive(true);
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
        _bow.SetActive(false);
        _partWood.SetActive(true);
        
    }

    public void Visit(Stone stone)
    {
        Debug.Log("Visit Stone");
        _pointStorage = ServiceLocator.Instance.StoragePointStone;
        _bow.SetActive(false);
        _partStone.SetActive(true);
    }

    public void Visit(Food food)
    {
        Debug.Log("Visit food");
        _pointStorage = ServiceLocator.Instance.StoragePointFood;
        _bow.SetActive(false);
        _partFood.SetActive(true);
    }
}
