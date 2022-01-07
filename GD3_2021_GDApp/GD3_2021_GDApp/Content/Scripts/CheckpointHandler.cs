using GDLibrary;
using GDLibrary.Components;
using GDLibrary.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDApp.Content.Scripts
{
    public class CheckpointHandler : Component
    {
        public Checkpoint[] list;
        public int currentCheckpoint = 0;
        public float distance = 5;
        public Transform player;

        private AudioEmitter emitter;

        private GDLibrary.Managers.Cue checkPointSound;

        public CheckpointHandler(int size,Game game)
        {
            list = new Checkpoint[size];
            emitter = new AudioEmitter();
            checkPointSound = new GDLibrary.Managers.Cue("CheckpointSound"
                                                            , game.Content.Load<SoundEffect>("Assets/Sounds/checkPoint")
                                                            , SoundCategoryType.BackgroundMusic, new Vector3(1f, 1f, 1f), false);
            Application.SoundManager.Add(checkPointSound);
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
                    emitter.Position = list[currentCheckpoint].gameObject.Transform.LocalTranslation;

                    list[currentCheckpoint].gameObject.Transform.SetTranslation(0,-100,0);

                    Application.SoundManager.Play3D(checkPointSound.ID,Application.playerListener,emitter);

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
