using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreManager : MonoBehaviour
{
   public TextMeshProUGUI homeScoreText;
   public TextMeshProUGUI awayScoreText;

   // Start is called before the first frame update
   void Start()
   {
      homeScoreText.text = PlayerPrefs.GetInt("homeScore").ToString();
      awayScoreText.text = PlayerPrefs.GetInt("awayScore").ToString();
   }

   // Update is called once per frame
   void Update()
   {

   }
}
