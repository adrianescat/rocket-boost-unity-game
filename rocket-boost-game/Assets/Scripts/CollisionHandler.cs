using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Fuel":
        Debug.Log("is a FUEL");
        break;
      case "Friendly":
        Debug.Log("Launch Pad");
        break;
      case "Finish":
        Debug.Log("Finish Line");
        GoToNextLevel();
        break;
      default:
        Debug.Log("Explode");
        ReloadLevel();
        break;
    }
  }
  void ReloadLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  void GoToNextLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextSceneIndex = 0;
    }
    SceneManager.LoadScene(nextSceneIndex);
  }
}
