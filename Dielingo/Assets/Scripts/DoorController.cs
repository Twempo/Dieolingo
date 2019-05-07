using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator anim;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        //storer.FrontDoor.SetActive(true);
        open = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
