using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public enum Direction
    {
        Forward,
        Backward
    }

    public enum Rotation
    {
        Right,
        Left
    }

    public enum CurrentDirection
    {
        North,
        East,
        South,
        West
    }

    public CurrentDirection FacingDirection = CurrentDirection.North;

    void Start()
    {
        FacingDirection = CurrentDirection.North;
    }

    void Update()
    {
    }

    public void Walk(Direction direction)
    {
        if (direction == Direction.Forward)
        {
            switch (FacingDirection)
            {
                case CurrentDirection.North:
                    gameObject.transform.position += new Vector3(0, 1.5f);
                    break;
                case CurrentDirection.East:
                    gameObject.transform.position += new Vector3(1.5f, 0);
                    break;
                case CurrentDirection.South:
                    gameObject.transform.position += new Vector3(0, -1.5f);
                    break;
                case CurrentDirection.West:
                    gameObject.transform.position += new Vector3(-1.5f, 0);
                    break;
                default:
                    Debug.Log("Error while walking");
                    break;
            }
        }
        else
        {
            gameObject.transform.position -= new Vector3(0, 1);
        }
    }

    public void Rotate(Rotation rotation)
    {
        if (rotation == Rotation.Right)
        {
            gameObject.transform.Rotate(0, 0, -90f);
            FacingDirection++;

            if ((Int32)FacingDirection > 3)
            {
                FacingDirection = 0;
            }
        }
        else
        {
            gameObject.transform.Rotate(0, 0, 90f);
            FacingDirection--;

            if ((Int32)FacingDirection < 0)
            {
                FacingDirection += 4;
            }
        }
    }
}
