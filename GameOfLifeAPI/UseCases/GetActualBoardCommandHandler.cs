using GameOfLifeAPI.Repository;
using Newtonsoft.Json;

namespace GameOfLifeAPI.UseCases {
    public class GetActualBoardCommandHandler {
        private readonly SaveBoardRepository saveBoardRepository;

        public GetActualBoardCommandHandler(SaveBoardRepository saveBoardRepository) {
            this.saveBoardRepository = saveBoardRepository;
        }

        public string Execute() {
            return JsonConvert.SerializeObject(saveBoardRepository.GetBoard());
        }
    }
}
