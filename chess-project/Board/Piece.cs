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
        public Board board { get; protected set; }

        public Piece(Position pos, Color color, Board board) {
            this.pos = pos;
            this.color = color;
            this.board = board;
            this.moviments = 0;
        }

    }
}
