using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyMove
{
    [SerializeField]
    public Vector2 direction;
    [SerializeField]
    public float duration;
}
