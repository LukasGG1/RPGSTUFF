using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;


namespace RPG
{
    class Building2 : Actor
    {

        private Sprite _sprite;
        public Building2(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
           : base(x, y, icon, color)
        {
            _sprite = new Sprite("Assest/SmolHouse.png");
        }

        public Building2(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Assest/SmolHouse.png");
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
