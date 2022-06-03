using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFromSceneRoom_X : MonoBehaviour
{
    [SerializeField] sceneController sc;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("Playground");
            sc.changeSceneTo("Playground");
        }
    }
}
