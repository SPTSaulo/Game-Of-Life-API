using GameOfLifeAPI.Models;

namespace GameOfLifeAPI.Repository
{
    public class SaveBoardInMemory : SaveBoardRepository
    {
        private Board board;

        public SaveBoardInMemory() {
            board = new Board(new Cell[,] {{ new Cell("Alive") }});
        }

        public void SetBoard(Board newBoard)
        {
            board = newBoard;
        }

        public Board GetBoard()
        {
            return board;
        }

        public void UpdateBoard()
        {
            board = board.GetNextGenerationBoard(); 
        }
    }
}