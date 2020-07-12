using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public int quarterNum;
   public int opponentCount;
   public int maxOpponentCount;

   private bool _quaterFinished = false;
   private float _timer;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      quarterNum = 1;
      SpawnManager.instance.canSpawn = true;
   }

   // Update is called once per frame
   void Update()
   {
      if (quarterNum <= 4)
      {
         if (opponentCount <= 0 && SpawnManager.instance.spawnOpponentCount >= maxOpponentCount)
         {
            _quaterFinished = true;

            if (_quaterFinished)
            {
               quarterNum++;
               SpawnManager.instance.canSpawn = true;
               SpawnManager.instance.spawnOpponentCount = 0;
               _quaterFinished = false;
            }
         }
      }
      else
      {
         Debug.Log("Game Over");
      }



   }

}
