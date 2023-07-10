using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwThePlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private void Update()
    {
         transform.position = new Vector3(Player.position.x,Player.position.y,transform.position.z);
    }
}
