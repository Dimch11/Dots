using System;
using System.Collections.Generic;

public abstract class Field<T>
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

    public int Height { get => cells.GetLength(0); }
    public int Width { get => cells.GetLength(1); }

    protected T[,] cells;

    public Field(int height, int width)
    {
        cells = new T[height, width];
    }

    
    
    public bool CellExists(int height, int width)
    {
        if (height < cells.GetLength(0) && width < cells.GetLength(1))
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