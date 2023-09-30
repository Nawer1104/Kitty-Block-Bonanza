using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float speed;

    public GameObject vfx;

    private bool canMove = false;

    public Transform target;

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            float distance = Vector2.Distance(target.position, transform.position);

            if (distance == 0f)
            {
                transform.GetComponent<BoxCollider2D>().enabled = false;

                GameObject vfxSuccess = Instantiate(vfx, transform.position, Quaternion.identity) as GameObject;
                Destroy(vfxSuccess, 1f);

                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);

                GameManager.Instance.CheckLevelUp();

                canMove = false;
            }
        }
    }
}
