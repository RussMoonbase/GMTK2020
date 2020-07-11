using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDribble : MonoBehaviour
{
   public GameObject playerModel;
   public GameObject target;
   public GameObject player;

   private 

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      target.transform.Translate(new Vector3(0f, Input.GetAxisRaw("MouseY"), 0f) * Time.deltaTime * 10f);
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Ball")
      {
         Vector3 direction = target.transform.position - player.transform.position;
         direction = direction.normalized;
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

         if (rb)
         {
            rb.AddForce(direction * 5f, ForceMode.Impulse);
         }
         
      }
   }
}
