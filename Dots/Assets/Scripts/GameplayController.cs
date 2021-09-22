using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameplayConfig gameplayConfig;

    private DotField _dotField;
    private RandomFieldFiller<Dot> _randomFieldFiller;
    private DotFieldViewBuilder _dotFieldViewBuilder;
    [SerializeField]
    private CellDrawer _cellDrawer;

    public void StartGame()
    {
        _dotField = new DotField(gameplayConfig.fieldHeight, gameplayConfig.fieldWidth);

        _randomFieldFiller = new RandomFieldFiller<Dot>(_dotField, gameplayConfig.possibleDots);
        _randomFieldFiller.FillEmptyCellsInField();

        _cellDrawer.Construct(_dotField.Width);

        _dotFieldViewBuilder = new DotFieldViewBuilder(_dotField, _cellDrawer);
        _dotFieldViewBuilder.DrawField();
    }

    public void Start()
    {
        StartGame();
    }
}
