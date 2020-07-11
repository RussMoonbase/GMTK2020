using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FootballGuyController : MonoBehaviour
{
   public NavMeshAgent navAgent; //loaded in Inspector
   public Transform destination;

   [SerializeField] private Animator _animator; // loaded in Inspector

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      navAgent.SetDestination(destination.position);
   }

   public void TurnOnRagdoll(Collider col)
   {
      _animator.enabled = false;
      navAgent.speed = 0f;
      col.attachedRigidbody.AddForce((Camera.main.transform.forward * 150f), ForceMode.Impulse);
   }
}
