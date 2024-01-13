using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    private PlayerController _player;
    void Start()
    {
        _player = GetComponentInParent<PlayerController>();
    }

    private void AnimationTrigger()
    {
        _player.AttackStop();
    }
}
