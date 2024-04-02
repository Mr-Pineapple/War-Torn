using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/**
 * Author: @Zack
 */
public class TrenchGenerator : MonoBehaviour {
    [SerializeField] private List<Transform> levelParts;
    private List<Transform> currentLevelParts;
    private List<Transform> generatedLevelParts;
    [SerializeField] private Jigsaw nextJigsawPieceLocation;
    [SerializeField] private Transform lastLevelPiece;
    private Jigsaw defaultJigsaw;

    [SerializeField] private float generationCooldown;
    private float cooldownTimer;
    private bool generationOver;

    private void Start() {
        defaultJigsaw = nextJigsawPieceLocation;
        generatedLevelParts = new List<Transform>();
        currentLevelParts = new List<Transform>(levelParts);
        InitializeGeneration();
    }

    private void Update() {
        if(generationOver) {
            return;
        }

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0) {
            if (currentLevelParts.Count > 0) {
                cooldownTimer = generationCooldown;
                GenerateNextLevelPiece();
            } else if (generationOver == false) {
                FinishGeneration();
            }
        }
    }

    [ContextMenu("Restart Generation")]
    private void InitializeGeneration() {
        nextJigsawPieceLocation = defaultJigsaw;
        generationOver = false;
        currentLevelParts = new List<Transform>(levelParts);

        foreach (Transform t in generatedLevelParts) {
            Destroy(t.gameObject);
        }

        generatedLevelParts.Clear();
    }

    private void FinishGeneration() {
        generationOver = true;
        GenerateNextLevelPiece();
    }

    private void GenerateNextLevelPiece() {
        Transform newPiece = null;

        if (generationOver) {
            newPiece = Instantiate(lastLevelPiece);
        } else {
            newPiece = Instantiate(ChooseRandomPiece());
        }

        generatedLevelParts.Add(newPiece);

        LevelPiece levelPieceScript = newPiece.GetComponent<LevelPiece>();
        levelPieceScript.ConnectAndAlignParts(nextJigsawPieceLocation);

        if(levelPieceScript.IntersectionDetected()) {
            Debug.Log("Intersection");
        }

        nextJigsawPieceLocation = levelPieceScript.GetExitPoint();
    }

    private Transform ChooseRandomPiece() {
        int randomIndex = Random.Range(0, currentLevelParts.Count);
        Transform chosenPiece = currentLevelParts[randomIndex];

        currentLevelParts.RemoveAt(randomIndex);
        return chosenPiece;
    }
}
