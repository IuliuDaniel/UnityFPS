using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthCollect : MonoBehaviour
{
    
    void OnTriggerEnter(Collider ohter)
    {
        GlobalHealth.healthValue = 100;
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
    
        
    }

