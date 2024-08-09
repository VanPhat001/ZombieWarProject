using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TopDownEffect))]
public class FinishLayout : BaseLayout
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TopDownEffect _topDownEffect;


    void Start()
    {
        _restartButton.onClick.AddListener(() =>
        {
            Loader.LoadScene(Loader.GetCurrentScene());
        });

        _homeButton.onClick.AddListener(() =>
        {
            Loader.LoadScene(Loader.SceneName.MenuScene);
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