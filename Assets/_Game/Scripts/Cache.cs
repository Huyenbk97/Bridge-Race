using System;
using System.Collections.Generic;
using UnityEngine;
public class Cache 
{
    // Start is called before the first frame update
    #region GetColorName
    private static Dictionary<GameObject, Brick> brickColor = new Dictionary<GameObject, Brick>();
      public static Brick GetColorName(GameObject Brick)
    {
        if (!brickColor.ContainsKey(Brick))
        {
            Brick blockColor = Brick.GetComponent<Brick>();
            brickColor.Add(Brick, blockColor);
        }
        return brickColor[Brick];
    }
    #endregion
    #region WaitForSeconds
    public static WaitForSeconds waitFor(float time)
    {
        return new WaitForSeconds(time);
    }
    #endregion
    #region GetRigidBody
    private static Dictionary<GameObject, Rigidbody> rigidDict = new Dictionary<GameObject, Rigidbody>();
    public static Rigidbody GetRigidbody(GameObject obj)
    {
        if (!rigidDict.ContainsKey(obj))
        {
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
            rigidDict.Add(obj, rigidbody);
        }

        return rigidDict[obj];
    }
    #endregion
    #region GetTransform
    private static Dictionary<GameObject, Transform> transformDict = new Dictionary<GameObject, Transform>();

    public static Transform GetTransform(GameObject obj)
    {
        if (!transformDict.ContainsKey(obj))
        {
            Transform transform = obj.transform;

            transformDict.Add(obj, transform);
        }

        return transformDict[obj];
    }
    #endregion
    #region GetChild
    private static Dictionary<Transform, GameObject> Child = new Dictionary<Transform, GameObject>();

    public static GameObject GetChild(Transform Trans)
    {
        if (!Child.ContainsKey(Trans))
        {
            GameObject gameObject = Trans.GetChild(Trans.childCount-1).gameObject;
            Child.Add(Trans, gameObject);
        }

        return Child[Trans];
    }
    #endregion
}
