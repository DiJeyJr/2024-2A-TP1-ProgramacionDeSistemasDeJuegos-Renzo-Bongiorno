using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> where T : Component
{
    private readonly Queue<T> _pool = new Queue<T>();
    private readonly T _prefab;
    private readonly Transform _parent;

    public Pool(T prefab, int initialSize, Transform parent = null)
    {
        //Input prefab and parent
        _prefab = prefab;
        _parent = parent;
        
        //Create Initial Amount of Objects
        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public T Get()
    {
        //Try to get an existing object
        if (_pool.Count > 0)
        {
            T obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            //Expand the pool
            T obj = GameObject.Instantiate(_prefab, _parent);
            return obj;
        }
    }

    public void ReturnToPool(T obj)
    {
        //Return Object to the pool
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
    
    public int Count => _pool.Count;
}
