using System;

namespace Pg2.Actors.Player.PlayerStateMachine.states.AbilityPlayerState
{
    public class DashPlayerState : AbilityPlayerState
    {
        private long _LastDashTimestamp;
        public int DashesLeft;

        public DashPlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animationName) :
            base(player, stateMachine, data, animationName)
        {
            DashesLeft = Data.DashCount;
        }

        public bool CanDash => DashesLeft > 0;

        public override void Enter()
        {
            base.Enter();
            var currentUnixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            ResetDashes((int)((currentUnixTimestamp - _LastDashTimestamp) / Data.DashDelay));
            _LastDashTimestamp = currentUnixTimestamp;
            DashesLeft--;
            StateMachine.ChangeState(Player.PreviousState);
        }

        public void ResetDashes(int count = -1)
        {
            if (count == -1)
                DashesLeft = Data.DashCount;
            else if (count > 0)
                DashesLeft += count;
            else
                return;
        }
    }
}