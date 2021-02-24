using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public int size;
    public string tag;
    public GameObject objectType;
    public List<GameObject> objectPool;
}
