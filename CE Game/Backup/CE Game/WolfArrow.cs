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
    class WolfArrow : Sprite, EnemyWeapon
    {
        public int damage = 10;

                    public WolfArrow(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {
            
        }

          public WolfArrow(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            position.X -= speed.X;

            //if sprite is facing either left or right, change the arrow's 
            //direction of facing accordingly
            //negative speed means it's going right
            if (speed.X < 0)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                spriteEffects = SpriteEffects.None;
            }

            base.Update(gameTime);
        }
    }
}
