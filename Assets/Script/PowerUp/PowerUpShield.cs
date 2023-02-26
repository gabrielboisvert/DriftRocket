using UnityEngine;

public class PowerUpShield : PowerUp 
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool success = GameManager.Player.AddCollectable(this);
            if (success)
                GameManager.Ui.SwitchPowerUP(PlayerUI.PowerUPName.PowerUPShield);
            Destroy(this.gameObject);
        }
    }
}