using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjecentElementsFinder<T>
{
    private Field<T> _field;
    private T _element;
    private (int height, int width) _elementPos;

    public AdjecentElementsFinder(Field<T> field)
    {
        _field = field;
    }

    public List<T> GetAdjacentElements(T element)
    {
        _element = element;
        _elementPos = _field.GetIndicesOfElement(_element);

        var adjElements = new List<T>();

        AddElementToListIfItNotNull(adjElements, GetAdjTopElement());
        AddElementToListIfItNotNull(adjElements, GetAdjBottomElement());
        AddElementToListIfItNotNull(adjElements, GetAdjRightElement());
        AddElementToListIfItNotNull(adjElements, GetAdjLeftElement());

        return adjElements;
    }
    private T GetAdjTopElement()
    {
        var newHeight = _elementPos.height - 1;
        var newWidth = _elementPos.width;

        return GetElementIfExists(newHeight, newWidth);
    }
    private T GetAdjBottomElement()
    {
        var newHeight = _elementPos.height + 1;
        var newWidth = _elementPos.width;

        return GetElementIfExists(newHeight, newWidth);
    }
    private T GetAdjRightElement()
    {
        var newHeight = _elementPos.height;
        var newWidth = _elementPos.width + 1;

        return GetElementIfExists(newHeight, newWidth);
    }
    private T GetAdjLeftElement()
    {
        var newHeight = _elementPos.height;
        var newWidth = _elementPos.width - 1;

        return GetElementIfExists(newHeight, newWidth);
    }
    private T GetElementIfExists(int height, int width)
    {
        if (_field.CellExists(height, width))
        {
            return _field[height, width];
        }
        else
        {
            return default;
        }
    }
    private void AddElementToListIfItNotNull(List<T> list, T element)
    {
        if (element != null)
        {
            list.Add(element);
        }
    }
}
