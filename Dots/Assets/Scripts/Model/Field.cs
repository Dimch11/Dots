using System;
using System.Collections.Generic;

public class Field<T>
{
    public T this[int heightPos, int widthPos]
    {
        get
        {
            return cells[heightPos, widthPos];
        }
        set
        {
            cells[heightPos, widthPos] = value;
        }
    }
    public T this[(int height, int width) pos]
    {
        get
        {
            return cells[pos.height, pos.width];
        }
        set
        {
            cells[pos.height, pos.width] = value;
        }
    }
    public int Height { get => cells.GetLength(0); }
    public int Width { get => cells.GetLength(1); }

    protected T[,] cells;

    public Field(int height, int width)
    {
        cells = new T[height, width];
    }

    public bool CellExists(int height, int width)
    {
        var topBoundsIsOk = height < cells.GetLength(0) && width < cells.GetLength(1);
        var bottomBoundsIsOk = height >= 0 && width >= 0;

        if (topBoundsIsOk && bottomBoundsIsOk)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public (int height, int width) GetIndicesOfElement(T element)
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (EqualityComparer<T>.Default.Equals(cells[i, j], element))
                {
                    return (i, j);
                }
            }
        }

        throw new ArgumentException();
    }
}