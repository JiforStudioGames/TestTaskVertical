using System;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class PlayerWeaponSystem : MonoBehaviour
{
    public static Weapon ActiveWeapon;
    
    [Header("Settings")]
    [SerializeField] private PointerButton attackButton;
    
    private Weapon[] _weapons;
    private static Task _attacking;
    
    #region UNITY METHODS
    private void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>(true);
    }
    private async void OnEnable()
    {
        SwitchWeapon("Unarmed");
        
        if(_attacking == null)
        {
            _attacking = Async_Attacking();
            await _attacking;
        }
    }

    #endregion
    
    #region PUBLIC METHODS
    
    public void SwitchWeapon(string weaponName)
    {
        if(ActiveWeapon) ActiveWeapon.gameObject.SetActive(false);

        ActiveWeapon = Array.Find(_weapons, weapon => weapon.weaponName == weaponName);
        if (!ActiveWeapon)
        {
            Debug.LogError("No weapon was found!");
            return;
        }
        
        ActiveWeapon.gameObject.SetActive(true);
        //SwitchWeaponAnimator(ActiveWeapon.weaponType);
    }
    
    #endregion

    #region PRIVATE METHODS

    private async Task Async_Attacking()
    {
        while (true)
        {
            await Task.Run(() => PlayerTargetSystem.ActiveTarget != null);
            await Task.Delay((int)(ActiveWeapon.delayBeforeAttack * 1000));
            while (PlayerTargetSystem.ActiveTarget != null)
            {
                if(PlayerTargetSystem.ActiveTarget == null) break;
                ActiveWeapon.Attack();
                await Task.Delay((int)(ActiveWeapon.delayAttack * 1000));
            }
        }
    }

    #endregion
}
