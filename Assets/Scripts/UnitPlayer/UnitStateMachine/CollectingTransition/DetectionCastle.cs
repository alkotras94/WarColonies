using System;
using System.Collections;
using UnityEngine;

public class DetectionCastle : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _timePut;

    private Coroutine _coroutine;

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
        if (collision.gameObject.TryGetComponent(out Storage resours))
        {
            Debug.Log("Entered the castle");
            _coroutine = StartCoroutine(PutResours());
        }
    }

    private IEnumerator PutResours()
    {
        yield return new WaitForSeconds(_timePut);
        ExitTrigger?.Invoke();
    }
}
