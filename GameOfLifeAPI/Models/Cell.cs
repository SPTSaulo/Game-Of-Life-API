using System;

namespace GameOfLifeAPI.Models {
    public class Cell {
        public String Status { get; set; }
        public Cell(String status) {
            this.Status = status;
        }
    }
}
