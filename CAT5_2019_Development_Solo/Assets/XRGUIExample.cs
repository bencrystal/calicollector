using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


//using Dilmer's Script:  https://www.youtube.com/watch?v=IWuCrVMcYLc&ab_channel=DilmerValecillos

/* STILL NEED TO ADD:
 * SCENE CHANGES
 * IMAGES ON CHECKLIST
 * COUNTERS ON CHECKLIST
 * INDOOR/OUTDOOR(?) MAP(S)
 * AESTHETICS/RECOLORINGS
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */

public class XRGUIExample : MonoBehaviour
{

    //public List<XRController> controllers = null;

    /*[SerializeField]
    private RawImage background;
    */
    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject sceneManager;

    //[SerializeField]
    //private Button checklistButton;

    [SerializeField]
    private Button mapButton;

    [SerializeField]
    private Button sceneButton;

    //[SerializeField]
    //public GameObject checklist;

    [SerializeField]
    public GameObject map;

       
    void Start()
    {
        //checklist.gameObject.SetActive(false);
        //map.gameObject.SetActive(false);



        //checklistButton.onClick.AddListener(() => //when checklist button is clicked
        //{
            //mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf); //deactivates core panel
            //checklist.gameObject.SetActive(!checklist.gameObject.activeSelf); //change the state of the checklist (to the opposite state)

            /*checklistButton.GetComponentInChildren<TextMeshProUGUI>().text = checklist.gameObject.activeSelf ? //set the child text of the button equal to 
               "CHECKLIST ON" : "CHECKLIST OFF"; //whichever it is not*/

            
       // }); 
        
        
        mapButton.onClick.AddListener(() =>
        {
            //mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf);
            map.gameObject.SetActive(!map.gameObject.activeSelf);

            //mapButton.GetComponentInChildren<TextMeshProUGUI>().text = map.gameObject.activeSelf ?
                //"MAP ON" : "MAP OFF";
        });




        sceneButton.onClick.AddListener(() =>
        {
            sceneManager.GetComponent<SceneManagement>().swapScenes = true;
        });

        





       // __________________________________________________________________________________________________________________________







        /*lightButton.onClick.AddListener(() =>
        {
            if (skyMaterial.GetFloat("_Exposure") > 0)
            {
                skyMaterial.SetFloat("_Exposure", 0);
                lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "NIGHT TIME";
            }
            else
            {
                skyMaterial.SetFloat("_Exposure", 1.3f);
                lightButton.GetComponentInChildren<TextMeshProUGUI>().text = "DAY TIME";
            }
        });

        alphaToggle.onValueChanged.AddListener((value) =>
        {
            Color currColor = background.color;
            currColor.a = value ? 0.7f : 0;
            background.color = currColor;
        });

        fontSlider.onValueChanged.AddListener((value) =>
        {
            creditsInfoDetails.fontSize = value;
            fontText.text = $"FONT SIZE: {value}";
        });*/
    }
}