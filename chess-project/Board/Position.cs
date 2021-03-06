using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_project.Board {
    internal class Position {
        public int row { get; set; }
        public int col { get; set; }

        public Position(int row, int col) {
            this.row = row;
            this.col = col;
        }

        public void defineValue(int row, int column) {
            this.row = row;
            this.col = column;
        }

        public override string ToString() {
            return this.row
                + ", "
                + this.col;
        }
    }
}
