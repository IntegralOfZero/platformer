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
    class Bird : EnemySprite
    {
        SpriteManager spriteManager;

             public Bird(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {

            this.spriteManager = spriteManager;
        }

          public Bird(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {

            this.spriteManager = spriteManager;
        }

          public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
          {
              position.X -= speed.X;
              position.Y -= speed.Y;

              base.Update(gameTime);
          }

          public override void InitializeStats()
          {
              HP = 10;
              AttackFrequency = 2000;
              EXP = 50;
          }

          public override void TakeDamage(int damage)
          {
              HP -= damage;
          }

          public override void Death()
          {
             
          }
    }
}
