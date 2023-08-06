using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Board.PlayerTurn = 1;
            PopulateBoard();
        }

        private void PopulateBoard() {
            A1.Content = "Rook"; A1.Foreground = Brushes.White;
            A2.Content = "Knight"; A2.Foreground = Brushes.White;
            A3.Content = "Bishop"; A3.Foreground = Brushes.White;
            A4.Content = "Queen"; A4.Foreground = Brushes.White;
            A5.Content = "King"; A5.Foreground = Brushes.White;
            A6.Content = "Bishop"; A6.Foreground = Brushes.White;
            A7.Content = "Knight"; A7.Foreground = Brushes.White;
            A8.Content = "Rook"; A8.Foreground = Brushes.White;

            B1.Content = "Pawn"; B1.Foreground = Brushes.White;
            B2.Content = "Pawn"; B2.Foreground = Brushes.White;
            B3.Content = "Pawn"; B3.Foreground = Brushes.White;
            B4.Content = "Pawn"; B4.Foreground = Brushes.White;
            B5.Content = "Pawn"; B5.Foreground = Brushes.White;
            B6.Content = "Pawn"; B6.Foreground = Brushes.White;
            B7.Content = "Pawn"; B7.Foreground = Brushes.White;
            B8.Content = "Pawn"; B8.Foreground = Brushes.White;

            G1.Content = "Pawn"; G1.Foreground = Brushes.Black;
            G2.Content = "Pawn"; G2.Foreground = Brushes.Black;
            G3.Content = "Pawn"; G3.Foreground = Brushes.Black;
            G4.Content = "Pawn"; G4.Foreground = Brushes.Black;
            G5.Content = "Pawn"; G5.Foreground = Brushes.Black;
            G6.Content = "Pawn"; G6.Foreground = Brushes.Black;
            G7.Content = "Pawn"; G7.Foreground = Brushes.Black;
            G8.Content = "Pawn"; G8.Foreground = Brushes.Black;

            H1.Content = "Rook"; H1.Foreground = Brushes.Black;
            H2.Content = "Knight"; H2.Foreground = Brushes.Black;
            H3.Content = "Bishop"; H3.Foreground = Brushes.Black;
            H4.Content = "Queen"; H4.Foreground = Brushes.Black;
            H5.Content = "King"; H5.Foreground = Brushes.Black;
            H6.Content = "Bishop"; H6.Foreground = Brushes.Black;
            H7.Content = "Knight"; H7.Foreground = Brushes.Black;
            H8.Content = "Rook"; H8.Foreground = Brushes.Black;
        }

        private void Tile_Click(object sender, RoutedEventArgs e) {

            string selectionName = (string)((System.Windows.FrameworkElement)e.Source).Name;
            Button? tile = e.Source as Button;
            Brush pieceColor = tile.Foreground;

            BoardToXY(selectionName);

            if (Board.selectedPiece == null) {
                bool occupied = TileIsOccupied(tile);
                if (occupied) {
                    int owner = CheckPiecePlayer(tile);
                    if (owner == Board.PlayerTurn) {
                        Board.selectedPiece = new Board();

                        Board.selectedPiece.type = (string)tile.Content;
                        Board.selectedPiece.color = pieceColor;
                        Board.selectedPiece.MoveFrom = new int[] { Board.TileX, Board.TileY };
                        Board.selectedPiece.BoardMoveFrom = tile;
                    }
                }
            } else {
                Board.selectedPiece.MoveTo = new int[] { Board.TileX, Board.TileY };
                Board.selectedPiece.BoardMoveTo = tile;
                MovePiece(Board.selectedPiece);
            }
        }

        private int CheckPiecePlayer(Button tile) {
            Brush pieceColor = tile.Foreground;

            if (pieceColor == Brushes.Black) {
                return 1;
            } else {
                return 2;
            }
        }

        private bool TileIsOccupied(Button tile) {
            if (string.IsNullOrEmpty((string)tile.Content)) {
                return false;
            } else {
                return true;
            }
        }

        static void MovePiece(Board piece) {
            Board.selectedPiece.BoardMoveFrom.Content = "";
            Board.selectedPiece.BoardMoveTo.Content = piece.type;
            Board.selectedPiece.BoardMoveTo.Foreground = Board.selectedPiece.color;

            Board.selectedPiece = null;
            SwitchPlayer();
        }

        static void BoardToXY(string boardTile) {

            char[] xPos = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            for (int i = 0; i < xPos.Length; i++) {
                if (boardTile[0] == xPos[i]) {
                    Board.TileX = i;
                }
            }

            char yChar = boardTile[1];
            string toParse = "";
            toParse += yChar;

            bool parser = int.TryParse(toParse, out int yTile);
            Board.TileY = yTile - 1;
        }

        static void XYToBoard(int[] coord) {
            string board = "";
            char[] xPos = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            for (int i = 0; i < xPos.Length; i++) {
                if (coord[0] == i) {
                    board += xPos[i];
                }
            }
            board += coord[1];

        }

        static void SwitchPlayer() {
            if (Board.PlayerTurn == 1) {
                Board.PlayerTurn = 2;
            } else {
                Board.PlayerTurn = 1;
            }
        }
    }
}