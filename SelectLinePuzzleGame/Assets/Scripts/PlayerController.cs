using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CurrentDirection FacingDirection = CurrentDirection.North;

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

    private float _waitingDelay = 0.5f;

    void Start()
    {
        FacingDirection = CurrentDirection.North;
    }

    void Update()
    {
    }

    public void Walk(Int32 repititions)
    {
        StartCoroutine(DelayWalk(repititions));
    }

    private IEnumerator DelayWalk(Int32 repititions)
    {
        for (int i = 0; i < repititions; i++)
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
                    Debug.LogError("Error while walking.");
                    break;
            }

            yield return new WaitForSecondsRealtime(_waitingDelay);
        }
    }

    public void Rotate(Rotation rotation, Int32 repititions)
    {
        StartCoroutine(DelayRotation(rotation, repititions));
    }

    private IEnumerator DelayRotation(Rotation rotation, Int32 repititions)
    {
        for (int i = 0; i < repititions; i++)
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

            yield return new WaitForSeconds(_waitingDelay);
        }
    }
}
