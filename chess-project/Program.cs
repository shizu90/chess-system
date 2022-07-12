using chess_project.Board;

namespace chess_project {
    class Program { 
        static void Main(string[] args) {
            ChessBoard board = new ChessBoard(8, 8);
            try {
                BoardBuilder.printBoard(board);
            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
