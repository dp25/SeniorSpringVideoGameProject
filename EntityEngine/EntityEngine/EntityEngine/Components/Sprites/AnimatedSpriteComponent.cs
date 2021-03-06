﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EntityEngine.Components.Component_Parents;


namespace EntityEngine.Components.Sprites
{
    public class AnimatedSpriteComponent : DrawableComponent
    {
        //Use this component when you want to have a sprite that is animated

        protected Vector2 currentFrame;
        public void setCurrentFrame(Vector2 myFrame)
        {
            currentFrame = myFrame;
        }
        public void setCurrentFrameX(int x)
        {
            currentFrame.X = x;
        }
        public void setCurrentFrameY(int y)
        {
            currentFrame.X = y;
        }
        public int frameWidth, frameHeight;

        protected float timer = 0;
        protected float interval;
        protected int numberFrames;

        Color color;
        public void SetColor(Color myColor)
        {
            color = myColor;
        }

        protected bool animating;//Turns the animating on and off
        public void SetAnimated(bool myTruth)
        {
            animating = myTruth;
        }

        public AnimatedSpriteComponent(bool myMain, Vector2 myPosition, Texture2DFramed myTex)
            : base(myMain)
        {
            this.name = "AnimatedSpriteComponent";
            this.position = myPosition;

            this.texture = myTex.texture;
            frameWidth = myTex.frameWidth;
            frameHeight = myTex.frameHeight;

            numberFrames = this.texture.Width / frameWidth -1;
            interval = myTex.animationSpeed;
            animating = true;
        }

        public override void Initialize()
        {
            this.offset = new Vector2(frameWidth / 2, frameHeight / 2);
            this._updateOrder = 1;
            base.Initialize();
        }

        public override void Update(GameTime myTime)
        {
            timer += myTime.ElapsedGameTime.Milliseconds;

            if (animating)
            {
                if (timer > interval)
                {
                    timer = timer - interval;
                    if (currentFrame.X != numberFrames)
                    {
                        currentFrame.X++;
                    }
                    else
                    {
                        currentFrame.X -= numberFrames;
                    }
                }
            }
            base.Update(myTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, position, color);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Draw(spriteBatch, pos, color);
        }

        public void Draw(SpriteBatch spriteBatch, Color myColor)
        {
            Draw(spriteBatch, position, myColor);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, Color myColor)
        {
            spriteBatch.Draw(texture, pos - offset,
                new Rectangle(frameWidth * (int)currentFrame.X, frameHeight * (int)currentFrame.Y, frameWidth, frameHeight), myColor);
        }
    }
}
