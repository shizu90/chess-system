using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_project.Board {
    internal class ChessBoard {
        public int rows { get; set; }
        public int cols { get; set; }
        private Piece[,] pieces;

        public ChessBoard(int rows, int cols) {
            this.rows = rows;
            this.cols = cols;
            this.pieces = new Piece[rows, cols];
        }

        public Piece piece(int row, int col) {
            return pieces[row, col];
        }
    }
}
