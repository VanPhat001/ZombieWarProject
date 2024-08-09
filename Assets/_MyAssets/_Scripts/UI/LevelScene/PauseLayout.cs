using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TopDownEffect))]
public class PauseLayout : BaseLayout
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TopDownEffect _topDownEffect;

    void Start()
    {
        _continueButton.onClick.AddListener(() =>
        {
            CloseLayout();
        });

        _quitButton.onClick.AddListener(() =>
        {
            QuitGame();
        });
    }

    public override void OpenLayout()
    {
        base.OpenLayout();
        _topDownEffect.Appear();
    }

    public override void CloseLayout()
    {
        _topDownEffect.Disappear(() =>
        {
            base.CloseLayout();
        });
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}