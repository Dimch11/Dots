using System;
using System.Collections.Generic;

public class RandomFieldFiller<T>
{
    private Field<T> _field;
    private List<T> _possibleElements;
    
    private Random _rnd;

    public RandomFieldFiller(Field<T> field, List<T> possibleElements)
    {
        _field = field;
        _possibleElements = possibleElements;
        _rnd = new Random();
    }

    public void FillEmptyCellsInField()
    {
        for (int i = 0; i < _field.Height; i++)
        {
            for (int j = 0; j < _field.Width; j++)
            {
                if (_field.IsCellEmpty(i, j))
                {
                    _field[i, j] = _possibleElements[_rnd.Next(0, _possibleElements.Count)];
                }
            }
        }
    }
}
