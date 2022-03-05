using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun;
    public GameObject fakeHandgun;
    public AudioSource handgunPickupFX;
    
   


     void OnTriggerEnter(Collider other)
     {
         realHandgun.SetActive(true);
         fakeHandgun.SetActive(false);
         handgunPickupFX.Play();

     }
   
}
