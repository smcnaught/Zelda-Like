using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
  public Vector2 cameraChange;
  public Vector3 playerChange;
  public bool needText;
  public string placeName;
  public GameObject text;
  public Text placeText;
  private CameraMovement cam;

  // Start is called before the first frame update
  void Start()
  {
    this.cam = Camera.main.GetComponent<CameraMovement>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  // Changing from one room to another.
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player")) // if player is in trigger zone (switching rooms)
    {
      // Debug.Log("Is Player");
      this.cam.minPosition += this.cameraChange;
      this.cam.maxPosition += this.cameraChange;
      other.transform.position += this.playerChange;

      if(this.needText)
      {
        StartCoroutine(this.placeNameCoRoutine());
      }
    }
  }

  private IEnumerator placeNameCoRoutine()
  {
    this.text.SetActive(true);
    this.placeText.text = this.placeName;
    yield return new WaitForSeconds(4f); // wait for 4 seconds
    text.SetActive(false);
  }
}
