using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }

    public class ItemManager : Singleton<ItemManager>
    {
        public List<ItemSetup> itemSetups;

        private void Start()
        {
            Reset();
            LoadItensFromSave();
        }

        public void LoadItensFromSave()
        {
            AddByType(ItemType.COIN, (int) SaveManager.Instance.Setup.coins);
            AddByType(ItemType.LIFE_PACK, (int)SaveManager.Instance.Setup.health);
        }

        private void Reset()
        {
            foreach (var i in itemSetups)
            {
                i.soInt.value = 0;
            }

        }

        public ItemSetup GetItemByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.itemType == itemType);
        }

        public void AddByType(ItemType itemType, int amount = 1)
        {
            if (amount < 0) return;
            itemSetups.Find(i => i.itemType == itemType).soInt.value += amount;
        }

        public void RemoveByType(ItemType itemType, int amount = 1)
        {
            var item = itemSetups.Find(i => i.itemType == itemType);
            item.soInt.value -= amount;

            if(item.soInt.value < 0) item.soInt.value = 0;
        }

    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }

}
