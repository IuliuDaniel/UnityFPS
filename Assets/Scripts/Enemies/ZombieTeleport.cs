using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTeleport : MonoBehaviour
{
    public GameObject ThePlayer;
    public Transform teleportTarget;
    public GameObject theZombie;
    public float TargetDistance;
    public float AllowedRange = 5;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public int IsAttacking;

    void Update() 
    {
    transform.LookAt(ThePlayer.transform);
    

    if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
        TargetDistance = Shot.distance;
        if(TargetDistance < AllowedRange) {
            EnemySpeed = 0.01f;
            if(AttackTrigger == 0) {
                TheEnemy.GetComponent<Animation>().Play("Walking");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
            }
           

        }
         else {
             theZombie.transform.position = teleportTarget.transform.position;
            EnemySpeed = 0;
            TheEnemy.GetComponent<Animation> ().Play ("Idle");
            
        
        }
    }
    if (AttackTrigger == 1) {
        if(IsAttacking == 0){
            StartCoroutine(EnemyDamage());
        }
        EnemySpeed= 0;
        TheEnemy.GetComponent<Animation> ().Play ("Attacking");
    }
    }
    void OnTriggerEnter() {
        AttackTrigger = 1;
    }
    void OnTriggerExit(){
        AttackTrigger = 0;
    }
    IEnumerator EnemyDamage() {
        IsAttacking = 1;
        GlobalHealth.healthValue -=1;
        yield return new WaitForSeconds(2);
        IsAttacking = 0;
    }
}
