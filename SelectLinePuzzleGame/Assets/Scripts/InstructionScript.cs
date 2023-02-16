using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionScript : MonoBehaviour
{
    private Vector3 _defaultLocation;

    void Start()
    {
        _defaultLocation = transform.position;
    }

    void Update()
    {
        if (transform.parent.name != "BtRepeatLoop")
        {
            transform.position = _defaultLocation;
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
