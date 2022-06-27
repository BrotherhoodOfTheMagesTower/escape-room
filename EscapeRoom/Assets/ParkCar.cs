using UnityEngine;

public class ParkCar : MonoBehaviour
{
    [Space, Header("Car Stuff")]
    [SerializeField] GameObject car;
    [SerializeField] GameObject key;

    void Start()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "CarCollider")
        {
            key.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "CarCollider")
        {
            key.SetActive(false);
        }
    }
}