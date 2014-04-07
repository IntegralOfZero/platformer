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
    class Player : Sprite
    {
        //player stats
        public int statRange = 5;
        public int statHP = 100;
        public int statMana = 100;
        public int statAttack = 5;
        public int statDefense = 5;
        //variable to hold changes in these variables
        public int HP;
        public int Mana;

        //jumping physics
        public float startingAcceleration = 0.95f;
        public float startingVelocity = 5;
        public float acceleration = 0.95f;
        public float velocity = 5;
       
        //if MC is falling or not
        public new bool isFalling = false;

        //keyboard (updated in KeyboardCheck
        public KeyboardState keyboard;

        public SpriteManager spriteManager;

        //leveling
        public int EXPCounter = 0;
        public int playerLevel = 1;
        //when to increase the stats
        bool levelTwo = false;
        bool levelThree = false;
        bool levelFour = false;
        bool levelFive = false;
        bool levelSix = false;
        bool levelSeven = false;

        //special attack states
        public bool strongerShot = false;
        public bool fartherShot = false;

          public Player(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {
            this.spriteManager = spriteManager;
            this.HP = statHP;
            this.Mana = statMana;
        }

          public Player(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {
            this.spriteManager = spriteManager;
            this.HP = statHP;
            this.Mana = statMana;
        }
            
        public override void Update(GameTime gameTime)
        {
            //check for keyboard input
            KeyboardCheck();

            //check for mouse input
            MouseCheck();

            //if MC is falling...
            if (isFalling)
            {
                Falling();
            }

            LevelUpCheck();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            base.Draw(gameTime, spriteBatch);
        }

        public void KeyboardCheck()
        {
            //check for input
            keyboard = Keyboard.GetState();

            //move player depending on arrow key pressed
            if(keyboard.IsKeyDown(Keys.A))
            {
                position.X -= speed.X;
                RunningLeftAnimation();
            }

            if(keyboard.IsKeyDown(Keys.D))
            {
                position.X += speed.X;
                RunningRightAnimation();
            }

            if(keyboard.IsKeyDown(Keys.W))
            {
                //for jumping
                //if not falling
                if(!isFalling)
                {
                    JumpingAnimation();

                    position.Y -= speed.Y * velocity;
                    velocity *= acceleration;

                    //when reach certain peak...
                    if (velocity < 1 && velocity > 0)
                    {
                        //MC is falling
                        isFalling = true;
                    }
                }
            }

            //when the jump button is released mid jump
            if (keyboard.IsKeyUp(Keys.W))
            {
                if (velocity != startingVelocity)
                {
                    isFalling = true;
                }

            }

            if(keyboard.IsKeyDown(Keys.S))
            {
                position.Y += speed.Y;
            }

            //if no key is pressed
            if (keyboard.GetPressedKeys().Length == 0)
            {

                if (!isFalling)
                {
                    //reset physics
                    acceleration = startingAcceleration;
                    velocity = startingVelocity;

                    WalkingAnimation();
                }
            }

            //if mana is greater than zero, spec atk is possible
            if (Mana > 0)
            {
                //stronger shot special
                if (keyboard.IsKeyDown(Keys.Z))
                {
                    strongerShot = true;
                    tint = Color.Red;
                }
                //farther shot special
                else if (keyboard.IsKeyDown(Keys.X))
                {
                    fartherShot = true;
                    tint = Color.Blue;
                }
                
            }

            //if spec atk buttons not pressed, then spec atk doesn't work
            if (keyboard.IsKeyUp(Keys.Z))
            {
                strongerShot = false;
            }

            if (keyboard.IsKeyUp(Keys.X))
            {
                fartherShot = false;
            }
        
            if(strongerShot == false && fartherShot == false)
            {
                tint = Color.White;
            }
            ///////////////////////////////////////////
        }

        public void MouseCheck()
        {
            //check if mouse buttons are pressed
            MouseState mouseState = new MouseState();
            mouseState = Mouse.GetState();

            //for shooting!

            //if left button pressed
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                //set X speed to zero when shooting
                speed.X = 0;

                //above and right
                if ((mouseState.X > this.position.X) && (mouseState.Y < this.position.Y))
                {
                    ShootingUpwardAnimation();
                    this.spriteEffects = SpriteEffects.None;
                }
                //above and left
                else if ((mouseState.X < this.position.X) && (mouseState.Y < this.position.Y))
                {
                    ShootingUpwardAnimation();

                    //if not facing left, turn left
                    if (this.spriteEffects == SpriteEffects.None)
                    {
                        this.spriteEffects = SpriteEffects.FlipHorizontally;
                    }
                }
                //straight and left
                else if (mouseState.X < this.position.X)
                {
                    ShootingForwardAnimation();

                    //if not facing left, turn left
                    if (this.spriteEffects == SpriteEffects.None)
                    {
                        this.spriteEffects = SpriteEffects.FlipHorizontally;
                    }
                }
                //straight and right
                else
                {
                    ShootingForwardAnimation();
                    this.spriteEffects = SpriteEffects.None;
                }
            }
            else
            {
                //when mouse is not down
                //set speed back to normal
                speed.X = startingSpeedX;
            }
        }

        public void Falling()
        {
            //this method handles the gravity effect when MC is falling
            //called by Update when isFalling = true;

            position.Y -= speed.Y * -velocity;
            velocity /= acceleration;

            JumpingAnimation();

        }

        public void ResetJumpPhysics()
        {
            //reset the velocity and acceleration
            velocity = startingVelocity;
            acceleration = startingAcceleration;
        }

        public void LevelUpCheck()
        {
            if (EXPCounter >= 100)
            {
                playerLevel = 2;
            }
            if (EXPCounter >= 200)
            {
                playerLevel = 3;
            }
            if (EXPCounter >= 400)
            {
                playerLevel = 4;
            }
            if (EXPCounter >= 600)
            {
                playerLevel = 5;
            }
            if (EXPCounter >= 800)
            {
                playerLevel = 6;
            }
            if (EXPCounter >= 900)
            {
                playerLevel = 7;
            }
            if (EXPCounter >= 1100)
            {
                playerLevel = 8;
            }

            //the initial values can be found at the top of this class
            statRange = 5 + ((playerLevel - 1) * 2);
            statHP = 100 + ((playerLevel - 1) * 10);
            statMana = 100 + ((playerLevel - 1) * 10); 
            statAttack = 5 + ((playerLevel - 1) * 1);
            statDefense = 5 + ((playerLevel - 1) * 4);
        }

        public void StatUp()
        {

        }

        //Animation methods
        public void RunningRightAnimation()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\Main\Running");
            this.frameSize = new Point(55, 65);
            this.sheetSize = new Point(4, 1);
            this.millisecondsPerFrame = 100;
            this.spriteEffects = SpriteEffects.None;
        }

        public void RunningLeftAnimation()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\Main\Running");
            this.frameSize = new Point(55, 65);
            this.sheetSize = new Point(4, 1);
            this.millisecondsPerFrame = 100;
            this.spriteEffects = SpriteEffects.FlipHorizontally;
        }

        public void WalkingAnimation()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\Main\Idle");
            this.frameSize = new Point(45, 60);
            this.sheetSize = new Point(1, 1);
            this.millisecondsPerFrame = 50;


        }

        public void JumpingAnimation()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\Main\Jumping");
            this.frameSize = new Point(60, 65);
            this.sheetSize = new Point(1, 1);
            this.millisecondsPerFrame = 50;
        }

        public void ShootingForwardAnimation()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\Main\ShootingForward");
            this.frameSize = new Point(59, 60);
            this.sheetSize = new Point(5, 1);
            this.millisecondsPerFrame = 100;
        }

        public void ShootingUpwardAnimation()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\Main\ShootingUpward");
            this.frameSize = new Point(55, 60);
            this.sheetSize = new Point(6, 1);
            this.millisecondsPerFrame = 100;
        }

    }

}
