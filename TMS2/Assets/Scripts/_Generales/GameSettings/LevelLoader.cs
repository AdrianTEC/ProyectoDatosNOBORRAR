
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public  class LevelLoader :MonoBehaviour
{
   public static string nextLevel;
   /// <summary>
   /// Load a level
   /// </summary>
   /// <param name="name"></param>
   public static void LoadLevel(string name)
   {
      nextLevel = name;

      SceneManager.LoadScene("Loading");
   }

   private static IEnumerator LoadLevelAsyncAux(string Sname){
      AsyncOperation operation= SceneManager.LoadSceneAsync(Sname);
      while (operation.isDone==false){
         SceneManager.LoadScene(Sname);
         yield return null;
         
      }
   }

   public  void LoadLevelAsync(string name){
      StartCoroutine(LoadLevelAsyncAux(name));

   }
 
}
