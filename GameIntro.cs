using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntro : MonoBehaviour
{
    public int Timer;
    public GameObject MainMenu;
    public void Awake()
    {
        Timer = 5;
    }
    void Update()
    {
         if(Input.GetKey(KeyCode.Space))
        {
            MainMenu.SetActive (true);

            gameObject.SetActive(false);
        }
    }
}
