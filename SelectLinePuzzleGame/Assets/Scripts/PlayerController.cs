using System;
using System.Collections;
using System.IO.IsolatedStorage;
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


    void Start()
    {
        FacingDirection = CurrentDirection.North;
    }

    void Update()
    {
    }

    public void Walk(Int32 steps)
    {
        for (int i = 0; i < steps; i++)
        {
            StartCoroutine(ChooseDirection()); //TODO Zeitverz�gerung nach einem Schritt
        }
    }

    private IEnumerator ChooseDirection()
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

        yield return new WaitForSeconds(1);
    }

    //TODO Zeitverz�gerung nach einer Rotation
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
