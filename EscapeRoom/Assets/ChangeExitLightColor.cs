using UnityEngine;

public class ChangeExitLightColor : MonoBehaviour
{
    [SerializeField] int keyId;
    private GameObject exitLight;
    // Start is called before the first frame update
    void Start()
    {
        exitLight = GameObject.Find("Exit_Light");
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Items.Find(k => k.id == keyId))
        {
            exitLight.GetComponent<Light>().color = Color.green;
        }
    }
}
