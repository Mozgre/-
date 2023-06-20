using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using ChessBoard;
namespace ChessBoard
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private Board _board = new();
        private bool whiteTurn = true;
        private ICommand _newGameCommand;
        private ICommand _clearCommand;
        private ICommand _cellCommand;
        public IEnumerable<char> Numbers => "87654321";
        public IEnumerable<char> Letters => "ABCDEFGH";
        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewGameCommand => _newGameCommand ??= new RelayCommand(parameter =>
        {
            SetupBoard();
        });

        public ICommand ClearCommand => _clearCommand ??= new RelayCommand(parameter =>
        {
            Board = new();
        });

        public ICommand CellCommand => _cellCommand ??= new RelayCommand(parameter =>
        {
            Cell cell = (Cell)parameter;
            Cell activeCell = Board.FirstOrDefault(x => x.Active);
            if (cell.State != State.Empty)
            {
                if (!cell.Active && activeCell != null)
                    activeCell.Active = false;
                cell.Active = !cell.Active;

            }
            //Смена ходов и логика проверки ходов
            if ((whiteTurn && activeCell != null && activeCell.State.IsWhite()) || (!whiteTurn && activeCell != null && activeCell.State.IsBlack()))
            {
                if (activeCell.State is State.BlackPawn & cell.State != activeCell.State & cell.State != State.BlackBishop & cell.State != State.BlackKing & cell.State != State.BlackQueen & cell.State != State.BlackKnight & cell.State != State.WhiteRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.BlackBishop & cell.State != activeCell.State & cell.State != State.BlackPawn & cell.State != State.BlackKing & cell.State != State.BlackQueen & cell.State != State.BlackKnight & cell.State != State.BlackRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.BlackKing & cell.State != activeCell.State & cell.State != State.BlackBishop & cell.State != State.BlackPawn & cell.State != State.BlackQueen & cell.State != State.BlackKnight & cell.State != State.BlackRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.BlackKnight & cell.State != activeCell.State & cell.State != State.BlackBishop & cell.State != State.BlackKing & cell.State != State.BlackQueen & cell.State != State.BlackPawn & cell.State != State.BlackRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.BlackRook & cell.State != activeCell.State & cell.State != State.BlackBishop & cell.State != State.BlackKing & cell.State != State.BlackQueen & cell.State != State.BlackKnight & cell.State != State.BlackPawn)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.BlackQueen & cell.State != activeCell.State & cell.State != State.BlackBishop & cell.State != State.BlackKing & cell.State != State.BlackPawn & cell.State != State.BlackKnight & cell.State != State.BlackRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.WhitePawn & cell.State != activeCell.State & cell.State != State.WhiteBishop & cell.State != State.WhiteKing & cell.State != State.WhiteQueen & cell.State != State.WhiteKnight & cell.State != State.WhiteRook)
                {
                        cell.State = activeCell.State;
                        activeCell.State = State.Empty;
                        activeCell.Active = false;
                        whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.WhiteBishop & cell.State != activeCell.State & cell.State != State.WhitePawn & cell.State != State.WhiteKing & cell.State != State.WhiteQueen & cell.State != State.WhiteKnight & cell.State != State.WhiteRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.WhiteKing & cell.State != activeCell.State & cell.State != State.WhiteBishop & cell.State != State.WhitePawn & cell.State != State.WhiteQueen & cell.State != State.WhiteKnight & cell.State != State.WhiteRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.WhiteKnight & cell.State != activeCell.State & cell.State != State.WhiteBishop & cell.State != State.WhiteKing & cell.State != State.WhiteQueen & cell.State != State.WhitePawn & cell.State != State.WhiteRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
                if (activeCell.State is State.WhiteQueen & cell.State != activeCell.State & cell.State != State.WhiteBishop & cell.State != State.WhiteKing & cell.State != State.WhitePawn & cell.State != State.WhiteKnight & cell.State != State.WhiteRook)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }

                if (activeCell.State is State.WhiteRook & cell.State != activeCell.State & cell.State != State.WhiteBishop & cell.State != State.WhiteKing & cell.State != State.WhiteQueen & cell.State != State.WhiteKnight & cell.State != State.WhitePawn)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                    activeCell.Active = false;
                    whiteTurn = !whiteTurn;
                }
            }
            else if (activeCell != null)
            {
                activeCell.Active = false;
            }
        }, parameter => parameter is Cell cell && (Board.Any(x => x.Active) || cell.State != State.Empty));
        public void SetupBoard()
        {
            whiteTurn = true;
            Board board = new();
            board[0, 0] = State.BlackRook;
            board[0, 1] = State.BlackKnight;
            board[0, 2] = State.BlackBishop;
            board[0, 3] = State.BlackQueen;
            board[0, 4] = State.BlackKing;
            board[0, 5] = State.BlackBishop;
            board[0, 6] = State.BlackKnight;
            board[0, 7] = State.BlackRook;

            for (int i = 0; i < 8; i++)
            {
                board[1, i] = State.BlackPawn;
                board[6, i] = State.WhitePawn;
            }
            board[7, 0] = State.WhiteRook;
            board[7, 1] = State.WhiteKnight;
            board[7, 2] = State.WhiteBishop;
            board[7, 3] = State.WhiteQueen;
            board[7, 4] = State.WhiteKing;
            board[7, 5] = State.WhiteBishop;
            board[7, 6] = State.WhiteKnight;
            board[7, 7] = State.WhiteRook;
            Board = board;

        }
        public MainViewModel()
        {

        }
    }
}