using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{

    public LayerMask m_LayerMask;
    // Start is called before the first frame update
    void Start()
    {
        m_LayerMask = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, new Vector3(0.2f,0.2f,0.2f), Quaternion.identity, m_LayerMask);
        
        if (hitColliders.Length > 1)
        {
            foreach (Collider a in hitColliders)
            {
                if (a.gameObject.CompareTag("Floor"))
                {
                    gameObject.SetActive(false);
                    break;
                }
            }
        }
        // void OnTriggerEnter(Collider other)
        //{
        //   if (other.gameObject.CompareTag("floor"))
        // {
        //       
        //  }
        // }
    }
}
