using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _selectedGameObject;
    [SerializeField] private UnitStateMachine _stateMachine;
    [SerializeField] private Movement _movement;
    [SerializeField] private ManagementTransition _managementTransition;

    private Health _health;

    public void Initialize(ResourcesFortrres resourcesFortrres, UnitData unitData)
    {
        _health = new Health(unitData.MaxHealth);
        _healthBar.Initialize(_health);
        Enable();
        _stateMachine.Initialize(_movement, _health);
        _managementTransition.Initialize(resourcesFortrres);
        Diselect();
    }

    private void Enable() => _healthBar.Enable();

    private void OnDisable() => _healthBar.Disable();

    public void Select() => _selectedGameObject.SetActive(true);

    public void Diselect() => _selectedGameObject.SetActive(false);

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
