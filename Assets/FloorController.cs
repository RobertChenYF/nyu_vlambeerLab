using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public LayerMask m_LayerMask;
    private bool reportOnce = false;
  
    // Start is called before the first frame update
    void Start()
    {
        


        m_LayerMask = LayerMask.GetMask("Default");
       // meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!meshRenderer.isVisible)
        {
            CameraController.FOV += Time.deltaTime*10;

        }
       
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        if (hitColliders.Length>1 && reportOnce==false)
        {
            foreach (Collider a in hitColliders)
        {
            if (a.gameObject.CompareTag("Floor")){
               // Debug.Log("floor overlap");
                    reportOnce = true;
                    break;
            }
        }
        }
        
       
    }

    

    

}
