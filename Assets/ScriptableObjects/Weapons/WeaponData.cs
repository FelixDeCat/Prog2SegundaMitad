using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Items/Armas" )]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public int speedAttk;
    
}
