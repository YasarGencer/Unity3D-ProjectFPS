using UnityEngine;

public class TagManager : MonoBehaviour
{
    public static TagManager Instance;
    private void Awake() {
        if(Instance == null)
            Instance = this;
    }
    public string TagPlayer(){return "Player";}
    public string TagWall(){return "Zone/Wall";}
    public string TagStaticSurface(){return "Zone/Surface";}
    public string TagStaticNavSurface(){return "Zone/SurfaceNav";}
    public string TagDynamicNavSurface(){return "Zone/SurfaceRotate";}
}
