using chess_project.Board;

namespace chess_project.Rules {
    internal class King: Piece {

        private Game chessGame;

        public King(ChessBoard board, Color color, Game chessGame) : base(color, board) {
            this.chessGame = chessGame;
        }

        public override string ToString() {
            return "K";
        }

        private bool canMove(Position pos) {
            Piece piece = board.piece(pos);
            return piece == null || piece.color != this.color;
        }

        private bool rookCastle(Position pos) {
            Piece piece = this.board.piece(pos);
            return piece != null && piece is Rook && piece.color == this.color && piece.moviments == 0;
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

            // castle special play
            if(this.moviments == 0 && !chessGame.checkmate) {
                //castle kingside
                Position positionRookKingside = new Position(this.pos.row, this.pos.col + 2);
                if(rookCastle(positionRookKingside)) {
                    Position pos1 = new Position(this.pos.row, this.pos.col + 1);
                    Position pos2 = new Position(this.pos.row, this.pos.col + 2);
                    if(this.board.piece(pos1) == null && this.board.piece(pos2) == null) {
                        mat[this.pos.row, this.pos.col + 2] = true;
                    }
                }
                //castle queenside
                Position positionRookQueenside = new Position(this.pos.row, this.pos.col - 3);
                if (rookCastle(positionRookQueenside)) {
                    Position pos1 = new Position(this.pos.row, this.pos.col - 1);
                    Position pos2 = new Position(this.pos.row, this.pos.col - 2);
                    Position pos3 = new Position(this.pos.row, this.pos.col - 3);
                    if (this.board.piece(pos1) == null && this.board.piece(pos2) == null && this.board.piece(pos3) == null) {
                        mat[this.pos.row, this.pos.col - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
