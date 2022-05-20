using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

  [SerializeField] float delay = 1f;

  [SerializeField] AudioClip crashSound;
  [SerializeField] AudioClip successSound;

  AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }
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
        StartSuccessSequence();
        break;
      default:
        StartCrashSequence();
        break;
    }
  }
  void StartCrashSequence()
  {
    audioSource.PlayOneShot(crashSound);
    // Add particle effect
    GetComponent<Movement>().enabled = false; // remove control
    Invoke("ReloadLevel", delay);
  }
  void StartSuccessSequence()
  {
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
