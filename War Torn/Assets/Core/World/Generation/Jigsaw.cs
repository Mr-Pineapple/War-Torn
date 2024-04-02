using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JigsawType { Entry, Exit }
public class Jigsaw : MonoBehaviour {
    public JigsawType jigsawType;

    private void OnValidate() {
        gameObject.name = "Jigsaw - " + jigsawType.ToString();
    }
}
