using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;
    public GameObject Camera6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("1Key"))
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);

        }
        if (Input.GetButtonDown("2Key"))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);


        }
        if (Input.GetButtonDown("3Key"))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(true);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);


        }
        if (Input.GetButtonDown("4Key"))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(true);
            Camera5.SetActive(false);
            Camera6.SetActive(false);


        }
        if (Input.GetButtonDown("5Key"))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(true);
            Camera6.SetActive(false);

        }
        if (Input.GetButtonDown("6Key"))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(true);

        }
    }

}
