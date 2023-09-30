using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isMoving = false;


    public IEnumerator Move(Vector2 direction, float moveDuration, float gridSize)
    {
        // Record that we're moving so we don't accept more input.
        isMoving = true;

        // Make a note of where we are and where we are going.
        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * gridSize);

        // Smoothly move in the desired direction taking the required time.
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        // Make sure we end up exactly where we want.
        transform.position = endPosition;

        // We're no longer moving so we can accept another move input.
        isMoving = false;
    }
}