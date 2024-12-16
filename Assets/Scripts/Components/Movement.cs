using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _distanceStop = 0.5f;

    private Coroutine _coroutine;
    private Rotation _rotation;

    public event Action PointCame;

    public void Initialize()
    {
        _rotation = new Rotation(transform);
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void AddTarget(Vector2 target)
    {
        _agent.isStopped = false;
        _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        _coroutine = StartCoroutine(CalculateDistance(target));
        _rotation.Rotate(target);
    }
    public void StopMovement()
    {
        _agent.isStopped = true;
    }

    private IEnumerator CalculateDistance(Vector2 target)
    {
        yield return new WaitUntil(() => Vector2.Distance(gameObject.transform.position, target) <= _distanceStop);
        PointCame?.Invoke();
        StopCoroutine(_coroutine);
    }
}
