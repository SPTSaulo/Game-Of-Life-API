using GameOfLifeAPI.Repository;
using Newtonsoft.Json;

namespace GameOfLifeAPI.UseCases {
    public class GetNextGenerationBoardCommandHandler {
        private readonly SaveBoardRepository saveBoardRepository;
        public GetNextGenerationBoardCommandHandler(SaveBoardRepository saveBoardRepository) {
            this.saveBoardRepository = saveBoardRepository;
        }

        public string Execute() {
            saveBoardRepository.UpdateBoard();
            return JsonConvert.SerializeObject(saveBoardRepository.GetBoard());
        }
    }
}
