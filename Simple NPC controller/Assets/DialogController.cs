using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StarterAssets;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;

    [SerializeField] private GameObject dialogPanel;

    [SerializeField] private string[] phrases = new string[2];
    [SerializeField] private GameObject dialogImage;
    private Sprite[] _sprites;
    [SerializeField] private Camera dialogCamera;

    // Start is called before the first frame update
    void Start()
    {
        _sprites = Resources.LoadAll<Sprite>("Sprites");
        Debug.Log(_sprites.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDialog()
    {
        
        Time.timeScale = 0;
        transform.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogCamera.gameObject.SetActive(true);
        dialogPanel.SetActive(true);
        dialogText.SetText(phrases[0]);
        dialogImage.GetComponent<Image>().sprite = _sprites[0];
    }

    public void SwitchDialog()
    {
        dialogText.SetText(phrases[1]);
        dialogImage.GetComponent<Image>().sprite = _sprites[1];
    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
        dialogCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1;
    }
    
}
