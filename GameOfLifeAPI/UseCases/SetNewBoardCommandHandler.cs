using GameOfLifeAPI.Models;
using GameOfLifeAPI.Repository;
using Newtonsoft.Json;

namespace GameOfLifeAPI.UseCases {
    public class SetNewBoardCommandHandler {
        private readonly SaveBoardRepository saveBoardRepository;

        public SetNewBoardCommandHandler(SaveBoardRepository saveBoardRepository) {
            this.saveBoardRepository = saveBoardRepository;
        }

        public void Execute(string userBoard) {
            saveBoardRepository.SetBoard(JsonConvert.DeserializeObject<Board>(userBoard));
        }
    }
}
