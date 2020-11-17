using GameOfLifeAPI.Repository;
using Newtonsoft.Json;

namespace GameOfLifeAPI.UseCases {
    public class GetNextGenerationBoardQuery {
        private readonly SaveBoardRepository saveBoardRepository;
        public GetNextGenerationBoardQuery(SaveBoardRepository saveBoardRepository) {
            this.saveBoardRepository = saveBoardRepository;
        }

        public string Execute() {
            saveBoardRepository.UpdateBoard();
            return JsonConvert.SerializeObject(saveBoardRepository.GetBoard());
        }
    }
}
