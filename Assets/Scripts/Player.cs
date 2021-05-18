using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    private Vector2 firstPos, secondPos;


    private bool isMoving = false;
    private Vector3 originalPos, targetPos;
    private float moveTime = 0.2f;

    public static Vector2 currentSwipe;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentSwipe = new Vector2(secondPos.x - firstPos.x, secondPos.y - firstPos.y);
            currentSwipe.Normalize();
        }

        if (currentSwipe.y > 0 && currentSwipe.x < 0.5 && currentSwipe.x > -0.5 && !isMoving)
        {
            StartCoroutine(Move(Vector3.up));
        }
        if (currentSwipe.y < 0 && currentSwipe.x < 0.5 && currentSwipe.x > -0.5 && !isMoving)
        {
            StartCoroutine(Move(Vector3.down));
        }
        if (currentSwipe.x < 0 && currentSwipe.y < 0.5 && currentSwipe.y > -0.5 && !isMoving)
        {
            StartCoroutine(Move(Vector3.left)); 
        }
        if (currentSwipe.x > 0 && currentSwipe.y < 0.5 && currentSwipe.y > -0.5 && !isMoving)
        {
            StartCoroutine(Move(Vector3.right));
        }
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        float elapsedtime = 0;
        originalPos = transform.position;
        targetPos = originalPos + direction/2;
        while (elapsedtime < moveTime)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedtime / moveTime));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
