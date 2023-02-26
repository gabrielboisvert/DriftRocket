using UnityEngine;

public class PowerUpMissile : PowerUp 
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool success = GameManager.Player.AddCollectable(this);
            if (success)
                GameManager.Ui.SwitchPowerUP(PlayerUI.PowerUPName.PowerUPMissile);
            Destroy(this.gameObject);
        }
    }
}