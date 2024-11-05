using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable //naming convention = I + ... + -able interface used by classes that are not related but can do same func.
{
    GameObject Bullet { get; set; } //interface cannot have access modifier or SerializeField ONLY auto-property is allowed (( { get; set; } ))
    Transform BulletSpawnPoint { get; set; }

    float BulletSpawnTime { get; set; }
    float BulletTimer { get; set; }

    void Shoot(); //method signature
}
