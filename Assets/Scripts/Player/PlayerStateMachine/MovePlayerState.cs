using UnityEngine;
public class MovePlayerState : PlayerState
{
    private Movement _movement;
    private PlayerStateMachine _stateMachine;

    public MovePlayerState(Movement movement, PlayerStateMachine playerStateMachine)
    {
        _movement = movement;
        _stateMachine = playerStateMachine;
    }

    public override void Enter(Hit hitData)
    {
        _movement.AddTarget(hitData.Target);
        _movement.PointCame += OnPointCame;
        Debug.Log("Player вошел в состояние передвижения");
    }

    public override void Exit()
    {
        _movement.PointCame -= OnPointCame;
        Debug.Log("Player вышел из состояния передвижения");
    }

    private void OnPointCame()
    {
        _stateMachine.Wait();
    }
}
