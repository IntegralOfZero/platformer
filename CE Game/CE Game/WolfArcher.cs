using System;
using System.Collections.Generic;
using System.Linq;
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
    class WolfArcher : EnemySprite
    {
        //for usual pattern
        int walkdistance = 200;
        int walked = 200;

        //for determining where to shoot
        //left = 1, right = -1
        public int facingLeft = 1;

        //for reseting the speed after standing and shooting
        float originalspeedX;

        //shooting purposes
        public bool enableShooting = false;
        public SpriteManager spriteManager;

        Random rnd = new Random();

        //the difference between the two constructors is that the second constructor
        //takes a defaultMillisecondsPerFrame variable. The first constructor will
        //call the second constructor.
            public WolfArcher(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame, 
            sheetSize, speed, collisionCueName)
        {
            this.originalspeedX = speed.X;
            this.spriteManager = spriteManager;
        }

          public WolfArcher(SpriteManager spriteManager, Game game, Texture2D textureImage, Vector2 position, Point frameSize, 
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, 
            int millisecondsPerFrame, string collisionCueName) :
            base(game, textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName)
        {
            this.originalspeedX = speed.X;
            this.spriteManager = spriteManager;
        }

        public override void Update(GameTime gameTime)
        {
            //walking patterns
            if (walked >= 0)
            {
                //walking left initially, but speed is negative when walking right
                position.X -= speed.X;
                //decrease onyl when wolf is walking!
                if (speed.X != 0)
                {
                    walked -= 1;
                }
            }
            else
            {
 
                SwitchDirections();
            }

            //no more HP
            if (HP <= 0)
            {
                Death();
            }

            //attacking
            AttackCounter += gameTime.ElapsedGameTime.Milliseconds;
            Shoot();

            base.Update(gameTime);
        }

        public override void InitializeStats()
        {
            HP = 50;
            AttackFrequency = 2000;
            EXP = 100;

        }

        public override void TakeDamage(int damage)
        {
            HP -= damage;
        }

        public override void Death()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\WolfArcherDeath");
            frameSize = new Point(85, 69);
            millisecondsPerFrame = 75;

            if (currentFrame.X == 3)
            {
                RemoveSprite = true;
            }
        }

        public void SwitchDirections()
        {
            textureImage = game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk");

            //flip the sprite in order to appear to be walking in different directions
            if (spriteEffects == SpriteEffects.None)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                spriteEffects = SpriteEffects.None;
            }

            //restart the walking process
            walked = walkdistance;
            //switch directions
            speed.X *= -1f;
            facingLeft *= -1;
        }

        public void Shoot()
        {
            

            //attacking
            if (AttackCounter > AttackFrequency)
            {

                //go into shooting animation, enable shooting, and
                //restart counter
                AttackCounter -= AttackFrequency + rnd.Next(0, 1000);

                //if the player is to the left of this sprite, and this sprite is facing left, or
                //the player is to the right of this sprite, and this sprite is facing right
                if (((spriteManager.GetPlayerPositionX() < position.X) && facingLeft == 1) || ((spriteManager.GetPlayerPositionX() > position.X) && facingLeft == -1))
                {
                    //change animation
                    textureImage = game.Content.Load<Texture2D>(@"Sprites\WolfArcherShoot");
                    sheetSize = new Point(4, 1);
                    frameSize = new Point(80, 70);
                    millisecondsPerFrame = 200;
                    //stand still
                    speed.X = 0;

                    enableShooting = true;
                }
           
            }
            else if(enableShooting)
            {
                //shoot at end of animation
                if (currentFrame.X == 3)
                {
                    //tell spritemanager to fire weapon
                    FireWeapon = true;
                    enableShooting = false;
                }
            }
            else if(FireWeapon == true) 
            {
                FireWeapon = false;

                //this makes the wolf go back to normal pattern only when the animation is done

                    //reset speed, make him stop firing, change animation back
                    speed.X = originalspeedX * facingLeft;
                    
                    textureImage = game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk");
                    millisecondsPerFrame = 150;
                    sheetSize = new Point(6, 1);
                    frameSize = new Point(75, 67);
                
            }
        }
    }
}
