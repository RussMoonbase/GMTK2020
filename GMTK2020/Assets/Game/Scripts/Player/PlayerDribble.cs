using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDribble : MonoBehaviour
{
   public static PlayerDribble instance;
   public float translateSpeed;
   public float kickPower;

   public GameObject arrow;
   public GameObject playerModel;
   public GameObject target;
   public GameObject player;
   public Ball ball;

   public bool isKicking = false;

   private Vector3 _aimVector;
   private Vector3 _arrowVector;

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
      if (Input.GetButtonDown("R3"))
      {
         _aimVector = target.transform.position;
         _aimVector.x = player.transform.position.x;
         target.transform.position = _aimVector;
      }

      //target.transform.Translate(new Vector3(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"), 0f) * Time.deltaTime * 10f);
      target.transform.Translate(new Vector3(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY"), 0f) * Time.deltaTime * translateSpeed);
      _aimVector = target.transform.position;
      _aimVector.y = Mathf.Clamp(_aimVector.y, 0.3f, 17f);
      target.transform.position = _aimVector;

      _arrowVector = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
      arrow.transform.LookAt(_arrowVector);
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Ball")
      {
         Vector3 direction = target.transform.position - playerModel.transform.position;
         direction = direction.normalized;
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
         if (isKicking)
         {
            ball = collision.gameObject.GetComponent<Ball>();

            if (rb)
            {
               rb.AddForce(direction * kickPower, ForceMode.Impulse);
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
