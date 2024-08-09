using UnityEngine;
using UnityEngine.UI;

public class MenuLayout : BaseLayout
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    void Start()
    {
        _startButton.onClick.AddListener(() =>
        {
            MenuSceneUIManager.Singleton.LevelLayout.OpenLayout();
        });

        _quitButton.onClick.AddListener(() => {
            MenuSceneUIManager.Singleton.QuitLayout.OpenLayout();
        });
    }
}