using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        break;
      default:
        Debug.Log("Explode");
        break;
    }
  }
}
