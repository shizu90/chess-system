using chess_project.Board;

namespace chess_project.Rules {
    internal class King: Piece {
        public King(ChessBoard board, Color color) : base(color, board) {

        }

        public override string ToString() {
            return "K";
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
            if(board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            //northeast's tile
            pos.defineValue(this.pos.row - 1, this.pos.col + 1);
            if(board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            //east's tile
            pos.defineValue(this.pos.row, this.pos.col + 1);
            if(board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            //southeast's tile
            pos.defineValue(this.pos.row + 1, this.pos.col + 1);
            if(board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            //south's tile
            pos.defineValue(this.pos.row + 1, this.pos.col);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }
            //southwest's tile
            pos.defineValue(this.pos.row + 1, this.pos.col - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            //west's tile
            pos.defineValue(this.pos.row, this.pos.col - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            //northwest's tile
            pos.defineValue(this.pos.row - 1, this.pos.col - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.col] = true;
            }

            return mat;
        }
    }
}
