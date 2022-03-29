using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    //------------------ VARIABLES ------------------
    public Texture2D cursor;
    public Texture2D cursorClicked;

    private ClickControl controls;
    private Camera mainCamera;

    //------------------ FUNCTIONS ------------------
    private void Awake()
    {
        controls = new ClickControl();
        ChangedCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined; // Stay at center of screen
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    //-----------------------------------------------
    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangedCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangedCursor(cursor);
        DetectObject();
    }
    //---------------------- RAYCASTING -------------------------
    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                IClicked click = hit.collider.gameObject.GetComponent<IClicked>();
                if (click != null)
                {
                    click.onClickAction(); // Interface >> StandScript >> Destroy object
                }
                Debug.Log("3D Hit: " + hit.collider.tag);
            }
        }
    }

    //------------------ METHOD ------------------
    private void ChangedCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}