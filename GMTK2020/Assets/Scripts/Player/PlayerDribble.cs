using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDribble : MonoBehaviour
{
   public GameObject playerModel;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Ball")
      {
         Debug.Log("TRUE");
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

         if (rb)
         {
            rb.AddForce((playerModel.transform.localRotation * Vector3.forward) * 15f);
         }
      }
   }
}
