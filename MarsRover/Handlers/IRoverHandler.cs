using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Handlers
{
    public interface IRoverHandler
    {
        void Initialize(int coordinateX, int coordinateY, string direction);
        Task<string> MoveDirection(char[] moveDirection);
        Task TurnRight(string direction);
        Task TurnLeft(string direction);
        Task Move(int coordinateX, int coordinateY, string direction);
    }
}
