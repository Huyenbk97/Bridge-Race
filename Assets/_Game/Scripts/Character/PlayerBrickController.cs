using UnityEngine;
public class PlayerBrickController : MonoBehaviour
{
    public int bricks;
    public float brickCount;
    public BrickGenerator brickGenerator;
    [SerializeField]
    private Transform brickArea;
    [SerializeField]
    private Transform brickPlacer;
    [SerializeField]
    private Transform placedBrick;
    private Vector3 bridgePos;
    private Transform placedBricks;

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
        if (hit.collider.GetComponent<PlacedBrick>() != null  && bricks <= 0)
        {
            DontStepToOtherColorBrick();
        }
        else if (hit.collider.GetComponent<PlacedBrick>() != null && bricks > 0)
        {
            ReplaceOtherColorBrick(hit);
        }
        if (hit.collider.CompareTag(Constant.BRIDGE))
        {
            if (bricks > 0)
            {
                PlaceBricks(hit);
            }
            else
            {
                brickCount = hit.collider.GetComponent<WayKeeper>().bricksPlaced;
                BlockFallOff();
            }
        }

    }
    private void ReplaceOtherColorBrick(RaycastHit hit)
    {
        Vector3 newBrickposition = hit.transform.position;

        Destroy(hit.collider.gameObject);

        Transform newBrick = Instantiate(placedBrick, newBrickposition, placedBrick.transform.rotation);

       // newBrick.GetComponent<Renderer>().material.SetColor("_Color", selectedColor);
        //newBrick.GetComponent<PlacedBrick>().colorName = selectedColorName;

        RemoveDummyBrick();

       // brickGenerator.GenerateRemovedBrick();
    }
    private void DontStepToOtherColorBrick()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
    }
    private void BlockFallOff()
    {
        Vector3 playerPosition = transform.position;

        if (transform.position.z > bridgePos.z + (brickCount * 0.50f))
        {
            playerPosition.z = bridgePos.z + (brickCount * 0.50f);
        }

        transform.position = playerPosition;
    }
    private void PlaceBricks(RaycastHit hit)
    {
        brickCount = hit.collider.GetComponent<WayKeeper>().bricksPlaced;
        Transform bridgeTrans= Cache.GetTransform(hit.collider.gameObject);
        bridgePos = bridgeTrans.position;
        //Debug.Log("tren cau");
        Vector3 brickPlacement = new Vector3(bridgePos.x, bridgePos.y + (brickCount * 0.40f), bridgePos.z + (brickCount * 0.9f));
        Transform brick = Instantiate(placedBrick, brickPlacement, placedBrick.transform.rotation, placedBricks);
        hit.collider.GetComponent<WayKeeper>().bricksPlaced += 1;
        RemoveDummyBrick();
        brickGenerator.GenerateRemovedBrick();
    }
    private void RemoveDummyBrick()
    {
        GameObject lastBrick = brickArea.GetChild(brickArea.childCount - 1).gameObject;
        Destroy(lastBrick);
        bricks--;
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
              bricks++;
        }
      
    }

}
