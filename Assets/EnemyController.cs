using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour

    //This is a patrol script that will allow the enemy to wander around the map based on how the corresponded chess piece moves in real life chess. If the player collides with the enemy, the game is over
{
    Vector3 nextMove ; //the move will be called every time the enemy has landed on a square and will be assigned a random value from the list

    [SerializeField] List<Vector3> placesEnemyCanMove = new List<Vector3>(); //List of spaces the enemy can move to next

    //CHARACTER
    [SerializeField] float moveSpeed = 0.25f;

    [SerializeField] float snappingDistance;

    float initialPositionY; //to make snapping smoother


    Vector3 targetPos;
    Vector3 startPos;

    bool moving = false;

    void Start()
    {
        initialPositionY = transform.position.y;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(transform.position, targetPos) < snappingDistance)
            {
                transform.position = new Vector3(targetPos.x, initialPositionY, targetPos.z);
                
                moving = false;

                
                return;
            }

            transform.position += (targetPos - startPos) * moveSpeed * Time.deltaTime;

        }

       else if (!moving)
        {
            MoveToNextSquare();
        }

        
    }

    void MoveToNextSquare()
    {
        int randomPosition = Random.Range(0, placesEnemyCanMove.Count);
        nextMove = placesEnemyCanMove[randomPosition];

        

        if (!moving)
        {

            targetPos = transform.position + nextMove;
            

            startPos = transform.position;
            

            moving = true;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy Bound"))
        {
            transform.position = startPos; //If the enemy runs into a bound, its position will be reset and it will move another direction
            moving = false;
            MoveToNextSquare();
        }
    }
}
