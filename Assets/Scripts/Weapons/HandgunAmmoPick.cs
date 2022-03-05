using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunAmmoPick : MonoBehaviour
{
    
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupFX;
    
   


     void OnTriggerEnter(Collider other)
     {
         
         fakeAmmoClip.SetActive(false);
         ammoPickupFX.Play();
         GlobalAmmo.handgunAmmo += 10;

     }
}
