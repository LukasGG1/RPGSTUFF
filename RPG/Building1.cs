using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;


namespace RPG
{
    class Building1 : Actor
    {
        private Sprite _sprite;
        public Building1(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
           : base(x, y, icon, color)
        {
            _sprite = new Sprite("Assest/House.png");
            

        }

        public Building1(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Assest/House.png");
        }



        public override void Update(float deltaTime)
        {

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
