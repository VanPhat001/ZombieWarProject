using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Loader.SceneName _levelSceneName;
    public Loader.SceneName LevelSceneName => _levelSceneName;

    public void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => Loader.LoadScene(LevelSceneName));
    }
}