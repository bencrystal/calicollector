using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * still need to figure out how to save infomation between scene swaps (e.g. what's been found)
 * 
 * ITEM TRACKER
 * 
 * Add functionality to turn on/ off XR Rig when changing scenes
 */




public class SceneManagement : MonoBehaviour
{
    public bool swapScenes = false;

    public string currentLevelName;
    public string otherLevelName;
    public static string thisLevel;
    private string nameHolder;



    //[SerializeField]
    //private GameObject wholeScene;




    //public  List<GameObject> items;// = null; //new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //wholeScene.gameObject.SetActive(true);
        //itemLoad();   
        thisLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

        sceneChange();
        //itemCheck(); //checks to see if object was found before scene reloaded
    }

    void sceneChange()
    {
        if (swapScenes == true)
        {



            //wholeScene.gameObject.SetActive(false);

            currentLevelName = SceneManager.GetActiveScene().name; //saves current scene name

            SceneManager.LoadScene(otherLevelName); //swaps scenes


            SceneManager.UnloadSceneAsync(currentLevelName); //add unload scene

            otherLevelName = currentLevelName; //stores the original scene as "other" level name

            swapScenes = false; //disables scene swap feature
        }
    }
    
    /*void itemCheck()
    {
        foreach (GameObject item in items) //check each item to see if it was found globally
        {
            if (item.GetComponent<Collider>().isTrigger == false || collected == true) //if that item has been disabled before
            {
                item.GetComponent<CollectedPiece>().silentMove(); //run the noiseless teleport script
            }
        }
    }*/

}
