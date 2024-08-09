using UnityEngine;

public class LevelSceneUIManager : MonoBehaviour
{
    public static LevelSceneUIManager Singleton { get; private set; }

    [SerializeField] private GameLayout _gameLayout;
    public GameLayout GameLayout  => _gameLayout;
    
    [SerializeField] private FinishLayout _finishLayout;
    public FinishLayout FinishLayout  => _finishLayout;

    [SerializeField] private PauseLayout _pauseLayout;
    public PauseLayout PauseLayout  => _pauseLayout;



    void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        GameLayout.SetLayoutActive(true);
        FinishLayout.SetLayoutActive(false);
        PauseLayout.SetLayoutActive(false);
    }
}