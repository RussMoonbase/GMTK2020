using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public static SceneLoader instance;

   private void Awake()
   {
      instance = this;
   }

   private int _sceneNumber;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void LoadNextScene()
   {
      _sceneNumber = SceneManager.GetActiveScene().buildIndex;
      _sceneNumber++;
      SceneManager.LoadScene(_sceneNumber);
   }
}
