using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace Tests {
    public class Tests {
        [Test]
        public void Generate_1_x_1_board_where_one_live_cell_die() {
            Cell aliveCell1 = new Cell("Alive");
            Cell[,] table = new Cell[,] {{aliveCell1}};
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell deadCellExpected1 = new Cell("Dead");
            Cell[,] expectedTable = new Cell[,] {{deadCellExpected1}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        
        [Test]
        public void Generate_1_x_2_board_where_live_cell_die_by_underpopulation() {
            Cell aliveCell1 = new Cell("Alive");
            Cell deadCell1 = new Cell("Dead");
            Cell[,] table = {{deadCell1, aliveCell1}};
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell deadCellExpected1 = new Cell("Dead");
            Cell deadCellExpected2 = new Cell("Dead");
            Cell[,] expectedTable = {{deadCellExpected1, deadCellExpected2}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_1_x_3_board_with_three_live_cell_where_1_cell_survive() {
            Cell aliveCell1 = new Cell("Alive");
            Cell aliveCell2 = new Cell("Alive");
            Cell aliveCell3 = new Cell("Alive");
            Cell[,] table = { { aliveCell1, aliveCell2, aliveCell3 } };
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell deadCellExpected1 = new Cell("Dead");
            Cell aliveCellExpected1 = new Cell("Alive");
            Cell deadCellExpected2 = new Cell("Dead");
            Cell[,] expectedTable = {{deadCellExpected1, aliveCellExpected1, deadCellExpected2}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_1_x_3_board_with_one_live_cell_between_two_die_cell_where_live_cell_die_by_underpopulation() {
            Cell deadCell1 = new Cell("Dead");
            Cell aliveCell1 = new Cell("Alive");
            Cell deadCell2 = new Cell("Dead");
            Cell[,] table = {{deadCell1, aliveCell1, deadCell2}};
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell deadCellExpected1 = new Cell("Dead");
            Cell deadCellExpected2 = new Cell("Dead");
            Cell deadCellExpected3 = new Cell("Dead");
            Cell[,] expectedTable = {{deadCellExpected1, deadCellExpected2, deadCellExpected3}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_2_x_2_board_where_die_cell_revive() {
            Cell aliveCell1 = new Cell("Alive");
            Cell aliveCell2 = new Cell("Alive");
            Cell deadCell1 = new Cell("Dead");
            Cell aliveCell3 = new Cell("Alive");
            Cell[,] table = {{aliveCell1, aliveCell2}, {deadCell1, aliveCell3}};
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell aliveCellExpected1 = new Cell("Alive");
            Cell aliveCellExpected2 = new Cell("Alive");
            Cell aliveCellExpected3 = new Cell("Alive");
            Cell aliveCellExpected4 = new Cell("Alive");
            Cell[,] expectedTable = {{aliveCellExpected1, aliveCellExpected2}, {aliveCellExpected3, aliveCellExpected4}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_2_x_2_board_with_four_live_cell_where_all_live() {
            Cell aliveCell1 = new Cell("Alive");
            Cell aliveCell2 = new Cell("Alive");
            Cell aliveCell3 = new Cell("Alive");
            Cell aliveCell4 = new Cell("Alive");
            Cell[,] table = {{aliveCell1, aliveCell2}, {aliveCell3, aliveCell4}};
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell aliveCellExpected1 = new Cell("Alive");
            Cell aliveCellExpected2 = new Cell("Alive");
            Cell aliveCellExpected3 = new Cell("Alive");
            Cell aliveCellExpected4 = new Cell("Alive");
            Cell[,] expectedTable = {{aliveCellExpected1, aliveCellExpected2}, {aliveCellExpected3, aliveCellExpected4}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_3_x_3_board_where_live_cell_die_by_overcrowding() {
            Cell deadCell1 = new Cell("Dead");
            Cell aliveCell1 = new Cell("Alive");
            Cell deadCell2 = new Cell("Dead");
            Cell aliveCell2 = new Cell("Alive");
            Cell aliveCell3 = new Cell("Alive");
            Cell aliveCell4 = new Cell("Alive");
            Cell deadCell3 = new Cell("Dead");
            Cell aliveCell5 = new Cell("Alive");
            Cell deadCell4 = new Cell("Dead");
            Cell[,] table = {{deadCell1, aliveCell1, deadCell2 }, { aliveCell2, aliveCell3, aliveCell4 }, { deadCell3, aliveCell5, deadCell4 }};
            Game game = new Game(table);

            Board generatedBoard = game.GetNextBoardGeneration();

            Cell aliveCellExpected1 = new Cell("Alive");
            Cell aliveCellExpected2 = new Cell("Alive");
            Cell aliveCellExpected3 = new Cell("Alive");
            Cell aliveCellExpected4 = new Cell("Alive");
            Cell deadCellExpected1 = new Cell("Dead");
            Cell aliveCellExpected5 = new Cell("Alive");
            Cell aliveCellExpected6 = new Cell("Alive");
            Cell aliveCellExpected7 = new Cell("Alive");
            Cell aliveCellExpected8 = new Cell("Alive");
            Cell[,] expectedTable = {{ aliveCellExpected1, aliveCellExpected2, aliveCellExpected3 }, { aliveCellExpected4, deadCellExpected1, aliveCellExpected5 }, { aliveCellExpected6, aliveCellExpected7, aliveCellExpected8}};
            Board expectedBoard = new Board(expectedTable);
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

    }
}