using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;
using chess_project.Rules;

namespace chess_project.Rules {
    internal class Queen: Piece {
        public Queen(ChessBoard board, Color color) : base(color, board) {

        }

        public override string ToString() {
            return "Q";
        }

        private bool canMove(Position pos) {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.rows, board.cols];

            Position pos = new Position(0, 0);

            //west
            pos.defineValue(this.pos.row, this.pos.col - 1);
            while(this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if(this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row, pos.col - 1);
            }

            //east
            pos.defineValue(this.pos.row, this.pos.col + 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row, pos.col + 1);
            }

            //north
            pos.defineValue(this.pos.row - 1, this.pos.col);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row - 1, pos.col);
            }

            //south 
            pos.defineValue(this.pos.row + 1, this.pos.col);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row + 1, pos.col);
            }

            //northwest
            pos.defineValue(this.pos.row - 1, this.pos.col - 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row - 1, pos.col - 1);
            }

            //northeast
            pos.defineValue(this.pos.row - 1, this.pos.col + 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row - 1, pos.col + 1);
            }

            //southwest
            pos.defineValue(this.pos.row + 1, this.pos.col + 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row + 1, pos.col + 1);
            }

            //southeast
            pos.defineValue(this.pos.row + 1, this.pos.col - 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != color) {
                    break;
                }

                pos.defineValue(pos.row + 1, pos.col - 1);
            }

            return mat;
        }
    }
}
