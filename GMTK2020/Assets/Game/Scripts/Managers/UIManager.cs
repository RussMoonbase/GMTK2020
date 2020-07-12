using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
   public static UIManager instance;

   public TextMeshProUGUI quaterNumberText;
   public TextMeshProUGUI homeScoreText;
   public TextMeshProUGUI awayScoreText;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      quaterNumberText.text = "1";
      homeScoreText.text = "0";
      awayScoreText.text = "0";
   }

   // Update is called once per frame
   void Update()
   {

   }
}
