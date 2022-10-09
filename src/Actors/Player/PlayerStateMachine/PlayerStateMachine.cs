using System.Collections.Generic;
using Godot;

namespace Pg2.Actors.Player.PlayerStateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState PreviousState;
        public Stack<PlayerState> StateStack;

        public PlayerStateMachine()
        {
            StateStack = new Stack<PlayerState>();
        }

        public PlayerState CurrentState => StateStack.Peek();

        public void Initialize(PlayerState startingState, PlayerState previousState)
        {
            PreviousState = previousState;
            StateStack.Push(startingState);
            StateStack.Peek().Enter();
        }

        public void ChangeState(PlayerState newState, bool append = false)
        {
            GD.Print($"Changing state {newState}");
            if (!append)
                StateStack.Pop().Exit();
            else
                StateStack.Peek().Exit();

            if (newState != PreviousState) StateStack.Push(newState);
            StateStack.Peek().Enter();
        }
    }
}