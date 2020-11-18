using System;

namespace GameOfLife {
    public class Board {
        public Cell[,] Table { get; set; }
        private int[,] neighboursCounter;

        public Board(Cell[,] table) {
            this.Table = table;
            neighboursCounter = new int[table.GetLength(0), table.GetLength(1)];
        }

        public Board GetNextGenerationBoard() {
            UpdateNeighboursCounter();
            UpdateTable();
            return this;
        }

        private void UpdateTable() {
            for (int i = 0; i < Table.GetLength(0); i++) {
                for (int j = 0; j < Table.GetLength(1); j++) {
                    if (Table[i, j].Status == "Alive") UpdateLiveCell(i, j, neighboursCounter[i, j]);
                    if (Table[i, j].Status == "Dead") UpdateDeadCell(i, j, neighboursCounter[i, j]);
                }
            }
        }

        private void UpdateDeadCell(int row, int column, int amountOfLiveNeighbours) {
            Table[row, column].Status = amountOfLiveNeighbours == 3 ? "Alive" : Table[row, column].Status;
        }

        private void UpdateLiveCell(int row, int column, int amountOfLiveNeighbours) {
            Table[row, column].Status = amountOfLiveNeighbours == 2 || amountOfLiveNeighbours == 3 ? "Alive" : "Dead";
        }

        private void UpdateNeighboursCounter() {
            for (int i = 0; i < neighboursCounter.GetLength(0); i++) {
                for (int j = 0; j < neighboursCounter.GetLength(1); j++) {
                    neighboursCounter[i, j] = CountLivingNeighbours(i, j);
                }
            }
        }

        private int CountLivingNeighbours(int row, int column) {
            int count = 0;
            count += CountLeftLivingNeighbours(row, column);
            count += CountRightLivingNeigbours(row, column);
            count += CountTopLeftLivingNeighbours(row, column);
            count += CountTopRightLivingNeighbours(row, column);
            count += CountUnderLivingNeighbours(row, column);
            count += CountUpLivingNeighbours(row, column);
            count += CountLowerRightNeighbours(row, column);
            count += CountLowerLeftNeighbours(row, column);
            return count;

        }

        private int CountLowerLeftNeighbours(int row, int column) {
            try {
                if (Table[row + 1, column - 1].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountLowerRightNeighbours(int row, int column) {
            try {
                if (Table[row + 1, column + 1].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountUpLivingNeighbours(int row, int column) {
            try {
                if (Table[row - 1, column].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountUnderLivingNeighbours(int row, int column) {
            try {
                if (Table[row + 1, column].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountTopRightLivingNeighbours(int row, int column) {
            try {
                if (Table[row - 1, column + 1].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountTopLeftLivingNeighbours(int row, int column) {
            try {
                if (Table[row - 1, column - 1].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountLeftLivingNeighbours(int row, int column) {
            try {
                if (Table[row, column - 1].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        private int CountRightLivingNeigbours(int row, int column) {
            try {
                if (Table[row, column + 1].Status == "Alive") return 1;
            } catch (Exception e) {
                return 0;
            }
            return 0;
        }

        public string GetStringFromBoard() {
            DateTime dateTime = DateTime.Now;
            string description = dateTime.ToString("g") + "\n";
            for (int i = 0; i < Table.GetLength(0); i++) {
                for (int j = 0; j < Table.GetLength(1); j++) {
                    description += Table[i, j].Status + "\t";
                }
                description = description.Trim() + "\n";
            }
            return description.Trim();
        }
    }
}
