using UnityEngine;
public class Fallow : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    public float speed;
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
