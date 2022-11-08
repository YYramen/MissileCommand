using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// バレットのObjectPool管理用クラス
/// </summary>
public class BulletPoolManager : MonoBehaviour
{
    ObjectPool<GameObject> _pool;

    [SerializeField] GameObject _prefab;

    public GameObject Prefab { get => _prefab; set => _prefab = value; }

    void Awake()
    {
        _pool = new ObjectPool<GameObject>(OnCreatePooledObject, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject);
    }
    GameObject OnCreatePooledObject()
    {
        return Instantiate(Prefab);
    }
    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }
    void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    void OnDestroyPooledObject(GameObject obj)
    {
        Destroy(obj);
    }
    public GameObject GetGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        Prefab = prefab;
        GameObject obj = _pool.Get();
        Transform tf = obj.transform;
        tf.position = position;
        tf.rotation = rotation;
        return obj;
    }
    public void ReleaseGameObject(GameObject obj)
    {
        _pool.Release(obj);
    }
}
