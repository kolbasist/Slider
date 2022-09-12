using UnityEngine;

namespace PlayerAnimations
{
    public static class HashAnimatorNames
    {
        public static int HitHash = Animator.StringToHash("Hit");
        public static int HealHash = Animator.StringToHash("Heal");
        public static int DizzyHash = Animator.StringToHash("Dizzy");
        public static int DieHash = Animator.StringToHash("Die");
        public static int WinHash = Animator.StringToHash("Win");
        public static int IdleHash = Animator.StringToHash("Idle");
    }
}
