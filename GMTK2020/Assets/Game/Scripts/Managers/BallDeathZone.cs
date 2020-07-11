using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeathZone : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Ball")
      {
         other.GetComponent<Ball>().DeathRespawn();
      }
   }
}
