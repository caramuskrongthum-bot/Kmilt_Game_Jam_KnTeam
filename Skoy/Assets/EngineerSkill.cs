using UnityEngine;

public class EngineerSkill : MonoBehaviour
{
    public Camera cam;
    public GameObject previewPrefab;    
    public GameObject realPrefab;       
    public LayerMask floorMask;

    private GameObject previewObj;

    public Vector3 Rot;

    void Start()
    {
        previewObj = Instantiate(previewPrefab);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, floorMask))
        {
            previewObj.SetActive(true);
            previewObj.transform.position = hit.point;


            previewObj.transform.rotation = Quaternion.Euler(Rot);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(realPrefab, hit.point, previewObj.transform.rotation);
            }
        }
        else
        {
            previewObj.SetActive(false);
        }
    }
}