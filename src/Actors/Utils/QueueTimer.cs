using System.Threading;
using Godot;

namespace Pg2.Actors.Utils
{
    [Signal]
    internal delegate void OneFinished();

    [Signal]
    internal delegate void AllFinished();

    public class QueueTimer : Node
    {
        private readonly float allWaitTime;
        private bool isOnFullCooldown;
        private object queueSize;
        private readonly float singleWaitTime;

        public QueueTimer(int capacity, float singleWaitTime, float allWaitTime = -1.0f)
        {
            Capacity = capacity;
            this.singleWaitTime = singleWaitTime;
            this.allWaitTime = allWaitTime > 0 ? allWaitTime : singleWaitTime * capacity;
            queueSize = 0;
        }

        public int Capacity { get; }

        public bool CheckForSpace(int count)
        {
            int currentQueueSize =  
        }

        public void Push(int count = 1)
        {
            if (Capacity > -1)
            {
                lock (queueSize)
                {
                    var unboxedQueueSize = (int)queueSize;
                    if (unboxedQueueSize + count >= Capacity)
                    {
                        isOnFullCooldown = true;
                        queueSize = Capacity;
                        Wait(Capacity);
                    }
                }
            }
            else
            {
                
            }
        }

        private void Wait(int count = 1)
            {
                GetTree().CreateTimer(isOnFullCooldown ? allWaitTime : singleWaitTime * count);
                if (!isOnFullCooldown)
                {
                    Interlocked.Add(ref queueSize, -1);
                    if 
                    EmitSignal(nameof(OneFinished));
                }
                else if (count == Capacity)
                {
                    Interlocked.Exchange(ref queueSize, 0);
                    isOnFullCooldown = false;
                    EmitSignal(nameof(AllFinished));
                }
            }
        }
    }