using UnityEngine;
using System;

[RequireComponent(typeof(Movement), typeof(UnitStateMachine))]
public class Unit : MonoBehaviour
{
    [SerializeField] private ManagementTransition _managementTransition;
    [SerializeField] private InitTransition _initTransition;

    private SliderDistribution _sliderDistribution;
    private UnitStateMachine _stateMachine;
    private Movement _movement;

    private Health _health;
    private Player _player;

    public void Initialize(UnitData unitData)
    {
        _movement = GetComponent<Movement>();
        _movement.Initialize();
        _health = new Health(unitData.MaxHealth);
        _stateMachine = GetComponent<UnitStateMachine>();
        _stateMachine.Initialize(_movement, _health, _managementTransition, _initTransition);
        Vector2 firstPoint = new Vector2(ServiceLocator.Instance.ReceptionFirstPoint.position.x, ServiceLocator.Instance.ReceptionFirstPoint.position.y);
        AddHit(firstPoint);
        _player = ServiceLocator.Instance.Player;
        _sliderDistribution = ServiceLocator.Instance.SliderDistribution;
    }

    public void AddHit(Vector2 target)
    {
        Hit hitData = new Hit(target, null, null);
        _stateMachine.Move(hitData);
    }

    public void TransferStateMachine(Hit hitData)
    {
        _stateMachine.CollectingResources(hitData);
    }

    public void AddFreeList() //��� �������� ����� ��������� ��� � List ��������� ������
    {
        _player.AddFreeUnits(this);
        _stateMachine.Wait();
        _sliderDistribution.UpdateSlider();
    }

    public void SendWaitingState()
    {
        _stateMachine.Wait();
    }
 
}
