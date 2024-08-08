using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolItem
{
    public string Name;
    public GameObject Prefab;
}


public class Pool : MonoBehaviour
{
    [SerializeField] private List<PoolItem> _poolItemList;
    private List<GameObject> _pool = new();


    public GameObject Get(string itemName, Transform parent = null)
    {
        var go = FindInPool(itemName);

        if (go != null)
        {
            _pool.Remove(go);
        }
        else
        {
            go = CreateNewGO(itemName);
        }


        go.SetActive(true);
        go.transform.SetParent(parent);
        return go;
    }


    public void Release(GameObject go)
    {
        _pool.Add(go);
        go.transform.SetParent(this.transform);
        go.SetActive(false);
    }


    private GameObject CreateNewGO(string itemName)
    {
        var poolItem = FindPoolItemByName(itemName);
        if (poolItem == null)
        {
            Debug.LogError($"ItemName [{itemName}] not exists in pool");
            return null;
        }

        return Instantiate(poolItem.Prefab);
    }


    protected GameObject FindInPool(string itemName)
    {
        return _pool.Find(item => item.name == itemName);
    }


    protected PoolItem FindPoolItemByName(string itemName)
    {
        return _poolItemList.Find(item => item.Name == itemName);
    }

}