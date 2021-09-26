using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldElementsMover<T>
{
    public event Action<(int, int), (int, int)> ElementsSwaped;

    private Field<T> _field;
    
    public FieldElementsMover(Field<T> field)
    {
        _field = field;
    }

    public void SwapElements((int h, int w) curPos, (int h, int w) newPos)
    {
        var tmp = _field[curPos];
        _field[curPos] = _field[newPos];
        _field[newPos] = tmp;

        ElementsSwaped?.Invoke(curPos, newPos);
    }
}
