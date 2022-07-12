using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;

namespace chess_project.Rules {
    internal class Game {
        public ChessBoard board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public Game() {
            this.board = new ChessBoard(8, 8);
            this.turn = 1;
            this.currentPlayer = Color.White;
            putPieces();
        }

        public void makeMoviment(Position origin, Position destiny) {
            Piece piece = board.removePiece(origin);
            piece.incrementMoviments();
            board.removePiece(destiny);
            Piece catchPiece = board.removePiece(destiny);
            board.putPiece(piece, destiny);
        }

        private void putPieces() {
            this.board.putPiece(new King(board, Color.White), new ChessPosition('a', 1).toMatrixPosition());
        }
    
    }
}
