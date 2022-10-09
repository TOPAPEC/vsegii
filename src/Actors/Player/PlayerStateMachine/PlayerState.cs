using Godot;

namespace Pg2.Actors.Player.PlayerStateMachine
{
    public class PlayerState
    {
        protected readonly Player Player;
        protected string AnimationName;

        public bool CrouchInput;
        public bool DashInput;
        protected PlayerData Data;

        // Wouldn't it be automatic? 
        public bool GrabInput;
        protected bool IsAnimationFinished;

        protected bool IsExitingState;
        public bool IsGrounded;

        public bool IsTouchingCeiling;
        public bool IsTouchingLedge;
        public bool IsTouchingWall;
        public bool JumpInput;
        protected long StartTime;
        protected PlayerStateMachine StateMachine;
        public float XInput;

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data,
            string animationName)
        {
            Data = data;
            Player = player;
            AnimationName = animationName;
            StateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            DoChecks();
            IsExitingState = false;
            Player.SetAnimation(AnimationName);
        }

        public virtual void Exit()
        {
            IsExitingState = true;
        }

        public virtual void Process(float delta)
        {
            JumpInput = Input.IsActionJustPressed("jump");
            CrouchInput = Input.IsActionPressed("move_down");
            DashInput = Input.IsActionJustPressed("dash");
        }

        public virtual void PhysicsProcess(float delta)
        {
            DoChecks();
            XInput = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        }

        public virtual void DoChecks()
        {
            IsGrounded = Player.IsOnFloor();
            IsTouchingWall = Player.IsOnWall();
            IsTouchingCeiling = Player.IsOnCeiling();
        }

        public virtual void AnimationTrigger()
        {
        }

        public virtual void AnimationFinishedTrigger()
        {
            IsAnimationFinished = true;
        }
    }
}