using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSpecificRoom : MonoBehaviour
{
    [SerializeField] sceneController sc;
    [SerializeField] string sceneName;
    void OnTriggerEnter(Collider other)
    {
        sc.changeSceneTo(sceneName);
        //SceneManager.LoadScene(2);
    }
}