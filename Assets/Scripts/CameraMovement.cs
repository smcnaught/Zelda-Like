using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public Transform target;
  public float smoothing;
  public Vector2 maxPosition;
  public Vector2 minPosition;

  // Start is called before the first frame update
  void Start()
  {

  }

  // LateUpdate is called last
  void LateUpdate()
  {
    if (this.transform.position != this.target.position)
    {
      Vector3 targetPosition = new Vector3(this.target.position.x, this.target.position.y, transform.position.z);
      
      targetPosition.x = Mathf.Clamp(targetPosition.x, this.minPosition.x, this.maxPosition.x); // Prevent the camera from going past this x
      targetPosition.y = Mathf.Clamp(targetPosition.y, this.minPosition.y, this.maxPosition.y); // Prevent the camera from going past this y
      this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, this.smoothing);
    }
  }
}
