﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDribble : MonoBehaviour
{
   public static PlayerDribble instance;

   public GameObject playerModel;
   public GameObject target;
   public GameObject player;
   public Ball ball;

   public bool isKicking = false;

   private Vector3 _aimVector;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      //target.transform.Translate(new Vector3(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"), 0f) * Time.deltaTime * 10f);
      _aimVector = new Vector3(0f, Input.GetAxisRaw("MouseY"), 0f);
      _aimVector.y = Mathf.Clamp(_aimVector.y, 0.3f, 9f);
      target.transform.Translate(_aimVector * Time.deltaTime * 10f);
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Ball")
      {
         Vector3 direction = target.transform.position - player.transform.position;
         direction = direction.normalized;
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
         if (isKicking)
         {
            ball = collision.gameObject.GetComponent<Ball>();

            if (rb)
            {
               rb.AddForce(direction * 5f, ForceMode.Impulse);
            }

            if (ball)
            {
               ball.wasKicked = true;
            }
         }
         else
         {
            rb.AddForce(direction * 0.3f, ForceMode.Impulse);
         }
      }
   }
}
