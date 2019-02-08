using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recursion_106
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D image;
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Content
            image = Content.Load<Texture2D>("pepe");
            font = Content.Load<SpriteFont>("File");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //Begin the recursive drawing and store the count
            int count = DrawRecursiveThing(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Color.White);

            //Draw the count on the screen
            spriteBatch.DrawString(font, "Count: " + count, new Vector2(GraphicsDevice.Viewport.Width - 100, 0), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        /// Draws the image and swaps the color between white and orange, 
        /// then it shrinks the image by half and redraws it in the top and bottom corners.
        /// Continues until the image gets smaller than 20 pixels
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        int DrawRecursiveThing(int x, int y, int width, int height, Color color)
        {
            //Draw the image
            spriteBatch.Draw(image, new Rectangle(x, y, width, height), color);

            //Return if image is below 20 X 20 pixels
            if (width <= 20 || height <= 20)
                return 1;

            //Invert the colors
            if (color == Color.White)
                color = Color.Orange;
            else
                color = Color.White;

            //Half the image size
            width /= 2;
            height /= 2;

            //Call the method twice and add 1 to the return
            return 1 + DrawRecursiveThing(x,y,width, height, color) + 
                DrawRecursiveThing(x + width, y + height, width, height, color);
        }
    }
}
