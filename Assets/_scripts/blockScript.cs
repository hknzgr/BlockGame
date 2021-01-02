using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockScript : MonoBehaviour {

    public int life;
    public Sprite[] renkler;
 
    public void CanAta(int can)
    {
        life = can;
        GetComponent<SpriteRenderer>().sprite = renkler[can];
    }
}
