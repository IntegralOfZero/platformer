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
    abstract class EnemySprite : Sprite
    {
        public int HP;
        public int AttackFrequency;
        public int AttackCounter = 0;
        public int EXP;
        //this is to let the sprite manager know when to remove this sprite
        public bool RemoveSprite = false;
        //let the sprite manager know when to add in the weapon this sprite fires
        public bool FireWeapon = false;

        //the difference between the two constructors is that the second constructor
        //takes a defaultMillisecondsPerFrame variable. The first constructor will
        //call the second constructor.
            public EnemySprite(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {
            InitializeStats();
        }

          public EnemySprite(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {
            InitializeStats();
        }

          public abstract void InitializeStats();

          public abstract void TakeDamage(int damage);

          public abstract void Death();
    }
}
