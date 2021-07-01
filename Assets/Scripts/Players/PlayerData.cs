using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float maxHp;
    public int maxMp;
    public int maskPieces;
    public float Exp;

    public float[] position;

    public PlayerData(PlayerController player)
    {
        maxHp = player.maxCurse;
        maxMp = player.maxMana;
        maskPieces = player.maskCollected;
        Exp = player.Exp;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
