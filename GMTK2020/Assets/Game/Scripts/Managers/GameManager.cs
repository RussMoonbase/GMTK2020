using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public int quarterNum;
   public int opponentCount;
   public int maxOpponentCount;
   public int touchdownAmount;
   public int hitAmount;
   public int fieldGoalAmount;

   private int _homeScore = 0;
   private int _awayScore = 0;
   private bool _quaterFinished = false;
   private float _timer;


   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      _homeScore = 0;
      _awayScore = 0;
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
               UIManager.instance.quaterNumberText.text = quarterNum.ToString();
            }
         }
      }
      else
      {
         SpawnManager.instance.canSpawn = false;
         SpawnManager.instance.spawnOpponentCount = 0;
         Debug.Log("Game Over");
      }
   }

   public void UpdateAwayScore()
   {
      _awayScore += touchdownAmount;
      UIManager.instance.awayScoreText.text = _awayScore.ToString();
   }

   public void UpdateHomeScoreHit()
   {
      _homeScore += hitAmount;
      UIManager.instance.homeScoreText.text = _homeScore.ToString();
   }

   public void UpdateHomeScoreFieldGoal()
   {
      _homeScore += fieldGoalAmount;
      UIManager.instance.homeScoreText.text = _homeScore.ToString();
   }

}
