using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTransition : Transition
{
    [SerializeField] private MoveCastleTransition _moveCastleTransition;
    [SerializeField] private float _timeCollect;
    [SerializeField] private UnitAnimation _unitAnimation;
    [SerializeField] private Movement _movement;
    [SerializeField] private DetectionMove _detectionMove;

    private Coroutine _coroutine;
    private Hit _hitData;

    public override void Enter(Hit hitData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _hitData = hitData;
        _coroutine = StartCoroutine(Collect());
    }
    public override void Exit()
    {
        if (_coroutine != null) // Проверка, что объект существует
        {
            StopCoroutine(_coroutine);
        }
        _unitAnimation.FinishAnimationCollectResources();
    }

    private IEnumerator Collect()
    {
        _unitAnimation.StartAnimationCollectResources();

        yield return new WaitForSeconds(_timeCollect);

        _unitAnimation.FinishAnimationCollectResources();
        _moveCastleTransition.Enter(_hitData);
    }
}
