using MarsRover.Handlers;
using MarsRover.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Controllers
{
    [Route("rover/api")]
    public class RoverController : ControllerBase
    {
        private IRoverHandler _roverHandler;
        public RoverController(IRoverHandler roverHandler)
        {
            _roverHandler = roverHandler;
        }

        [Route("marsrover"), HttpPost]
        public async Task<string> MarsRover([FromBody] RoverModel rover)
        {
            int areaX = 5;
            int areaY = 5;

            if((rover.coordinateX > 0 &&  rover.coordinateX <= areaX) && (rover.coordinateY > 0 && rover.coordinateY <= areaY))
            {
                _roverHandler.Initialize(rover.coordinateX, rover.coordinateY, rover.direction);

                char[] moveDirectionArray = rover.moveDirection.ToCharArray();

                var directionMove = await _roverHandler.MoveDirection(moveDirectionArray);

                return directionMove;
            }

            return "The coordinate is not in the area";
            
        }
    }
}
