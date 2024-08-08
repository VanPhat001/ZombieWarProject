using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerManager _playerManager;

    private float _timer = 0;
    private float _rate = .3f;

    void Start()
    {
        _playerManager = this.GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        AutoShoot();
    }

    void AutoShoot()
    {
        if (!CanShoot())
        {
            return;
        }

        _timer = _rate;
        _playerManager.Anim.SetTrigger("shoot");
    }

    bool CanShoot()
    {
        return _timer <= 0;
    }
}