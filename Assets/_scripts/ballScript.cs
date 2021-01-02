using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour {

    public GameObject block;
    public GameObject blocks;
    public GameObject gameController;
    public GameObject sinir;
    public GameObject extraBall;
    GameObject[] blockList;
    public Text fail;
    public Text win;
    public Button retry;
    public static int bonus = 0;
   	
	
	void FixedUpdate ()
    {
        blockList = GameObject.FindGameObjectsWithTag("block");
        if (blocks.transform.childCount == 0)
        {
            gameController.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            win.gameObject.SetActive(true);
            retry.gameObject.SetActive(true);

        }
        else
        {
            for (int i = 0; i < blocks.transform.childCount; i++)
            {
                if (blockList[i].transform.position.y < -8)
                {
                    gameController.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                    fail.gameObject.SetActive(true);
                    retry.gameObject.SetActive(true);
                }

            }
        }
    }
   
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "block")
        {
            int can= col.gameObject.GetComponent<blockScript>().life;
            if (can==1)
            {
                Destroy(col.gameObject);                
            }
            else
            {
                can -= 1;
                col.gameObject.GetComponent<blockScript>().CanAta(can);
            }
        }
        
        if (col.gameObject.tag=="bottom" && this.gameObject.tag=="top")
        {
            extraBall.gameObject.SetActive(true);
            this.gameObject.transform.position = new Vector3(0, -9, 0);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Vector3 place = new Vector3(-3.56f, 8);

            
            float x = GameObject.FindGameObjectWithTag("blocks").transform.position.x;
            float y = GameObject.FindGameObjectWithTag("blocks").transform.position.y;
            GameObject.FindGameObjectWithTag("blocks").transform.position = new Vector3(x, y - 1.3f);

            for (int i = 0; i < 3; i++)
            {
                GameObject newBlock = Instantiate(block,
                        place, Quaternion.identity);
                place.x += 3.50f;
                newBlock.GetComponent<blockScript>().CanAta(Random.Range(1, 6));
                newBlock.transform.parent = GameObject.FindGameObjectWithTag("blocks").transform;
            }
        }
        if (col.gameObject.tag == "bottom" && this.gameObject.tag == "faketop")
        {
            Destroy(GameObject.FindGameObjectWithTag("faketop"));
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="extraball")
        {
            bonus += 1;
            col.gameObject.SetActive(false);
        }     
    }
}
