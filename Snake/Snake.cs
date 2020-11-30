using System;
using System.Collections.Generic;
using Raylib_cs;
namespace Snake
{
    public class Snake : GameObject
    {
        public enum Directions
        {
            Up,
            Right,
            Down,
            Left
        }
        Directions direction = Directions.Right;
        List<SnakeTail> tail = new List<SnakeTail>();

        public List<List<float>> points = new List<List<float>>();

        public Snake()
        {
            rectangle = new Rectangle(800 / 2, 600 / 2, 20, 20);
            gameObjects.Add(this);
            EatFood();
        }
        public void EatFood()
        {
            tail.Add(new SnakeTail(direction,rectangle));
        }
        private void AddPoint()     //Gets position which gets put into a list keeping turning positions
        {
            List<float> point = new List<float>();

            point.Add(rectangle.x);
            point.Add(rectangle.y);
            points.Add(point);

        }
        public override void Update()
        {
            //Getting input and setting direction based on input
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) || Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                direction = Directions.Up;
                AddPoint();
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                direction = Directions.Right;
                AddPoint();
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                direction = Directions.Down;
                AddPoint();
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                direction = Directions.Left;
                AddPoint();
            }

            //Moving based on direction
            switch (direction)
            {
                case Directions.Up:
                    {
                        rectangle.y -= 3f;
                    }
                    break;
                case Directions.Right:
                    {
                        rectangle.x += 3f;
                    }
                    break;
                case Directions.Down:
                    {
                        rectangle.y += 3f;
                    }
                    break;
                case Directions.Left:
                    {
                        rectangle.x -= 3f;
                    }
                    break;
                default:
                    {
                        rectangle.x += 4f;
                    }
                    break;
            }

            foreach(SnakeTail t in tail){
                t.Update(direction);
            }

        }
    }
}
