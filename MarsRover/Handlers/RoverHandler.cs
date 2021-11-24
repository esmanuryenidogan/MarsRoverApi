using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Handlers
{
    public class RoverHandler : IRoverHandler
    {
        public int _coordinateX { get; set; }
        public int _coordinateY { get; set; }
        public string _direction { get; set; }

        public void Initialize(int coordinateX, int coordinateY, string direction)
        {
            _coordinateX = coordinateX;
            _coordinateY = coordinateY;
            _direction = direction;
        }

        public async Task<string> MoveDirection(char[] moveDirection)
        {
            if (moveDirection.Length > 0)
            {
                foreach (var chr in moveDirection)
                {
                    if (chr.ToString() == "R")
                        await TurnRight(_direction);
                    else if (chr.ToString() == "L")
                        await TurnLeft(_direction);
                    else
                        await Move(_coordinateX, _coordinateY, _direction);
                }
            }
            var result = _coordinateX + " " + _coordinateY + " " + _direction;

            return result;
        }

        public async Task TurnLeft(string direction)
        {
            switch (direction)
            {
                case "N":
                    _direction = "W";
                    break;
                case "S":
                    _direction = "E";
                    break;
                case "W":
                    _direction = "S";
                    break;
                case "E":
                    _direction = "N";
                    break;
            }
        }

        public async Task TurnRight(string direction)
        {
            switch (direction)
            {
                case "N":
                    _direction = "E";
                    break;
                case "S":
                    _direction = "W";
                    break;
                case "W":
                    _direction = "N";
                    break;
                case "E":
                    _direction = "S";
                    break;
            }
        }

        public async Task Move(int coordinateX, int coordinateY, string direction)
        {
            switch (direction)
            {
                case "N":
                    _coordinateY += 1;
                    break;
                case "S":
                    _coordinateY -= 1;
                    break;
                case "W":
                    _coordinateX -= 1;
                    break;
                case "E":
                    _coordinateX += 1;
                    break;
            }
        }
    }
}
