using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerMoveMouse : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject PointPrefab;
    public LayerMask mapLayer;

    public RaycastHit hit;
    public Vector3 targetPoint;
    bool JustMove;

    private Vector3 mouseDownPos;
    private bool isDragging;
    public float dragThreshold = 10f;

    void Update()
    {
        if (agent.velocity.magnitude > 0.9f)
        {
            animator.SetBool("Move", true);
            JustMove = true;
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(mouseDownPos, Input.mousePosition) > dragThreshold)
            {
                isDragging = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
            isDragging = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging) return;

            if (IsPointerOverUIExceptABC())
                return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mapLayer))
            {
                targetPoint = hit.point;

                GameObject[] P = GameObject.FindGameObjectsWithTag("Point");
                foreach (GameObject p_ in P)
                    Destroy(p_);

                Instantiate(PointPrefab).transform.position = hit.point;

                agent.SetDestination(hit.point);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            GameObject[] P = GameObject.FindGameObjectsWithTag("Point");
            foreach (GameObject p_ in P)
                Destroy(p_);
        }
    }

    private bool IsPointerOverUIExceptABC()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var r in results)
        {
            if (r.gameObject.layer != LayerMask.NameToLayer("CamControll"))
                return true;
        }

        return false;
    }
}
