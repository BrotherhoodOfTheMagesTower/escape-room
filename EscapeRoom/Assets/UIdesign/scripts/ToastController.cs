using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastController : MonoBehaviour
{
    [SerializeField] GameObject ToastPanel;
    [SerializeField] GameObject KeyIsMissingPanel;
    [SerializeField] Text toastContent;
    [SerializeField] Text keyIsMissingContent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setToastContent(string toastInfo)
    {
        toastContent.text = toastInfo;
    }
    
    public void setKeyIsMissingToastContent(string toastInfo)
    {
        keyIsMissingContent.text = toastInfo;
    }

    public void makeToast()
    {
        StartCoroutine(DipslayToast());
    }
    
    public void makeKeyIsMissingToast()
    {
        StartCoroutine(DipslayKeyIsMissingToast());
    }

    IEnumerator DipslayToast()
    {
        ToastPanel.SetActive(true);
        for (float alpha = 0.0f; alpha <= 0.67f; alpha += 0.05f)
        {
            var image = ToastPanel.GetComponent<Image>();
            var textColor = toastContent.color;
            var color = image.color;
            textColor.a = color.a = alpha;
            image.color = color;
            toastContent.color = textColor;
            yield return new WaitForSeconds(0.01f);
        }
        for(int i = 0; i < 100; i++)
            yield return new WaitForSeconds(0.01f);

        StartCoroutine(CloseToast());
    }
    
    IEnumerator DipslayKeyIsMissingToast()
    {
        KeyIsMissingPanel.SetActive(true);
        for (float alpha = 0.0f; alpha <= 0.67f; alpha += 0.05f)
        {
            var image = KeyIsMissingPanel.GetComponent<Image>();
            var textColor = keyIsMissingContent.color;
            var color = image.color;
            textColor.a = color.a = alpha;
            image.color = color;
            keyIsMissingContent.color = textColor;
            yield return new WaitForSeconds(0.01f);
        }
        for(int i = 0; i < 100; i++)
            yield return new WaitForSeconds(0.01f);

        StartCoroutine(CloseKeyIsMissingToast());
    }

    IEnumerator CloseToast()
    {
        for (float alpha = 0.67f; alpha >= 0.1f; alpha -= 0.05f)
        {
            var image = ToastPanel.GetComponent<Image>();
            var textColor = toastContent.color;
            var color = image.color;
            textColor.a = color.a = alpha;
            image.color = color;
            toastContent.color = textColor;
            yield return new WaitForSeconds(0.01f);
        }
        ToastPanel.SetActive(false);
    }
    
    IEnumerator CloseKeyIsMissingToast()
    {
        for (float alpha = 0.67f; alpha >= 0.1f; alpha -= 0.05f)
        {
            var image = KeyIsMissingPanel.GetComponent<Image>();
            var textColor = keyIsMissingContent.color;
            var color = image.color;
            textColor.a = color.a = alpha;
            image.color = color;
            keyIsMissingContent.color = textColor;
            yield return new WaitForSeconds(0.01f);
        }
        KeyIsMissingPanel.SetActive(false);
    }
}
