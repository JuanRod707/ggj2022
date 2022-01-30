using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource attackSfx;
        [SerializeField] AudioSource hitSfx;
        [SerializeField] AudioSource deathSfx;
        [SerializeField] AudioSource dashSfx;

        [SerializeField] AudioClip[] attackClips;
        [SerializeField] AudioClip[] hitClips;
        [SerializeField] AudioClip[] deathClips;
        [SerializeField] AudioClip[] dashClips;

        public void PlayAttack()
        {
            attackSfx.clip = attackClips.PickOne();
            attackSfx.Play();
        }

        public void PlayHit()
        {
            hitSfx.clip = hitClips.PickOne();
            hitSfx.Play();
        }

        public void PlayDeath()
        {
            deathSfx.clip = deathClips.PickOne();
            deathSfx.Play();
        }

        public void PlayDash()
        {
            dashSfx.clip = dashClips.PickOne();
            dashSfx.Play();
        }
    }
}
