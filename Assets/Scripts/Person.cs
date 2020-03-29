using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public float moveSpeed {get; private set;}
    public enum PersonState {idle, walking, running, sitting, sheltered}
    #endregion

    #region PRIVATE VARIABLES
    private Animator animator;
    private Rigidbody rb; 
    private PersonState state = PersonState.idle;
    private float speedAnimAdj = 5f;    // fixed number to sync animation with movement speed
    private float targetTime = 0f;
    #endregion

    #region FUNCTIONS
    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        switch(state) {
            case PersonState.idle:
                StartWalking();    // TODO: REPLACE THIS
                break;
            case PersonState.walking:
                if(Mathf.Round(Time.timeSinceLevelLoad % 2) == 0) {
                    Turn(90f);
                }
                break;
            case PersonState.running:
                break;
            default:
                StartWalking();    // TODO: REPLACE THIS
                break;
        }
    }

    private void FixedUpdate() {
        // Move Person
        rb.MovePosition(transform.position + transform.forward * moveSpeed * speedAnimAdj * Time.fixedDeltaTime);
    }

    private void StartWalking() {
        state = PersonState.walking;
        moveSpeed = .75f;
        animator.SetFloat("Speed_f", moveSpeed);
    }

    private void StartRunning() {
        state = PersonState.running;
        moveSpeed = 1.5f;
        animator.SetFloat("Speed_f", moveSpeed);
    }

    private void Turn(float turnDegrees) {
        transform.Rotate(0,turnDegrees,0);
    }
    #endregion

}
