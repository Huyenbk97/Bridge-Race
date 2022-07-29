
using UnityEngine;

public class GameMn : MonoBehaviour
{
    public GameObject WinUI;
    public static GameMn ins;
    // Start is called before the first frame update
    private void Awake()
    {
        ins = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showWINUI()
    {
        WinUI.SetActive(true);
    }
}
