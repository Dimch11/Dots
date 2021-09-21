public class DotField : Field<Dot>
{
    public DotField(int height, int width) : base(height, width)
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
