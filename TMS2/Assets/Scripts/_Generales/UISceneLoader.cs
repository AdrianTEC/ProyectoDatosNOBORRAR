using UnityEngine;

public class UISceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void loadScene(string value)
    {
        LevelLoader.LoadLevel(value);
    }
}
