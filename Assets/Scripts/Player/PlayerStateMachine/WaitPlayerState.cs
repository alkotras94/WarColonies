using UnityEngine;
public class WaitPlayerState : PlayerState
{
    public override void Enter(Hit hitData)
    {
        Debug.Log("Player вошел в состояние ожидания");
    }

    public override void Exit()
    {
        Debug.Log("Player вышел из состояния ожидания");
    }
}
