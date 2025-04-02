using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _distanceStop = 0.5f;
    [SerializeField] private float _searchRadius = 5f;

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

        // Находим ближайшую свободную точку
        Vector2 adjustedTarget = FindFreePosition(target);

        // Устанавливаем новую точку назначения
        _agent.SetDestination(new Vector3(adjustedTarget.x, adjustedTarget.y, transform.position.z));

        // Запускаем корутину для отслеживания прибытия
        _coroutine = StartCoroutine(CalculateDistance(adjustedTarget));

        // Поворачиваем юнита в сторону цели
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

        // Если точка свободна, возвращаем её
        if (colliders.Length == 0)
            return target;

        // Если точка занята, ищем ближайшую свободную
        for (int i = 0; i < 10; i++) // 10 попыток найти свободное место
        {
            Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * _searchRadius;
            Vector2 newTarget = target + randomOffset;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(new Vector3(newTarget.x, newTarget.y, 0), out hit, _searchRadius, NavMesh.AllAreas))
            {
                return new Vector2(hit.position.x, hit.position.y);
            }
        }

        // Если не нашли свободное место, возвращаем оригинальную цель
        return target;
    }


    private IEnumerator CalculateDistance(Vector2 target)
    {
        yield return new WaitUntil(() => Vector2.Distance(gameObject.transform.position, target) <= _distanceStop);
        PointCame?.Invoke();
        StopCoroutine(_coroutine);
    }
}
