using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Button _button;
    public Image _image;


    void Start()
    {
        _button = this.GetComponent<Button>();
        _image = this.GetComponent<Image>();

        if (_image != null && _button == null)
        {
            _image.transform.localPosition = Vector3.up * -Screen.height;
        }
    }


    public void ClickEffect()
    {
        var oldScale = _button.transform.localScale;
        _button.transform.LeanScale(Vector3.one + oldScale, .2f).setEaseInExpo();
        _button.transform.LeanScale(oldScale, .2f).setEaseOutBack().delay = .2f;
    }

    public void ShowImage()
    {
        _image.transform.LeanMoveLocalY(0, .8f).setEaseInExpo();
    }
}
