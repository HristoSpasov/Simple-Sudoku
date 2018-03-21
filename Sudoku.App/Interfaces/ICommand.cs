namespace Sudoku.App.Interfaces
{
    using System.Collections.Generic;
    using Sudoku.App.Entities;

    public interface ICommand
    {
        void Execute(HashSet<Field> fields);
    }
}
