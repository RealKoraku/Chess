using Microsoft.VisualBasic;
using System.Windows.Controls;
using System.Windows.Media;

class Board {
    public static Board selectedPiece { get; set; }
    public static int TileX { get; set; }
    public static int TileY { get; set; }
    public static int PlayerTurn { get; set; }

    public string type;
    public Brush color;
    public int[] MoveFrom;
    public int[] MoveTo;
    public Button BoardMoveFrom;
    public Button BoardMoveTo;

    public void GetColor() {
        if (PlayerTurn == 1) {
            Board.selectedPiece.color = Brushes.Black;
        } else {
            Board.selectedPiece.color = Brushes.White;
        }
    }
}