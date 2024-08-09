using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _img;
    [SerializeField] private float _freezeTime = 3f;
    private float _timer = 0;

    void Awake()
    {
        _timer = _freezeTime;
    }

    void Update()
    {
        _timer = Mathf.Clamp(_timer + Time.deltaTime, 0, _freezeTime);
        _img.fillAmount = _timer / _freezeTime;
    }

    public void StartFreeze()
    {
        StartCoroutine(FreezeCoroutine());
    }

    IEnumerator FreezeCoroutine()
    {
        _button.interactable = false;
        _timer = 0;

        yield return new WaitForSeconds(_freezeTime);

        _button.interactable = true;
    }
}