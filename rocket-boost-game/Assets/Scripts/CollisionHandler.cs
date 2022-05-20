using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

  [SerializeField] float delay = 3f;

  [SerializeField] AudioClip crashSound;
  [SerializeField] AudioClip successSound;

  AudioSource audioSource;

  bool isTransitioning = false;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }
  void OnCollisionEnter(Collision other)
  {
    if (isTransitioning) return;

    switch (other.gameObject.tag)
    {
      case "Fuel":
        Debug.Log("is a FUEL");
        break;
      case "Friendly":
        Debug.Log("Launch Pad");
        break;
      case "Finish":
        StartSuccessSequence();
        break;
      default:
        StartCrashSequence();
        break;
    }
  }
  void StartCrashSequence()
  {
    isTransitioning = true;
    audioSource.PlayOneShot(crashSound);
    // Add particle effect
    GetComponent<Movement>().enabled = false; // remove control
    Invoke("ReloadLevel", delay);
  }
  void StartSuccessSequence()
  {
    isTransitioning = true;
    audioSource.PlayOneShot(successSound);
    // Add particle effect
    GetComponent<Movement>().enabled = false; // remove control
    Invoke("GoToNextLevel", delay);
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
