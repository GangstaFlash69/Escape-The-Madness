using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Function : MonoBehaviour
{
   private float timer;
   private Action action;
   private bool stop;
   public Function(Action action, float timer)
   {
       this.action = action;
       this.timer = timer;
   }
    void Update()
    {
        if(!stop)
        {
            timer -= Time.deltaTime;
            if(timer < 0 )
            {
                action();
                stopPlease();
            }
        }
    }
    private void stopPlease()
    {
        stop = true;
    }
}
