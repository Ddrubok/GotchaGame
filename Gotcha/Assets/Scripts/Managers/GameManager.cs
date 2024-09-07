using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GameManager
{
    private CameraController _camera;
    public CameraController Camera { get { return _camera; } set { _camera = value; } }

    public SoundManager _sound;
    public SoundManager Sound { get { return _sound; } set { _sound = value; } }

    #region Gold

    public event Action<ulong> OnGoldChanged;
    private ulong _gold = 0;
    public ulong Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            //if (_gold >= (ulong)MaxMoneyLimit)
            //    _gold = (ulong)MaxMoneyLimit;

            OnGoldChanged?.Invoke(_gold);
        }
    }

    #endregion

    #region SaveGold

    public event Action<double> OnSaveGoldChanged;
    private double _saveGold = 0;

   
    public double SaveGold
    {
        get { return _saveGold; }
        set
        {
            _saveGold = value;
            if (_saveGold >= (double)MaxMoneyLimit)
                _saveGold = (double)MaxMoneyLimit;

            OnSaveGoldChanged?.Invoke(_saveGold);
        }
    }

    #endregion

    #region CharacterAttack

    public event Action<ulong> OnCharacterAttackChanged;
    private ulong _characterAttack = 0;
    public ulong CharacterAttack
    {
        get { return _characterAttack; }
        set
        {
            _characterAttack = value;
            BattlePowerCal();
            OnCharacterAttackChanged?.Invoke(_characterAttack);
        }
    }

    #endregion

    #region CharacterHP

    public event Action<ulong> OnCharacterHPChanged;
    private ulong _characterHP = 0;
    public ulong CharacterHP
    {
        get { return _characterHP; }
        set
        {
            _characterHP = value;
            BattlePowerCal();
            OnCharacterHPChanged?.Invoke(_characterHP);
        }
    }

    #endregion

    #region CharacterShiled

    public event Action<ulong> OnCharacterShiledChanged;
    private ulong _characterShiled = 0;
    public ulong CharacterShiled
    {
        get { return _characterShiled; }
        set
        {
            _characterShiled = value;
            BattlePowerCal();
            OnCharacterShiledChanged?.Invoke(_characterShiled);
        }
    }

    #endregion

    #region CharacterBattlePower

    public event Action<ulong> OnCharacterBattlePowerChanged;
    private ulong _characterBattlePower = 0;
    public ulong CharacterBattlePower
    {
        get { return _characterBattlePower; }
        set
        {
            _characterBattlePower = value;
            OnCharacterBattlePowerChanged?.Invoke(_characterBattlePower);
        }
    }

    private void BattlePowerCal()
    {
        CharacterBattlePower = CharacterAttack + CharacterHP + CharacterShiled;
    }

    #endregion

    #region GameTap

    public event Action<GameTap> OnGameTapChanged;
    private GameTap _gameTap = GameTap.Resources;
    public GameTap GameTap
    {
        get { return _gameTap; }
        set
        {
            _gameTap = value;
            OnGameTapChanged?.Invoke(_gameTap);
        }
    }

    #endregion

    #region EquipmentTap

    public event Action<ItemType> OnEquipmentTapChanged;
    private ItemType _equipmentTap = ItemType.Weapon;
    public ItemType EquipmentTap
    {
        get { return _equipmentTap; }
        set
        {
            _equipmentTap = value;
            OnEquipmentTapChanged?.Invoke(_equipmentTap);
        }
    }
    #endregion

    public Transform[] Equipment = new Transform[(int)ItemType.None];

}
