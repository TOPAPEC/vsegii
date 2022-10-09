using System;
using Godot;
using Pg2.Actors.Player.PlayerStateMachine;
using Pg2.Actors.Player.PlayerStateMachine.states.AbilityPlayerState;
using Pg2.Actors.Player.PlayerStateMachine.states.AirPlayerState;
using Pg2.Actors.Player.PlayerStateMachine.states.GroundedPlayerState;

namespace Pg2.Actors.Player
{
    public class Player : KinematicBody2D
    {
        public AnimatedSprite AnimatedSprite;

        public Vector2 CurrentVelocity;
        public DashPlayerState DashState;

        public PlayerData Data;
        public IdlePlayerState IdleState;
        public InAirPlayerState InAirState;
        public JumpPlayerState JumpState;
        public MovePlayerState MoveState;
        public PlayerState PreviousState;
        public Vector2 Snap = Vector2.Down;
        public PlayerStateMachine.PlayerStateMachine StateMachine;
        public Vector2 UpDirection = Vector2.Up;

        public override void _Ready()
        {
            StateMachine = new PlayerStateMachine.PlayerStateMachine();
            Data = new PlayerData();
            AnimatedSprite = (AnimatedSprite)GetNode("AnimatedSprite");
            IdleState = new IdlePlayerState(this, StateMachine, Data, "idle");
            MoveState = new MovePlayerState(this, StateMachine, Data, "move");
            JumpState = new JumpPlayerState(this, StateMachine, Data, "jump");
            InAirState = new InAirPlayerState(this, StateMachine, Data, "in_air");
            DashState = new DashPlayerState(this, StateMachine, Data, "move");
            PreviousState = new PlayerState(this, StateMachine, Data, "");
            CurrentVelocity = new Vector2();
            StateMachine.Initialize(IdleState, PreviousState);
            base._Ready();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            StateMachine.CurrentState.Process(delta);
            base._Process(delta);
        }

        public override void _PhysicsProcess(float delta)
        {
            base._PhysicsProcess(delta);
            StateMachine.CurrentState.PhysicsProcess(delta);
            CurrentVelocity = MoveAndSlideWithSnap(CurrentVelocity, Snap, UpDirection);
        }

        public void SetAnimation(string animationName)
        {
            AnimatedSprite.Animation = animationName;
        }

        private void SetCorrectSpriteFlip()
        {
            if (Math.Sign(CurrentVelocity.x) == -1)
                AnimatedSprite.FlipH = true;
            else
                AnimatedSprite.FlipH = false;
        }

        public void SetXVelocity(float value)
        {
            CurrentVelocity.x = value;
            SetCorrectSpriteFlip();
        }
    }
}