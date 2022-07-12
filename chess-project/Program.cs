using chess_project.Board;
using chess_project.Rules;

namespace chess_project {
    class Program { 
        static void Main(string[] args) {
            ChessBoard board = new ChessBoard(8, 8);
            try {
                board.putPiece(new King(board, Color.Black), new Position(0, 0));
                BoardBuilder.printBoard(board);
            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
