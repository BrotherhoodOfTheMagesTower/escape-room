using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Vehicles.Car;

public class GettingInOutOfCars : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] AutoCam myCamera = null;

    [Space, Header("Player Stuff")]
    [SerializeField] GameObject playerCharacter = null;

    [Space, Header("Car Stuff")]
    [SerializeField] GameObject car = null;
    [SerializeField] CarUserControl carController = null;
    [SerializeField] CarController carEngine = null;
    [SerializeField] float distanceToCar = 3f;

    [Header("Input")]
    [SerializeField] KeyCode enterExitKey = KeyCode.E;
    private bool inCar = false;

    // Start is called before the first frame update
    void Start()
    {
        inCar = !car.activeSelf;
        carController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enterExitKey))
        {
            if (inCar)
                GetOutOfCar();
            else if (Vector3.Distance(car.transform.position, playerCharacter.transform.position) < distanceToCar)
                GetIntoCar();
        }
    }

    void GetOutOfCar()
    {
        inCar = false;
        playerCharacter.SetActive(true);
        playerCharacter.transform.position = car.transform.position + car.transform.TransformDirection(2.0f * Vector3.left);
        myCamera.SetTarget(playerCharacter.transform);
        carController.enabled = false;
        carEngine.Move(0, 0, 1, 1);
    }
    void GetIntoCar()
    {
        inCar = true;
        playerCharacter.SetActive(false);
        myCamera.SetTarget(car.transform);
        carController.enabled = true;
    }
}