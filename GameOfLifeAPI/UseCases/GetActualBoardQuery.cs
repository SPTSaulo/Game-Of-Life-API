using GameOfLifeAPI.Repository;
using Newtonsoft.Json;

namespace GameOfLifeAPI.UseCases {
    public class GetActualBoardQuery {
        private readonly SaveBoardRepository saveBoardRepository;

        public GetActualBoardQuery(SaveBoardRepository saveBoardRepository) {
            this.saveBoardRepository = saveBoardRepository;
        }

        public string Execute() {
            return JsonConvert.SerializeObject(saveBoardRepository.GetBoard());
        }
    }
}
