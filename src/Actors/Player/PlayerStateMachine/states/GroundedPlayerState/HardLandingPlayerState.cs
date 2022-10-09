namespace Pg2.Actors.Player.PlayerStateMachine.states.GroundedPlayerState
{
    public class HardLandingPlayerState : GroundedPlayerState
    {
        public HardLandingPlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data,
            string animationName) : base(player, stateMachine, data, animationName)
        {
        }
    }
}