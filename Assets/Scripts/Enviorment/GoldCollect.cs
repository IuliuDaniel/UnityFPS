using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCollect : MonoBehaviour
{
    public GameObject goldIngots;
    public AudioSource collectSound;
    
    void OnTriggerEnter(Collider other) 
    {
        GlobalScore.scoreValue += 10;
        goldIngots.SetActive(false);
        collectSound.Play();
        GetComponent<BoxCollider>().enabled = false;

    }
    
}
