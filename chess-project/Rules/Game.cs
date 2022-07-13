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
        private HashSet<Piece> pieces;
        private HashSet<Piece> catchedPieces;

        public Game() {
            this.board = new ChessBoard(8, 8);
            this.turn = 1;
            this.currentPlayer = Color.White;
            this.finished = false;
            this.pieces = new HashSet<Piece>();
            this.catchedPieces = new HashSet<Piece>();
            putPieces();
        }

        public void makeMoviment(Position origin, Position destiny) {
            Piece piece = board.removePiece(origin);
            piece.incrementMoviments();
            Piece catchPiece = board.removePiece(destiny);
            board.putPiece(piece, destiny);
            if(catchPiece != null) {
                this.catchedPieces.Add(catchPiece);
            }
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

        public HashSet<Piece> getCatchedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in this.catchedPieces) {
                if(x.color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in this.pieces) {
                if(x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(this.getCatchedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int row, Piece piece) {
            this.board.putPiece(piece, new ChessPosition(column, row).toMatrixPosition());
            this.pieces.Add(piece);
        }

        private void putPieces() {
            this.putNewPiece('a', 1, new Rook(this.board, Color.White));
            this.putNewPiece('h', 1, new Rook(this.board, Color.White));
            this.putNewPiece('a', 8, new Rook(this.board, Color.Black));
            this.putNewPiece('h', 8, new Rook(this.board, Color.Black));
            this.putNewPiece('d', 1, new King(this.board, Color.White));
            this.putNewPiece('d', 8, new King(this.board, Color.Black));
        }
    
    }
}
