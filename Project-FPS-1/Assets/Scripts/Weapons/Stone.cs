using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : PlayerWeapon
{
    Transform _hand;

    public override bool Shoot() {
        if (base.Shoot()) {
            Rock();
        }
        return true;
    }
    public override void Reload() {
        base.Reload();
    }
    public void Rock() {
        if (_hand == null)
            _hand = GameObject.FindGameObjectWithTag(TagManager.Instance.TagPlayer()).GetComponent<PlayerWeaponManager>().Hand;
        GameObject throwen = GameObject.Instantiate(Weapon.Bullet, _hand.position, Quaternion.identity);
        Rigidbody throwenRB = throwen.GetComponent<Rigidbody>();
        Vector3 dir = (base.ShootRay(10000) - _hand.position).normalized;
        Vector3 forceDir = dir * Weapon.Range;
        throwenRB.AddForce(forceDir, ForceMode.Impulse);
    }
}