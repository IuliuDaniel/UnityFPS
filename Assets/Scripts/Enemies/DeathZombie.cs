using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZombie : MonoBehaviour
{
    public int enemyHealth = 10;
   
   
   public GameObject Zombie;

    void DamageEnemy(int damageAmount) 
   {
       enemyHealth -= damageAmount;
   }
    void Update()
    {
        
        if (enemyHealth <=0 )
        {
            
            
            Zombie.SetActive(false);
            GlobalScore.scoreValue += 50;
            
            
        }
    }
}
    
