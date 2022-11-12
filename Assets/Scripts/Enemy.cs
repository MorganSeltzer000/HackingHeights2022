using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<EnemyMove> movementBehaviour;
    public List<EnemyRotate> rotationBehaviour;

    public float movementSpeed;
    public float rotateSpeed;
    public bool loopMovementBehaviour;
    public bool loopRotationBehaviour;

    Vector2 movementDirection;
    RotationDirection rotationDirection;

    private void Start()
    {
        movementDirection = Vector2.zero;
        StartCoroutine(MovementControl());
        StartCoroutine(RotationControl());
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private IEnumerator MovementControl()
    {
        foreach (EnemyMove enemyMove in movementBehaviour)
        {
            movementDirection = enemyMove.direction;
            yield return new WaitForSeconds(enemyMove.duration);
        }

        if (loopMovementBehaviour)
        {
            StartCoroutine(MovementControl());
        }
        else
        {
            movementDirection = Vector2.zero;
        }
    }

    private IEnumerator RotationControl()
    {
        foreach (EnemyRotate enemyRotate in rotationBehaviour)
        {
            rotationDirection = enemyRotate.rotationDirection;
            yield return new WaitForSeconds(enemyRotate.duration);
        }

        if (loopRotationBehaviour)
        {
            StartCoroutine(RotationControl());
        }
        else
        {
            rotationDirection = RotationDirection.Idle;
        }
    }

    private void Move()
    {
        this.transform.position += (Vector3) movementDirection * movementSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        if (rotationDirection == RotationDirection.Clockwise)
        {
            this.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
        }
        else if (rotationDirection == RotationDirection.AntiClockwise)
        {
            this.transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
        }
    }
}
