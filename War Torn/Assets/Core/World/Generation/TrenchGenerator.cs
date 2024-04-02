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
    [SerializeField] private Jigsaw nextJigsawPieceLocation;
    [SerializeField] private Transform lastLevelPiece;

    [SerializeField] private float generationCooldown;
    private float cooldownTimer;
    private bool generationOver;

    private void Start() {
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

    private void InitializeGeneration() {
        generationOver = false;
        currentLevelParts = new List<Transform>(levelParts);
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
