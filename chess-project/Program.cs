using chess_project.Board;

namespace chess_project {
    class Program { 
        static void Main(string[] args) {
            ChessBoard board = new ChessBoard(8, 8);

            BoardBuilder.printBoard(board);

            Console.ReadLine();
        }
    }
}
