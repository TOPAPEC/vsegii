using System;
using Godot;

namespace Pg2.Actors.Player.PlayerStateMachine
{
    public class PlayerData
    {
        public int AmountOfJumps = 1;

        // In air
        public float CoyoteTime = 0.2f;
        public float crouchColliderHeight = 0.8f;

        // Crouch
        public float crouchMovementVelocity = 5f;
        public float DashCooldown = 0.5f;

        // Dash
        public int DashCount = 2;
        public float DashDelay = 0.2f;
        public float DashEndYMultiplier = 0.2f;
        public float DashTime = 0.2f;
        public float DashVelocity = 30f;
        public float DistBetweenAfterImages = 0.5f;
        public float Drag = 10f;
        public float HoldTimeScale = 0.25f;
        public float JumpAscendDuration = 0.4f;
        public float JumpDescendDuration = 0.3f;

        // Jump
        public float JumpHeight = 150f;

        public float MaxHoldTime = 1f;

        // Move
        public float MovementVelocity = 300f;
        public float standColliderHeight = 1.6f;

        // Ledge climb
        public Vector2 StartOffset;
        public Vector2 StopOffset;
        public float VariableJumpHeightMultiplier = 0.5f;

        // Wall climb
        public float WallClimbVelocity = 3f;
        public Vector2 WallJumpAngle = new Vector2(1, 2);
        public float WallJumpTime = 0.4f;

        // Wall jump
        public float WallJumpVelocity = 20;

        // Wall slide
        public float WallSlideVelocity = 3f;
        public float JumpStartingSpeed => -1.0f * 2.0f * JumpHeight / JumpAscendDuration;
        public float JumpGravity => (float)(-1.0f * -2.0f * JumpHeight / Math.Pow(JumpAscendDuration, 2.0f));
        public float FallGravity => (float)(-1.0f * -2.0f * JumpHeight / Math.Pow(JumpDescendDuration, 2.0f));
    }
}