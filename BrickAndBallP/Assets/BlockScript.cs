using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    public int healthPoint;
    public GameObject blockText;

    void Start()
    {
        healthPoint = Random.Range(1, 30);
    }

    void Update()
    {
        blockText.GetComponent<Text>().text = healthPoint.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthPoint--;
        }
        if(healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
