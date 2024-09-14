using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string CollectResources = nameof(CollectResources);

    public void StartAnimationCollectResources()
    {
        _animator.SetBool(CollectResources, true);
    }

    public void FinishAnimationCollectResources()
    {
        _animator.SetBool(CollectResources, false);
    }
}
