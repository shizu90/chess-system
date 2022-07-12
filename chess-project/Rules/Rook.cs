using chess_project.Board;

namespace chess_project.Rules {
    internal class Rook: Piece {
        public Rook(ChessBoard board, Color color): base(color, board) {

        }

        public override string ToString() {
            return "R";
        }
    }
}
