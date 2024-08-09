using System;
using UnityEngine;

public class ZoomEffect : MonoBehaviour
{
    private Vector3 _localScale;

    void Awake()
    {
        _localScale = this.transform.localScale;
    }

    public void ZoomIn()
    {
        this.transform.localScale = Vector3.zero;
        this.transform.LeanScale(this._localScale, .6f).setEaseInExpo();
    }

    public void ZoomOut(Action onComplete = null)
    {
        if (onComplete == null)
        {
            onComplete = () => {};    
        }
        this.transform.LeanScale(Vector3.zero, .6f).setEaseOutExpo().setOnComplete(onComplete);
    }
}