using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public float timer;
    public itemEnum itemType;
    public bool isTimeDependent;


}
public class PlayerControls : MonoBehaviour
{
    public KeyCode moveRight;
    public KeyCode moveLeft;
    public const float radius = 0.155764f;
    public float speed;
    public RaycastHit2D hit;
    public Vector3 velocity;
    public Vector3 wall2;
    public Vector3 wall3;
    public BoxCollider2D playerCollider;
    public List<ItemData> listItem;
    public GameObject newBall;
    public BallControl control;
    public Vector3 scaleUpScale;
    public Vector3 scaleDownScale;
    public Vector3 NormalScale;
    public int boundary;



    void Start()
    {

        velocity = new Vector3(speed, 0);
        listItem = new List<ItemData>();
        this.transform.localScale = NormalScale;

    }


    [System.Obsolete]
    void Update()
    {


        for (int i = 0; i < listItem.Count; i++)
        {
            if (listItem[i].isTimeDependent)
            {

                listItem[i].timer -= Time.deltaTime;
                if (listItem[i].timer < 0)
                {
                    RemoveItem(listItem[i]);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.scoreValue = 0;
            Application.LoadLevel(0);
            GameManager.Instance.gameOverStr = " ";
            GameManager.Instance.GameOver();
            GameManager.Instance.HealthReset();
            GameManager.Instance.Health();
            Time.timeScale = 1;
        }

        if (Input.GetKey(moveRight))
        {
            velocity = new Vector3(speed, 0);
        }
        else if (Input.GetKey(moveLeft))
        {
            velocity = new Vector3(-speed, 0);
        }

        else
        {
            velocity.x = 0.0f;
        }

        this.transform.position += velocity * Time.deltaTime;
        float width = playerCollider.size.x * transform.localScale.x * 0.5f;
        float pos = this.transform.position.x;
        pos = Mathf.Clamp(pos, -10.10f + width, 10.10f - width);

        playerCollider.transform.position = new Vector3(pos, playerCollider.transform.position.y);

    }

    public ItemData ItemFactory(itemEnum item)
    {
        ItemData data = new ItemData();

        data.itemType = item;

        switch (item)
        {
            case itemEnum.ScaleUp:
                data.timer = 10;
                data.isTimeDependent = true;
                break;
            case itemEnum.ScaleDown:
                data.timer = 10;
                data.isTimeDependent = true;
                break;
        }

        return data;
    }

    public void SetItem(itemEnum item)
    {
        //Item alınabilir mi?
        listItem.Add(ItemFactory(item));

        GameManager.Instance.AddScore();
        GameManager.Instance.Score();

        switch (item)
        {
            case itemEnum.ScaleUp:

                gameObject.transform.localScale = scaleUpScale;
                break;

            case itemEnum.ScaleDown:
                gameObject.transform.localScale = scaleDownScale;
                break;

            case itemEnum.MultiBall:
                if (GameManager.Instance.BallList.Count == 1)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        GameObject clone = Instantiate(newBall);
                        control = clone.GetComponent<BallControl>();
                        control.transform.position = new Vector2(GameManager.Instance.mainBall.transform.position.x, GameManager.Instance.mainBall.transform.position.y);
                        control.velocity = Quaternion.AngleAxis(i * 30, Vector3.forward) * GameManager.Instance.mainBall.velocity;
                        control.playerGameObject = this.gameObject;
                    }
                }
                break;
            default:
                break;
        }
    }
    public void RemoveItem(ItemData item)
    {
        switch (item.itemType)
        {
            case itemEnum.ScaleUp:
            case itemEnum.ScaleDown:
                gameObject.transform.localScale = NormalScale;
                break;
        }

        listItem.Remove(item);
    }
}














