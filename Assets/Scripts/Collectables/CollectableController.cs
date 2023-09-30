using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public bool isMoving = false;
    public bool isCollected = false;
    public int value = 0;

    public IEnumerator Move(float moveDuration, float gridSize)
    {
        isMoving = true;

        // Make a note of where we are and where we are going.
        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (Vector2.down * gridSize);


        // Smoothly move in the desired direction taking the required time.
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            if (isCollected)
            {
                break;
            }

            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        // Make sure we end up exactly where we want.
        if (!isCollected)
        {
            transform.position = endPosition;
        }

        isMoving = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Despawner"))
        {
            Destroy(gameObject);
        }
    }
}