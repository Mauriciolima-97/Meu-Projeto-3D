using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Level Piece Based Setup")]
public class LevelPieceBasedSetup : ScriptableObject
{
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    [Header("Amounts")]
    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 3;

    [Header("Art")]
    public ArtManager.ArtType artType;
}
