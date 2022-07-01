using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
   [Header("Parameters")]
   [SerializeField] private float playerSpeed;

	 [SerializeField] private float jumpForce;

	 [Header("Links")]
   [SerializeField] private Rigidbody2D playerRb;

   [SerializeField] private Animator playerAnimator;

	 [SerializeField] private bool isOnGround;

	 private void Update()
	 {
			if (isOnGround && Input.GetKeyDown(KeyCode.Space))
			{
				 Jump();
			}
	 }


	 private void FixedUpdate()
	 {
      float horizontalInput = Input.GetAxis("Horizontal");

			if (horizontalInput != 0)
			{
         transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
      }

      playerRb.velocity = new Vector2(horizontalInput * playerSpeed * Time.deltaTime, playerRb.velocity.y);

      playerAnimator.SetFloat("HorizontalInput", Mathf.Abs(horizontalInput));

	 }

	 private void Jump()
	 {
			isOnGround = false;

			playerRb.AddForce(playerRb.transform.up*jumpForce,ForceMode2D.Impulse);
	 }

	 private void OnTriggerEnter2D(Collider2D collision)
	 {
			if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				 isOnGround = true;
			}
	 }
}
