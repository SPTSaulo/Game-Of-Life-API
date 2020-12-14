using GameOfLife;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace GameOfLifeAPI.Repository {
    public class SaveBoardInMemory : SaveBoardRepository {
        private readonly IConfiguration configuration;
        private Board board;

        public SaveBoardInMemory(IConfiguration configuration)
        {
            this.configuration = configuration;
            board = new Board(new Cell[,] {{ new Cell("Alive") }});
        }

        public void SetBoard(Board newBoard) {
            board = newBoard;
        }

        public Board GetBoard() {
            return board;
        }

        public void UpdateBoard() {
            board = board.GetNextGenerationBoard();
            var filePath = configuration["FilePath"];
            File.AppendAllText(@filePath, board.GetStringFromBoard());
        }
    }
}