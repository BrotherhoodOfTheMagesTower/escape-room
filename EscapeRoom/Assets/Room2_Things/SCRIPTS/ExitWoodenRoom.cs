using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWoodenRoom : MonoBehaviour
{
    [SerializeField] sceneController sc;

    private static List<Item> Items = new List<Item>();

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
                sc.changeSceneTo("Playground");
        }
    }
}
