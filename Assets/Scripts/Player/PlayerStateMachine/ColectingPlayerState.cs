
public class ColectingPlayerState : PlayerState
{
    private Player _player;

    public ColectingPlayerState(Player player)
    {
        _player = player;
    }

    public override void Enter(Hit hitData)
    {

    }

    public override void Exit()
    {
        
    }

}
