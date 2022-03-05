using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor;
    public AudioSource doorFX;
    
    void OnTriggerEnter(Collider other) 
    {
        doorFX.Play();
        theDoor.GetComponent<Animator>().Play("DoorOpen");
        StartCoroutine(CloseDoor());
        this.GetComponent<BoxCollider>().enabled=false;
            }

   IEnumerator CloseDoor()
   {
       yield return new WaitForSeconds(5);
       theDoor.GetComponent<Animator>().Play("DoorClose");
       doorFX.Play();
       this.GetComponent<BoxCollider>().enabled=true;
   }
  
}
