using Unity.Cinemachine;
using UnityEngine;

public class SetPlayerCam : MonoBehaviour
{
    public float dragSpeed = 0.2f;
    public float dragThreshold = 10f;
    private Vector3 mouseDown;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = Input.mousePosition;
            isDragging = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (!isDragging && Vector3.Distance(mouseDown, Input.mousePosition) > dragThreshold)
            {
                isDragging = true;
            }

            if (isDragging)
            {
                Vector3 delta = Input.mousePosition - mouseDown;
                mouseDown = Input.mousePosition;
                Vector3 right = Camera.main.transform.right;
                Vector3 forward = Camera.main.transform.forward;
                right.y = 0;
                forward.y = 0;
                Vector3 move = (-right * delta.x + -forward * delta.y) * dragSpeed;
                transform.position += move;
            }
        }
    }
}