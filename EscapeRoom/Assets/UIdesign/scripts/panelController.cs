using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] bool hideAtStart;
    // Start is called before the first frame update

    private void Start()
    {
        if(hideAtStart)
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
