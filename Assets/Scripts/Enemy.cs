using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<EnemyMove> movementBehaviour;

    public float speed;

    int moveIndex = 0;

    private IEnumerator MoveIndexIncrease()
    {
        moveIndex += 1;

    }
}
