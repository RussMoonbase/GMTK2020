using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   public Rigidbody rb; // loaded in Inspector

   //public float deathTime;
   public float maxTimeSittingStill;
   public float minRigidBodyVel;
   public bool wasKicked = false;

   private float _timer;
   public float currentVelocity;

   private void Start()
   {
      _timer = 0f;
   }

   private void FixedUpdate()
   {
      currentVelocity = rb.velocity.magnitude;
      //Debug.Log("Velocity = " + rb.velocity.magnitude);
      if (rb.velocity.magnitude <= minRigidBodyVel && wasKicked)
      {
         _timer += Time.deltaTime;

         if (_timer >= maxTimeSittingStill)
         {
            DeathRespawn();
         }
      }
      else
      {
         if (_timer >= 0.1f)
         {
            _timer = 0f;
         }
      }
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Opponent")
      {
         collision.gameObject.GetComponentInParent<FootballGuyController>().TurnOnRagdoll(collision.collider);
      }
   }

   public void DeathRespawn()
   {
      SpawnManager.instance.canSpawnBall = true;
      Destroy(this.gameObject);
   }


}
