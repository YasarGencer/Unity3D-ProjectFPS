using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;
    [SerializeField] private TextMeshProUGUI _prompText;
    [SerializeField] private GameObject weaponScreen;
    [SerializeField] private TextMeshProUGUI _weaponName, _weaponAmmo;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        Cursor.visible = false;
        WeaponUI(new StructWeapon());
    }
    public TextMeshProUGUI GetPrompText(){
        return _prompText;
    }
    public void SetText(TextMeshProUGUI textObject, string text){
        textObject.SetText(text);
    }
    public void WeaponUI(StructWeapon weapon)
    {
        if (weapon.Name == null)
        {
            weaponScreen.SetActive(false);
            return;
        }
        weaponScreen.SetActive(true);
        _weaponName.text = weapon.Name;
        _weaponAmmo.text = weapon.Ammo + "  /  " + (weapon.MagCapasite * weapon.MagCount);
    }
}
