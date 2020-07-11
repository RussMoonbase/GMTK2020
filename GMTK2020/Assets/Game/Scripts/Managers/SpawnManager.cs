using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public static SpawnManager instance;

   public Transform[] footballGuySpawnPoints; // loaded in Inspector
   public Transform[] goalPoints; // loaded in Inspector
   public Transform[] ballSpawnPoints; // loaded in Inspector
   public GameObject footballGuy; // loaded in Inspector
   public GameObject ball; // loaded in Inspector
   public bool canSpawn;
   public bool canSpawnBall;

   private GameObject spawnedOpponent;

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
      if (canSpawn)
      {
         SpawnFootballGuy();
         canSpawn = false;
      }

      if (canSpawnBall)
      {
         SpawnBall();
         canSpawnBall = false;
      }
      
   }

   private void SpawnFootballGuy()
   {
      if (footballGuySpawnPoints.Length == goalPoints.Length)
      {
         for (int i = 0; i < footballGuySpawnPoints.Length; i++)
         {
            spawnedOpponent = Instantiate(footballGuy, footballGuySpawnPoints[i].position, footballGuySpawnPoints[i].rotation);
            spawnedOpponent.GetComponent<FootballGuyController>().destination = goalPoints[i];
         }
      }
   }

   private void SpawnBall()
   {
      int randomNum = Random.Range(0, ballSpawnPoints.Length);
      Instantiate(ball, ballSpawnPoints[randomNum].position, Quaternion.identity);
   }
}
