using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;
  private Rigidbody2D myRigidBody;
  private Vector3 change;
  private Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    this.myRigidBody = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    this.change = Vector3.zero;
    this.change.x = Input.GetAxisRaw("Horizontal");
    this.change.y = Input.GetAxisRaw("Vertical");
    this.UpdateAnimationAndMove();

    // Debug.Log(this.change);
  }

  void UpdateAnimationAndMove()
  {
    bool playerIsMoving = this.change != Vector3.zero;

    if (playerIsMoving)
    {
      this.MoveCharacter();
      this.animator.SetFloat("moveX", this.change.x);
      this.animator.SetFloat("moveY", this.change.y);
      this.animator.SetBool("moving", true);
    }
    else
    {
      this.animator.SetBool("moving", false);
    }
  }

  void MoveCharacter()
  {
    // var currentPosition = transform.position;
    this.myRigidBody.MovePosition(transform.position + this.change * this.speed * Time.fixedDeltaTime);
  }
}
