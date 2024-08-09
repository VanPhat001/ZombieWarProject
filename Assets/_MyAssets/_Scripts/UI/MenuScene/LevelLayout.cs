using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(ZoomEffect))]
public class LevelLayout : BaseLayout
{
    [SerializeField] private Button _returnButton;
    [SerializeField] private ZoomEffect _zoomEffect;
    

    void OnEnable()
    {
        _zoomEffect.ZoomIn();
    }

    void Start()
    {
        _returnButton.onClick.AddListener(() =>
        {
            CloseLayout();
        });
    }

    public override void OpenLayout()
    {
        base.OpenLayout();
        _zoomEffect.ZoomIn();
    }

    public override void CloseLayout()
    {
        _zoomEffect.ZoomOut(() => base.CloseLayout());
    }
}