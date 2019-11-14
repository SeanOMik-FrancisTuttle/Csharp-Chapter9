using System;

using static System.Console;

namespace TilingDemo {
    class Room {
        private double floor;
        private const double BOX_SQUARE_FOOT = 12; // 12 full square feet
        private double squareFootage;

        public Room(double length, double width) {
            this.length = length;
            this.width = width;
            squareFootage = length * width;

            numberOfBoxes = squareFootage / 12;
            if (squareFootage % 12 != 0) numberOfBoxes += squareFootage % 12;
        }

        public double length { get; private set; }
        public double width { get; private set; }
        public double numberOfBoxes { get; private set; }
    }
    class Program {
        static void Main(string[] args) {
            Room room = new Room(12, 12);
            WriteLine("Length: {0, 3} - Width: {1, 3} | Needed amount of boxes: {2, 3}", room.length, room.width, room.numberOfBoxes);
        }
    }
}
