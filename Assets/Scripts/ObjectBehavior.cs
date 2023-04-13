using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private bool isColliding = false;
    private bool isSelected = false;
    private bool isMovable = true;
    private Collider currentCollider = null;
    private GameState gs = null;

    private void Start()
    {
        gs = GameObject.Find("GameState").GetComponent<GameState>();
    }

    private void Update()
    {
        if (!isSelected) return;

        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    transform.Rotate(Vector3.up * 1.5f, Space.World);
        //}
        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
        //    transform.Rotate(Vector3.up * -1.5f, Space.World);
        //}
    }

    void OnMouseDown()
    {
        if (!isMovable) return;

        isSelected = true;

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (!isMovable) return;

        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnMouseUp()
    {
        if (!isMovable) return;

        isSelected = false;

        if (isColliding && currentCollider)
        {
            if (gameObject.tag == currentCollider.tag /*&& transform.eulerAngles.z >= -10 && transform.eulerAngles.y <= 10*/)
            {
                gs.IncrementMatchCount();
                isMovable = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        currentCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        currentCollider = null;
    }
}
