using System;
using System.Collections.Generic;

public abstract class FieldFiller<T>
{
    protected Field<T> _field;

    public FieldFiller(Field<T> field)
    {
        _field = field;
    }

    public void FillEmptyCellsInField()
    {
        for (int i = 0; i < _field.Height; i++)
        {
            for (int j = 0; j < _field.Width; j++)
            {
                FillCellIfEmpty(i, j);
            }
        }
    }
    protected void FillCellIfEmpty(int height, int width)
    {
        if (_field.CellIsEmpty(height, width))
        {
            FillCell(height, width);
        }
    }
    protected abstract void FillCell(int height, int width);
}
