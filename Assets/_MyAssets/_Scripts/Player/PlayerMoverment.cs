using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    private PlayerManager _playerManager;
    private Vector2 _direction;
    private bool _canMove = false;


    void Start()
    {
        _playerManager = this.GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        _direction = InputManager.Singleton.JoystickDirection;

        Move();
    }

    void LateUpdate()
    {
        if (_playerManager.Shoot.DetectEnemy)
        {
            return;
        }

        if (!_canMove)
        {
            return;
        }

        RotateModelFollowJoystick(_direction);
    }

    void Move()
    {
        _canMove = _direction != Vector2.zero;
        if (_canMove)
        {
            // var velocity = Vector3.forward * _direction.y + Vector3.right * _direction.x;
            // _playerManager.Rigid.velocity = velocity * _moveSpeed;
            _playerManager.Rigid.velocity = new Vector3(
                _direction.x * _moveSpeed,
                _playerManager.Rigid.velocity.y,
                _direction.y * _moveSpeed
            );
        }

        _playerManager.Anim.SetBool("runForward", _canMove);
    }

    void RotateModelFollowJoystick(Vector2 joystickDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(joystickDirection.x, 0, joystickDirection.y));
        _playerManager.Model.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
    }
}