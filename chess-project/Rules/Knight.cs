using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;
using chess_project.Rules;

namespace chess_project.Rules {
    internal class Knight: Piece {
        public Knight(ChessBoard board, Color color) : base(color, board) {

        }

        private bool canMove(Position pos) {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.rows, board.cols];

            Position pos = new Position(0, 0);

            pos.defineValue(this.pos.row - 1, this.pos.col - 2);
            if(this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row - 2, this.pos.col - 1);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row - 2, this.pos.col + 1);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row - 1, this.pos.col + 2);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row + 1, this.pos.col + 2);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row + 2, this.pos.col + 1);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row + 2, this.pos.col - 1);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            pos.defineValue(this.pos.row + 1, this.pos.col - 2);
            if (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            return mat;

        }
        public override string ToString() {
            return "N";
        }
    }
}

