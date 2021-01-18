using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCollection : MonoBehaviour
{
    /*
     * The format of this is first real-world object and then its map icon counterpart.
     */


    // KIBBLE 1
    [SerializeField]
    private GameObject kibble1;

    [SerializeField]
    private GameObject kibble1Icon;

    /*/KIBBLE 2
    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject mainPanel;


    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject mainPanel;


    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject mainPanel;
    */


    // Start is called before the first frame update
    void Start()
    {
        if (kibble1.GetComponent<CollectedPiece>().isCollected)
        {
            kibble1Icon.gameObject.SetActive(true);
        }
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
