using UnityEngine;

public class Level2SpawnManager : SpawnManager
{
    private float _decreaseRate = .95f; // 95%
    private float _currentInterval = 8f; // second
    private float _minInterval = .4f;
    private float _startDelay = 2f;
    private float _timer = 0;


    protected override void OnEnable()
    {
        // base.OnEnable();
        _timer = _startDelay;
    }

    protected override void Update()
    {
        if (_playerManager.HP <= 0)
        {
            return;
        }

        _timer -= Time.deltaTime;
        if (!CanSpawn())
        {
            return;
        }

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        SpawnRandom();
        _timer = _currentInterval;
        _currentInterval = Mathf.Max(_currentInterval * _decreaseRate, _minInterval);
    }

    private bool CanSpawn()
    {
        return _timer <= 0;
    }
}