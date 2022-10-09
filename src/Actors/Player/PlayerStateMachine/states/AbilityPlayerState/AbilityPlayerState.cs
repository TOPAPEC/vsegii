using System;

namespace Pg2.Actors.Player.PlayerStateMachine.states.AbilityPlayerState
{
    public class AbilityPlayerState : PlayerState
    {
        protected bool IsAbilityDone;
        public bool IsGrounded;

        public AbilityPlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animationName)
            : base(player, stateMachine, data, animationName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            IsGrounded = Player.IsOnFloor();
        }

        public override void Enter()
        {
            base.Enter();
            IsAbilityDone = false;
        }

        public override void Process(float delta)
        {
            base.Process(delta);
            if (IsAbilityDone)
            {
                if (IsGrounded && Math.Abs(Player.CurrentVelocity.y) < 0.1f)
                    StateMachine.ChangeState(Player.IdleState);
                else
                    StateMachine.ChangeState(Player.InAirState);
            }
        }
    }
}