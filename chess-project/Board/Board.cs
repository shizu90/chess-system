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

        public Piece piece(Position pos) {
            return pieces[pos.row, pos.col];
        }

        public bool pieceExists(Position pos) {
            checkPosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece piece, Position pos) {
            if (pieceExists(pos)) throw new BoardException("Piece already exists in that position");
            this.pieces[pos.row, pos.col] = piece;
            piece.pos = pos;
        }

        public void removePiece(Piece piece, Position pos) {
            this.pieces[pos.row, pos.col] = null;
            piece.pos = null;
        }

        public bool validPosition(Position pos) {
            if(pos.row < 0 || pos.row >= this.rows || pos.col < 0 || pos.col >= this.cols) return false;
            return true;
        }

        public void checkPosition(Position pos) {
            if (!validPosition(pos)) throw new BoardException("Invalid position");
        }
    }
}
