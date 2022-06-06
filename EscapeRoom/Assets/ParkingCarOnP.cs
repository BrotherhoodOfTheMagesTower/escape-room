using UnityEngine;

public class ParkingCarOnP : MonoBehaviour
{
    bool inside = false;

    [Space, Header("Car Stuff")]
    [SerializeField] GameObject car = null;

    void Start()
    {
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "pBoxCollider")
        {
            col.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "pBoxCollider")
        {
            inside = !inside;
        }
    }
}

