using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAI : MonoBehaviour
{
    
    public string hitTag;
    
    public GameObject theSoldier;
    public AudioSource fireSound;
    public bool isFiring = false;
    public float fireRate = 1.5f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    
    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast( transform.position, transform.TransformDirection(Vector3.forward), out Hit )) 
        {
           hitTag = Hit.transform.tag;
           
        }
        if(hitTag =="Soldier" && isFiring == false) 
        {
            StartCoroutine(EnemyFire());
        }
        if(hitTag != "Soldier")
        {
            theSoldier.GetComponent<Animator>().Play("Idle");
           
        }
    }
    IEnumerator EnemyFire(){
        isFiring=true;
        theSoldier.GetComponent<Animator>().Play("FirePistol", -1, 0);
        theSoldier.GetComponent<Animator>().Play("FirePistol");
           fireSound.Play();
            
            GlobalHealth.healthValue -= 5;
            hurtFlash.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            hurtFlash.SetActive(false);
            genHurt = Random.Range(0,3);
            
            
            hurtSound[genHurt].Play();        
            yield return new WaitForSeconds(fireRate);
            isFiring= false;
    }
}
