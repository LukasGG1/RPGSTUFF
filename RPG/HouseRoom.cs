﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace RPG
{
    class HouseRoom : Actor
    {
        private Sprite _sprite;
        public HouseRoom(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
           : base(x, y, icon, color)
        {
            _sprite = new Sprite("Assest/HouseMap.png");


        }

        public HouseRoom(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Assest/HouseMap.png");
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
