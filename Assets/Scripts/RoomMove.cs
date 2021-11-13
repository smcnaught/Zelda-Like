using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // if player is in trigger zone (switching rooms)
        {
            Debug.Log("Is Player");
            this.cam.minPosition += this.cameraChange;
            this.cam.maxPosition += this.cameraChange;

            other.transform.position += this.playerChange;
        }
    }
}
