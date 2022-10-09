using System;
using Godot;

namespace Pg2.Actors.Player.PlayerStateMachine.states.AirPlayerState
{
    public class InAirPlayerState : PlayerState
    {
        private string _currentAnimation;

        public InAirPlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animationName) :
            base(player, stateMachine, data, animationName)
        {
        }

        public string CurrentAnimation
        {
            get => _currentAnimation;
            set
            {
                Player.SetAnimation(value);
                _currentAnimation = value;
            }
        }


        public override void Process(float delta)
        {
            base.Process(delta);
            if (IsGrounded && Math.Abs(Player.CurrentVelocity.y) < 0.01f)
                StateMachine.ChangeState(Player.IdleState);
            else if (JumpInput && Player.JumpState.CanJump) StateMachine.ChangeState(Player.JumpState);
        }

        public override void PhysicsProcess(float delta)
        {
            base.PhysicsProcess(delta);
            Player.SetXVelocity(Mathf.Lerp(Player.CurrentVelocity.x, XInput * Data.MovementVelocity, 1 * delta));
            if (Player.CurrentVelocity.y < 0.0f)
                Player.CurrentVelocity.y += Data.JumpGravity * delta;
            else
                Player.CurrentVelocity.y += Data.FallGravity * delta;
        }
    }
}