using chess_project.Board;
using chess_project.Rules;

namespace chess_project {
    class Program { 
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try {
                Game chessGame = new Game();

                while (!chessGame.finished) {
                    try {
                        Console.Clear();
                        BoardBuilder.printChessGame(chessGame);
                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = BoardBuilder.readChessPosition().toMatrixPosition();
                        chessGame.validateOriginPosition(origin);
                        bool[,] possiblePositions = chessGame.board.piece(origin).possibleMoviments();

                        Console.Clear();
                        BoardBuilder.printBoardMoviments(chessGame.board, possiblePositions);
                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = BoardBuilder.readChessPosition().toMatrixPosition();
                        chessGame.validateDestinyPosition(origin, destiny);

                        chessGame.executeTurn(origin, destiny);
                    }catch(BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                BoardBuilder.printChessGame(chessGame);

            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
