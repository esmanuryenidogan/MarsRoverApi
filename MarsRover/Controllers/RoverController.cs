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
            var areaSize = "5,5";

            _roverHandler.Initialize(rover.coordinateX, rover.coordinateY, rover.direction);

            char[] moveDirectionArray = rover.moveDirection.ToCharArray();

            var directionMove = await _roverHandler.MoveDirection(moveDirectionArray);

            return directionMove;
        }
    }
}
