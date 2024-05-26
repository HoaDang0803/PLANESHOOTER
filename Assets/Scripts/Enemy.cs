using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5;
    public bool isMoving;

    public void Move(Vector3 targetPos)
    {
        StartCoroutine(IEMove(targetPos));
    }
    
    private IEnumerator IEMove(Vector3 targetPos)
    {
        Vector3 dir = (targetPos - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPos);

        isMoving = true;
        while (distance >= 0.1f)
        {
            distance = Vector3.Distance(transform.position, targetPos);
            transform.position += dir * Time.deltaTime * GameController.ins.enemyMoveSpeed;
            yield return null;
        }
        isMoving = false;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            GameController.ins.score++;
            Debug.Log(GameController.ins.score);
            GameController.ins.scoreText.text = "Score:" + GameController.ins.score;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isMoving)
        {
            return;
        }
        
        TakeDamage(1);
    }
}
