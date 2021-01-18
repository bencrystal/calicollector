using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPiece : MonoBehaviour
{
    //GameObject kibbleBlock1 = GetComponent <Box Collider>();
    // Start is called before the first frame update
    public float xLoc;
    public float yLoc;
    public float zLoc;
    public AudioSource collectedSound;
    public AudioSource auraSound;

    //static bool true if all items collected
    public static bool VICTORY = false;

    //static bool declared for each collectible

    public static bool kuchikopiMoved = false;
    public static bool birdtoyMoved = false;
    public static bool catbowlMoved = false;
    public static bool alienMoved = false;
    public static bool balloonsMoved = false;
    public static bool catrabbitMoved = false;
    public static bool dangoMoved = false;
    public static bool ikuraMoved = false;
    public static bool foodbowlMoved = false;
    public static bool magikarpMoved = false;
    public static bool toymouseMoved = false;
    //public static bool piggyMoved = false;
    //public static bool squidMoved = false;
    //public static bool sushiMoved = false;

    //public static bool weirdcrabMoved = false;




    //public bool moved = false;

    [SerializeField]
    private GameObject silhouette;

    public bool isCollected = false; //used for map silhouette

    [SerializeField]
    private GameObject collectibleMapIcon;

    [SerializeField]
    private GameObject collectibleMapShadow;



    private void Start()
    {
        if (kuchikopiMoved == true && this.gameObject.name == "kuchikopi")
        {
            //print("KUCHIKOPI MOVED");
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (birdtoyMoved == true && this.gameObject.name == "birdtoy")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (catbowlMoved == true && this.gameObject.name == "catbowl")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (alienMoved == true && this.gameObject.name == "alien")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (balloonsMoved == true && this.gameObject.name == "balloons")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (catrabbitMoved == true && this.gameObject.name == "catrabbit")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (dangoMoved == true && this.gameObject.name == "dango")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (ikuraMoved == true && this.gameObject.name == "ikura")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (foodbowlMoved == true && this.gameObject.name == "foodbowl")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (magikarpMoved == true && this.gameObject.name == "magikarp")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }

        if (toymouseMoved == true && this.gameObject.name == "toymouse")
        {
            //DontDestroyOnLoad(this.gameObject);
            silentMove();
        }





    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collectedSound.Play();
            this.transform.position = new Vector3(xLoc, yLoc, zLoc);
            isCollected = true;
            silhouette.gameObject.SetActive(false);
            this.GetComponent<Collider>().isTrigger = false;
            auraSound.Stop();
            collectibleMapIcon.gameObject.SetActive(true);
            collectibleMapShadow.gameObject.SetActive(false);
            //DontDestroyOnLoad(this.gameObject);
            
            if (this.gameObject.name == "kuchikopi")
                {
                kuchikopiMoved = true;

                //print("KUCHIKOPI FOUND");
                }
            
            if (this.gameObject.name == "birdtoy")
                {
                birdtoyMoved = true;
                }

            if (this.gameObject.name == "catbowl")
                {
                catbowlMoved = true;
                }

            if (this.gameObject.name == "alien")
                {
                alienMoved = true;
                }

            if (this.gameObject.name == "balloons")
                {
                balloonsMoved = true;
                }

            if (this.gameObject.name == "catrabbit")
                {
                catrabbitMoved = true;
                }

            if (this.gameObject.name == "dango")
                {
                dangoMoved = true;
                }

            if (this.gameObject.name == "ikura")
                {
                ikuraMoved = true;
                }

            if (this.gameObject.name == "foodbowl")
                {
                foodbowlMoved = true;
                }

            if (this.gameObject.name == "magikarp")
                {
                magikarpMoved = true;
                }

            if (this.gameObject.name == "toymouse")
                {
                toymouseMoved = true;
                }


            //WIN CONDITION
            //if (kuchikopiMoved == birdtoyMoved == catbowlMoved == alienMoved == balloonsMoved == catrabbitMoved == dangoMoved == ikuraMoved == foodbowlMoved == magikarpMoved == toymouseMoved == true)
            if ((kuchikopiMoved == true) && (kuchikopiMoved == birdtoyMoved) && (kuchikopiMoved == catbowlMoved) && (kuchikopiMoved == alienMoved) && (kuchikopiMoved == balloonsMoved) && (kuchikopiMoved == catrabbitMoved) && (kuchikopiMoved == dangoMoved) && (kuchikopiMoved == ikuraMoved) && (kuchikopiMoved == foodbowlMoved) && (kuchikopiMoved == magikarpMoved) && (kuchikopiMoved == toymouseMoved))
            {
                VICTORY = true;
            }

            //moved = true;

        }
    }

    public void silentMove()
    {

            //audioSource.Play();
            this.transform.position = new Vector3(xLoc, yLoc, zLoc);
            isCollected = true;
            silhouette.gameObject.SetActive(false);
            this.GetComponent<Collider>().isTrigger = false;
            auraSound.Stop();
            collectibleMapIcon.gameObject.SetActive(true);
            collectibleMapShadow.gameObject.SetActive(false);



    }
}
