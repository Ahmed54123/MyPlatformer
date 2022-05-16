using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //INPUT
    Vector2 movementInput = Vector2.zero;
    

    //CHARACTER
    [SerializeField] float moveSpeed = 0.25f;
    

    Vector3 targetPos;
    Vector3 startPos;

    bool moving = false;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (moving)
        {
            if(Vector3.Distance(transform.position, targetPos) < 0.02f)
            {
                transform.position = targetPos;
                moving = false;
                return;
            }

            transform.position += (targetPos - startPos) * moveSpeed * Time.deltaTime;
            
        }

        
    }


   public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        MovePiece(movementInput);
       
    }

    void MovePiece(Vector2 movementReading)
    {

        if (!moving)
        {
            if (movementReading.y >= 1f)
            {
                targetPos = transform.position + Vector3.forward;
                startPos = transform.position;



                moving = true;
            }

            else if (movementReading.y <= -1f)
            {

                targetPos = transform.position + Vector3.back;
                startPos = transform.position;

                moving = true;


            }

            else if (movementReading.x >= 1f)
            {

                targetPos = transform.position + Vector3.right;
                startPos = transform.position;

                moving = true;


            }

            else if (movementReading.x <= -1f)
            {

                targetPos = transform.position + Vector3.left;
                startPos = transform.position;

                moving = true;


            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyController>() != null)
        {
            if (collision.gameObject.CompareTag("King"))
            {
                GameManager.Instance.WinGame();
            }

            else
            {
                GameManager.Instance.GameOver();

            }
        }


    }


}
