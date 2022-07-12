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
                    if (board.piece(new Position(i, j)) == null) {
                        Console.Write("- ");
                    } else {
                        printPiece(board.piece(new Position(i, j)));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   A B C D E F G H");
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece) {
            if(piece.color == Color.White) {
                Console.Write(piece);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
