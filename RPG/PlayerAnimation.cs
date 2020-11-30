using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;


namespace RPG
{
    class PlayerAnimation
    {
        protected PlayerAnimation playerAnimation;
        private Sprite _sprite;
        private float animation;


        public PlayerAnimation(float animation)
        {
            this.animation = animation;
        }

        public PlayerAnimation (float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _sprite = new Sprite("Images/PlayerAnimation/Right/Right 1.png");
        }

    }
}
