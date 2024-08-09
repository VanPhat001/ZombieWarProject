using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Singleton { get; private set; }

    [SerializeField] private Joystick _joystick;
    public Vector2 JoystickDirection { get; private set; }

    // private bool _gamePause = false;
    // public bool GamePause { get => _gamePause; set => _gamePause = value; }


    void Awake()
    {
        if (Singleton != null)
        {
            Debug.LogError("There are more than 1 " + this.GetType().Name);
        }

        Singleton = this;
    }

    void Update()
    {
        JoystickDirection = _joystick.Direction;
    }
}