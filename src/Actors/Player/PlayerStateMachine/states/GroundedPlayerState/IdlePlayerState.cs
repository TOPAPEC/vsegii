using System;

namespace Pg2.Actors.Player.PlayerStateMachine.states.GroundedPlayerState
{
    public class IdlePlayerState : GroundedPlayerState
    {
        public IdlePlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animationName) :
            base(player, stateMachine, data, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Player.CurrentVelocity.x = 0;
        }

        public override void Process(float delta)
        {
            base.Process(delta);
            if (!IsExitingState)
            {
                if (Math.Abs(XInput) > 0.001f)
                {
                    StateMachine.ChangeState(Player.MoveState);
                }
                else if (CrouchInput)
                {
                }
            }
        }
    }
}