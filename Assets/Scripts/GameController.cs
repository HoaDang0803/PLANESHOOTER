using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController ins;
    
    public List<Shape> shapes;
    public EnemyManager enemyManager;

    public int score;
    public Text scoreText;
    
    public float enemyMoveSpeed = 5;
    public float waitTime = 5;

    void Awake()
    {
        ins = this;
        score = 0;
    }

    void Start()
    {
        StartCoroutine(IEWait(waitTime));
    }


    private void MoveEnemies(Shape shape)
    {
        for (int i = 0; i < enemyManager.enemies.Count; i++)
        {
            Enemy e = enemyManager.enemies[i];
            if(e == null) continue;
            e.Move(shape.listPos[i].position);
        }
    }

    private IEnumerator IEWait(float _waitTime)
    {
        for (int i = 0; i < shapes.Count; i++)
        {
            MoveEnemies(shapes[i]);
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
