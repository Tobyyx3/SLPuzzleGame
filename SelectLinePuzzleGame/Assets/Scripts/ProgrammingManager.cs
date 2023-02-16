using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class ProgrammingManager : MonoBehaviour
{
    public TMP_Dropdown RotateDropdown;
    public TMP_InputField RepeatLoopInput;

    [SerializeField] 
    private PlayerController _playerController;

    public void Walk()
    {
        _playerController.Walk(1);
    }

    private void Walk(Int32 repetitions)
    {
        _playerController.Walk(repetitions);
    }

    public void Rotate(TMP_Dropdown tmpDropdown)
    {
        if (tmpDropdown.value == 0)
        {
            _playerController.Rotate(PlayerController.Rotation.Right, 1);
        }
        else
        {
            _playerController.Rotate(PlayerController.Rotation.Left, 1);
        }
    }

    private void Rotate(PlayerController.Rotation rotation, Int32 repetitions)
    {
        _playerController.Rotate(rotation, repetitions);
    }

    public void RepeatLoop()
    {
        var repetitions = Convert.ToInt32(RepeatLoopInput.text);

        var repeatModule = RepeatLoopInput.transform.parent.gameObject;

        
        foreach (var child in repeatModule.GetComponentsInChildren<Transform>())
        {
            switch (child.name)
            {
                case "BtWalk":
                    Walk(repetitions);
                    break;
                case "BtRotate":
                    RotateRepetition(repetitions, child);
                    break;
                default:
                    break;
            }
        }
    }

    private void RotateRepetition(Int32 repetitions, Transform child)
    { 
        var tmpDropdown = child.GetComponentInChildren<TMP_Dropdown>();

        if (tmpDropdown.value == 0)
        {
            Rotate(PlayerController.Rotation.Right, repetitions);
        }
        else
        {
            Rotate(PlayerController.Rotation.Left, repetitions);
        }
    }


}
