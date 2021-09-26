using System;
using System.Collections.Generic;

public class RandomDotFieldFiller : FieldFiller<Dot>
{
    private List<DotConfig> _possibleDotConfigs;
    private Random _rnd;

    public RandomDotFieldFiller(Field<Dot> field, FieldClearer<Dot> fieldClearer, List<DotConfig> possibleDotConfigs) : base(field, fieldClearer)
    {
        _possibleDotConfigs = possibleDotConfigs;
        _rnd = new Random();
    }

    protected override void FillCell(int height, int width)
    {
        var randomPossibleConfigNum = _rnd.Next(0, _possibleDotConfigs.Count);
        _field[height, width].Construct(_possibleDotConfigs[randomPossibleConfigNum]);
    }
}
