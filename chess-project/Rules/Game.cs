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
        public bool checkmate { get; private set; }

        public Game() {
            this.board = new ChessBoard(8, 8);
            this.turn = 1;
            this.currentPlayer = Color.White;
            this.finished = false;
            this.checkmate = false;
            this.pieces = new HashSet<Piece>();
            this.catchedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Piece makeMoviment(Position origin, Position destiny) {
            Piece p = board.removePiece(origin);
            p.incrementMoviments();
            Piece catchedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if (catchedPiece != null) {
                catchedPieces.Add(catchedPiece);
            }

            // #jogadaespecial roque pequeno
            if (p is King && destiny.col == origin.col + 2) {
                Position originRook = new Position(origin.row, origin.col + 3);
                Position destinyRook = new Position(origin.row, origin.col + 1);
                Piece Rook = board.removePiece(originRook);
                Rook.incrementMoviments();
                board.putPiece(Rook, destinyRook);
            }

            // #jogadaespecial roque grande
            if (p is King && destiny.col == origin.col - 2) {
                Position originRook = new Position(origin.row, origin.col - 4);
                Position destinyRook = new Position(origin.row, origin.col - 1);
                Piece Rook = board.removePiece(originRook);
                Rook.incrementMoviments();
                board.putPiece(Rook, destinyRook);
            }

            // #jogadaespecial en passant
            /*if (p is Peao) {
                if (origem.coluna != destino.coluna && pecaCapturada == null) {
                    Posicao posP;
                    if (p.cor == Cor.Branca) {
                        posP = new Posicao(destino.linha + 1, destino.coluna);
                    } else {
                        posP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    pecaCapturada = tab.retirarPeca(posP);
                    capturadas.Add(pecaCapturada);
                }
            }*/

            return catchedPiece;
        }

        public void undoMoviment(Position origin, Position destiny, Piece catchedPiece) {
            Piece piece = board.removePiece(destiny);
            piece.decrementMoviments();
            if (catchedPiece != null) {
                board.putPiece(catchedPiece, destiny);
                catchedPieces.Remove(catchedPiece);
            }
            board.putPiece(piece, origin);

            // #jogadaespecial roque pequeno
            if (piece is King && destiny.col == origin.col + 2) {
                Position originRook = new Position(origin.row, origin.col + 3);
                Position destinyRook = new Position(origin.row, origin.col + 1);
                Piece Rook = board.removePiece(destinyRook);
                Rook.decrementMoviments();
                board.putPiece(Rook, originRook);
            }

            // #jogadaespecial roque grande
            if (piece is King && destiny.col == origin.col - 2) {
                Position originRook = new Position(origin.row, origin.col - 4);
                Position destinyRook = new Position(origin.row, origin.col - 1);
                Piece Rook = board.removePiece(destinyRook);
                Rook.decrementMoviments();
                board.putPiece(Rook, originRook);
            }

            // #jogadaespecial en passant
            /*if (p is Peao) {
                if (origem.coluna != destino.coluna && pecaCapturada == vulneravelEnPassant) {
                    Peca peao = tab.retirarPeca(destino);
                    Posicao posP;
                    if (p.cor == Cor.Branca) {
                        posP = new Posicao(3, destino.coluna);
                    } else {
                        posP = new Posicao(4, destino.coluna);
                    }
                    tab.colocarPeca(peao, posP);
                }
            }*/
        }

        public void executeTurn(Position origin, Position destiny) {
            Piece catchedPiece = makeMoviment(origin, destiny);

            if (isInCheck(currentPlayer)) {
                undoMoviment(origin, destiny, catchedPiece);
                throw new BoardException("Already in check or will be in check");
            }

            Piece piece = board.piece(destiny);

            // #jogadaespecial promocao
            /*if (p is Peao) {
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7)) {
                    p = tab.retirarPeca(destino);
                    pecas.Remove(p);
                    Peca dama = new Dama(tab, p.cor);
                    tab.colocarPeca(dama, destino);
                    pecas.Add(dama);
                }
            }*/

            if (isInCheck(adversary(currentPlayer))) {
                checkmate = true;
            } else {
                checkmate = false;
            }

            if (testCheckmate(adversary(currentPlayer))) {
                finished = true;
            } else {
                turn++;
                changePlayer();
            }

            // #jogadaespecial en passant
            /*if (p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2)) {
                vulneravelEnPassant = p;
            } else {
                vulneravelEnPassant = null;
            }*/

        }

        public void validateOriginPosition(Position pos) {
            if (board.piece(pos) == null) {
                throw new BoardException("Dont exists a piece in that position");
            }
            if (currentPlayer != board.piece(pos).color) {
                throw new BoardException("That piece is not yours");
            }
            if (!board.piece(pos).existsPossibleMoviments()) {
                throw new BoardException("That piece is blocked");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) {
            if (!board.piece(origin).canMoveTo(destiny)) {
                throw new BoardException("Invalid destiny position");
            }
        }

        private void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
            } else {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> manipulateCatchedPieces(Color color) {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece i in catchedPieces) {
                if (i.color == color) {
                    temp.Add(i);
                }
            }
            return temp;
        }

        public HashSet<Piece> piecesInGame(Color color) {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece i in pieces) {
                if (i.color == color) {
                    temp.Add(i);
                }
            }
            temp.ExceptWith(manipulateCatchedPieces(color));
            return temp;
        }

        private Color adversary(Color color) {
            if (color == Color.White) {
                return Color.Black;
            } else {
                return Color.White;
            }
        }

        private Piece King(Color color) {
            foreach (Piece i in piecesInGame(color)) {
                if (i is King) {
                    return i;
                }
            }
            return null;
        }

        public bool isInCheck(Color color) {
            Piece k = King(color);
            if (k == null) {
                throw new BoardException("Dont exists " + color + " King in game");
            }
            foreach (Piece i in piecesInGame(adversary(color))) {
                bool[,] mat = i.possibleMoviments();
                if (mat[k.pos.row, k.pos.col]) {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckmate(Color color) {
            if (!isInCheck(color)) {
                return false;
            }
            foreach (Piece x in piecesInGame(color)) {
                bool[,] mat = x.possibleMoviments();
                for (int i = 0; i < board.rows; i++) {
                    for (int j = 0; j < board.cols; j++) {
                        if (mat[i, j]) {
                            Position origin = x.pos;
                            Position destiny = new Position(i, j);
                            Piece catchedPiece = makeMoviment(origin, destiny);
                            bool testCheck = isInCheck(color);
                            undoMoviment(origin, destiny, catchedPiece);
                            if (!testCheck) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char col, int row, Piece piece) {
            board.putPiece(piece, new ChessPosition(col, row).toMatrixPosition());
            pieces.Add(piece);
        }

        private void putPieces() {
            putNewPiece('a', 1, new Rook(board, Color.White));
            putNewPiece('b', 1, new Knight(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White, this));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Knight(board, Color.White));
            putNewPiece('h', 1, new Rook(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White));
            putNewPiece('b', 2, new Pawn(board, Color.White));
            putNewPiece('c', 2, new Pawn(board, Color.White));
            putNewPiece('d', 2, new Pawn(board, Color.White));
            putNewPiece('e', 2, new Pawn(board, Color.White));
            putNewPiece('f', 2, new Pawn(board, Color.White));
            putNewPiece('g', 2, new Pawn(board, Color.White));
            putNewPiece('h', 2, new Pawn(board, Color.White));

            putNewPiece('a', 8, new Rook(board, Color.Black));
            putNewPiece('b', 8, new Knight(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Knight(board, Color.Black));
            putNewPiece('h', 8, new Rook(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black));
            putNewPiece('b', 7, new Pawn(board, Color.Black));
            putNewPiece('c', 7, new Pawn(board, Color.Black));
            putNewPiece('d', 7, new Pawn(board, Color.Black));
            putNewPiece('e', 7, new Pawn(board, Color.Black));
            putNewPiece('f', 7, new Pawn(board, Color.Black));
            putNewPiece('g', 7, new Pawn(board, Color.Black));
            putNewPiece('h', 7, new Pawn(board, Color.Black));
        }

    }
}
