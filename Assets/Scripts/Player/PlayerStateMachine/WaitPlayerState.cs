using UnityEngine;
public class WaitPlayerState : PlayerState
{
    public override void Enter(Hit hitData)
    {
        Debug.Log("Player ����� � ��������� ��������");
    }

    public override void Exit()
    {
        Debug.Log("Player ����� �� ��������� ��������");
    }
}
