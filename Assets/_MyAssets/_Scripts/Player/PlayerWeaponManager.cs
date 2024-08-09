using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public enum WeaponName
    {
        AKM,
        M416,
        K98
    }

    [Serializable]
    public class WeaponInfo
    {
        public WeaponName Name;
        public Gun Gun;
    }

    [SerializeField] private List<WeaponInfo> _weapons;
    [SerializeField] private WeaponName _useWeapon;
    public WeaponName CurrentWeaponName => _useWeapon;



    void Start()
    {
        UseWeapon(_useWeapon);
    }


    public Gun GetCurrentWeapon()
    {
        return FindWeapon(_useWeapon).Gun;
    }

    public void UseWeapon(WeaponName weaponName)
    {
        _weapons.ForEach(item =>
        {
            item.Gun.gameObject.SetActive(item.Name == weaponName);
        });
        _useWeapon = weaponName;
    }

    public WeaponInfo FindWeapon(WeaponName weaponName)
    {
        return _weapons.Find(item => item.Name == weaponName);
    }
}