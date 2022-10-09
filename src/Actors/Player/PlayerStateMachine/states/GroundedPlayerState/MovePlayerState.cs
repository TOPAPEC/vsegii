using System;
using Godot;

namespace Pg2.Actors.Player.PlayerStateMachine.states.GroundedPlayerState
{
    public class MovePlayerState : GroundedPlayerState
    {
        public MovePlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animationName) :
            base(player, stateMachine, data, animationName)
        {
        }

        public override void Process(float delta)
        {
            base.Process(delta);


            if (!IsExitingState)
            {
                if (Math.Abs(XInput) < 0.001f)
                {
                    StateMachine.ChangeState(Player.IdleState);
                }
                else if (CrouchInput)
                {
                }
            }
        }

        public override void PhysicsProcess(float delta)
        {
            base.PhysicsProcess(delta);
            Player.SetXVelocity(Mathf.Lerp(Player.CurrentVelocity.x, XInput * Data.MovementVelocity, 8 * delta));
        }
    }
}