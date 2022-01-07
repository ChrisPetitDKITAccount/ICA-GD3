using GDLibrary;
using GDLibrary.Components.UI;
using GDLibrary.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDApp.Content.Scripts
{

    //Code Largely taken from the GCA of Boomer Shooter as it is a good and simple UI. Cut back on a lot of the features, as a lot are not needed for this game.
    public class UI
    {
        private UISceneManager uiSceneManager;
        private float timeElapsed = 0;

        UIScene mainGameUIScene = new UIScene("UI");

        SpriteFont font = Application.Main.Content.Load<SpriteFont>("Assets/Fonts/ui");

        UITextObject previous = null;

        public UI(UISceneManager manager)
        {
            uiSceneManager = manager;

        }

        public void updateTime(float newTime)
        {

            timeElapsed = newTime;
            Vector2 tiDimensions = font.MeasureString(timeElapsed.ToString());
            Vector2 timeOrigin = new Vector2(tiDimensions.X / 2, tiDimensions.Y / 2);
            var timeTextObject = new UITextObject("Time", UIObjectType.Text,
                new Transform2D(new Vector2(450, Application.Main.GraphicsDevice.Viewport.Height - 100), Vector2.One * 3, 0),
                0,
                Color.White,
                SpriteEffects.None,
                timeOrigin,
                font,
                timeElapsed.ToString()
                );
            mainGameUIScene.Remove(previous);
            mainGameUIScene.Add(timeTextObject);
            previous = timeTextObject;

        }

        public void InitializeUI()
        {
            //updateTime();

            //Texture
            var blackTexture = Application.Main.Content.Load<Texture2D>("Assets/Textures/UI/Backgrounds/backgroundTexture");
            var backgroundTexture = new UITextureObject(
                "BlackTexture",
                UIObjectType.Texture,
                new Transform2D(new Vector2(0, Application.Main.GraphicsDevice.Viewport.Height - 210),
                new Vector2(10, 2), 0),
                0,
                blackTexture
                );

            //Text : timer
            var strTimer = "Timer";
            Vector2 tDimensions = font.MeasureString(strTimer);
            Vector2 timerOrigin = new Vector2(tDimensions.X / 2, tDimensions.Y / 2);
            var timerTextObject = new UITextObject("Timer", UIObjectType.Text,
                new Transform2D(new Vector2(450, Application.Main.GraphicsDevice.Viewport.Height - 150), Vector2.One * 3, 0),
                0,
                Color.White,
                SpriteEffects.None,
                timerOrigin,
                font,
                strTimer
                );


            //add the ui element to the scene
            mainGameUIScene.Add(backgroundTexture); //First add background texture.
            mainGameUIScene.Add(timerTextObject);



            #region Add Scene To Manager & Set Active Scene

            //add the ui scene to the manager
            uiSceneManager.Add(mainGameUIScene);

            //set the active scene
            uiSceneManager.SetActiveScene("UI");

            #endregion Add Scene To Manager & Set Active Scene
        }
    }
}
