using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{
    public TMP_Dropdown WalkDropdown;
    public TMP_Dropdown RotateDropdown;

    public PlayerController _playerController;

    public void Walk()
    {
        if (WalkDropdown.value == 0)
        {
            _playerController.Walk(PlayerController.Direction.Forward);
        }
        else
        {
            _playerController.Walk(PlayerController.Direction.Backward);
        }
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
}