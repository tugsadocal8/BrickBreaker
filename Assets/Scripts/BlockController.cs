using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public int health;
    public Sprite[] sprites;
    public GameObject itemPrefab;
    int rastgele;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[health - 1];
    }

    public void Break(GameObject gameObject)
    {

        rastgele = Random.Range(0, 100);
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore();
            GameManager.Instance.Score();
        }

        if (itemPrefab != null && GameManager.Instance.scoreValue >= 20)
        {

            itemController controller = null;
            if (rastgele < 50)
            {
                
                GameObject newBox = Instantiate(itemPrefab);
                newBox.transform.position = this.transform.position;
                controller = newBox.GetComponent<itemController>();
                if (controller)
                {
                    controller.SetItemType(itemEnum.ScaleUp);
                }

            }

            if (rastgele > 30 && rastgele < 50 && GameManager.Instance.BallList.Count==1)
            {
                GameObject newBox = Instantiate(itemPrefab);
                newBox.transform.position = this.transform.position;
                controller = newBox.GetComponent<itemController>();

                if (controller)
                {
                    controller.SetItemType(itemEnum.MultiBall);

                }


            }


        }

    }

}
