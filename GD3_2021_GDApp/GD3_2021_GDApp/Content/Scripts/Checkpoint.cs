using GDLibrary.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDApp.Content.Scripts
{
    public class Checkpoint : Component
    {

        public bool checkDistance(Transform player, float distance)
        {
            Vector3 temp = player.LocalTranslation - gameObject.Transform.LocalTranslation;
            return temp.Length() <= distance;
        }
    }
}
