using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class ButtonManager : MonoBehaviour
{
    public TMP_Dropdown RotateDropdown;
    public TMP_InputField RepeatLoopInput;

    [SerializeField] private PlayerController _playerController;

    public void Walk()
    {
        _playerController.Walk(1);
    }

    public void Walk(Int32 repetitions)
    {
        _playerController.Walk(repetitions);
    }

    public void Rotate()
    {
        if (RotateDropdown.value == 0)
        {
            _playerController.Rotate(PlayerController.Rotation.Right);
        }
        else
        {
            _playerController.Rotate(PlayerController.Rotation.Left);
        }
    }

    public void Rotate(Int32 repetitions, PlayerController.Rotation rotation)
    {
        for (int i = 0; i < repetitions; i++)
        {
            _playerController.Rotate(rotation);
        }
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
            Rotate(repetitions, PlayerController.Rotation.Right);
        }
        else
        {
            Rotate(repetitions, PlayerController.Rotation.Left);
        }
    }
}
