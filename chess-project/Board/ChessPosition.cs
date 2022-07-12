using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_project.Board {
    internal class ChessPosition {
        public char column { get; set; }
        public int row { get; set; }

        public ChessPosition(char column, int row) {
            this.column = column;
            this.row = row;
        }

        public Position toMatrixPosition() {
            return new Position(8 - this.row, this.column - 'a');
        }

        public override string ToString() {
            return "" + this.column + this.row;
        }
    }
}
