using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverDetector : MonoBehaviour
{
    [field: SerializeField] public int Time—onsumptionFoof { get; private set; } = 5;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private UnitStateMachine _stateMachine;


    private void Start()
    {
        Enable();
    }
    public void Enable()
    {
        _collider.enabled = true;
    }

    public void Disable()
    {
        _collider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ReceiverView resours))
        {
            _stateMachine.Init();
        }
    }
}
