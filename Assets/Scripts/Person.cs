using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    #region PUBLIC VARIABLES
    #endregion
        public float moveSpeed {get; private set;}
    #region PRIVATE VARIABLES
        private Animator animator;
        private Rigidbody rb; 
        private float speedAnimAdj;

    #endregion

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        speedAnimAdj = 3f;
    }

    private void FixedUpdate() {
        if (moveSpeed < 1) {
            moveSpeed += 0.002f;
            animator.SetFloat("Speed_f", moveSpeed);
        }
        else {
            moveSpeed = 0;
            animator.SetFloat("Speed_f", moveSpeed);
        }
        rb.MovePosition(transform.position + transform.forward * moveSpeed * speedAnimAdj * Time.fixedDeltaTime);
    }
}
