using GameOfLife;
using GameOfLifeAPI.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.Logging;

namespace GameOfLifeAPI.Controllers {
    [Route("api/[controller]/board")]
    [ApiController]
    public class GameOfLifeController : ControllerBase {
        private readonly ILogger<GameOfLifeController> logger;
        private readonly SetNewBoardCommandHandler setNewBoardCommandHandler;
        private readonly GetActualBoardQuery getActualBoardQuery;
        private readonly GetNextGenerationBoardQuery getNextGenerationBoardQuery;

        public GameOfLifeController(ILogger<GameOfLifeController> logger, SetNewBoardCommandHandler setNewBoardCommandHandler, GetActualBoardQuery getActualBoardQuery, GetNextGenerationBoardQuery getNextGenerationBoardQuery) {
            this.logger = logger;
            this.setNewBoardCommandHandler = setNewBoardCommandHandler;
            this.getActualBoardQuery = getActualBoardQuery;
            this.getNextGenerationBoardQuery = getNextGenerationBoardQuery;
        }

        [HttpGet("logger")]
        public ActionResult<bool> ObtenerLogsPrueba()
        {
            logger.LogError("Esto es un error");
            logger.LogWarning("Esto es un warning");
            logger.LogInformation("Esto es un information");
            return true;
        }
        
        /// <summary>
        /// Return the actual board generation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public ActionResult<string> Get() {
            string board = getActualBoardQuery.Execute();
            logger.LogInformation("Llamada al método para obtener la iteración actual del tablero");
            return Ok(board);
        }

        /// <summary>
        /// Return the next board generation
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        public ActionResult<string> PostGetGeneration() {
            string board = getNextGenerationBoardQuery.Execute();
            logger.LogInformation("Llamada al metodo para obtener la siguiente iteración del tablero");
            return Ok(board);
        }

        /// <summary>
        /// Set a new board
        /// </summary>
        /// <param name="userBoard"></param>
        /// <returns></returns>
        [HttpPost("set_board")]
        [Consumes("text/plain")]
        public ActionResult<bool> PostSetGeneration([FromBody] string userBoard) {
            setNewBoardCommandHandler.Execute(userBoard);
            logger.LogInformation("Llamada al método para establecer un nuevo tablero");
            return Ok(true);
        }
        
    }
}
