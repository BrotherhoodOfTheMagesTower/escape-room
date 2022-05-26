using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    private List<Button> buttons; 
    public void changeSceneTo(string scaneName)
    {
        SceneManager.LoadScene(scaneName);
    }
    public void changeSceneTo(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void closeApplication()
    {
        Application.Quit();
    }
}
