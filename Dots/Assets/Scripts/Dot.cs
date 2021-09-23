using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public DotConfig dotConfig;
    public SpriteRenderer _dotImage;

    public void Construct(DotConfig dotConfig)
    {
        this.dotConfig = dotConfig;
        _dotImage.sprite = this.dotConfig.sprite;
    }
}
