using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum RotationDirection { Clockwise, AntiClockwise, Idle}

[Serializable]
public class EnemyRotate
{
    [SerializeField]
    public RotationDirection rotationDirection;
    [SerializeField]
    public float duration;
    [SerializeField]
    public bool toBeLooped;
}
