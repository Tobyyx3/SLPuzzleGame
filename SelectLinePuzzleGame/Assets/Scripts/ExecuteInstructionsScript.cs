using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExecuteInstructionsScript : MonoBehaviour
{
    public Transform ExecutionSlot;

    [SerializeField] 
    private ProgrammingManager _programmingManager;

    private float _waitingDelay = 0.5f;

    public void ExecuteInstructions()
    {
        StartCoroutine(DelayExecution(_waitingDelay));
    }

    private IEnumerator DelayExecution(float timeToWait)
    {
        foreach (Transform instruction in ExecutionSlot)
        {
            switch (instruction.name)
            {
                case "WalkItem":
                    _programmingManager.Walk();
                    break;
                case "RotateItem":
                    _programmingManager.Rotate(instruction.GetComponentInChildren<TMP_Dropdown>());
                    break;
                case "RepeatLoopItem":
                // TODO: Anweisung unter GameObj andocken und hier auswerten
                default:
                    break;
            }

            yield return new WaitForSecondsRealtime(timeToWait);
        }
    }
}
