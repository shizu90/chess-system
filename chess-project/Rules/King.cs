using chess_project.Board;

namespace chess_project.Rules {
    internal class King: Piece {
        public King(ChessBoard board, Color color) : base(color, board) {

        }

        public override string ToString() {
            return "K";
        }
    }
}
