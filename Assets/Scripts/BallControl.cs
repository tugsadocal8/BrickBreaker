using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;
using Assets.Scripts;
using UnityEngine.UI;
using System.CodeDom;

public class BallControl : MonoBehaviour
{

    public float speed;
    public const float radius = 0.155764f;
    public Vector2 velocity;
    public RaycastHit2D hit;
    const int deadZoneLayer = 9;
    const int blockLayer = 13;
    const int playerLayer = 11;
    const int itemLayer = 15;
    const string blockTag = "block";
    public GameObject playerGameObject;
    public BoxCollider2D playerBox;
    public float timerResetBall = 3;
    public float timer=3;
    void Start()
    {


    }

    [System.Obsolete]
    void Update()
    {
        GameManager.Instance.AddBallList(this);


        Vector2 dir = velocity.normalized;
        float dist = velocity.magnitude * Time.deltaTime;
        hit = Physics2D.CircleCast(transform.position, radius, dir, dist);

        if (hit.collider != null && hit.collider.gameObject.layer != itemLayer)
        {

            if (hit.collider.gameObject.layer == playerLayer)
            {
                float playercolliderSize = playerBox.size.x;
                playercolliderSize *= 4;
                float ballPosDx = this.transform.position.x;
                float ballPosDy = this.transform.position.y;
                float playerGameObjectDx = playerGameObject.transform.position.x;
                float ballPlayerDistance = playerGameObjectDx - ballPosDx;
                float ballAngle = ballPlayerDistance / playercolliderSize * 80;
                transform.position = new Vector2(ballPosDx, ballPosDy + 0.07f);
                velocity = new Vector2(0, -speed);
                velocity = Quaternion.AngleAxis(ballAngle, Vector3.forward) * velocity;
            }
            else
            {
                //velocity = Vector2.zero;
                velocity -= 2 * (Vector2.Dot(velocity, hit.normal)) * hit.normal;

            }

            if (GameManager.Instance.BallList.Count == 1 && hit.collider.gameObject.layer == deadZoneLayer)
            {
                this.transform.position = new Vector2(playerGameObject.transform.position.x, playerGameObject.transform.position.y);

                GameManager.Instance.healthValue--;
                GameManager.Instance.Health();
                if (GameManager.Instance.healthValue == 0)
                {
                    GameManager.Instance.gameOverStr = "Game Over";
                    GameManager.Instance.GameOver();

                }

            }
            if (GameManager.Instance.BallList.Count != 1 && hit.collider.gameObject.layer == deadZoneLayer)
            {
                Destroy(gameObject);
                GameManager.Instance.RemoveBallList(this);

            }
            if (hit.collider.gameObject.layer == blockLayer)
            {
                if (hit.collider.gameObject.tag == blockTag)
                {
                    hit.collider.gameObject.GetComponent<BlockController>().Break(hit.collider.gameObject);
                }
            }
        }
        else
        {
            Vector3 vc = new Vector3(velocity.x, velocity.y);
            this.transform.position += vc * Time.deltaTime;
         
        }
    }
}

