using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FootballGuyController : MonoBehaviour
{
   public NavMeshAgent navAgent; //loaded in Inspector
   public GameObject player;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      navAgent.SetDestination(player.transform.position);
   }
}
