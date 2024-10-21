using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement), typeof(PlayerStateMachine), typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private PlayerStateMachine _stateMachine;
    private Movement _movement;
    private Health _health;
    private PlayerInput _playerInput;
    
    public FreeSquad FreeSquad { get; private set; }
    public WoodSquad WoodSquad { get; private set; }
    public StoneSquad StoneSquad  { get; private set; }
    public FoodSquad FoodSquad { get; private set; }

    private void Awake()
    {
        _stateMachine = GetComponent<PlayerStateMachine>();
        _movement = GetComponent<Movement>();
        _playerInput = GetComponent<PlayerInput>();
        Initialize();
    }
    public void Initialize()
    {
        _health = new Health(_playerData.Health);
        _stateMachine.Initialize(_movement, _health);
        _playerInput.Initialize(this);
        
        FreeSquad = new FreeSquad();
        WoodSquad = new WoodSquad();
        StoneSquad = new StoneSquad();
        FoodSquad = new FoodSquad();
    }

    public void TransferStateMachine(Hit hit)
    {
        _stateMachine.Move(hit);
    }

    public void AddFreeUnits(Unit unit)
    {
        FreeSquad.Add(unit);
    }
}
