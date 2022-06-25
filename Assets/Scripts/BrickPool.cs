using System.Collections.Generic;
using UnityEngine;
public class BrickPool : MonoBehaviour
{
    public static BrickPool ins;
    public List<GameObject> pooledBricks;
    public List<GameObject> pooledBricksBridge;
    public GameObject Brick;
    public int amountToPool;
    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
        pooledBricks = new List<GameObject>();
        GameObject brick;
        for (int i = 0; i < amountToPool; i++)
        {
            brick = Instantiate(Brick);
            brick.SetActive(false);
            pooledBricks.Add(brick);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBricks[i].activeInHierarchy)
            {
                return pooledBricks[i];
            }
        }
        return null;
    }
}
