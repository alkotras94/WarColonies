using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTransition : MonoBehaviour
{
    [SerializeField] private ReceiverDetector _receiverDetector;
    [SerializeField] private UnitStateMachine _stateMachine;
    [SerializeField] private Unit _unit;

    private Coroutine _coroutine;

    public void Enter()
    {
        _coroutine = StartCoroutine(EatFood());
    }

    public void Exit()
    {
        _receiverDetector.Disable();
        StopCoroutine(_coroutine);
    }

    public IEnumerator EatFood()
    {
        Vector2 vector = new Vector2(ServiceLocator.Instance.PointFreeWorkers.position.x, ServiceLocator.Instance.PointFreeWorkers.position.y);
        Hit hitData = new Hit(vector, null, null);

        yield return new WaitForSeconds(_receiverDetector.Time);
        
        _unit.AddFreeList();
       // _stateMachine.Move(hitData);

    }
}
