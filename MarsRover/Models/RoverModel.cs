using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class RoverModel
    {
        //rover's coordinate and direction
        public int coordinateX { get; set; }
        public int coordinateY { get; set; }
        public string direction { get; set; }

        //the direction the rover's will move
        public string moveDirection { get; set; }
    }
}
