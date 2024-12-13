using System;
using UnityEngine;

public class DetectionCastle : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    public Action ExitTrigger;

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
        _collider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Storage resours))
        {
            Debug.Log("Зашел в замок");
            ExitTrigger?.Invoke();
        }
    }
}
