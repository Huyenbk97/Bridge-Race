using UnityEngine;
public class PlayerBrickController : MonoBehaviour
{
    public float bricks;
    [SerializeField]
    private Transform brickArea;
    [SerializeField]
    private Transform brickPlacer;
    // Start is called before the first frame update
    public void FixedUpdate()
    {
        CheckBridge();
    }
    public void CheckBridge()
    {
        RaycastHit hit;
        if (Physics.Raycast(brickPlacer.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(brickPlacer.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);

        }
        if (hit.collider.CompareTag(Constant.BRIDGE))
        {
            if (bricks > 0)
            {
                PlaceBricks(hit);
            }
        }
    }
    private void PlaceBricks(RaycastHit hit)
    {
      
    }
    public void UpdatePlayerBricks()
    {
        Vector3 brickPosition = new Vector3(brickArea.position.x, brickArea.position.y + (bricks * 0.3f), brickArea.position.z);
        GameObject brick =  BrickPool.ins.GetPooledObject();
        if (brick != null)
        {
            Cache.GetTransform(brick).rotation = transform.rotation;
            Cache.GetTransform(brick).position= brickPosition;
            Cache.GetTransform(brick).transform.parent = brickArea;
      /*      brick.transform.rotation = transform.rotation;
            brick.transform.position = brickPosition;
            brick.transform.parent = brickArea;*/
            brick.SetActive(true);   
        }
        bricks++;
    }
    private void PlaceBrick()
    {

    }
}
