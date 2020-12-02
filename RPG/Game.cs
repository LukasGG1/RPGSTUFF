using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace RPG
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;


        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Used to set the value of game over.
        /// </summary>
        /// <param name="value">If this value is true, the game will end</param>
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }


        /// <summary>
        /// Returns the scene at the index given.
        /// Returns an empty scene if the index is out of bounds
        /// </summary>
        /// <param name="index">The index of the desired scene</param>
        /// <returns></returns>
        public static Scene GetScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return new Scene();

            return _scenes[index];
        }


        /// <summary>
        /// Returns the scene that is at the index of the 
        /// current scene index
        /// </summary>
        /// <returns></returns>
        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        /// <summary>
        /// Adds the given scene to the array of scenes.
        /// </summary>
        /// <param name="scene">The scene that will be added to the array</param>
        /// <returns>The index the scene was placed at. Returns -1 if
        /// the scene is null</returns>
        public static int AddScene(Scene scene)
        {
            //If the scene is null then return before running any other logic
            if (scene == null)
                return -1;

            //Create a new temporary array that one size larger than the original
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy values from old array into new array
            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //Store the current index
            int index = _scenes.Length;

            //Sets the scene at the new index to be the scene passed in
            tempArray[index] = scene;

            //Set the old array to the tmeporary array
            _scenes = tempArray;

            return index;
        }

        /// <summary>
        /// Finds the instance of the scene given that inside of the array
        /// and removes it
        /// </summary>
        /// <param name="scene">The scene that will be removed</param>
        /// <returns>If the scene was successfully removed</returns>
        public static bool RemoveScene(Scene scene)
        {
            //If the scene is null then return before running any other logic
            if (scene == null)
                return false;

            bool sceneRemoved = false;

            //Create a new temporary array that is one less than our original array
            Scene[] tempArray = new Scene[_scenes.Length - 1];

            //Copy all scenes except the scene we don't want into the new array
            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            //If the scene was successfully removed set the old array to be the new array
            if(sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }


        /// <summary>
        /// Sets the current scene in the game to be the scene at the given index
        /// </summary>
        /// <param name="index">The index of the scene to switch to</param>
        public static void SetCurrentScene(int index)
        {
            //If the index is not within the range of the the array return
            if (index < 0 || index >= _scenes.Length)
                return;

            //Call end for the previous scene before changing to the new one
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            //Update the current scene index
            _currentSceneIndex = index;
        }


        /// <summary>
        /// Returns true while a key is being pressed
        /// </summary>
        /// <param name="key">The ascii value of the key to check</param>
        /// <returns></returns>
        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }


        /// <summary>
        /// Returns true while if key was pressed once
        /// </summary>
        /// <param name="key">The ascii value of the key to check</param>
        /// <returns></returns>
        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1024, 760, "Math For Games");

            
            //Rectangle boxCollision = { 0 };


            //==========Camera==========\\
            //Camera2D camera = { 0 };


            //===========================\\
            Raylib.SetTargetFPS(60);

            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math For Games";

            //Create a new scene for our actors to exist in
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            //Create the actors to add to our scene

            //CollisionDetection smile = new CollisionDetection(15, 5, '@');
            Actor actor = new Actor(0,0,Color.GREEN,'■',ConsoleColor.Green);
            Enemy enemy = new Enemy(10, 10, Color.GREEN, '■', ConsoleColor.Green);
            Player player = new Player(0, 1,Color.BLUE, '@', ConsoleColor.Red);
            //=================================================
            //=======MAP=======================================
            //=================================================
            //Map1 map12 = new Map1(16, 11, Color.BLUE, '#');

            //MapGrid map13 = new MapGrid(15, 12, Color.BLUE, '#');
            Map2 mapVillage = new Map2(16, 11, ' ');
            
            ////Castle
            Castle castle = new Castle(15, 6, ' ');
            //Castle Room
            MapCastle mapCastle = new MapCastle(16, 11, ' ');


            ////GeneralStore
            GeneralStore store = new GeneralStore(14, 7, ' ');

            ////Building1
            Building1 house = new Building1(14, 8);
            Building1 house1 = new Building1(14, 11.5f);
            Building1 house2 = new Building1(16, 7);

            ////Building2
            Building2 smolhouse = new Building2(14, 9.5f, ' ');
            Building2 smolhouse1 = new Building2(18, 11, ' '); 

            ////Church
            Church church = new Church(10, 10, ' ');
            


            ////BlackSmith
            BlackSmith blacksmith = new BlackSmith(16, 9.5f);

            ////Tower
            Tower tower = new Tower(16, 8.5f, ' ');

            ////Collision\\\\
            //Castle
            CastleEnterance smile = new CastleEnterance(15, 5, '@');
            //Church
            CollisionDetection smile2 = new CollisionDetection(11, 10, '@');
            //Building1
            CollisionDetection smile3 = new CollisionDetection(14, 7, '@'); //<== House1
            CollisionDetection smile4 = new CollisionDetection(14, 11, '@'); //<== House2
            CollisionDetection smile5 = new CollisionDetection(16, 6, '@'); //<== House3
            //Building2
            CollisionDetection smile6 = new CollisionDetection(14, 9, '@'); //<== SmolHouse1
            CollisionDetection smile7 = new CollisionDetection(18, 10, '@'); //<== SmolHouse2
            //Tower
            CollisionDetection smile8 = new CollisionDetection(16, 8, '@');
            //BlackSmith
            CollisionDetection smile9 = new CollisionDetection(16, 9, '@');
            //General Store
            CollisionDetection smile10 = new CollisionDetection(14, 6, '@');


            //enemy.Target = player;
            ////enemy.SetTranslation(new Vector2(5, 0));
            mapVillage.SetScale(30, 20); //Break Point

            ////=====Castle
            castle.SetScale(25, 20);
            //Castle Room
            mapCastle.SetScale(30, 30);


            ////======GeneralStore
            store.SetScale(2, 2);
            
            ////=====Building1
            house.SetScale(2, 2);
            house1.SetScale(2, 2);
            house2.SetScale(2, 2);
            
            ////=====Building2
            smolhouse.SetScale(2, 2);
            smolhouse1.SetScale(2, 2);
            
            ////=====Church
            church.SetScale(30, 30);

            

            ////======Tower
            tower.SetScale(25, 25);


            ////=====BlackSmith
            blacksmith.SetScale(2, 2);

            player.Speed = 5;
            player.SetTranslation(new Vector2(5, 15));
            //player.AddChild(enemy);
            ////player.SetRotation(1);
            player.SetScale(3, 3);





            ////map.SetScale(31, 23.49f);


            ////=======================
            ////scene1.AddActor(map12);
            //////=========Map===========
            ////scene1.AddActor(map13);
            scene1.AddActor(mapVillage);

            //==========




            ////===============================
            ////=========Building==============
            ///
            //
           scene1.AddActor(smile); //<== Castle
            
            scene1.AddActor(smile2); //<== Church
            
            scene1.AddActor(smile3); //<== House1
            scene1.AddActor(smile4); //<== House2
            scene1.AddActor(smile5); //<== House3
            
            scene1.AddActor(smile6); //<== SmolHouse1
            scene1.AddActor(smile7); //<== SmolHouse2
            
            scene1.AddActor(smile8); //<== Tower
            
            scene1.AddActor(smile9); //<== BlackSmith
            
            scene1.AddActor(smile10); //<== General Store
            
            
            ////Castle
            scene1.AddActor(castle);

            ////General Store
            scene1.AddActor(store);

            ////Building1
            scene1.AddActor(house);
            scene1.AddActor(house1);
            scene1.AddActor(house2);

            ////Building2
            scene1.AddActor(smolhouse);


            ////Church
            scene1.AddActor(church);

            ////BlackSmith
            scene1.AddActor(blacksmith);

            ////Tower
            scene1.AddActor(tower);

            //================================




            scene1.AddActor(player);
            scene1.AddActor(actor);





            //scene2 as Castle
            scene2.AddActor(mapCastle);
            scene2.AddActor(player);

 
            
            //Sets the starting scene index and adds the scenes to the scenes array
            int startingSceneIndex = 0;
            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            //Sets the current scene to be the starting scene index
            SetCurrentScene(startingSceneIndex);
        }



        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time between each frame</param>
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            //Call start for all objects in game
            Start();


            //Loops the game until either the game is set to be over or the window closes
            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                //Stores the current time between frames
                float deltaTime = Raylib.GetFrameTime();
                //Call update for all objects in game
                Update(deltaTime);
                //Call draw for all objects in game
                Draw();
                //Clear the input stream for the console window
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
