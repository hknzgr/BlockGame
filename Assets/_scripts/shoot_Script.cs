using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shoot_Script : MonoBehaviour {

    public GameObject block;
    public GameObject blocks;
    public GameObject gameController;
    public GameObject balls;
    Vector3 mousepos;
    Vector3 ballpos;
    Vector3 kuvvet;
    public GameObject ball;
    public Button start;
    public Text won;
    public Text fail;
    public Button retry;

	void Start () {
        
        Vector3 place = new Vector3(-3.56f,8);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
               GameObject newBlock= Instantiate(block, 
                   place, Quaternion.identity);
                place.x += 3.50f;
                newBlock.GetComponent<blockScript>().CanAta(Random.Range(1,6));
                newBlock.transform.parent = blocks.transform;            
            }
            place.y -= 1.3f;
            place.x = -3.56f;
        }
	}
	
    void OnMouseUp()
	{
        if (!start.isActiveAndEnabled && ball.GetComponent<Rigidbody>().velocity==new Vector3(0,0,0) && balls.transform.childCount==0)
        {
            ballpos = ball.GetComponent<Transform>().position;
            ballpos = Camera.main.WorldToViewportPoint(ballpos);
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToViewportPoint(mousepos);
            kuvvet = new Vector3((mousepos.x - ballpos.x) * 1000, (mousepos.y - ballpos.y) * 1000, 0);
            ball.GetComponent<Rigidbody>().AddForce(kuvvet);
            StartCoroutine(atisYap());
        }
	}

    public void restartgame()
    {
        Vector3 place = new Vector3(-3.56f, 8);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject newBlock = Instantiate(block,
                    place, Quaternion.identity);
                place.x += 3.50f;
                newBlock.GetComponent<blockScript>().CanAta(Random.Range(1, 6));
                newBlock.transform.parent = blocks.transform;
            }
            place.y -= 1.3f;
            place.x = -3.56f;

        }

        blocks.gameObject.SetActive(true);
        gameController.gameObject.SetActive(true);
        ball.gameObject.SetActive(true);
        fail.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    IEnumerator atisYap()
    {        
        for (int i = 0; i < 2+ ballScript.bonus; i++)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject go= Instantiate(ball, new Vector3(0, -9, 0), Quaternion.identity);
            go.tag = "faketop";
            go.transform.parent = balls.transform;
            go.GetComponent<Rigidbody>().AddForce(kuvvet);
           
        }        
    }
}
