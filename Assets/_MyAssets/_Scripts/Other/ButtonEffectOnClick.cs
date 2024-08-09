using UnityEngine;
using UnityEngine.UI;

public class ButtonEffectOnClick : MonoBehaviour
{
    [SerializeField] private float _increaseOffset = .2f;
    private Button _button;
    private Vector3 _localScale;

    void Start()
    {
        _button = this.GetComponent<Button>();
        _localScale = _button.transform.localScale;

        _button.onClick.AddListener(() =>
        {
            _button.transform.LeanScale(_localScale + Vector3.one * _increaseOffset, .2f).setEaseInExpo();
            _button.transform.LeanScale(_localScale, .2f).setEaseOutExpo().delay = .2f;
        });
    }
}