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
    class Potion : Sprite
    {
        //type of potion
        //0 is HP, 1 is mana
        public int potionType;

                //the difference between the two constructors is that the second constructor
        //takes a defaultMillisecondsPerFrame variable. The first constructor will
        //call the second constructor.
            public Potion(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName, int potionType) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {
            this.potionType = potionType;
        }

          public Potion(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName, int potionType) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {
            this.potionType = potionType;
        }
    }
}
