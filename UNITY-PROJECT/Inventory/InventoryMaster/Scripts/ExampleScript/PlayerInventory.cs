using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
    private Inventory craftSystemInventory;
    private CraftSystem cS;
    private Inventory mainInventory;
    private Inventory characterSystemInventory;
    private Tooltip toolTip;
	private GameObject Item;
	public Transform parentObject;

    private InputManager inputManagerDatabase;

    public GameObject HPMANACanvas;

    Text hpText;
    Text manaText;
    Image hpImage;
    Image manaImage;

    float maxHealth = 100;
    float maxMana = 100;
    float maxDamage = 0;
    float maxArmor = 0;

    public float currentHealth = 100;
    public float currentMana = 100;
    float currentDamage = 0;
    float currentArmor = 0;

    int normalSize = 3;

	void Start()
	{
		if (HPMANACanvas != null)
		{
		    hpText = HPMANACanvas.transform.GetChild(1).GetChild(0).GetComponent<Text>();

		    manaText = HPMANACanvas.transform.GetChild(2).GetChild(0).GetComponent<Text>();

		    hpImage = HPMANACanvas.transform.GetChild(1).GetComponent<Image>();
		    manaImage = HPMANACanvas.transform.GetChild(2).GetComponent<Image>();

		    UpdateHPBar();
		    UpdateManaBar();
		}

		if (inputManagerDatabase == null)
			inputManagerDatabase = (InputManager)Resources.Load("InputManager");

		if (craftSystem != null)
			cS = craftSystem.GetComponent<CraftSystem>();

		if (GameObject.FindGameObjectWithTag("Tooltip") != null)
			toolTip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
		if (inventory != null)
			mainInventory = inventory.GetComponent<Inventory>();
		if (characterSystem != null)
			characterSystemInventory = characterSystem.GetComponent<Inventory>();
		if (craftSystem != null)
			craftSystemInventory = craftSystem.GetComponent<Inventory>();
	}

    public void OnEnable()
    {
		Screen.lockCursor = false;
		Inventory.ItemEquip += OnEquipItem;
		Inventory.ItemConsumed -= OnConsumeItem;

        Inventory.ItemEquip += OnBackpack;
        Inventory.UnEquipItem += UnEquipBackpack;

        Inventory.ItemEquip += OnGearItem;
        Inventory.ItemConsumed += OnConsumeItem;
        Inventory.UnEquipItem += OnUnEquipItem;

        Inventory.ItemEquip += EquipWeapon;
        Inventory.UnEquipItem += UnEquipWeapon;
    }

	void OnEquipItem(Item item)
	{
		Debug.Log ("Equiped : " + item.itemType);
		if (item.itemType.ToString() == "Weapon") {
			GameObject parent = GameObject.FindGameObjectWithTag ("WeaponHand");
			Item = (GameObject)Instantiate (item.itemModel, parent.transform.position, transform.rotation);
			Item.transform.parent = parent.transform;
			Item.transform.Translate (0f, -0.04f, -0.16f);
			Item.transform.Rotate (35, 90, 180);
		}
		else if (item.itemType.ToString() == "Shield") {
			GameObject parent = GameObject.FindGameObjectWithTag ("ShieldHand");
			Item = (GameObject)Instantiate (item.itemModel, parent.transform.position, transform.rotation);
			Item.transform.parent = parent.transform;
			Item.transform.Translate (0f, 0f, 0f);
			Item.transform.Rotate (58, 0, -90);
		}
	}

    public void OnDisable()
    {
		Screen.lockCursor = true;
        Inventory.ItemEquip -= OnBackpack;
        Inventory.UnEquipItem -= UnEquipBackpack;

        Inventory.ItemEquip -= OnGearItem;
        Inventory.ItemConsumed -= OnConsumeItem;
        Inventory.UnEquipItem -= OnUnEquipItem;

        Inventory.UnEquipItem -= UnEquipWeapon;
        Inventory.ItemEquip -= EquipWeapon;
    }

    void EquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //add the weapon if you unequip the weapon
        }
    }

    void UnEquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //delete the weapon if you unequip the weapon
        }
    }

    void OnBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
        {
            for (int i = 0; i < item.itemAttributes.Count; i++)
            {
                if (mainInventory == null)
                    mainInventory = inventory.GetComponent<Inventory>();
                mainInventory.sortItems();
                if (item.itemAttributes[i].attributeName == "Slots")
                    changeInventorySize(item.itemAttributes[i].attributeValue);
            }
        }
    }

    void UnEquipBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
            changeInventorySize(normalSize);
    }

    void changeInventorySize(int size)
    {
        dropTheRestItems(size);

        if (mainInventory == null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (size == 3)
        {
            mainInventory.width = 3;
            mainInventory.height = 1;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        if (size == 6)
        {
            mainInventory.width = 3;
            mainInventory.height = 2;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 12)
        {
            mainInventory.width = 4;
            mainInventory.height = 3;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 16)
        {
            mainInventory.width = 4;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 24)
        {
            mainInventory.width = 6;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
    }

    void dropTheRestItems(int size)
    {
        if (size < mainInventory.ItemsInInventory.Count)
        {
            for (int i = size; i < mainInventory.ItemsInInventory.Count; i++)
            {
                GameObject dropItem = (GameObject)Instantiate(mainInventory.ItemsInInventory[i].itemModel);
                dropItem.AddComponent<PickUpItem>();
                dropItem.GetComponent<PickUpItem>().item = mainInventory.ItemsInInventory[i];
                dropItem.transform.localPosition = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
            }
        }
    }

    public void UpdateHPBar()
    {
        hpText.text = (currentHealth + "/" + maxHealth);
        float fillAmount = currentHealth / maxHealth;
        hpImage.fillAmount = fillAmount;
    }

    public void UpdateManaBar()
    {
        manaText.text = (currentMana + "/" + maxMana);
        float fillAmount = currentMana / maxMana;
        manaImage.fillAmount = fillAmount;
    }


    public void OnConsumeItem(Item item)
    {
		Debug.Log("Consumed : " + item.itemName);
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
            {
                if ((currentHealth + item.itemAttributes[i].attributeValue) > maxHealth)
                    currentHealth = maxHealth;
                else
                    currentHealth += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Mana")
            {
                if ((currentMana + item.itemAttributes[i].attributeValue) > maxMana)
                    currentMana = maxMana;
                else
                    currentMana += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Armor")
            {
                if ((currentArmor + item.itemAttributes[i].attributeValue) > maxArmor)
                    currentArmor = maxArmor;
                else
                    currentArmor += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Damage")
            {
                if ((currentDamage + item.itemAttributes[i].attributeValue) > maxDamage)
                    currentDamage = maxDamage;
                else
                    currentDamage += item.itemAttributes[i].attributeValue;
            }
        }
		Debug.Log ("HP : " + currentHealth + " Stamina : " + currentMana);
        if (HPMANACanvas != null)
        {
            UpdateManaBar();
            UpdateHPBar();
        }
    }

    public void OnGearItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                maxHealth += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Mana")
                maxMana += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Armor")
                maxArmor += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                maxDamage += item.itemAttributes[i].attributeValue;
        }
        if (HPMANACanvas != null)
        {
            UpdateManaBar();
            UpdateHPBar();
        }
    }

    public void OnUnEquipItem(Item item)
    {
		Debug.Log("Unequiped : " + item.itemName);
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                maxHealth -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Mana")
                maxMana -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Armor")
                maxArmor -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                maxDamage -= item.itemAttributes[i].attributeValue;
        }
        if (HPMANACanvas != null)
        {
            UpdateManaBar();
            UpdateHPBar();
        }
    }



    // Update is called once per frame
    void Update()
    {
		UpdateManaBar();
		UpdateHPBar();
        if (Input.GetKeyDown(inputManagerDatabase.CharacterSystemKeyCode))
        {
            if (!characterSystem.activeSelf)
            {
                characterSystemInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                characterSystemInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.InventoryKeyCode))
        {
            if (!inventory.activeSelf)
            {
                mainInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                mainInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.CraftSystemKeyCode))
        {
            if (!craftSystem.activeSelf)
                craftSystemInventory.openInventory();
            else
            {
                if (cS != null)
                    cS.backToInventory();
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                craftSystemInventory.closeInventory();
            }
        }

    }

}
