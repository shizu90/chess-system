using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_project.Board;

namespace chess_project {
    internal class BoardBuilder {
        public static void printBoard(ChessBoard board) {
            for(int i=0; i < board.rows; i++) {
                Console.Write(8 - i + "| ");
                for(int j=0; j < board.cols; j++) {
                    printPiece(board.piece(new Position(i, j)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   A B C D E F G H");
        }

        public static void printBoardMoviments(ChessBoard board, bool[,] possiblePositions) {

            ConsoleColor originBack = Console.BackgroundColor;
            ConsoleColor alterBack = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < board.cols; j++) {
                    if (possiblePositions[i,j]) {
                        Console.BackgroundColor = alterBack;
                    }else {
                        Console.BackgroundColor = originBack;
                    }

                    printPiece(board.piece(new Position(i, j)));
                    Console.BackgroundColor = originBack;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   A B C D E F G H");
            Console.BackgroundColor = originBack;
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece) {
            if(piece == null) {
                Console.Write("- ");
            } else {
                if (piece.color == Color.White) {
                    Console.Write(piece);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
