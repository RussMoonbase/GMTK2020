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
   public GameObject runningBack;
   public GameObject ball; // loaded in Inspector
   public bool canSpawn;
   public bool canSpawnBall;

   private GameObject spawnedOpponent;
   public int spawnOpponentCount;

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
         if (spawnOpponentCount < GameManager.instance.maxOpponentCount)
         {
            StartCoroutine(ResetCanSpawn());
         }
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
            int randomNum = Random.Range(0, 9);
            if (GameManager.instance.quarterNum <= 2) // Quarter 1 & 2
            {
               spawnedOpponent = Instantiate(footballGuy, footballGuySpawnPoints[i].position, footballGuySpawnPoints[i].rotation);
            }
            else if (GameManager.instance.quarterNum == 3) // Quarter 3
            {
               if (randomNum <= 6)
               {
                  spawnedOpponent = Instantiate(footballGuy, footballGuySpawnPoints[i].position, footballGuySpawnPoints[i].rotation);
               }
               else
               {
                  spawnedOpponent = Instantiate(runningBack, footballGuySpawnPoints[i].position, footballGuySpawnPoints[i].rotation);
               }
            }
            else // Quarter 4
            {
               if (randomNum <= 4)
               {
                  spawnedOpponent = Instantiate(footballGuy, footballGuySpawnPoints[i].position, footballGuySpawnPoints[i].rotation);
               }
               else
               {
                  spawnedOpponent = Instantiate(runningBack, footballGuySpawnPoints[i].position, footballGuySpawnPoints[i].rotation);
               }
            }
            GameManager.instance.opponentCount++;
            spawnOpponentCount++;
            spawnedOpponent.GetComponent<FootballGuyController>().destination = goalPoints[i];
         }
      }
   }

   private void SpawnBall()
   {
      int randomNum = Random.Range(0, ballSpawnPoints.Length);
      Instantiate(ball, ballSpawnPoints[randomNum].position, Quaternion.identity);
   }

   private IEnumerator ResetCanSpawn()
   {
      yield return new WaitForSeconds(10.0f);
      canSpawn = true;
   }
}
