﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameController
{
    class GameController : MonoBehaviour
    {


        [SerializeField] private float moveDuration = 0.3f;

        // The size of the grid
        [SerializeField] private float gridSize = 1f;

        private GameObject player;
        private PlayerController playerController;


        private void Start()
        {
            player = GameObject.Find("Player");
            playerController = player.GetComponent<PlayerController>();
        }


        // Update is called once per frame
        private void Update()
        {
            // Only process on move at a time.
            if (!playerController.isMoving)
            {
                // Accomodate two different types of moving.
                System.Func<KeyCode, bool> inputFunction;
                // GetKeyDown fires once per keypress
                inputFunction = Input.GetKeyDown;
                // If the input function is active, move in the appropriate direction.
                // if (inputFunction(KeyCode.UpArrow))
                // {
                //     StartCoroutine(Move(Vector2.up));
                // }
                // else if (inputFunction(KeyCode.DownArrow))
                // {
                //     StartCoroutine(Move(Vector2.down));
                // }
                if (inputFunction(KeyCode.LeftArrow))
                {
                    StartCoroutine(playerController.Move(Vector2.left, moveDuration, gridSize));
                }
                else if (inputFunction(KeyCode.RightArrow))
                {
                    StartCoroutine(playerController.Move(Vector2.right, moveDuration, gridSize));
                }
            }
        }

    }
}
