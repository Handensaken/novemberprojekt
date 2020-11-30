using System;
using Raylib_cs;
namespace Snake
{
    public class SnakeTail : Snake
    {
        Directions direction = Directions.Right;
        public SnakeTail(Directions d, Rectangle r)
        {
            gameObjects.Add(this);

            switch (d)
            {
                case Directions.Up:
                    {
                        rectangle = r;
                        rectangle.y += 20;
                    }
                    break;
                case Directions.Right:
                    {
                        rectangle = r;
                        rectangle.x -= 20;
                    }
                    break;
                case Directions.Down:
                    {
                        rectangle = r;
                        rectangle.y -= 20;
                    }
                    break;
                case Directions.Left:
                    {
                        rectangle = r;
                        rectangle.x += 20;
                    }
                    break;
            }


        }
        public void Update(Directions d)
        {
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

            if(rectangle.x == points[0][0] && rectangle.y == points[0][1]){
                direction = d;
                points.RemoveAt(0);
            }

        }
    }
}
