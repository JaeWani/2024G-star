using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string poolName;
    public int objectAmount;

    public Transform objectParent;
    public GameObject objectPrefab;

    public Queue<GameObject> pool = new Queue<GameObject>();
}

public class PoolManager : MonoBehaviour
{
    public List<Pool> pools = new List<Pool>();

    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    public Dictionary<string, Pool> getPoolDictionary = new Dictionary<string, Pool>();

    public static PoolManager poolManager;

    private void Awake()
    {
        if(poolManager == null) poolManager = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        foreach (var item in pools)
        {
            var key = item.poolName;
            var value = item.pool;
            var parent = new GameObject();
            parent.transform.SetParent(this.gameObject.transform);
            parent.name = key;
            item.objectParent = parent.transform;

            poolDictionary.Add(key, value);
            getPoolDictionary.Add(key, item);

            for (int i = 0; i < item.objectAmount; i++)
            {
                var obj = Instantiate(item.objectPrefab);
                obj.transform.SetParent(item.objectParent.transform);
                obj.SetActive(false);
                poolDictionary[key].Enqueue(obj);
            }
        }
    }


    private GameObject _SpawnFromPool(string key, Vector3 position)
    {
        var obj = poolDictionary[key].Dequeue();

        obj.SetActive(true);
        obj.transform.position = position;

        return obj;
    }

    public static GameObject SpawnFromPool(string key, Vector3 position) => poolManager._SpawnFromPool(key, position);

    private GameObject _SpawnFromPool(string key, Vector3 position, Quaternion quaternion)
    {
        var obj = poolDictionary[key].Dequeue();

        obj.SetActive(true);
        obj.transform.rotation = quaternion;
        obj.transform.position = position;

        return obj;
    }

    public static GameObject SpawnFromPool(string key, Vector3 position, Quaternion quaternion) => poolManager._SpawnFromPool(key, position, quaternion);

    private GameObject _SpawnFromPool(string key, Vector3 position, Quaternion quaternion, Transform parent)
    {
        var obj = poolDictionary[key].Dequeue();

        obj.SetActive(true);
        obj.transform.SetParent(parent);
        obj.transform.rotation = quaternion;
        obj.transform.position = position;

        return obj;
    }

    public static GameObject SpawnFromPool(string key, Vector3 position, Quaternion quaternion, Transform parent) => poolManager._SpawnFromPool(key, position, quaternion, parent);


    private void _ReturnToPool(string key, GameObject gameObject)
    {
        var pool = poolDictionary[key];
        var parent = getPoolDictionary[key].objectParent;

        gameObject.SetActive(false);
        gameObject.transform.SetParent(parent);
        pool.Enqueue(gameObject);
    }

    public static void ReturnToPool(string key, GameObject gameObject) => poolManager._ReturnToPool(key, gameObject);
}
