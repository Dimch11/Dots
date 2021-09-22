public class DotField : Field<Dot>
{
    private const int heightMultiplier = 2;

    public DotField(int height, int width) : base(height * heightMultiplier, width)
    {
        
    }

    public override void ClearCell(int heightPos, int widthPos)
    {
        cells[heightPos, widthPos] = null;
    }
    public override bool IsCellEmpty(int heightPos, int widthPos)
    {
        return cells[heightPos, widthPos] == null;
    }
}
