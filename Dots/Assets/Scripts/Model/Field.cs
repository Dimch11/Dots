using System;

public abstract class Field<T>
{
    public T this[int heightPos, int widthPos]
    {
        get
        {
            return TryGetCell(heightPos, widthPos);
        }
        set
        {
            TrySetCell(heightPos, widthPos, value);
        }
    }

    public int Height { get => cells.GetLength(0); }
    public int Width { get => cells.GetLength(1); }

    protected T[,] cells;

    public Field(int height, int width)
    {
        cells = new T[height, width];

        Clear();
    }

    public void Clear()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                ClearCell(i, j);
            }
        }
    }
    public abstract void ClearCell(int heightPos, int widthPos);
    public abstract bool IsCellEmpty(int heightPos, int widthPos);

    protected T TryGetCell(int heightPos, int widthPos)
    {
        if (CellExists(heightPos, widthPos))
        {
            return cells[heightPos, widthPos];
        }
        else
        {
            throw new ArgumentException();
        }
    }
    protected void TrySetCell(int heightPos, int widthPos, T cellContent)
    {
        if (CellExists(heightPos, widthPos))
        {
            cells[heightPos, widthPos] = cellContent;
        }
        else
        {
            throw new ArgumentException();
        }
    }
    protected bool CellExists(int heightPos, int widthPos)
    {
        bool heightIsOk = heightPos >= 0 && heightPos < cells.GetLength(0);
        bool widthIsOk = widthPos >= 0 && widthPos < cells.GetLength(1);

        return heightIsOk && widthIsOk;
    }
}