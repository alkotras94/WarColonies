using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTransition : Transition
{
    [SerializeField] private MoveCastleTransition _moveCastleTransition;
    [SerializeField] private float _timeCollect;
    [SerializeField] private UnitAnimation _unitAnimation;
    [SerializeField] private Movement _movement;

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
        StopCoroutine(_coroutine);
    }

    private IEnumerator Collect()
    {
        _unitAnimation.StartAnimationCollectResources();

        yield return new WaitForSeconds(_timeCollect);

        _unitAnimation.FinishAnimationCollectResources();
        _moveCastleTransition.Enter(_hitData);
    }
}
