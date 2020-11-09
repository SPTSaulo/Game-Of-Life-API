using GameOfLifeAPI.Models;

namespace GameOfLifeAPI.Repository
{
    public interface SaveBoardRepository
    {
        public void SetBoard(Board newBoard);
        public Board GetBoard();
        public void UpdateBoard();

    }
}