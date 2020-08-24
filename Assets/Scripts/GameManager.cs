using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngineInternal;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public List<BallControl> BallList;
        public BallControl mainBall;

        public int scoreValue = 0;
        public Text scoreText;

        public int healthValue = 3;
        public Text healthScore;

        public string gameOverStr;
        public Text gameOver;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(gameObject);
                BallList = new List<BallControl>();
                mainBall = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddBallList(BallControl ball)
        {
            if (BallList.Contains(ball) == false)
            {
                if (mainBall ==null)
                {
                    mainBall = ball;

                }
                BallList.Add(ball);
            }

        }

        public void RemoveBallList(BallControl ball)
        {
            if (BallList.Contains(ball))
            {
                
                BallList.Remove(ball);
                if (ball == mainBall)
                {
                    if (BallList.Count > 0)
                    {
                        mainBall = BallList[0];
                        
                    }

                }
            }

        }

        public void Score()
        {

            scoreText.text = "Score: " + scoreValue;
        }

        public void AddScore()
        {
            scoreValue += 10;
        }


        public void Health()
        {

            healthScore.text = "Health: " + healthValue;
        }

        public void HealthDecrase()
        {
            healthValue--;
        }
        public void HealthReset()
        {
            healthValue = 3;
        }

        public void GameOver()
        {
            gameOver.text = gameOverStr;
        }

    }
}
