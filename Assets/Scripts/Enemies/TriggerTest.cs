using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public int IsAttacking;
    public int enemyHealth = 10;
   
   
   public GameObject Zombie;
   void DamageEnemy(int damageAmount) 
   {
       enemyHealth -= damageAmount;
   }

    void Update() 
    {
        
    transform.LookAt(ThePlayer.transform);
    
        if (enemyHealth <=0 )
        {
            
            
            Zombie.SetActive(false);
            GlobalScore.scoreValue += 50;
            
            
        }
    
    if (GlobalHealth.healthValue <100) {
        StartCoroutine(SmellBlood());
    }
    else {
        StartCoroutine(Casual());
    }

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
   IEnumerator SmellBlood() {
       AllowedRange = 15;
       yield return null;

   }
   IEnumerator Casual(){
       AllowedRange = 10;
       yield return null;
   }
}
