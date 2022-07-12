using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_project.Board {
    internal abstract class Piece {
        public Position pos { get; set; }
        public Color color { get; protected set; }
        public int moviments { get; protected set; }
        public ChessBoard board { get; protected set; }

        public Piece(Color color, ChessBoard board) {
            this.pos = null;
            this.color = color;
            this.board = board;
            this.moviments = 0;
        }

        public abstract bool[,] possibleMoviments();
        
        public void incrementMoviments() {
            this.moviments++;
        }

        public bool existsPossibleMoviments() {
            bool[,] mat = possibleMoviments();
            for(int i=0;i<this.board.rows;i++) {
                for(int j = 0; j < this.board.cols; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos) {
            return this.possibleMoviments()[pos.row, pos.col];
        }

    }
}
