using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckForNewChildren : MonoBehaviour
{
    public Int32 DefaultChildrenCount = 2;
    private String[] ValidOperators = { "BtWalk", "BtRotate" };

    void Start()
    {
    }


    void Update()
    {
        AttachAndDetachChildren();
    }

    private void AttachAndDetachChildren()
    {
        List<GameObject> children = new List<GameObject>();

        if (transform.childCount != DefaultChildrenCount)
        {
            foreach (Transform child in transform)
            {
                if (ValidOperators.Contains(child.name))
                {
                    children.Add(child.transform.gameObject);

                    child.transform.position = transform.position + new Vector3(0, -35, 0);
                    child.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 60);
                    child.GetComponent<Button>().interactable = false;
                }
            }
        }
        else
        {
            if (children.Count > 0)
            {
                foreach (var child in children)
                {
                    child.transform.position = new Vector2(800f, -250f);             
                }

                children.Clear();
            }
        }
    }
}
