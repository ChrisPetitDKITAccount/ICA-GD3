using GDLibrary.Components;
using GDLibrary.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDApp.Content.Scripts
{
    public class CheckpointHandler : Component
    {
        Checkpoint[] list;
        int currentCheckpoint = 0;
        public float distance = 10;
        public Transform player;

        public CheckpointHandler(int size)
        {
            list = new Checkpoint[size];
        }

        public override void Update()
        {
            CheckCheckpoint();
        }

        private void CheckCheckpoint()
        {
            if (currentCheckpoint < list.Length)
            {
                if (list[currentCheckpoint].checkDistance(player, distance))
                {
                    list[currentCheckpoint].gameObject.Transform.SetTranslation(0,-100,0);
                    currentCheckpoint++;

                }
            }
            else
            {
                EventDispatcher.Raise(new EventData(EventCategoryType.GameState, EventActionType.OnWin));
            }
        }

        public void addCheckPoint(Checkpoint check, int index)
        {
            list[index] = check;
        }
    }
}
