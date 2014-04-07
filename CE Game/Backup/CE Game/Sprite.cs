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
    //this class holds the base functionality of the sprites

    class Sprite
    {
        //variables for initialization
        public Texture2D textureImage;
        public Vector2 position;
        public Point frameSize;
        int collisionOffset;
        public Point currentFrame;
        public Point sheetSize;
        int timeSinceLastFrame = 0;
        public int millisecondsPerFrame;
        public Vector2 speed;
        const int defaultMillisecondsPerFrame = 16;
        string collisionCueName;
        public Game game; 

        //changed by other sprite classes
        public SpriteEffects spriteEffects = SpriteEffects.None;
        public Color tint = Color.White;

        //for when there's multiple sprites
        public float layerDepth = 0;

        //rotation for certian sprites
        public float rotation = 0;

        //for physics of inheriting sprites
        public bool isFalling = false;

        //for staying still while shooting
        public float startingSpeedX;

        //the difference between the two constructors is that the second constructor
        //takes a defaultMillisecondsPerFrame variable. The first constructor will
        //call the second constructor.
        public Sprite(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            this(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, defaultMillisecondsPerFrame, collisionCueName)
        {

        }

        public Sprite(Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.collisionCueName = collisionCueName;
            this.game = game;
            //for staying still while shooting purposes
            startingSpeedX = speed.X;
        }

        public virtual void Update(GameTime gameTime)
        {
            Animate(gameTime);  
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage, position, new Rectangle(
                currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, 
                frameSize.X, frameSize.Y),
                tint, rotation, Vector2.Zero, 1f, spriteEffects, layerDepth);

        }

        //Animate the sprite!
        public void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            //once the time passed is more than the specified wait time
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                //readjust the time so it can wait again
                timeSinceLastFrame -= millisecondsPerFrame;
                //if the currentFrame is out of the bounds of the spritesheet...
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        //for collision purposes
        public bool Collide(Sprite other)
        {
            Rectangle thisRect = new Rectangle((int)position.X + collisionOffset, 
                (int)position.Y + collisionOffset,
                frameSize.X - (collisionOffset * 2), frameSize.Y - (collisionOffset * 2));
            Rectangle otherRect = new Rectangle((int)other.position.X + other.collisionOffset,
                (int)other.position.Y + other.collisionOffset,
                other.frameSize.X - (other.collisionOffset * 2), other.frameSize.Y - (other.collisionOffset * 2));

            return thisRect.Intersects(otherRect); //returns either true or false
        }


    }
}
