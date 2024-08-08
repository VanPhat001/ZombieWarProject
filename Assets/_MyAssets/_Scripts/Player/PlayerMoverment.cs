using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    private PlayerManager _playerManager;

    void Start()
    {
        _playerManager = this.GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        var direction = InputManager.Singleton.JoystickDirection;
        var canMove = direction != Vector2.zero;
        if (canMove)
        {
            var velocity = Vector3.forward * direction.y + Vector3.right * direction.x;
            _playerManager.Rigid.velocity = velocity * _moveSpeed;
            RotateModelFollowJoystick(direction);
        }

        _playerManager.Anim.SetBool("run", canMove);
    }

    void RotateModelFollowJoystick(Vector2 joystickDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(joystickDirection.x, 0, joystickDirection.y));
        _playerManager.Model.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
    }
}