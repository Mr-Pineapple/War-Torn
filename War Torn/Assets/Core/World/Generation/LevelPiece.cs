using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

/**
 * Author: @Zack
 */
public class LevelPiece : MonoBehaviour {

    public void ConnectAndAllignParts(Jigsaw targetJigsaw) {
        Jigsaw entrancePoint = GetEntrancePoint();
        ConnectTo(entrancePoint, targetJigsaw);
    }

    /**
     * @brief                       Connects the pieces together relative to the current location
     *                              This will calculate the offset betweent he level parts current
     *                              position and its own jigsaw position. The offset represents
     *                              the distance and direction from the level parts pivot to the jigsaw
     * 
     * @param ownJigsawPiece        The jigsaw of the current piece
     * @param targetJigsawPiece     The jigsaw of the connecting piece
     */
    private void ConnectTo(Jigsaw ownJigsawPiece, Jigsaw targetJigsawPiece) {
        var offset = transform.position - ownJigsawPiece.transform.position;
        var newPosition = targetJigsawPiece.transform.position + offset;
        transform.position = newPosition;
    }

    public Jigsaw GetEntrancePoint() => GetJigsawPointOfType(JigsawType.Entry);
    public Jigsaw GetExitPoint() => GetJigsawPointOfType(JigsawType.Exit);

    /**
     * @brief       Gets the type of jigsaw piece to connect to
     * @param type  The type of jigsaw to connect to
     * @return      Get the connecting jigsaw
     */
    private Jigsaw GetJigsawPointOfType(JigsawType type) {
        Jigsaw[] jigsawPoints = GetComponentsInChildren<Jigsaw>();
        List<Jigsaw> filteredJigsawPoints = new List<Jigsaw>();

        foreach (Jigsaw jigsaw in jigsawPoints) {
            if(jigsaw.jigsawType == type) {
                filteredJigsawPoints.Add(jigsaw);
            }
        }

        if(filteredJigsawPoints.Count > 0) {
            int randomIndex = Random.Range(0, filteredJigsawPoints.Count);
            return filteredJigsawPoints[randomIndex];
        }
        return null;
    }
}
