using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ZoomEffect))]
public class QuitLayout : BaseLayout
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;
    [SerializeField] private ZoomEffect _zoomEffect;

    void Start()
    {
        _yesButton.onClick.AddListener(QuitGame);
        _noButton.onClick.AddListener(() =>
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

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}