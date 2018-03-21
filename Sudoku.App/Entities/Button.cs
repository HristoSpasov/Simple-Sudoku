namespace Sudoku.App.Entities
{
    public class Button
    {
        private string id;
        private int minCol;
        private int minRow;
        private int maxCol;
        private int maxRow;

        public Button(string id, int minCol, int minRow, int maxCol, int maxRow)
        {
            this.id = id;
            this.minCol = minCol;
            this.minRow = minRow;
            this.maxCol = maxCol;
            this.maxRow = maxRow;
        }

        public string Id
        {
            get
            {
                return this.id;
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

        public int MaxRow
        {
            get
            {
                return this.maxRow;
            }
        }

        public int MaxCol
        {
            get
            {
                return this.maxCol;
            }
        }
    }
}
