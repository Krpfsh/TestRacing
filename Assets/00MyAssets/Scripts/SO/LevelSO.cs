using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Level_", menuName = "ScriptableObjects/LevelSO")]
public class LevelSO : ScriptableObject
{
    public string levelName;
    public Sprite levelPreview;
}
