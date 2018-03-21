namespace Sudoku.App.Entities
{
    using Sudoku.App.Constants;

    public class Mouse
    {
        private int positionX;
        private int positionY;

        public Mouse()
        {
            this.positionX = MouseConstants.MouseInitialPositionX;
            this.positionY = MouseConstants.MouseInitialPositionY;
        }

        public int PositionX
        {
            get
            {
                return this.positionX;
            }

            set
            {
                if (value >= BoardConstants.BoardMintX && value <= BoardConstants.BoardMaxX)
                {
                    this.positionX = value;
                }
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }

            set
            {
                if (value >= BoardConstants.BoardMintY && value <= BoardConstants.BoardMaxY)
                {
                    this.positionY = value;
                }
            }
        }
    }
}
