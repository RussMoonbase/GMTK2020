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

   public Image fadeImage;
   public Color newColor;
   public float fadeSpeed;
   public bool changeToColor;
   public bool changeToTransparent;

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
      changeToTransparent = true;
   }

   // Update is called once per frame
   void Update()
   {
      if (changeToColor)
      {
         FadeScreenToColor();
      }

      if (changeToTransparent)
      {
         FadeScreenToTransparent();
      }
   }

   private void FadeScreenToColor()
   {
      newColor = fadeImage.color;
      newColor.a = Mathf.MoveTowards(newColor.a, 1f, fadeSpeed * Time.deltaTime);
      fadeImage.color = newColor;

      if (fadeImage.color.a >= 1f)
      {
         changeToColor = false;
      }
   }

   private void FadeScreenToTransparent()
   {
      newColor = fadeImage.color;
      newColor.a = Mathf.MoveTowards(newColor.a, 0f, fadeSpeed * Time.deltaTime);
      fadeImage.color = newColor;

      if (fadeImage.color.a <= 0f)
      {
         changeToTransparent = false;
      }
   }
}
