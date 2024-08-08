using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider _mainSlider;
    [SerializeField] private Slider _effectSlider;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _maxHP;

    public float HP => _mainSlider.value;


    void Start()
    {
        // ResetHP();
        // StartCoroutine(test());
        // IEnumerator test()
        // {
        //     while (_hp > 0)
        //     {
        //         yield return new WaitForSeconds(1);
        //         DescreaseHP(25);
        //     }
        // }
    }

    void Update()
    {
        _effectSlider.value = Mathf.Lerp(_effectSlider.value, _mainSlider.value, _speed * Time.deltaTime);
    }


    public void UpdateHP(float hp)
    {
        _mainSlider.value = hp;
    }

    public void DescreaseHP(float amount)
    {
        _mainSlider.value = Mathf.Clamp(_mainSlider.value - amount, 0, _maxHP);
    }

    public void ResetHP()
    {
        _mainSlider.maxValue = _effectSlider.maxValue = _maxHP;
        _mainSlider.value = _effectSlider.value = _maxHP;
    }

    public void ResetHP(float maxHP)
    {
        _maxHP = maxHP;
        _mainSlider.maxValue = _effectSlider.maxValue = _maxHP;
        _mainSlider.value = _effectSlider.value = _maxHP;
    }
}