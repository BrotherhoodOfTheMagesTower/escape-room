using UnityEngine;

public class ShowItem : MonoBehaviour
{
    [SerializeField] GameObject objectToBeShown;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            objectToBeShown.SetActive(true);
        }
    }

}
