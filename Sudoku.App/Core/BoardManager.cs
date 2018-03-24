namespace Sudoku.App.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Sudoku.App.Constants;
    using Sudoku.App.Entities;
    using Sudoku.App.Factories;

    public class BoardManager
    {
        private readonly char[][] board;
        private readonly HashSet<Field> fields;
        private readonly HashSet<Button> buttons;

        public BoardManager()
        {
            this.board = new char[50][];
            this.fields = new HashSet<Field>();
            this.buttons = new HashSet<Button>();
        }

        public HashSet<Field> Fields
        {
            get
            {
                return this.fields;
            }
        }

        public void GenerateBoard()
        {
            string directory = Directory.GetCurrentDirectory();
            string boardPath = "../../Files/Board.txt";

            StringBuilder boardToPrint = new StringBuilder();

            using (StreamReader reader = new StreamReader(boardPath))
            {
                int lineCounter = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    boardToPrint.AppendLine(line);
                    this.board[lineCounter] = line.ToCharArray();
                    lineCounter++;
                }
            }

            System.Console.Write(boardToPrint);
        }

        public char GetCharByPosition(int x, int y)
        {
            return this.board[y][x];
        }

        public void InitializeFields(int[][] generatedSudoku)
        {
            int topLeftFieldStartRow = FieldConstants.FieldMinY;

            int offset = 1; // Used to overcome borders

            // Loop over the generated array of digits and create new field object
            for (int row = 0; row < generatedSudoku.Length; row++)
            {
                int topLeftFieldStartCol = FieldConstants.FieldMinX;

                for (int col = 0; col < generatedSudoku[row].Length; col++)
                {
                    AsciiNumberFactory asciiNumberFactory = new AsciiNumberFactory();
                    Field newField = new Field(topLeftFieldStartCol, topLeftFieldStartRow, asciiNumberFactory.GetNumberAscii(generatedSudoku[row][col]), generatedSudoku[row][col], generatedSudoku[row][col] != 0);

                    if (newField.Value == 0)
                    {
                        newField.Content[0, 0] = FieldConstants.EmptyFieldSymbol;
                    }

                    this.fields.Add(newField);
                    topLeftFieldStartCol += FieldConstants.FieldCols + offset;
                }

                topLeftFieldStartRow += FieldConstants.FieldRows + offset;
            }
        }

        public void DrawFieldsContentAndUpdateBoard()
        {
            foreach (var field in this.fields)
            {
                this.UpdateField(field);
            }
        }

        public void UpdateField(Field field)
        {
            if (!field.IsImmutable)
            {
                field.Content[0, 0] = FieldConstants.EmptyFieldSymbol;
            }

            ConsoleManager.SetCursorPosition(field.MinCol, field.MinRow);
            int maxRow = field.MinRow + FieldConstants.FieldRows;
            int maxCol = field.MinCol + FieldConstants.FieldCols;

            for (int row = field.MinRow, contentRow = 0; row < maxRow; row++, contentRow++)
            {
                for (int col = field.MinCol, contentCol = 0; col < maxCol; col++, contentCol++)
                {
                    ConsoleManager.SetCursorPosition(col, row);
                    ConsoleManager.WriteSingleChar(field.Content[contentRow, contentCol]);
                    this.board[row][col] = field.Content[contentRow, contentCol];
                }
            }

            ConsoleManager.DefaultColors();
        }

        public void InitializeButtons()
        {
            Button checkButton = new Button(ButtonsConstants.CheckId, ButtonsConstants.CheckMinCol, ButtonsConstants.CheckMinRow, ButtonsConstants.CheckMaxCol, ButtonsConstants.CheckMaxRow);
            Button solutionkButton = new Button(ButtonsConstants.SolutionId, ButtonsConstants.SolutionMinCol, ButtonsConstants.SolutionMinRow, ButtonsConstants.SolutionMaxCol, ButtonsConstants.SolutionMaxRow);
            Button exitButton = new Button(ButtonsConstants.ExitId, ButtonsConstants.ExitMinCol, ButtonsConstants.ExitMinRow, ButtonsConstants.ExitMaxCol, ButtonsConstants.ExitMaxRow);

            this.buttons.Add(checkButton);
            this.buttons.Add(solutionkButton);
            this.buttons.Add(exitButton);
        }

        public Field SearchForField(int mouseCol, int mouseRow)
        {
            int offset = 1; // To exclude border

            Field field = this.fields.Where(f => !f.IsImmutable)
                                   .SingleOrDefault(f => mouseCol >= f.MinCol &&
                                                         mouseCol <= f.MinCol + FieldConstants.FieldCols - offset &&
                                                         mouseRow >= f.MinRow &&
                                                         mouseRow <= f.MinRow + FieldConstants.FieldRows - offset);

            return field;
        }

        public Button SearchForButton(int mouseCol, int mouseRow)
        {
            Button button = this.buttons.SingleOrDefault(b => mouseCol >= b.MinCol &&
                                                                   mouseCol <= b.MaxCol &&
                                                                   mouseRow >= b.MinRow &&
                                                                   mouseRow <= b.MaxRow);

            return button;
        }
    }
}
