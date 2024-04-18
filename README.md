# Alchemist

This is my first project as a Unity developer, I tried to implement many mechanics and in the process of creating this game I learned the Unity engine.

___

## Development plan

- [ ] Core mechanics
  - [X] Movement
  - [ ] Battle
    - [X] Enemis
    - [ ] Boss fight
  - [X] Сombat system
  - [X] Inventory system
  - [X] Items 
  - [X] Game art
  - [X] Craft system
  - [X] In game shop
- [ ] Side goals
  - [X] Advertising (test version)
  - [X] Ui
    - [X] Main menu
    - [X] Pause menu
    - [X] Shop menu
    - [X] Craft menu
  - [ ] Audio
  - [ ] Particle system

  ## Short description

  In this game I use my own art, I do this for fun.
  ![Items](https://sun9-74.userapi.com/impg/GTz9oCFNDHf6PmJUO09SRia3lsPSlnH8LPH3Hg/Y9cu6mKiZy8.jpg?size=1906x748&quality=96&sign=53335581fdaf345bae14ade4e2f0292f&type=album)
 ![alt text](https://github.com/roki09/Alchemist/blob/main/ForGit/image.png?raw=true)
 ![alt text](https://github.com/roki09/Alchemist/blob/main/ForGit/slime.gif?raw=true)

And more others.

___

Implemented here:
- Base movement ![alt text](https://github.com/roki09/Alchemist/blob/main/ForGit/2.gif?raw=true)
  - [Movement](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/MainHero/HeroDirectionReader.cs) 
- Battle system ![alt text](https://github.com/roki09/Alchemist/blob/main/ForGit/4.gif?raw=true)
  - [WeaponMoving](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/MainHero/Hands/HandsMoving.cs)
  - [Damage](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/WeaponTrigger.cs)
  - [Enemis](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Enemis/Enemis.cs)
    - [Slime](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Enemis/Slime/SlimeBase.cs)
    - [BlueSlime](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Enemis/Slime/BlueSlime.cs)
- Items system ![alt text](https://github.com/roki09/Alchemist/blob/main/ForGit/5.gif?raw=true) ![alt text](https://github.com/roki09/Alchemist/blob/main/ForGit/6.gif?raw=true)
  - [InventorySystem](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/InventoryHandler.cs)
    - [Chest](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/ChestLogic.cs)
  - [Item](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/Item.cs)
    - [Weapon](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/Weapon.cs)
    - [ItemAnimation](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/ItemAnimation.cs)
    - [ItemPickUp](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/ItemPickUp.cs), [ItemDrop](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Enemis/ItemDrop.cs)
    - [ItemShowStats](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/ItemShowStats.cs)
- Shop and craft system ![alt text](craft.gif)
  - [Craft](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/Formula.cs)
  - [Shop](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/ShopHandler.cs)
    - [ButtonLogic](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Items/ShopButtonLogic.cs)
    
**All items have rarity,and  are randomly generated in chests with different characteristics.**

- **Ui**
  - [MainMenu](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Ui/MainMenuUI.cs)
  - [PauseMenu](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Ui/PauseMenu.cs)
  - Advertising
    - [AdInitializer](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Monetization/AdInitializer.cs)
    - [InterstitialAds](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Monetization/InterstitialAds.cs)
  - [SaveSystem](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Save/SaveLoad.cs)
    - [SaveManager](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Save/SaveManager.cs)
    - [PlayerPrefs](https://github.com/roki09/Alchemist/blob/main/Assets/Scripts/Save/PlayerPrefsData.cs)

    ## More updates in the future
    - Boss fight
    - More items
    - Particle
    - Game statistic
    - And more others...




 
