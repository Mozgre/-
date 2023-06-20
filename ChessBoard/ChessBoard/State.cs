namespace ChessBoard
{
    public enum State
    {
        Empty,       // пусто
        WhiteKing,   // король
        WhiteQueen,  // ферзь
        WhiteRook,   // ладья
        WhiteKnight, // конь
        WhiteBishop, // слон
        WhitePawn,   // пешка
        BlackKing,
        BlackQueen,
        BlackRook,
        BlackKnight,
        BlackBishop,
        BlackPawn,
        Active,
    }
    public static class StateExtensions
    {
        public static bool IsWhite(this State state)
        {
            return state switch
            {
                State.WhiteKing or State.WhiteQueen or State.WhiteRook or
                State.WhiteKnight or State.WhiteBishop or State.WhitePawn => true,
                _ => false
            };
        }

        public static bool IsBlack(this State state)
        {
            return state switch
            {
                State.BlackKing or State.BlackQueen or State.BlackRook or
                State.BlackKnight or State.BlackBishop or State.BlackPawn => true,
                _ => false
            };
        }
    }
}