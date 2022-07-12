using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;

namespace chess_project.Rules {
    internal class Game {
        public ChessBoard board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public Game() {
            this.board = new ChessBoard(8, 8);
            this.turn = 1;
            this.currentPlayer = Color.White;
            this.finished = false;
            putPieces();
        }

        public void makeMoviment(Position origin, Position destiny) {
            Piece piece = board.removePiece(origin);
            piece.incrementMoviments();
            board.removePiece(destiny);
            Piece catchPiece = board.removePiece(destiny);
            board.putPiece(piece, destiny);
        }

        public void makeMove(Position origin, Position destiny) {
            makeMoviment(origin, destiny);
            this.turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) {
            if (this.board.piece(pos) == null) {
                throw new BoardException("Doesn't exists piece in chosen origin position");
            }
            if(this.currentPlayer != this.board.piece(pos).color) {
                throw new BoardException("That piece is not yours");
            }
            if(!this.board.piece(pos).existsPossibleMoviments()) {
                throw new BoardException("That piece is blocked");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) {
            if(!this.board.piece(origin).canMoveTo(destiny)) {
                throw new BoardException("Invalid destiny position");
            }
        }

        public void changePlayer() {
            if(this.currentPlayer == Color.White) {
                this.currentPlayer = Color.Black;
            } else {
                currentPlayer = Color.White;
            }
        }

        private void putPieces() {
            this.board.putPiece(new Rook(board, Color.White), new ChessPosition('a', 1).toMatrixPosition());
            this.board.putPiece(new Rook(board, Color.White), new ChessPosition('h', 1).toMatrixPosition());
            this.board.putPiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toMatrixPosition());
            this.board.putPiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toMatrixPosition());
            this.board.putPiece(new King(board, Color.White), new ChessPosition('d', 1).toMatrixPosition());
            this.board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).toMatrixPosition());
        }
    
    }
}
