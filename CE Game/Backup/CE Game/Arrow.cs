using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace CE_Game
{
    class Arrow : Sprite
    {
           //arrow physics
        public float startingAcceleration = 0.95f;
        public float startingVelocity = 3;
        public float acceleration = 0.95f;
        public float velocity = 3;

        //if arrow is falling or not
        public new bool isFalling = false;

         public Arrow(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {

        }

          public Arrow(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //change layerdepth
            this.layerDepth = 0.01f;

            
            //move in x axis
            position.X += speed.X;

            //if arrow is falling...
            if (isFalling)
            {
                Falling();
            }
            else
            {
                position.Y -= speed.Y * velocity;
                velocity *= acceleration;

                //when reach certain peak...
                if (velocity < 1 && velocity > 0)
                {
                    //arrow is falling
                    isFalling = true;
                }
            }

            base.Update(gameTime);
        }

        public void Falling()
        {
            //this method handles the gravity effect when MC is falling
            //called by Update when isFalling = true;

            position.Y -= speed.Y * -velocity;
            velocity /= acceleration;

            //change animation
            spriteEffects = SpriteEffects.FlipVertically;

        }

        public void SetSpeed()
        {

        }
    }
}
