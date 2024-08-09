using UnityEngine;
using UnityEngine.UI;

public class GameLayout : BaseLayout
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _grenadeButton;   
    [SerializeField] private Button _switchButton;   
    [SerializeField] private Button _pauseButton;


    void Start()
    {
        _pauseButton.onClick.AddListener(() => {
            LevelSceneUIManager.Singleton.PauseLayout.OpenLayout();
        });
    }
}