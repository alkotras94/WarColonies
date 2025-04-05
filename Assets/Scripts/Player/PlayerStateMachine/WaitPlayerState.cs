using UnityEngine;
public class WaitPlayerState : PlayerState
{
    public override void Enter(Hit hitData)
    {
        Debug.Log("The player has entered the standby state");
    }

    public override void Exit()
    {
        Debug.Log("The player has exited the standby state");
    }
}
