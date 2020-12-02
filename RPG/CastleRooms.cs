using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class CastleRooms
    {
        delegate void GameEvent();

        /// <summary>
        /// The GameManager class contains all game logic that needs to be accessed globally.
        /// Making the class static means that no instance of it can be created. It also means
        /// that any fields or methods declared inside must also be static.
        /// </summary>
        static class Castles
        {
            private static bool _gameOver = false;

            /// <summary>
            /// This is an instance of the GameEvent delegate.
            /// Just as with classes, you must create an instance of a custom type
            /// before you can use it.
            /// This instance is being used to store functions that are called
            /// when the player has won the game.
            /// Find all references to see how this instance is used.
            /// </summary>
            public static GameEvent onWin;

            public static bool GameOver { get => _gameOver; set => _gameOver = value; }

        }
    }
}
