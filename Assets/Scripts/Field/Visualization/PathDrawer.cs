using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _linerender;

    private Color red = Color.red;
    private Color blue = Color.blue;

    private void Awake()
    {
        var grad = new Gradient();
        GradientColorKey[] gradientColorKeys = new GradientColorKey[2];
        gradientColorKeys[0].color = red;
        gradientColorKeys[0].time = 0.2f;

        gradientColorKeys[1].color = blue;
        gradientColorKeys[1].time = 0.01f;

        GradientAlphaKey[] gradientAlphaKeys = new GradientAlphaKey[1];
        gradientAlphaKeys[0].alpha = 1f;
        gradientAlphaKeys[0].time = 1f;
        grad.SetKeys(gradientColorKeys, gradientAlphaKeys);
        grad.mode = GradientMode.Fixed;
        _linerender.colorGradient = grad;
    }
}
