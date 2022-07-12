using chess_project.Board;
using chess_project.Rules;

namespace chess_project {
    class Program { 
        static void Main(string[] args) {
            try {
                Game chessGame = new Game();

                while (!chessGame.finished) {
                    Console.Clear();
                    BoardBuilder.printBoard(chessGame.board);

                    Console.Write("Origin: ");
                    Position origin = BoardBuilder.readChessPosition().toMatrixPosition();
                    Console.Write("Destiny: ");
                    Position destiny = BoardBuilder.readChessPosition().toMatrixPosition();

                    chessGame.makeMoviment(origin, destiny);
                }

            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
