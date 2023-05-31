using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using ChessBoard;
namespace ChessBoard
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private Board _board = new();
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
            //Выбор фигуры
            if (cell.State != State.Empty)
            {
                if (!cell.Active && activeCell != null)
                    activeCell.Active = false;
                cell.Active = !cell.Active;
            }
            //Перемещение фигуры
            else if (activeCell != null)
            {
                activeCell.Active = false;
                //Ограничение на ход пешки
                if (activeCell.State == State.BlackPawn && cell.RowIndex == activeCell.RowIndex + 1
                && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                else if (activeCell.State == State.BlackPawn && cell.RowIndex == activeCell.RowIndex + 2
                && activeCell.RowIndex == 1 && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                else if (activeCell.State == State.WhitePawn && cell.RowIndex == activeCell.RowIndex - 1
                && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                else if (activeCell.State == State.WhitePawn && cell.RowIndex == activeCell.RowIndex - 2
                && activeCell.RowIndex == 6 && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                //Возможность пешки атаковать вражеские фигуры на диагонали
                else if (activeCell.State == State.BlackPawn && cell.RowIndex == activeCell.RowIndex + 1
                && Math.Abs(cell.ColumnIndex - activeCell.ColumnIndex) == 1 && cell.State != State.Empty
                && cell.State != State.BlackKing && cell.State != State.BlackPawn)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                else if (activeCell.State == State.WhitePawn && cell.RowIndex == activeCell.RowIndex - 1
                && Math.Abs(cell.ColumnIndex - activeCell.ColumnIndex) == 1 && cell.State != State.Empty
                && cell.State != State.WhiteKing && cell.State != State.WhitePawn)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                // Передвижение пешки на одну клетку вперёд
                if (activeCell.State is State.BlackPawn && cell.RowIndex == activeCell.RowIndex + 1
                && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                else if (activeCell.State is State.WhitePawn && cell.RowIndex == activeCell.RowIndex - 1
                && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                // Передвижение пешки на две клетки вперёд, если она стартовала с начальной позиции
                else if (activeCell.State is State.BlackPawn && cell.RowIndex == activeCell.RowIndex + 2
                && activeCell.RowIndex == 1 && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                else if (activeCell.State is State.WhitePawn && cell.RowIndex == activeCell.RowIndex - 2
                && activeCell.RowIndex == 6 && cell.State == State.Empty && cell.ColumnIndex == activeCell.ColumnIndex)
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
                // Атака фигурой
                else if (cell.State != State.Empty && cell.State != State.BlackKing && cell.State != State.WhiteKing
                && cell.State != activeCell.State && IsLegalMove(activeCell, cell))
                {
                    cell.State = activeCell.State;
                    activeCell.State = State.Empty;
                }
            }
        }, parameter => parameter is Cell cell && (Board.Any(x => x.Active) || cell.State != State.Empty));

       private bool IsLegalMove(Cell activeCell, Cell cell)
    {
        // Прямое движение ладьи по горизонтали или вертикали
        if (activeCell.RowIndex == cell.RowIndex || activeCell.ColumnIndex == cell.ColumnIndex)
        {
            int rowDir = activeCell.RowIndex < cell.RowIndex ? 1 : -1;
            int colDir = activeCell.ColumnIndex < cell.ColumnIndex ? 1 : -1;
            int row = activeCell.RowIndex + rowDir, col = activeCell.ColumnIndex + colDir;
            while (row != cell.RowIndex || col != cell.ColumnIndex)
            {
                if (Board[row, col] != State.Empty)
                {
                    return false; // Если на пути ладьи есть другие фигуры, то передвижение запрещено
                }
                row += rowDir; col += colDir;
            }
            return true;
        }
        return false; // Если ладья ходит не по горизонтали или вертикали
    }
        private void SetupBoard()
        {
            Board board = new();
            board[0, 0] = State.BlackRook;
            board[0, 1] = State.BlackKnight;
            board[0, 2] = State.BlackBishop;
            board[0, 3] = State.BlackQueen;
            board[0, 4] = State.BlackKing;
            board[0, 5] = State.BlackBishop;
            board[0, 6] = State.BlackKnight;
            board[0, 7] = State.BlackRook;
            board[2,4] = State.BlackKnight;
            
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