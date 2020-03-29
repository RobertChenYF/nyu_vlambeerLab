using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cameraOfThis;
    public static float FOV = 20;
    public int a;
    public int c;
    public static bool Over = false;
    public static List<GameObject> floors;
    public static List<int> floorsX;
    public static List<int> floorsZ;
    public GameObject Sphere;
    public GameObject RestartGameButton;
    // Start is called before the first frame update
    void Start()
    {

        floors = new List<GameObject>();
        floorsX = new List<int>();
        floorsZ = new List<int>();
        cameraOfThis = GetComponent<Camera>();
        
       // FOV = cameraOfThis.fieldOfView;
    }

    void Update()
    {
        
        if (Pathmaker.PathSphereCount<= 0)
        {
            Debug.Log("over");
            Over = true;
        }
        if (Over)
        {
            //display r to re instantiate
            FOV += Time.deltaTime * 10;
            RestartGameButton.SetActive(true);
        }
        else
        {
            RestartGameButton.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Pathmaker.globalCounter<500)
        // {
        //  Vector3 totalPosition = new Vector3(0, 0, 0);
        // foreach (GameObject a in Pathmaker.floors)
        // {
        //     totalPosition += a.transform.position;
        //  }

        if (floors.Count>0)
        {
        floorsX.Sort();
        floorsZ.Sort();

        //transform.position = new Vector3(Pathmaker.floorsX[(int)(Pathmaker.floorsX.Count/2)], FOV, Pathmaker.floorsZ[(int)(Pathmaker.floorsZ.Count/2)]);
        int a = ((int)(floorsX.Count/2));
        int c = ((int)(floorsZ.Count/2));
        transform.position = new Vector3(floorsX[a], FOV, floorsZ[c]);
        }
        

        //Debug.Log(Pathmaker.floorsX[b]);
        //Debug.Log(a);
        //Debug.Log(Pathmaker.floorsX.Count);
       // Debug.Log(Pathmaker.floorsZ.Count);
        // transform.position = new Vector3(totalPosition.x/Pathmaker.globalCounter,FOV,totalPosition.z/Pathmaker.globalCounter);

        // }


        // cameraOfThis.fieldOfView = FOV;
    }

    public void Restart()
    {
        floorsX.Clear();
        floorsZ.Clear();
        foreach (GameObject a in floors)
        {
            Destroy(a);
        }
        floors.Clear();
        Pathmaker.globalCounter = 0;
        FOV = 20;
        Over = false;
        Instantiate(Sphere, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
