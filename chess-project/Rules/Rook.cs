using chess_project.Board;

namespace chess_project.Rules {
    internal class Rook: Piece {
        public Rook(ChessBoard board, Color color): base(color, board) {

        }

        private bool canMove(Position pos) {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.rows, board.cols];

            Position pos = new Position(0, 0);

            //north's tile
            pos.defineValue(this.pos.row - 1, this.pos.col);
            while(board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if(board.piece(pos) != null && board.piece(pos).color != this.color) {
                    break;
                }
                pos.row = pos.row - 1;
            }

            //south's tile
            pos.defineValue(this.pos.row + 1, this.pos.col);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) {
                    break;
                }
                pos.row = pos.row + 1;
            }

            //east's tile
            pos.defineValue(this.pos.row, this.pos.col + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) {
                    break;
                }
                pos.col = pos.col + 1;
            }

            //west's tile
            pos.defineValue(this.pos.row, this.pos.col - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) {
                    break;
                }
                pos.col = pos.col - 1;
            }

            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
