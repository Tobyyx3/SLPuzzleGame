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
                case String a when a.Contains("WalkItem"):
                    _programmingManager.Walk();
                    break;
                case String b when b.Contains("RotateItem"):
                    _programmingManager.Rotate(instruction.GetComponentInChildren<TMP_Dropdown>());
                    break;
                case String c when c.Contains("RepeatLoopItem"):
                    RepeatLoop(instruction);
                    //TODO: delay einbauen
                    yield break;
                default:
                    Debug.LogError("Keine gültige Anweisung in 'ExecutionSlot' gefunden.");
                    break;
            }

            yield return new WaitForSecondsRealtime(timeToWait);
        }
    }

    private void RepeatLoop(Transform instruction)
    {
        var repititions = Convert.ToInt32(instruction.GetComponentInChildren<TMP_InputField>().text);

        List<Transform> instructionsList = new List<Transform>();

        foreach (Transform execution in ExecutionSlot)
        {
            instructionsList.Add(execution);
        }

        var repeatLoopIndex = instructionsList.FindIndex(x => x.name == "RepeatLoopItem");

        for (int i = repeatLoopIndex + 1; i < instructionsList.Count; i++)
        {
            switch (instructionsList[i].ToString())
            {
                case String a when a.Contains("WalkItem"):

                    _programmingManager.Walk(repititions);
                    break;
                case String b when b.Contains("RotateItem"):
                    var rotateDropdown = instructionsList[i].GetComponentInChildren<TMP_Dropdown>();

                    _programmingManager.Rotate(rotateDropdown, repititions);
                    break;
                default:
                    break;
            }
        }
    }
}
