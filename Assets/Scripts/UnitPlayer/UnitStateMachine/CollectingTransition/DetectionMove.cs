using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMove : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    public Action<ResoursView> EnteredTrigger;

    private void Start()
    {
        _collider.enabled = false;
    }
    public void Enable()
    {
        _collider.enabled = true;
    }

    public void Disable()
    {
        if (_collider != null && _collider.gameObject != null)
        {
            _collider.enabled = false;
        }
        else
        {
            Debug.LogWarning("Attempting to disable a collider that has already been destroyed or not appropriated.");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ResoursView resours))
        {
            EnteredTrigger?.Invoke(resours);
        }
    }
}
