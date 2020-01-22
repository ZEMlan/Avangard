using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimatinosScript : MonoBehaviour
{
    private Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
    }
    void Update() {
        if (heromove.is_moving) {
            anim.SetBool("can_move", true);
        }
        else {
            anim.SetBool("can_move", false);
        }
        if (Input.GetAxis("Horizontal") > 0) {
            anim.SetBool("right", true);
            anim.SetBool("left", false);
        }
        else if (Input.GetAxis("Horizontal") < 0) {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
        }
        else {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }
        if (Input.GetAxis("Vertical") < 0) {
            anim.SetBool("forward", true);
            anim.SetBool("back", false);
        }
        else if (Input.GetAxis("Vertical") > 0) {
            anim.SetBool("back", true);
            anim.SetBool("forward", false);
        }
        else {
            anim.SetBool("forward", false);
            anim.SetBool("back", false);
        }
    }
}
