namespace Pg2.Actors.Player.PlayerStateMachine.states.GroundedPlayerState
{
    public class GroundedPlayerState : PlayerState
    {
        public GroundedPlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data,
            string animationName) : base(player, stateMachine, data, animationName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            Player.JumpState.ResetJumps();
            Player.DashState.ResetDashes();
        }

        public override void Process(float delta)
        {
            base.Process(delta);

            if (JumpInput && Player.JumpState.CanJump)
                StateMachine.ChangeState(Player.JumpState);
            else if (!IsGrounded)
                StateMachine.ChangeState(Player.InAirState);
            // else if (IsTouchingWall)
            // {
            //     
            // }
            else if (DashInput && Player.DashState.CanDash) StateMachine.ChangeState(Player.DashState, true);
        }
    }
}