using UnityEngine;

[System.Serializable]
public class PlayerSoundConfig
{
    [SerializeField] private AudioClip[] missileEffect;
    [SerializeField] private AudioClip[] shieldEffect;
    [SerializeField] private AudioClip[] boostEffect;

    [SerializeField] private AudioSource thrustEffect;
    [SerializeField] private AudioSource deadEffect;

    [SerializeField] private AudioClip starCollect;
    [SerializeField] private AudioClip successEffect;

    public AudioClip[] ShieldEffect { get => shieldEffect; set => shieldEffect = value; }
    public AudioSource ThrustEffect { get => thrustEffect; set => thrustEffect = value; }
    public AudioSource DeadEffect { get => deadEffect; set => deadEffect = value; }
    public AudioClip StarCollect { get => starCollect; set => starCollect = value; }
    public AudioClip[] MissileEffect { get => missileEffect; set => missileEffect = value; }
    public AudioClip[] BoostEffect { get => boostEffect; set => boostEffect = value; }
    public AudioClip SuccessEffect { get => successEffect; set => successEffect = value; }
}