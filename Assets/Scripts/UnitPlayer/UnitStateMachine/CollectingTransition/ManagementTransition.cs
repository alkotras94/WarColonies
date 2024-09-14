using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementTransition : MonoBehaviour
{
    [SerializeField] private MoveTransition _moveTransition;
    [SerializeField] private CollectTransition _collectTransition;
    [SerializeField] private MoveCastleTransition _moveCastleTransition;

    public void Initialize(ResourcesFortrres resourcesFortrres)
    {
        _moveCastleTransition.Initialize(resourcesFortrres);
    }
    public void Enter(Hit hitData)
    {
        _moveTransition.Enter(hitData);
    }

    public void Exit()
    {
        _moveTransition.Exit();
        _moveCastleTransition.Exit();
        _collectTransition.Exit();
    }

}
