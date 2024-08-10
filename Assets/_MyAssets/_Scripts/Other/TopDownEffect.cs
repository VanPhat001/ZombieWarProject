using System;
using UnityEngine;

public class TopDownEffect : MonoBehaviour
{
    private float _yPos;

    void Awake()
    {
        _yPos = this.transform.localPosition.y;
    }

    public void Appear(Action onComplete = null)
    {
        if (onComplete == null)
        {
            onComplete = () => { };
        }
        this.transform.localPosition = Vector3.up * Screen.height;
        this.transform.LeanMoveLocalY(_yPos, .4f).setEaseInExpo().setOnComplete(onComplete);
    }

    public void Disappear(Action onComplete = null)
    {
        if (onComplete == null)
        {
            onComplete = () => { };
        }
        this.transform.LeanMoveLocalY(Screen.height, .4f).setEaseOutExpo().setOnComplete(onComplete);
    }
}