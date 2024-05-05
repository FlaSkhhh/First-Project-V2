using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUnlock : MonoBehaviour
{
   void Awake()
   {
            Cursor.lockState = CursorLockMode.Confined;
   }
    

}
