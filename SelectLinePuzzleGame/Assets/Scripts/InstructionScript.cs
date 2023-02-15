using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionScript : MonoBehaviour
{
    private Vector3 DefaultLocation = new Vector3(0, 0, 0);

    void Start()
    {            
    }

    void Update()
    {
        if (transform.parent.name != "BtRepeatLoop")
        {
            transform.localPosition = DefaultLocation;
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
