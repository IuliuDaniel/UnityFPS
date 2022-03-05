using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Per10HealthCollect : MonoBehaviour
{
    
    void OnTriggerEnter(Collider ohter)
    {
        if(GlobalHealth.healthValue >=91 )
        {
            GlobalHealth.healthValue = 100;
        }
        else{
            GlobalHealth.healthValue += 10;
        }
        
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
    
        
    }

