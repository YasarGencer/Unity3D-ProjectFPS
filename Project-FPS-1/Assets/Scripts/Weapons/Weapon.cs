using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public StructWeapon weapon;
}
[System.Serializable]
public struct StructWeapon {
    public GameObject Object;
    public GameObject Bullet;
    public string Name;
    [TextArea] public string Description;
    public GameObject ShootParticle;
    [Range(0, 100f)] public float Damage;
    [Range(0, 3f)] public float FireRate;
    [Range(0, 100f)] public float MagCapasite;
    [Range(0, 20f)] public float MagCount;
    [Range(0, 25f)] public float Range;
    [Range(0, 2f)] public float Recoil;
    [Range(0, 0.5f)] public float WalkSpeedEffect;
    [HideInInspector] public float Ammo;
    [HideInInspector] public float ShootTimer;
}