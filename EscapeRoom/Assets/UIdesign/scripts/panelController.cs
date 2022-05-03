using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    // Start is called before the first frame update

    private void Start()
    {
        this.hidePanel();
    }
    public void showPanel()
    {
        panel.SetActive(true);
    }

    public void hidePanel()
    {
        panel.SetActive(false);
    }
}
