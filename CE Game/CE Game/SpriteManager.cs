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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        //camera


        //list of sprites
        List<Sprite> spriteList = new List<Sprite>();

        //player
        Player player;

        //stat bars
        Sprite HPBar, ManaBar;

        //spriteBatch
        SpriteBatch spriteBatch;

        //keyboard for functions requried between classes
        MouseState mouseState = new MouseState();


        //delay between shots
        bool canShoot = true;

        public Random rnd = new Random();

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            //initialize the spritebatch
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            //height of ground from bottom of window
            int GroundConstant = Game.Window.ClientBounds.Height - 56;

            //initialize and load player
            player = new Player(this, Game, Game.Content.Load<Texture2D>(@"Sprites\Main\Idle"),
                new Vector2(0, GroundConstant - 60), new Point(45, 60), 5, new Point(0, 0), new Point(1, 1),
                new Vector2(5, 2), 50, null);

            //load sprites

            
            //load ground
            //GA
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
                new Vector2(0, GroundConstant), new Point(498, 56), 0, 
                    new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GB
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
               new Vector2(498, GroundConstant), new Point(498, 56), 0,
                   new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GC
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
               new Vector2(300, GroundConstant - 300), new Point(498, 56), 0,
                   new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GD
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
               new Vector2(100, GroundConstant - 150), new Point(100, 56), 0,
                   new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GE
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
               new Vector2(996, GroundConstant), new Point(498, 56), 0,
                   new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));
            //GF
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
               new Vector2(1494, GroundConstant), new Point(498, 56), 0,
                   new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GG
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
               new Vector2(1000, GroundConstant - 500), new Point(498, 56), 0,
                   new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GH
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
              new Vector2(950, GroundConstant - 250), new Point(498, 56), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));

            //GI
            spriteList.Add(new Ground(Game, Game.Content.Load<Texture2D>(@"Sprites\Ground"),
              new Vector2(1700, GroundConstant - 400), new Point(498, 56), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 1), 50, null));
            //load wolf

            //WA
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
               new Vector2(500, GroundConstant - 50), new Point(75, 67), 0,
                   new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WB
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                    new Vector2(600, GroundConstant - 300 - 50), new Point(75, 67), 0,
                    new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WC
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1200, GroundConstant - 500 - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WD
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1200, GroundConstant - 250 - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WE
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1950, GroundConstant - 400 - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WF
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1000, GroundConstant - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WG
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1300, GroundConstant - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WH
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1600, GroundConstant - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //WI
            spriteList.Add(new WolfArcher(this, Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArcherWalk"),
                new Vector2(1800, GroundConstant - 50), new Point(75, 67), 0,
                new Point(0, 0), new Point(6, 1), new Vector2(1, 0), 150, null));

            //load HP potions
            //H1
            spriteList.Add(new Potion(this, Game, Game.Content.Load<Texture2D>(@"Sprites\flask_red"),
                new Vector2(1050, GroundConstant - 500 - 32), new Point(32, 32), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 0), 150, null, 0));
            //H2
            spriteList.Add(new Potion(this, Game, Game.Content.Load<Texture2D>(@"Sprites\flask_red"),
                new Vector2(1900, GroundConstant - 32), new Point(32, 32), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 0), 150, null, 0));

            //H3
            spriteList.Add(new Potion(this, Game, Game.Content.Load<Texture2D>(@"Sprites\flask_red"),
                new Vector2(450, GroundConstant - 32), new Point(32, 32), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 0), 150, null, 0));

            //load Mana potions
            //M1
            spriteList.Add(new Potion(this, Game, Game.Content.Load<Texture2D>(@"Sprites\flask_blue"),
                new Vector2(1500, GroundConstant - 32), new Point(32, 32), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 0), 150, null, 1));
            //M2
            spriteList.Add(new Potion(this, Game, Game.Content.Load<Texture2D>(@"Sprites\flask_blue"),
                new Vector2(1900, GroundConstant - 400 - 32), new Point(32, 32), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 0), 150, null, 1));

            //M3
            spriteList.Add(new Potion(this, Game, Game.Content.Load<Texture2D>(@"Sprites\flask_blue"),
                new Vector2(400, GroundConstant - 300 - 32), new Point(32, 32), 0,
                new Point(0, 0), new Point(1, 1), new Vector2(1, 0), 150, null, 1));

            //load HUD
            LoadHUD();

            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            player.Update(gameTime);
            
            //for shooting the arrow!
            mouseState = Mouse.GetState();

            //move camera?
            //0 = no move   1 = right move      2 = move left
            int cameraMove = 0;

            ///////////////////////////////
            /*
             * If canSHoot is true, player can shoot an arrow if the animation frame
             * is a certain frame. Depending on where the mouse is, it'll either shoot
             * left or right. The X speed is the player's range stat, while the Y speed
             * is the difference between the mouse's Y pos and the pos of the player's
             * midbody (on the bow) multiplied by some constant number
             */ 
            if (canShoot)
            {
                int rangeMultiply = 1;

                //shooting left
                if ((mouseState.LeftButton == ButtonState.Pressed) && (mouseState.X < player.position.X) && (mouseState.Y < (player.position.Y + player.frameSize.Y / 2) + 20))
                {
                    if (player.fartherShot == true)
                    {
                        rangeMultiply = 2;
                    }
                    else
                    {
                        rangeMultiply = 1;
                    }

                    if (player.currentFrame.X == 2)
                    {
                        spriteList.Add(new Arrow(Game, Game.Content.Load<Texture2D>(@"Sprites\Arrow"),
                        new Vector2(player.position.X - 30, (player.position.Y + (player.frameSize.Y / 2)) - 10),
                        new Point(32, 32), 20, new Point(0, 0), new Point(1, 1),
                        new Vector2(-player.statRange * rangeMultiply, (player.position.Y + (player.frameSize.Y / 2) - 10 - mouseState.Y) * 0.04f), 0, null));

                        if (player.fartherShot == true)
                        {
                            player.Mana -= 5;
                        }

                        if (player.strongerShot == true)
                        {
                            player.Mana -= 5;
                        }
                    }
                }
                //shooting right
                else if ((mouseState.LeftButton == ButtonState.Pressed) && (mouseState.X > player.position.X) && (mouseState.Y < (player.position.Y + player.frameSize.Y / 2) + 20))
                {
                    if (player.fartherShot == true)
                    {
                        rangeMultiply = 2;
                    }
                    else
                    {
                        rangeMultiply = 1;
                    }

                    if (player.currentFrame.X == 2)
                    {
                        spriteList.Add(new Arrow(Game, Game.Content.Load<Texture2D>(@"Sprites\Arrow"),
                        new Vector2(player.position.X + player.frameSize.X - 30, (player.position.Y + (player.frameSize.Y / 2)) - 10),
                        new Point(32, 32), 20, new Point(0, 0), new Point(1, 1),
                        new Vector2(player.statRange * rangeMultiply, (player.position.Y + (player.frameSize.Y / 2) - 10 - mouseState.Y) * 0.04f), 0, null));

                        if (player.fartherShot == true)
                        {
                            player.Mana -= 5;
                        }

                        if (player.strongerShot == true)
                        {
                            player.Mana -= 10;
                        }
                    }
                }

                canShoot = false;
            }

            if (player.currentFrame.X == 1)
            {
                canShoot = true;
            }

            foreach (Sprite a in spriteList)
            {
                //if the sprite is an arrow
                if (a is Arrow)
                {
                        //rotate accordingly
                    if (a.isFalling == false)
                    {
                        //goign up
                        a.rotation = -(float)Math.Atan2((player.position.Y + (player.frameSize.Y / 2) - 10 - mouseState.Y), (mouseState.X - player.position.X));
                    }
                    else
                    {
                        //going down
                        //times 2 since it was rotated once already while going up
                        a.spriteEffects = SpriteEffects.FlipVertically;
                    }
                }
            }
          
            ///////////////////////////////


            //removing a sprite deep in the nested loops will cause an exception
            //so this will handle it
            try
            {
                foreach (Sprite s in spriteList)
                {
                    s.Update(gameTime);

                    //if ground and player collide
                    if (s is Ground)
                    {
                        if (s.Collide(player))
                        {
                            //set falling to false if player collides on top of ground
                            if (player.position.Y < s.position.Y)
                            {
                                player.isFalling = false;
                                player.position.Y -= 1;

                            }
                            else
                            {
                                //if player collides on the bottom of the sprite, make
                                //him bounce down
                                player.isFalling = true;
                            }

                            player.ResetJumpPhysics();
                        }
                    }

                    //when arrow collides with something
                    if (s is Arrow)
                    {
                        
                        foreach (Sprite t in spriteList)
                        {
                            //if an enemy collides with the player's arrow
                            if (t is EnemySprite)
                            {
                                if (t.Collide(s))
                                {
                                    //deal damage to enemy
                                    if (player.strongerShot == true)
                                    {
                                        ((EnemySprite)t).TakeDamage(player.statAttack * 2);
                                        player.Mana -= 5;
                                    }
                                    else
                                    {
                                        ((EnemySprite)t).TakeDamage(player.statAttack);
                                    }


                                    //remove arrow that hit
                                    spriteList.Remove(s);
                                }

                            }

                            //if arrow collides with ground
                            if (t is Ground)
                            {
                                //remove sprite
                                if (t.Collide(s))
                                {
                                    spriteList.Remove(s);
                                }
                            }
                        }
                    }

                    if (s is EnemySprite)
                    {
                        //enemy fires weapon
                        if (((EnemySprite)s).FireWeapon == true)
                        {
                            //wolf fires arrow, speed in X direction is random
                            if (s is WolfArcher)
                            {
                                spriteList.Add(new WolfArrow(Game, Game.Content.Load<Texture2D>(@"Sprites\WolfArrow"),
                                new Vector2(s.position.X + (s.frameSize.X / 2), s.position.Y + (s.frameSize.Y / 2 - 20)),
                                new Point(32, 32), 10, new Point(0, 0), new Point(1, 1),
                                new Vector2(rnd.Next(5, 10) * ((WolfArcher)s).facingLeft, 0), 0, null));
                            }
                        }

                        //remove the enemy if he has less than 1 hp
                        if (((EnemySprite)s).RemoveSprite == true)
                        {
                            spriteList.Remove(s);
                            //give player experience points
                            player.EXPCounter += ((EnemySprite)s).EXP;
                        }
                    }
                    //player collides with wolf's arrow
                    if (s is WolfArrow)
                    {

                        if (player.Collide(s))
                        {
                            //damage player and remove arrow
                            //dmg depend on player's stats
                            player.HP -= ((WolfArrow)s).damage - (int)(player.statDefense * 0.2);
                            spriteList.Remove(s);
                        }
                    }

                    //when player reaches edge, move screen (actually move everything else)
                    //depending on if player is heading right or left
                    //but only if the sprite isn't the HP or mana bars
                    if (!(s is BarSprite))
                    {
                        if (player.position.X > 750)
                        {
                            s.position.X -= 600;
                            cameraMove = 1;
                        }
                        else if (player.position.X < 50)
                        {
                            s.position.X += 600;
                            cameraMove = -1;
                        }
                    }

                    //player collides with a potion
                    if (s is Potion)
                    {
                        if (s.Collide(player))
                        {
                            //if it's HP potion
                            if (((Potion)s).potionType == 0)
                            {
                                //if over 50 HP
                                if ((player.statHP - player.HP) < 50)
                                {
                                    //Add to up to the max HP
                                    player.HP += (player.statHP - player.HP);
                                }
                                else
                                {
                                    player.HP += 50;
                                }
                            }
                            //if it's Mana potion
                            if (((Potion)s).potionType == 1)
                            {
                                //if over 50 Mana
                                if ((player.statMana - player.Mana) < 50)
                                {
                                    //Add to up to the max mana
                                    player.Mana += (player.statMana - player.Mana);
                                }
                                else
                                {
                                    player.Mana += 50;
                                }
                            }

                            //remove potion sprite
                            spriteList.Remove(s);
                        }
                    }
                }

                //when player reaches edge, move player
                //depending on if player is heading right or left
                if (cameraMove == 1)
                {
                    player.position.X -= 650;
                    cameraMove = 0;
                }
                else if (cameraMove == -1)
                {
                    player.position.X += 650;
                    cameraMove = 0;
                }
            }
            catch{}

            //game over
            if (player.HP < 0)
            {
                ((Game1)Game).state = Game1.GameState.GameOver;
            }

            if (player.EXPCounter >= 900)
            {
                ((Game1)Game).state = Game1.GameState.End;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront,
                SaveStateMode.None);

            player.Draw(gameTime, spriteBatch);

            //draw other sprites
            foreach (Sprite s in spriteList)
            {
                s.Draw(gameTime, spriteBatch);
            }

            //draw HUD text
            DrawHUD();

            //load background
            spriteBatch.Draw(Game.Content.Load<Texture2D>(@"Sprites\ForestBkg"), new Rectangle(0, 0, 1000, 1000), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 1);

            spriteBatch.End();


            base.Draw(gameTime);
        }

        //get player's position
        public float GetPlayerPositionX()
        {
            return player.position.X;
        }

        public void LoadHUD()
        {
            HPBar = new BarSprite(this, Game, Game.Content.Load<Texture2D>(@"Sprites\HPBar"),
            new Vector2(70, 10), new Point(200, 15), 0,
            new Point(0, 0), new Point(1, 1), new Vector2(0, 0), 0, null);
            spriteList.Add(HPBar);

            ManaBar = new BarSprite(this, Game, Game.Content.Load<Texture2D>(@"Sprites\ManaBar"),
            new Vector2(70, 30), new Point(200, 15), 0,
            new Point(0, 0), new Point(1, 1), new Vector2(0, 0), 0, null);
            spriteList.Add(ManaBar);
        }

        public void DrawHUD()
        {
            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\Arial"), "HP: ",
                new Vector2(10, 8), Color.Red);

            //calculate the size of the hp bar depending on the HP/totalHP * framesize of HPBar sprite
            float HPBarShow = ((float)player.HP / player.statHP) * 200;
            HPBar.frameSize.X = (int)HPBarShow;

            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\Arial"), "Mana: ",
                new Vector2(10, 28), Color.Blue);

            //calculate the size of the mana bar depending on the mana/totalmana * framesize of manaBar sprite
            float ManaBarShow = ((float)player.Mana / player.statMana) * 200;
            ManaBar.frameSize.X = (int)ManaBarShow;

            //text stuff

            //level
            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\Arial"), "Level: ",
                new Vector2(10, 48), Color.Yellow);

            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\Arial"), player.playerLevel.ToString(),
                new Vector2(70, 48), Color.Yellow);

            //moves
            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\SmallArial"), "Marksman's Spirit (Attack x2): Z",
                new Vector2(10, 70), Color.Yellow);

            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\SmallArial"), "Ranger's Soul (Range x2): X",
                new Vector2(10, 85), Color.Yellow);

            //stats
            spriteBatch.DrawString(Game.Content.Load<SpriteFont>(@"Fonts\SmallArial"), 
                "Stats: \n" + 
                "HP: " + player.statHP + "\n" + 
                "Mana: " + player.statMana + "\n" + 
                "Strength: " + player.statAttack + "\n" + 
                "Range: " + player.statRange + "\n",
                new Vector2(10, 115), Color.Black);


        }

    }
}