using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;
using chess_project.Rules;

namespace chess_project.Rules {
    internal class Bishop: Piece {
        public Bishop(ChessBoard board, Color color) : base(color, board) {

        }

        private bool canMove(Position pos) {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.rows, board.cols];

            Position pos = new Position(0, 0);

            // northwest's tile
            pos.defineValue(this.pos.row - 1, this.pos.col - 1);
            while(this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if(this.board.piece(pos) != null && this.board.piece(pos).color != this.color) {
                    break;
                }
                pos.defineValue(pos.row - 1, pos.col - 1);
            }

            // northeast's tile
            pos.defineValue(this.pos.row - 1, this.pos.col + 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != this.color) {
                    break;
                }
                pos.defineValue(pos.row - 1, pos.col + 1);
            }

            // southwest's tile
            pos.defineValue(this.pos.row + 1, this.pos.col + 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != this.color) {
                    break;
                }
                pos.defineValue(pos.row + 1, pos.col + 1);
            }

            // southeast's tile
            pos.defineValue(this.pos.row + 1, this.pos.col - 1);
            while (this.board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (this.board.piece(pos) != null && this.board.piece(pos).color != this.color) {
                    break;
                }
                pos.defineValue(pos.row + 1, pos.col - 1);
            }

            return mat;

        }
        public override string ToString() {
            return "B";
        }
    }
}
