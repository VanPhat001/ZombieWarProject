using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public enum SceneName
    {
        Nothing,
        MenuScene,
        Level1Scene,
        Level2Scene,
    }

    public static void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public static SceneName GetCurrentScene()
    {
        if (Enum.TryParse(SceneManager.GetActiveScene().name, out SceneName enumValue))
        {
            return enumValue;
        }
        return SceneName.Nothing;
    }
}