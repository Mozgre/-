using System;

namespace ChessBoard
{
    public class Cell : NotifyPropertyChanged
    {
        private State _state;
        private bool _active;
        private int _rowIndex;
        private int _columnIndex;
        public State State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }
        public int RowIndex
        {
            get => _rowIndex;
            set
            {
                _rowIndex = value;
                OnPropertyChanged();
            }
        }
        public int ColumnIndex
        {
            get => _columnIndex;
            set
            {
                _columnIndex = value;
                OnPropertyChanged();
            }
        }
    }
}