using System.Collections.Generic;
using UnityEngine;
public class Cache 
{
    // Start is called before the first frame update
  
    #region GetColorNamePlacedBrick
    private static Dictionary<GameObject, string> PlacedBrickColor = new Dictionary<GameObject, string>();
    public static string GetColorNamePlacedBrick(GameObject PlacedBrick)
    {
        if (!PlacedBrickColor.ContainsKey(PlacedBrick))
        {
            string blockColorName = PlacedBrick.GetComponent<PlacedBrick>().colorName;
            PlacedBrickColor.Add(PlacedBrick, blockColorName);
        }
        return PlacedBrickColor[PlacedBrick];
    }
    #endregion
    #region GetbricksPlaced
    private static Dictionary<GameObject, float> bricksPlacedNumber = new Dictionary<GameObject, float>();
    public static float GetbricksPlaced(GameObject PlacedBrick)
    {
        if (!bricksPlacedNumber.ContainsKey(PlacedBrick))
        {
            float bricksPlacedNumber1 = PlacedBrick.GetComponent<WayKeeper>().bricksPlaced;
            bricksPlacedNumber.Add(PlacedBrick, bricksPlacedNumber1);
        }
        return bricksPlacedNumber[PlacedBrick];
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
    #region GetPosition
    private static Dictionary<GameObject, Vector3> Position = new Dictionary<GameObject, Vector3>();

    public static Vector3 GetPosition(GameObject obj)
    {
        if (!Position.ContainsKey(obj))
        {
            Vector3 Position1 = obj.transform.position;

            Position.Add(obj, Position1);
        }

        return Position[obj];
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
