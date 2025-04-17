using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement), typeof(PlayerStateMachine), typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private DetectionResourc _detectionResourc;
    private PlayerStateMachine _stateMachine;
    private Movement _movement;
    private Health _health;
    private PlayerInput _playerInput;
    private Camera _camera;

    [SerializeField] private SliderDistribution _sliderDistribution;
    public FreeSquad FreeSquad { get; private set; }
    public WoodSquad WoodSquad { get; private set; }
    public StoneSquad StoneSquad  { get; private set; }
    public FoodSquad FoodSquad { get; private set; }

    [SerializeField] private FoodStorage _foodStorage;
    [SerializeField] private StoneStorage _stoneStorage;
    [SerializeField] private WoodStorage _woodStorage;

    private void Awake()
    {
        _camera = Camera.main;
        _camera.GetComponent<CameraFollow>().Follow(gameObject);
        _stateMachine = GetComponent<PlayerStateMachine>();
        _movement = GetComponent<Movement>();
        _playerInput = GetComponent<PlayerInput>();
        Initialize();
    }
    public void Initialize()
    {
        _health = new Health(_playerData.Health);
        _stateMachine.Initialize(_movement, _health, this);
        _playerInput.Initialize(this);
        _movement.Initialize();

        FreeSquad = new FreeSquad(_detectionResourc);
        WoodSquad = new WoodSquad(_detectionResourc);
        StoneSquad = new StoneSquad(_detectionResourc);
        FoodSquad = new FoodSquad(_detectionResourc);

        _sliderDistribution.Initialize(FreeSquad, WoodSquad, StoneSquad, FoodSquad);
        _detectionResourc.Initialize(FreeSquad, WoodSquad, StoneSquad, FoodSquad, _stateMachine);

        _foodStorage.Initialize();
        _woodStorage.Initialize();
        _stoneStorage.Initialize();
    }

    public void TransferStateMachine(Hit hit)
    {
        _stateMachine.Move(hit);
    }

    public void AddFreeUnits(Unit unit)
    {
        //Vector2 vector = new Vector2(ServiceLocator.Instance.PointFreeWorkers.position.x, ServiceLocator.Instance.PointFreeWorkers.position.y);
        FreeSquad.Add(unit);
        //FreeSquad.AddTarget(vector);
        _sliderDistribution.UpdateSlider();
    }
}
