namespace Sudoku.App.Entities
{
    using System;

    public class Field
    {
        private int minCol;
        private int minRow;
        private char[,] content;
        private int value;
        private bool isImmutable;
        private int boardRow;
        private int boardCol;

        public Field(int minCol, int minRow, char[,] content, int value, bool isImmutable, int boardRow, int boardCol)
        {
            this.minCol = minCol;
            this.minRow = minRow;
            this.Content = content;
            this.value = value;
            this.isImmutable = isImmutable;
            this.boardRow = boardRow;
            this.boardCol = boardCol;
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (this.IsImmutable)
                {
                    throw new InvalidOperationException("Dude, You are not allowed to modify sudoku pattern!");
                }

                this.value = value;
            }
        }

        public int MinRow
        {
            get
            {
                return this.minRow;
            }
        }

        public int MinCol
        {
            get
            {
                return this.minCol;
            }
        }

        public bool IsImmutable
        {
            get
            {
                return this.isImmutable;
            }
        }

        public char[,] Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

        public int BoardRow
        {
            get
            {
                return this.boardRow;
            }
        }

        public int BoardCol
        {
            get
            {
                return this.boardCol;
            }
        }
    }
}
