namespace Pg2.Actors.Player.PlayerStateMachine.states.AbilityPlayerState
{
    public class JumpPlayerState : AbilityPlayerState
    {
        public int JumpsLeft;

        public JumpPlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animationName) :
            base(player, stateMachine, data, animationName)
        {
        }

        public bool CanJump => JumpsLeft > 0;

        public override void Enter()
        {
            base.Enter();
            JumpsLeft--;
            Player.CurrentVelocity.y = Data.JumpStartingSpeed;
            IsAbilityDone = true;
            StateMachine.ChangeState(Player.InAirState);
        }

        public void ResetJumps()
        {
            JumpsLeft = Data.AmountOfJumps;
        }
    }
}