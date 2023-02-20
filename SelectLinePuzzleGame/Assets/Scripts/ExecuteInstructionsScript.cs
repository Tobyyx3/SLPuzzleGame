using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                    // TODO: Anweisung unter GameObj andocken und hier auswerten, statt alles darunter auszuwerten
                    RepeatLoop(instruction.GetComponentInChildren<TMP_InputField>(), instruction.GetComponentInChildren<TMP_Dropdown>());
                    yield break;
                default:
                    Debug.LogError("Keine gültige Anweisung in 'ExecutionSlot' gefunden.");
                    break;
            }

            yield return new WaitForSecondsRealtime(timeToWait);
        }
    }

    private void RepeatLoop(TMP_InputField inputField, TMP_Dropdown dropdown)
    {
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
                    if (inputField != null)
                    {
                        _programmingManager.Walk(Convert.ToInt32(inputField.text));
                    }
                    break;
                case String b when b.Contains("RotateItem"):
                    if (dropdown != null)
                    {
                        _programmingManager.Rotate(dropdown);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
