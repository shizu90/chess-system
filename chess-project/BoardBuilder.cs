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
                for(int j=0; j < board.cols; j++) {
                    if (board.piece(i, j) == null) Console.Write("- ");
                    Console.Write(board.piece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
