using GameOfLife;
using GameOfLifeAPI.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace GameOfLifeAPI.Controllers {
    [Route("api/[controller]/board")]
    [ApiController]
    public class GameOfLifeController : ControllerBase {

        private readonly SetNewBoardCommandHandler setNewBoardCommandHandler;
        private readonly GetActualBoardQuery getActualBoardQuery;
        private readonly GetNextGenerationBoardQuery getNextGenerationBoardQuery;

        public GameOfLifeController(SetNewBoardCommandHandler setNewBoardCommandHandler, GetActualBoardQuery getActualBoardQuery, GetNextGenerationBoardQuery getNextGenerationBoardQuery) {
            this.setNewBoardCommandHandler = setNewBoardCommandHandler;
            this.getActualBoardQuery = getActualBoardQuery;
            this.getNextGenerationBoardQuery = getNextGenerationBoardQuery;
        }
        
        /// <summary>
        /// Return the actual board generation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public ActionResult<string> Get() {
            string board = getActualBoardQuery.Execute();
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
            return Ok(true);
        }
        
    }
}
