using UnityEngine;

public class ParkCar : MonoBehaviour
{
    bool inside = false;

    [Space, Header("Car Stuff")]
    [SerializeField] GameObject car = null;
    GameObject key;

    void Start()
    {
        inside = false;
        key = GameObject.Find("Key_Garage");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "CarCollider")
        {
            key.transform.position = new Vector3(123.0f, 1.0f, -20.0f);
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "CarCollider")
        {
            inside = !inside;
            key.transform.position = new Vector3(140.0f, 1.0f, -20.0f);
        }
    }
}