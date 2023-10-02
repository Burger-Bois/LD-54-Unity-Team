using System;
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
        private SpawnManager spawnManager;
        private List<GameObject> collectables;
        private int charPos = 6;


        private void Awake()
        {
            Time.timeScale = 1;
        }

        private void Start()
        {
            player = GameObject.Find("Player");
            playerController = player.GetComponent<PlayerController>();
            spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        }


        // Update is called once per frame
        private void Update()
        {

            collectables = GameObject.FindGameObjectsWithTag("collectable").ToList();

            // Only process on move at a time.
            if (!playerController.isMoving && !collectables[0].GetComponent<CollectableController>().isMoving)
            {
                // Accomodate two different types of moving.
                System.Func<KeyCode, bool> inputFunction;
                // GetKeyDown fires once per keypress
                inputFunction = Input.GetKeyDown;
                // If the input function is active, move in the appropriate direction.
                
                if (inputFunction(KeyCode.LeftArrow))
                {
                    if (charPos > 1)
                    {
                        MoveCollectables();
                        StartCoroutine(playerController.Move(Vector2.left, moveDuration, gridSize));
                        spawnManager.Spawn();
                        charPos--;
                    }
                }
                else if (inputFunction(KeyCode.RightArrow))
                {
                    if (charPos < 11)
                    {
                    MoveCollectables();
                    StartCoroutine(playerController.Move(Vector2.right, moveDuration, gridSize));
                    spawnManager.Spawn();
                    charPos++;
                    }
                }
            }
        }


        private void MoveCollectables()
        {
           
            foreach (GameObject collectable in collectables)
            {
                StartCoroutine(collectable.GetComponent<CollectableController>().Move(moveDuration, gridSize));
            }
        }

    }
}
