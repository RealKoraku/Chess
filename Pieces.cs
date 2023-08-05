class Board {
    public static Board selectedPiece { get; set; }
    public static int TileX { get; set; }
    public static int TileY { get; set; }
    public static int PlayerTurn { get; set; }

    public Board Pawn;
    public Board Rook;
    public Board Bishop;
    public Board Knight;
    public Board Queen;
    public Board King;
}