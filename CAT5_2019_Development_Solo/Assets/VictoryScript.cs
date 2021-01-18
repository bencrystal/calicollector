using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{

    private bool fireworksIsRunning = false;

    //private Vector3 fireworkOrigin = new Vector3 (1.1f, -16f, 1.8f);
    //private Vector3 fireworkNew = new Vector3 (1.1f, -16f, 1.8f);

    /*
     * fireworkX is the gameobject
     * fwx is the particle system in the gameobject
     * 
     * this is because it's very complicated to move particle effects on their own, 
     * but if they're pinned to a gameobject, you can just transform it to a new 
     * location and teleport the particle system along
     */

    [SerializeField]
    private GameObject cat5picture;

    [SerializeField]
    private GameObject firework1;

    [SerializeField]
    private ParticleSystem fw1;

    [SerializeField]
    private GameObject firework2;

    [SerializeField]
    private ParticleSystem fw2;

    [SerializeField]
    private GameObject firework3;

    [SerializeField]
    private ParticleSystem fw3;

    [SerializeField]
    private GameObject firework4;

    [SerializeField]
    private ParticleSystem fw4;

    [SerializeField]
    private GameObject firework5;

    [SerializeField]
    private ParticleSystem fw5;

    [SerializeField]
    private GameObject firework6;

    [SerializeField]
    private ParticleSystem fw6;


    //these variables ensure that the current firework has not been played as one of the previous 4 (only 3/6 choices at the end of the day!)
    private int whichFirework = 0;
    private int lastFirework = 0;
    private int twoFireworksAgo = 0;
    private int threeFireworksAgo = 0;

    // Start is called before the first frame update
    void Start()
    {
        //CollectedPiece.VICTORY = true; //for testing fireworks
    }

    // Update is called once per frame
    void Update()
    {


        if (CollectedPiece.VICTORY == true && fireworksIsRunning == false)
        {
           
            //print("VICTORY");
            StartCoroutine(Fireworks());
            
            
            if (cat5picture.activeInHierarchy == false)
            {
                cat5picture.gameObject.SetActive(true);
            }

        }

    }



    IEnumerator Fireworks()
    {
        Vector3 fireworkNew = new Vector3 (Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f)); //location of randomly generated firework
        fireworksIsRunning = true;
        yield return new WaitForSeconds(Random.Range(0.2f, 0.7f)); //wait 0.2 to 0.7 seconds btw fireworks
        
        while (whichFirework == lastFirework || whichFirework == twoFireworksAgo || whichFirework == threeFireworksAgo) //generates a firework different from the last 2 :P
        {
            whichFirework = Random.Range(1, 6); //randomly selects firework
        }
        

        switch (whichFirework)
        {
            case 1:
                firework1.transform.position = fireworkNew;//set firework group to new location
                fw1.Play();
                    break;

            case 2:
                firework2.transform.position = fireworkNew;
                fw2.Play();
                break;

            case 3:
                firework3.transform.position = fireworkNew;
                fw3.Play();
                break;

            case 4:
                firework4.transform.position = fireworkNew;
                fw4.Play();
                break;

            case 5:
                firework5.transform.position = fireworkNew;
                fw5.Play();
                break;

            case 6:
                firework6.transform.position = fireworkNew;
                fw6.Play();
                break;
        }
        threeFireworksAgo = twoFireworksAgo;
        twoFireworksAgo = lastFirework;
        lastFirework = whichFirework;
        fireworksIsRunning = false;
    }
}
