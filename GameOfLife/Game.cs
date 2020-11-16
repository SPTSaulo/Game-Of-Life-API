using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife {
    public class Game {
        public Board board;
        public Game(Cell[,] table) {
            this.board = new Board(table);
        }

        public Board GetNextBoardGeneration() {
            return this.board.GetNextGenerationBoard();
        }

        public Board GetActualBoardGeneration() {
            return this.board;
        }
    }
}
