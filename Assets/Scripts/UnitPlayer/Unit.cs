using UnityEngine;

[RequireComponent(typeof(Movement), typeof(UnitStateMachine))]
public class Unit : MonoBehaviour
{
    [SerializeField] private ManagementTransition _managementTransition;
    [SerializeField] private InitTransition _initTransition;
    private UnitStateMachine _stateMachine;
    private Movement _movement;

    private Health _health;

    public void Initialize(UnitData unitData)
    {
        _health = new Health(unitData.MaxHealth);
        _stateMachine = GetComponent<UnitStateMachine>();
        _movement = GetComponent<Movement>();
        _stateMachine.Initialize(_movement, _health, _managementTransition, _initTransition);
        Vector2 firstPoint = new Vector2(ServiceLocator.Instance.ReceptionFirstPoint.position.x, ServiceLocator.Instance.ReceptionFirstPoint.position.y);
        AddHit(firstPoint);
    }

    public void AddHit(Vector2 target)
    {
        Hit hitData = new Hit(target, null);
        _stateMachine.Move(hitData);
    }

    public void TransferStateMachine(Hit hitData)
    {
        _stateMachine.CollectingResources(hitData);
    }
 
}
