using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;
using chess_project.Rules;

namespace chess_project.Rules {
    internal class Pawn: Piece {

        private Game chessGame;

        public Pawn(ChessBoard board, Color color, Game chessGame) : base(color, board) {
            this.chessGame = chessGame;
        }

        private bool existsEnemy(Position pos) {
            Piece piece = board.piece(pos);
            return piece != null && piece.color != this.color;
        }

        private bool free(Position pos) {
            return this.board.piece(pos) == null;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.rows, board.cols];

            Position pos = new Position(0, 0);
            if (this.color == Color.White) {
                pos.defineValue(this.pos.row - 1, this.pos.col);
                if (this.board.validPosition(pos) && free(pos)) {
                    Console.Write(pos.row);
                    mat[pos.row, pos.col] = true;
                }
                pos.defineValue(this.pos.row - 2, this.pos.col);
                if (this.board.validPosition(pos) && free(pos) && this.moviments == 0) {
                    mat[pos.row, pos.col] = true;
                }
                pos.defineValue(this.pos.row - 1, this.pos.col - 1);
                if (this.board.validPosition(pos) && existsEnemy(pos)) {
                    mat[pos.row, pos.col] = true;
                }
                pos.defineValue(this.pos.row - 1, this.pos.col + 1);
                if (this.board.validPosition(pos) && existsEnemy(pos)) {
                    mat[pos.row, pos.col] = true;
                }

                //#enPassant
                if(this.pos.row == 3) {
                    Position left = new Position(this.pos.row, this.pos.col - 1);
                    if (board.validPosition(left) && existsEnemy(left) && board.piece(left) == chessGame.enPassantVulnerability) {
                        mat[left.row - 1, left.col] = true;
                    }
                    Position right = new Position(this.pos.row, this.pos.col + 1);
                    if (board.validPosition(right) && existsEnemy(right) && board.piece(right) == chessGame.enPassantVulnerability) {
                        mat[right.row - 1, right.col] = true;
                    }
                }
            } else {
                pos.defineValue(this.pos.row + 1, this.pos.col);
                if (this.board.validPosition(pos) && free(pos)) {
                    mat[pos.row, pos.col] = true;
                }
                pos.defineValue(this.pos.row + 2, this.pos.col);
                if (this.board.validPosition(pos) && free(pos) && this.moviments == 0) {
                    mat[pos.row, pos.col] = true;
                }
                pos.defineValue(this.pos.row + 1, this.pos.col + 1);
                if (this.board.validPosition(pos) && existsEnemy(pos)) {
                    mat[pos.row, pos.col] = true;
                }
                pos.defineValue(this.pos.row + 1, this.pos.col - 1);
                if (this.board.validPosition(pos) && existsEnemy(pos)) {
                    mat[pos.row, pos.col] = true;
                }
                //#enPassant
                if (this.pos.row == 4) {
                    Position left = new Position(this.pos.row, this.pos.col - 1);
                    if (board.validPosition(left) && existsEnemy(left) && board.piece(left) == chessGame.enPassantVulnerability) {
                        mat[left.row + 1, left.col] = true;
                    }
                    Position right = new Position(this.pos.row, this.pos.col + 1);
                    if (board.validPosition(right) && existsEnemy(right) && board.piece(right) == chessGame.enPassantVulnerability) {
                        mat[right.row + 1, right.col] = true;
                    }
                }
            }
            
            return mat;
        }
        public override string ToString() {
            return "P";
        }
    }
}
