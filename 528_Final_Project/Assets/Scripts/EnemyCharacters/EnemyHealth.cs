using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EnemyCharacters
{
   public class EnemyHealth : MonoBehaviour
   {
       private int maxHP;
       private int currentHP;

       public EnemyHealth(int _maxHP)
       {
           maxHP = _maxHP;
           currentHP = maxHP;
       }

       public void IncrementByOne()
       {
           currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
       }

       public void IncrementByAmount(int amount)
       {
           currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
       }

       public void DecrementByOne()
       {
           currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
       }

       public void DecrementByAmount(int amount)
       {
           currentHP = Mathf.Clamp(currentHP - amount, 0, maxHP);
       }

       public void Die()
       {
           while (currentHP > 0) DecrementByOne();
       }

       public void ResetHealth()
       {
           currentHP = maxHP;
       }

       public bool CheckForDeath()
       {
           if (currentHP <= 0)
           {
               return true;
           }

           return false;
       }

       public int GetMaxHealth() { return maxHP; }

       public int GetCurrentHealth() { return currentHP; }
   }
}
