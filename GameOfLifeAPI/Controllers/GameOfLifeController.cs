using GameOfLifeAPI.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace GameOfLifeAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GameOfLifeController : ControllerBase {

        private readonly SetNewBoardCommandHandler setNewBoardCommandHandler;
        private readonly GetActualBoardCommandHandler getActualBoardCommandHandler;
        private readonly GetNextGenerationBoardCommandHandler getNextGenerationBoardCommandHandler;

        public GameOfLifeController(SetNewBoardCommandHandler setNewBoardCommandHandler, GetActualBoardCommandHandler getActualBoardCommandHandler, GetNextGenerationBoardCommandHandler getNextGenerationBoardCommandHandler) {
            this.setNewBoardCommandHandler = setNewBoardCommandHandler;
            this.getActualBoardCommandHandler = getActualBoardCommandHandler;
            this.getNextGenerationBoardCommandHandler = getNextGenerationBoardCommandHandler;
        }
        
        /// <summary>
        /// Return the actual board generation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<string> Get() {
            string board = getActualBoardCommandHandler.Execute();
            return Ok(board);
        }

        /// <summary>
        /// Return the next board generation
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<string> PostGetGeneration() {
            string board = getNextGenerationBoardCommandHandler.Execute();
            return Ok(board);
        }

        /// <summary>
        /// Set a new board
        /// </summary>
        /// <param name="userBoard"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        [Consumes("text/plain")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<bool> PostSetGeneration([FromBody] string userBoard)
        {
            setNewBoardCommandHandler.Execute(userBoard);
            return Ok(true);
        }
        
    }
}
