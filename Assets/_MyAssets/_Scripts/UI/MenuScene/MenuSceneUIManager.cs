using UnityEngine;

public class MenuSceneUIManager : MonoBehaviour
{
    public static MenuSceneUIManager Singleton { get; private set; }

    [SerializeField] private MenuLayout _menuLayout;
    public MenuLayout MenuLayout => _menuLayout;

    [SerializeField] private LevelLayout _levelLayout;
    public LevelLayout LevelLayout => _levelLayout;
    
    [SerializeField] private QuitLayout _quitLayout;
    public QuitLayout QuitLayout => _quitLayout;


    void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        MenuLayout.SetLayoutActive();
        LevelLayout.SetLayoutActive(false);
        QuitLayout.SetLayoutActive(false);
    }
}