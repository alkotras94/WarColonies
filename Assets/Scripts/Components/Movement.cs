using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _distanceStop = 0.5f;
    [SerializeField] private float _searchRadius = 0f; //Spread 

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

        // We find the nearest free point
        Vector2 adjustedTarget = FindFreePosition(target);

        // Setting a new destination
        _agent.SetDestination(new Vector3(adjustedTarget.x, adjustedTarget.y, transform.position.z));

        // Launching the arrival tracking routine
        _coroutine = StartCoroutine(CalculateDistance(adjustedTarget));

        // Turning the unit towards the target
        _rotation.Rotate(adjustedTarget);

        /* _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        _coroutine = StartCoroutine(CalculateDistance(target));
        _rotation.Rotate(target);*/
    }
    public void StopMovement()
    {
        _agent.isStopped = true;
    }


    private Vector2 FindFreePosition(Vector2 target)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(target, _distanceStop);

        // If the point is free, we return it.
        if (colliders.Length == 0)
            return target;

        // If the point is occupied, we look for the nearest vacant one.
        for (int i = 0; i < 10; i++) // 10 attempts to find an empty seat
        {
            Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * _searchRadius;
            Vector2 newTarget = target + randomOffset;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(new Vector3(newTarget.x, newTarget.y, 0), out hit, _searchRadius, NavMesh.AllAreas))
            {
                return new Vector2(hit.position.x, hit.position.y);
            }
        }

        // If you can't find an empty space, we will return the original goal.
        return target;
    }


    private IEnumerator CalculateDistance(Vector2 target)
    {
        yield return new WaitUntil(() => Vector2.Distance(gameObject.transform.position, target) <= _distanceStop);
        PointCame?.Invoke();
        StopCoroutine(_coroutine);
    }
}
