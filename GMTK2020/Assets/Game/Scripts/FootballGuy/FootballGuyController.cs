using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FootballGuyController : MonoBehaviour
{
   public NavMeshAgent navAgent; //loaded in Inspector
   public Transform destination;
   public float deathWaitTime;

   [SerializeField] private Animator _animator; // loaded in Inspector

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (navAgent.enabled)
      {
         navAgent.SetDestination(destination.position);
      }
      
   }

   public void TurnOnRagdoll(Collider col)
   {
      if (_animator.enabled)
      {
         GameManager.instance.opponentCount--;
         _animator.enabled = false;
         navAgent.enabled = false;
         StartCoroutine(ExplosionDestroy());
      }

      col.attachedRigidbody.AddForce((Camera.main.transform.forward * 150f), ForceMode.Impulse);
   }

   private IEnumerator ExplosionDestroy()
   {
      yield return new WaitForSeconds(deathWaitTime);
      Vector3 explodePosition = this.transform.position;
      Collider[] colliders = Physics.OverlapSphere(explodePosition, 4f);
      foreach (Collider hit in colliders)
      {
         Rigidbody rb = hit.GetComponent<Rigidbody>();

         if (rb != null)
         {
            rb.AddExplosionForce(300f, explodePosition, 20f, 200f, ForceMode.Impulse);
         }
      }
      Destroy(this.gameObject, deathWaitTime);
   }
}
