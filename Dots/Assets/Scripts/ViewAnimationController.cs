using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAnimationController<T> where T : MonoBehaviour
{
    public Field<T> _field;
    public Vector2[,] _coordinates;

    public void Construct(Field<T> field, Vector2[,] coordinates)
    {
        _field = field;
        _coordinates = coordinates;
    }
    public void SwapElements((int h, int w) elem1, (int h, int w) elem2)
    {
        _field[elem1].transform.DOLocalMove(_coordinates[elem2.h, elem2.w], 1);
        _field[elem2].transform.DOLocalMove(_coordinates[elem1.h, elem1.w], 1);
    }
}
