using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public DotConfig config;
    public SpriteRenderer _dotImage;

    public void Construct(DotConfig dotConfig)
    {
        this.config = dotConfig;
        _dotImage.sprite = this.config.sprite;
    }
    public void ClearConfig()
    {
        config = null;
        _dotImage.sprite = null;
    }
}
