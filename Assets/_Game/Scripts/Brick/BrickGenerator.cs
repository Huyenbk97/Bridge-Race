using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform BrickPrefab;
    private Vector3 startPoint;
    private Vector3 position;
    private int numberBrick = 36;
    private int line = 6;
    private int xOrder = 0;
    private float zPosition;
    private float xPosition;

    [System.Serializable]
    public class SpawnedBricks
    {
        public Color color;
        public string colorName;
        public Vector3 position;
        public bool removed;
    }
    public SpawnedBricks[] spawnedBricks;
    [System.Serializable]
    public class ColorData
    {
        public Color color;
        public string colorName;
    }
    public ColorData[] colorArray;
    void Start()
    {
        startPoint = transform.position;
        zPosition = transform.position.z;
        xPosition = transform.position.x;
        spawnedBricks = new SpawnedBricks[numberBrick];
        CreateBricks();
    }
    private void CreateBricks()
    {
        for (int i = 0; i < numberBrick; i++)
        {
            xOrder=xOrder+4;
            if (i % line == 0)
            {
                zPosition -= 3;
                xOrder = 0;
                position = new Vector3(xPosition, startPoint.y, zPosition);
            }
            else
            {
                position = new Vector3(xPosition + xOrder, startPoint.y, zPosition);
            }
            GetBricktoPool(position,i);
           
        }
    }
    private void GetBricktoPool(Vector3 BrickSpawPosition,int i)
    {
        GameObject brick = BrickPool.ins.GetPooledObject();
        if (brick != null)
        {
            brick.transform.position = BrickSpawPosition;
            brick.SetActive(true);
        }
        GiveColor(brick,i);
    }
    private void GiveColor(GameObject Brick,int i)
    {
        int randomColor = Random.Range(0, colorArray.Length);
        Brick.GetComponent<Renderer>().material.SetColor("_Color", colorArray[randomColor].color);
        Brick.GetComponent<Brick>().colorName = colorArray[randomColor].colorName;
        Brick.GetComponent<Brick>().brickNumber = i;
    }
    void Update()
    {
        
    }
    public void GenerateRemovedBrick()
    {
        for (int i = 0; i < numberBrick; i++)
        {
            if (spawnedBricks[i].removed == true)
            {
               
                GameObject createdBrick = BrickPool.ins.GetPooledObject();
                if (createdBrick != null)
                {
                    createdBrick.transform.position = spawnedBricks[i].position;
                    createdBrick.SetActive(true);
                }
                GiveColor(createdBrick, i);
                createdBrick.GetComponent<Renderer>().material.SetColor("_Color", spawnedBricks[i].color);
                createdBrick.GetComponent<Brick>().colorName = spawnedBricks[i].colorName;
                createdBrick.GetComponent<Brick>().brickNumber = i;

                spawnedBricks[i].removed = false;
                return;
            }
        }
    }
}
