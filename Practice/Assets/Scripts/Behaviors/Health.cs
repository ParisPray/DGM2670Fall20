using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public IntData health;
    public UnityEvent deathEvent, subtractHealthEvent;
  
    // Start is called before the first frame update
    void Start()
    {
        health.value = 1;
    }

    // Update is called once per frame
   public void AddHealth()
   {   
       if (health.value < 1)
   {
       health.value++;
   }
       
   }

   public void SubtractHealth()
   {
       health.value--;
       subtractHealthEvent.Invoke();
       if (health.value <= 0)
       {
           deathEvent.Invoke();
       }
   }

   public void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Enemy"))
       {
           SubtractHealth();
       }
   }
}
