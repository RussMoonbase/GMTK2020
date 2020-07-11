using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   public GameObject player;
   public Rigidbody rBody; // loaded in Inspector

   private Vector3 _distance;

   // Start is called before the first frame update
   void Start()
   {
      //player = GameObject.FindGameObjectWithTag("Player");
   }

   // Update is called once per frame
   void LateUpdate()
   {
      _distance = this.transform.position - player.transform.position;
      Debug.Log("Mag = " + _distance.magnitude);

      if (_distance.magnitude < 3f)
      {
         Debug.Log("TRUE");
         rBody.AddForce(player.transform.forward * 2f);
      }
   }
}
