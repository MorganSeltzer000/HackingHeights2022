using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<EnemyMove> movementBehaviour;

    public float speed;
    public bool loopMovementBehaviour;

    Vector2 movementDirection;

    private void Start()
    {
        movementDirection = Vector2.zero;
        StartCoroutine(MovementControl());
    }

    private void Update()
    {
        Move();
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
    }

    private void Move()
    {
        this.transform.position += (Vector3) movementDirection * speed * Time.deltaTime;
    }
}
