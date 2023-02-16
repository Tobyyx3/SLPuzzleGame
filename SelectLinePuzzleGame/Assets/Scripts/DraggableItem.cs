using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image DraggedItem;
    [HideInInspector] public Transform parentAfterDrag;

    [Header("All Raycasting Objects (Rotate)")]
    public TMP_Text RotateText;
    public Image RotateDropdown;
    public TMP_Text Label;
    public Image Arrow;
    public Image Template;
    public Image Viewport;
    public Image ItemBackground;
    public Image ItemCheckmark;
    public TMP_Text ItemLabel;
    public Image Scrollbar;
    public Image Handle;


    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        DraggedItem.raycastTarget = false;

        // TODO: Alle RaycastTarget Checkboxen der Dropdowns false setzen
        if (RotateText != null)
        {
            DropdownRaycastTarget(false);
        }

        // TODO: RaycastTarget Checkbox der Inputs false setzen
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        DraggedItem.raycastTarget = true;
        // TODO: Alle RaycastTarget Checkboxen der Dropdowns true setzen
        if (RotateText != null)
        {
            DropdownRaycastTarget(true);
        }

        // TODO: RaycastTarget Checkbox der Inputs true setzen
    }

    private void DropdownRaycastTarget(Boolean booleanValue)
    {
        RotateText.raycastTarget = booleanValue;
        RotateDropdown.raycastTarget = booleanValue;
        Label.raycastTarget = booleanValue;
        Arrow.raycastTarget = booleanValue;
        Template.raycastTarget = booleanValue;
        Viewport.raycastTarget = booleanValue;
        ItemBackground.raycastTarget = booleanValue;
        ItemCheckmark.raycastTarget = booleanValue;
        ItemLabel.raycastTarget = booleanValue;
        Scrollbar.raycastTarget = booleanValue;
        Handle.raycastTarget = booleanValue;
    }
}