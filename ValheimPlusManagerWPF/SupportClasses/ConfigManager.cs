using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using System;
using System.Globalization;
using ValheimPlusManager.Data;
using ValheimPlusManager.Models;

namespace ValheimPlusManager.SupportClasses
{
    public sealed class ConfigManager
    {
        public static ValheimPlusConf ReadConfigFile(bool manageClient)
        {
            ValheimPlusConf valheimPlusConfiguration = new ValheimPlusConf();
            Settings settings = SettingsDAL.GetSettings();
            IniData data;

            // Settings to make sure floats are using dots as separators and not commas
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            var parser = new FileIniDataParser();
            if (manageClient)
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ClientInstallationPath));
            }
            else
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ServerInstallationPath));
            }

            #region Advanced building mode
            if (bool.TryParse(data["AdvancedBuildingMode"]["enabled"], out bool advancedBuildingModeEnabled))
            {
                valheimPlusConfiguration.advancedBuildingModeEnabled = advancedBuildingModeEnabled;
            }
            if (data["AdvancedBuildingMode"]["enterAdvancedBuildingMode"] != null)
            {
                valheimPlusConfiguration.enterAdvancedBuildingMode = data["AdvancedBuildingMode"]["enterAdvancedBuildingMode"];
            }
            if (data["AdvancedBuildingMode"]["exitAdvancedBuildingMode"] != null)
            {
                valheimPlusConfiguration.exitAdvancedBuildingMode = data["AdvancedBuildingMode"]["exitAdvancedBuildingMode"];
            }
            if (data["AdvancedBuildingMode"]["copyObjectRotation"] != null)
            {
                valheimPlusConfiguration.copyObjectRotation = data["AdvancedBuildingMode"]["copyObjectRotation"];
            }
            if (data["AdvancedBuildingMode"]["pasteObjectRotation"] != null)
            {
                valheimPlusConfiguration.pasteObjectRotation = data["AdvancedBuildingMode"]["pasteObjectRotation"];
            }
            if (data["AdvancedBuildingMode"]["increaseScrollSpeed"] != null)
            {
                valheimPlusConfiguration.increaseScrollSpeed = data["AdvancedBuildingMode"]["increaseScrollSpeed"];
            }
            if (data["AdvancedBuildingMode"]["decreaseScrollSpeed"] != null)
            {
                valheimPlusConfiguration.decreaseScrollSpeed = data["AdvancedBuildingMode"]["decreaseScrollSpeed"];
            }

            #endregion Advanced building mode

            #region Advanced editing mode
            if (bool.TryParse(data["AdvancedEditingMode"]["enabled"], out bool advancedEditingModeEnabled))
            {
                valheimPlusConfiguration.advancedEditingModeEnabled = advancedEditingModeEnabled;
            }
            if (data["AdvancedEditingMode"]["enterAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.enterAdvancedEditingMode = data["AdvancedEditingMode"]["enterAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["resetAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.resetAdvancedEditingMode = data["AdvancedEditingMode"]["resetAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["abortAndExitAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.abortAndExitAdvancedEditingMode = data["AdvancedEditingMode"]["abortAndExitAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["confirmPlacementOfAdvancedEditingMode"] != null)
            {
                valheimPlusConfiguration.confirmPlacementOfAdvancedEditingMode = data["AdvancedEditingMode"]["confirmPlacementOfAdvancedEditingMode"];
            }
            if (data["AdvancedEditingMode"]["copyObjectRotation"] != null)
            {
                valheimPlusConfiguration.copyObjectRotationAEM = data["AdvancedEditingMode"]["copyObjectRotation"];
            }
            if (data["AdvancedEditingMode"]["pasteObjectRotation"] != null)
            {
                valheimPlusConfiguration.pasteObjectRotationAEM = data["AdvancedEditingMode"]["pasteObjectRotation"];
            }
            if (data["AdvancedEditingMode"]["increaseScrollSpeed"] != null)
            {
                valheimPlusConfiguration.increaseScrollSpeedAEM = data["AdvancedEditingMode"]["increaseScrollSpeed"];
            }
            if (data["AdvancedEditingMode"]["decreaseScrollSpeed"] != null)
            {
                valheimPlusConfiguration.decreaseScrollSpeedAEM = data["AdvancedEditingMode"]["decreaseScrollSpeed"];
            }
            #endregion Advanced editing mode

            #region Armor
            if (bool.TryParse(data["Armor"]["enabled"], out bool armorSettingsEnabled))
            {
                valheimPlusConfiguration.armorSettingsEnabled = armorSettingsEnabled;
            }
            if (float.TryParse(data["Armor"]["helmets"], NumberStyles.Any, ci, out float helmetsArmor))
            {
                valheimPlusConfiguration.helmetsArmor = helmetsArmor;
            }
            if (float.TryParse(data["Armor"]["chests"], NumberStyles.Any, ci, out float chestsArmor))
            {
                valheimPlusConfiguration.chestsArmor = chestsArmor;
            }
            if (float.TryParse(data["Armor"]["legs"], NumberStyles.Any, ci, out float legsArmor))
            {
                valheimPlusConfiguration.legsArmor = legsArmor;
            }
            if (float.TryParse(data["Armor"]["capes"], NumberStyles.Any, ci, out float capesArmor))
            {
                valheimPlusConfiguration.capesArmor = capesArmor;
            }
            #endregion Armor

            #region Bed
            if (bool.TryParse(data["Bed"]["enabled"], out bool bedSettingsEnabled))
            {
                valheimPlusConfiguration.bedSettingsEnabled = bedSettingsEnabled;
            }
            if (bool.TryParse(data["Bed"]["sleepWithoutSpawn"], out bool sleepWithoutSpawn))
            {
                valheimPlusConfiguration.sleepWithoutSpawn = sleepWithoutSpawn;
            }
            if (bool.TryParse(data["Bed"]["unclaimedBedsOnly"], out bool unclaimedBedsOnly))
            {
                valheimPlusConfiguration.unclaimedBedsOnly = unclaimedBedsOnly;
            }
            #endregion Bed


            #region Beehive
            if (bool.TryParse(data["Beehive"]["enabled"], out bool beehiveSettingsEnabled))
            {
                valheimPlusConfiguration.beehiveSettingsEnabled = beehiveSettingsEnabled;
            }
            if (float.TryParse(data["Beehive"]["honeyProductionSpeed"], NumberStyles.Any, ci, out float honeyProductionSpeed))
            {
                valheimPlusConfiguration.honeyProductionSpeed = honeyProductionSpeed;
            }
            if (int.TryParse(data["Beehive"]["maximumHoneyPerBeehive"], out int maximumHoneyPerBeehive))
            {
                valheimPlusConfiguration.maximumHoneyPerBeehive = maximumHoneyPerBeehive;
            }
            if (float.TryParse(data["Beehive"]["autoDepositRange"], NumberStyles.Any, ci, out float autoDepositHoneyRange))
            {
                valheimPlusConfiguration.autoDepositHoneyRange = autoDepositHoneyRange;
            }
            if (bool.TryParse(data["Beehive"]["autoDeposit"], out bool autoDepositHoney))
            {
                valheimPlusConfiguration.autoDepositHoney = autoDepositHoney;
            }
            if (bool.TryParse(data["Beehive"]["showDuration"], out bool showDurationBeehive))
            {
                valheimPlusConfiguration.showDurationBeehive = showDurationBeehive;
            }
            #endregion Beehive

            #region Building
            if (bool.TryParse(data["Building"]["enabled"], out bool buildingSettingsEnabled))
            {
                valheimPlusConfiguration.buildingSettingsEnabled = buildingSettingsEnabled;
            }
            if (bool.TryParse(data["Building"]["noInvalidPlacementRestriction"], out bool noInvalidPlacementRestriction))
            {
                valheimPlusConfiguration.noInvalidPlacementRestriction = noInvalidPlacementRestriction;
            }
            if (bool.TryParse(data["Building"]["noMysticalForcesPreventPlacementRestriction"], out bool noMysticalForcesPreventPlacementRestriction))
            {
                valheimPlusConfiguration.noMysticalForcesPreventPlacementRestriction = noMysticalForcesPreventPlacementRestriction;
            }
            if (bool.TryParse(data["Building"]["noWeatherDamage"], out bool noWeatherDamage))
            {
                valheimPlusConfiguration.noWeatherDamage = noWeatherDamage;
            }
            if (float.TryParse(data["Building"]["maximumPlacementDistance"], NumberStyles.Any, ci, out float maximumPlacementDistance))
            {
                valheimPlusConfiguration.maximumPlacementDistance = maximumPlacementDistance;
            }
            if (float.TryParse(data["Building"]["pieceComfortRadius"], NumberStyles.Any, ci, out float pieceComfortRadius))
            {
                valheimPlusConfiguration.pieceComfortRadius = pieceComfortRadius;
            }
            if (bool.TryParse(data["Building"]["alwaysDropResources"], out bool alwaysDropResources))
            {
                valheimPlusConfiguration.alwaysDropResources = alwaysDropResources;
            }
            if (bool.TryParse(data["Building"]["alwaysDropExcludedResources"], out bool alwaysDropExcludedResources))
            {
                valheimPlusConfiguration.alwaysDropExcludedResources = alwaysDropExcludedResources;
            }
            if (bool.TryParse(data["Building"]["enableAreaRepair"], out bool enableAreaRepair))
            {
                valheimPlusConfiguration.enableAreaRepair = enableAreaRepair;
            }
            if (float.TryParse(data["Building"]["areaRepairRadius"], NumberStyles.Any, ci, out float areaRepairRadius))
            {
                valheimPlusConfiguration.areaRepairRadius = areaRepairRadius;
            }
            #endregion Building

            #region Camera
            if (bool.TryParse(data["Camera"]["enabled"], out bool cameraSettingsEnabled))
            {
                valheimPlusConfiguration.cameraSettingsEnabled = cameraSettingsEnabled;
            }
            if (Int32.TryParse(data["Camera"]["cameraMaximumZoomDistance"], out int cameraMaximumZoomDistance)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.cameraMaximumZoomDistance = cameraMaximumZoomDistance;
            }
            if (Int32.TryParse(data["Camera"]["cameraBoatMaximumZoomDistance"], out int cameraBoatMaximumZoomDistance)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.cameraBoatMaximumZoomDistance = cameraBoatMaximumZoomDistance;
            }
            if (Int32.TryParse(data["Camera"]["cameraFOV"], out int cameraFOV)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.cameraFOV = cameraFOV;
            }
            #endregion Camera

            #region CraftFromChest
            if (bool.TryParse(data["CraftFromChest"]["enabled"], out bool craftFromChestSettingsEnabled))
            {
                valheimPlusConfiguration.craftFromChestSettingsEnabled = craftFromChestSettingsEnabled;
            }
            if (Int32.TryParse(data["CraftFromChest"]["lookupInterval"], out int lookupIntervalCraftFromChest))
            {
                valheimPlusConfiguration.lookupIntervalCraftFromChest = lookupIntervalCraftFromChest;
            }
            if (float.TryParse(data["CraftFromChest"]["range"], NumberStyles.Any, ci, out float rangeCraftFromChest))
            {
                valheimPlusConfiguration.rangeCraftFromChest = rangeCraftFromChest;
            }
            if (bool.TryParse(data["CraftFromChest"]["disableCookingStation"], out bool disableCookingStationCraftFromChest))
            {
                valheimPlusConfiguration.disableCookingStationCraftFromChest = disableCookingStationCraftFromChest;
            }
            if (bool.TryParse(data["CraftFromChest"]["checkFromWorkbench"], out bool checkFromWorkbenchCraftFromChest))
            {
                valheimPlusConfiguration.checkFromWorkbenchCraftFromChest = checkFromWorkbenchCraftFromChest;
            }
            if (bool.TryParse(data["CraftFromChest"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckCraftFromChest))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckCraftFromChest = ignorePrivateAreaCheckCraftFromChest;
            }
            #endregion CraftFromChest

            #region Durability
            if (bool.TryParse(data["Durability"]["enabled"], out bool durabilitySettingsEnabled))
            {
                valheimPlusConfiguration.durabilitySettingsEnabled = durabilitySettingsEnabled;
            }
            if (float.TryParse(data["Durability"]["axes"], NumberStyles.Any, ci, out float axesDurability))
            {
                valheimPlusConfiguration.axesDurability = axesDurability;
            }
            if (float.TryParse(data["Durability"]["pickaxes"], NumberStyles.Any, ci, out float pickaxesDurability))
            {
                valheimPlusConfiguration.pickaxesDurability = pickaxesDurability;
            }
            if (float.TryParse(data["Durability"]["hammer"], NumberStyles.Any, ci, out float hammerDurability))
            {
                valheimPlusConfiguration.hammerDurability = hammerDurability;
            }
            if (float.TryParse(data["Durability"]["cultivator"], NumberStyles.Any, ci, out float cultivatorDurability))
            {
                valheimPlusConfiguration.cultivatorDurability = cultivatorDurability;
            }
            if (float.TryParse(data["Durability"]["hoe"], NumberStyles.Any, ci, out float hoeDurability))
            {
                valheimPlusConfiguration.hoeDurability = hoeDurability;
            }
            if (float.TryParse(data["Durability"]["weapons"], NumberStyles.Any, ci, out float weaponsDurability))
            {
                valheimPlusConfiguration.weaponsDurability = weaponsDurability;
            }
            if (float.TryParse(data["Durability"]["armor"], NumberStyles.Any, ci, out float armorDurability))
            {
                valheimPlusConfiguration.armorDurability = armorDurability;
            }
            if (float.TryParse(data["Durability"]["bows"], NumberStyles.Any, ci, out float bowsDurability))
            {
                valheimPlusConfiguration.bowsDurability = bowsDurability;
            }
            if (float.TryParse(data["Durability"]["shields"], NumberStyles.Any, ci, out float shieldsDurability))
            {
                valheimPlusConfiguration.shieldsDurability = shieldsDurability;
            }
            if (float.TryParse(data["Durability"]["torch"], NumberStyles.Any, ci, out float torch))
            {
                valheimPlusConfiguration.torchDurability = torch;
            }
            #endregion Durability

            #region Experience
            if (bool.TryParse(data["Experience"]["enabled"], out bool experienceSettingsEnabled))
            {
                valheimPlusConfiguration.experienceSettingsEnabled = experienceSettingsEnabled;
            }
            if (int.TryParse(data["Experience"]["swords"], out int experienceSwords))
            {
                valheimPlusConfiguration.experienceSwords = experienceSwords;
            }
            if (int.TryParse(data["Experience"]["knives"], out int experienceKnives))
            {
                valheimPlusConfiguration.experienceKnives = experienceKnives;
            }
            if (int.TryParse(data["Experience"]["clubs"], out int experienceClubs))
            {
                valheimPlusConfiguration.experienceClubs = experienceClubs;
            }
            if (int.TryParse(data["Experience"]["polearms"], out int experiencePolearms))
            {
                valheimPlusConfiguration.experiencePolearms = experiencePolearms;
            }
            if (int.TryParse(data["Experience"]["spears"], out int experienceSpears))
            {
                valheimPlusConfiguration.experienceSpears = experienceSpears;
            }
            if (int.TryParse(data["Experience"]["blocking"], out int experienceBlocking))
            {
                valheimPlusConfiguration.experienceBlocking = experienceBlocking;
            }
            if (int.TryParse(data["Experience"]["axes"], out int experienceAxes))
            {
                valheimPlusConfiguration.experienceAxes = experienceAxes;
            }
            if (int.TryParse(data["Experience"]["bows"], out int experienceBows))
            {
                valheimPlusConfiguration.experienceBows = experienceBows;
            }
            if (int.TryParse(data["Experience"]["fireMagic"], out int experienceFireMagic))
            {
                valheimPlusConfiguration.experienceFireMagic = experienceFireMagic;
            }
            if (int.TryParse(data["Experience"]["frostMagic"], out int experienceFrostMagic))
            {
                valheimPlusConfiguration.experienceFrostMagic = experienceFrostMagic;
            }
            if (int.TryParse(data["Experience"]["unarmed"], out int experienceUnarmed))
            {
                valheimPlusConfiguration.experienceUnarmed = experienceUnarmed;
            }
            if (int.TryParse(data["Experience"]["pickaxes"], out int experiencePickaxes))
            {
                valheimPlusConfiguration.experiencePickaxes = experiencePickaxes;
            }
            if (int.TryParse(data["Experience"]["woodCutting"], out int experienceWoodCutting))
            {
                valheimPlusConfiguration.experienceWoodCutting = experienceWoodCutting;
            }
            if (int.TryParse(data["Experience"]["jump"], out int experienceJump))
            {
                valheimPlusConfiguration.experienceJump = experienceJump;
            }
            if (int.TryParse(data["Experience"]["sneak"], out int experienceSneak))
            {
                valheimPlusConfiguration.experienceSneak = experienceSneak;
            }
            if (int.TryParse(data["Experience"]["run"], out int experienceRun))
            {
                valheimPlusConfiguration.experienceRun = experienceRun;
            }
            if (int.TryParse(data["Experience"]["swim"], out int experienceSwim))
            {
                valheimPlusConfiguration.experienceSwim = experienceSwim;
            }
            if (Int32.TryParse(data["Experience"]["hammer"], out int experienceHammer)) // Added in case Iron Gate adds XP for hammers
            {
                valheimPlusConfiguration.experienceHammer = experienceHammer;
            }
            if (Int32.TryParse(data["Experience"]["hoe"], out int experienceHoe)) // Added in case Iron Gate adds XP for hoes
            {
                valheimPlusConfiguration.experienceHoe = experienceHoe;
            }
            #endregion Experience

            #region Fermenter
            if (bool.TryParse(data["Fermenter"]["enabled"], out bool fermenterSettingsEnabled))
            {
                valheimPlusConfiguration.fermenterSettingsEnabled = fermenterSettingsEnabled;
            }
            if (float.TryParse(data["Fermenter"]["fermenterDuration"], NumberStyles.Any, ci, out float fermenterDuration))
            {
                valheimPlusConfiguration.fermenterDuration = fermenterDuration;
            }
            if (int.TryParse(data["Fermenter"]["fermenterItemsProduced"], out int fermenterItemsProduced))
            {
                valheimPlusConfiguration.fermenterItemsProduced = fermenterItemsProduced;
            }
            if (bool.TryParse(data["Fermenter"]["showDuration"], out bool showFermenterDuration))
            {
                valheimPlusConfiguration.showFermenterDuration = showFermenterDuration;
            }
            if (bool.TryParse(data["Fermenter"]["autoDeposit"], out bool autoDepositFermenter))
            {
                valheimPlusConfiguration.autoDepositFermenter = autoDepositFermenter;
            }
            if (bool.TryParse(data["Fermenter"]["autoFuel"], out bool autoFuelFermenter))
            {
                valheimPlusConfiguration.autoFuelFermenter = autoFuelFermenter;
            }
            if (bool.TryParse(data["Fermenter"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckFermenter))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckFermenter = ignorePrivateAreaCheckFermenter;
            }
            if (int.TryParse(data["Fermenter"]["autoRange"], out int autoRangeFermenter))
            {
                valheimPlusConfiguration.autoRangeFermenter = autoRangeFermenter;
            }
            #endregion Fermenter

            #region FireSource
            if (bool.TryParse(data["FireSource"]["enabled"], out bool fireSourceSettingsEnabled))
            {
                valheimPlusConfiguration.fireSourceSettingsEnabled = fireSourceSettingsEnabled;
            }
            if (bool.TryParse(data["FireSource"]["torches"], out bool torches))
            {
                valheimPlusConfiguration.torchesFireSource = torches;
            }
            if (bool.TryParse(data["FireSource"]["fires"], out bool fires))
            {
                valheimPlusConfiguration.torchesFireSource = fires;
            }
            if (bool.TryParse(data["FireSource"]["autoFuel"], out bool autoFuelFireSource))
            {
                valheimPlusConfiguration.autoFuelFireSource = autoFuelFireSource;
            }
            if (bool.TryParse(data["FireSource"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckFireSource))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckFireSource = ignorePrivateAreaCheckFireSource;
            }
            if (int.TryParse(data["FireSource"]["autoRange"], out int autoRangeFireSource))
            {
                valheimPlusConfiguration.autoRangeFireSource = autoRangeFireSource;
            }
            #endregion FireSource

            #region FirstPerson
            if (bool.TryParse(data["FirstPerson"]["enabled"], out bool firstPersonSettingsEnabled))
            {
                valheimPlusConfiguration.firstPersonSettingsEnabled = firstPersonSettingsEnabled;
            }
            if (data["FirstPerson"]["hotkey"] != null)
            {
                valheimPlusConfiguration.hotkey = data["FirstPerson"]["hotkey"];
            }
            if (float.TryParse(data["FirstPerson"]["defaultFOV"], NumberStyles.Any, ci, out float defaultFOV))
            {
                valheimPlusConfiguration.defaultFOV = defaultFOV;
            }
            if (data["FirstPerson"]["raiseFOVHotkey"] != null)
            {
                valheimPlusConfiguration.raiseFOVHotkey = data["FirstPerson"]["raiseFOVHotkey"];
            }
            if (data["FirstPerson"]["lowerFOVHotkey"] != null)
            {
                valheimPlusConfiguration.lowerFOVHotkey = data["FirstPerson"]["lowerFOVHotkey"];
            }
            #endregion FirstPerson

            #region Food
            if (bool.TryParse(data["Food"]["enabled"], out bool foodSettingsEnabled))
            {
                valheimPlusConfiguration.foodSettingsEnabled = foodSettingsEnabled;
            }
            if (float.TryParse(data["Food"]["foodDurationMultiplier"], NumberStyles.Any, ci, out float foodDurationMultiplier))
            {
                valheimPlusConfiguration.foodDurationMultiplier = foodDurationMultiplier;
            }
            if (bool.TryParse(data["Food"]["disableFoodDegradation"], out bool disableFoodDegradation))
            {
                valheimPlusConfiguration.disableFoodDegradation = disableFoodDegradation;
            }
            #endregion Food

            #region FreePlacementRotation
            if (bool.TryParse(data["FreePlacementRotation"]["enabled"], out bool freePlacementRotationSettingsEnabled))
            {
                valheimPlusConfiguration.freePlacementRotationSettingsEnabled = freePlacementRotationSettingsEnabled;
            }
            if (data["FreePlacementRotation"]["rotateY"] != null)
            {
                valheimPlusConfiguration.rotateY = data["FreePlacementRotation"]["rotateY"];
            }
            if (data["FreePlacementRotation"]["rotateX"] != null)
            {
                valheimPlusConfiguration.rotateX = data["FreePlacementRotation"]["rotateX"];
            }
            if (data["FreePlacementRotation"]["rotateZ"] != null)
            {
                valheimPlusConfiguration.rotateZ = data["FreePlacementRotation"]["rotateZ"];
            }
            if (data["FreePlacementRotation"]["copyRotationParallel"] != null)
            {
                valheimPlusConfiguration.copyRotationParallel = data["FreePlacementRotation"]["copyRotationParallel"];
            }
            if (data["FreePlacementRotation"]["copyRotationPerpendicular"] != null)
            {
                valheimPlusConfiguration.copyRotationPerpendicular = data["FreePlacementRotation"]["copyRotationPerpendicular"];
            }
            #endregion FreePlacementRotation

            #region Furnace
            if (bool.TryParse(data["Furnace"]["enabled"], out bool furnaceSettingsEnabled))
            {
                valheimPlusConfiguration.furnaceSettingsEnabled = furnaceSettingsEnabled;
            }
            if (int.TryParse(data["Furnace"]["maximumOre"], out int maximumOre))
            {
                valheimPlusConfiguration.maximumOre = maximumOre;
            }
            if (int.TryParse(data["Furnace"]["maximumCoal"], out int maximumCoal))
            {
                valheimPlusConfiguration.maximumCoal = maximumCoal;
            }
            if (int.TryParse(data["Furnace"]["coalUsedPerProduct"], out int coalUsedPerProduct))
            {
                valheimPlusConfiguration.coalUsedPerProduct = coalUsedPerProduct;
            }
            if (int.TryParse(data["Furnace"]["productionSpeed"], out int furnaceProductionSpeed))
            {
                valheimPlusConfiguration.furnaceProductionSpeed = furnaceProductionSpeed;
            }
            if (float.TryParse(data["Furnace"]["autoRange"], NumberStyles.Any, ci, out float autoDepositRangeFurnace))
            {
                valheimPlusConfiguration.autoDepositRangeFurnace = autoDepositRangeFurnace;
            }
            if (bool.TryParse(data["Furnace"]["autoDeposit"], out bool autoDepositFurnace))
            {
                valheimPlusConfiguration.autoDepositFurnace = autoDepositFurnace;
            }
            if (bool.TryParse(data["Furnace"]["autoFuel"], out bool autoFuelFurnace))
            {
                valheimPlusConfiguration.autoFuelFurnace = autoFuelFurnace;
            }
            if (bool.TryParse(data["Furnace"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckFurnace))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckFurnace = ignorePrivateAreaCheckFurnace;
            }
            #endregion Furnace

            #region Game
            if (bool.TryParse(data["Game"]["enabled"], out bool gameSettingsEnabled))
            {
                valheimPlusConfiguration.gameSettingsEnabled = gameSettingsEnabled;
            }
            if (float.TryParse(data["Game"]["gameDifficultyDamageScale"], NumberStyles.Any, ci, out float gameDifficultyDamageScale))
            {
                valheimPlusConfiguration.gameDifficultyDamageScale = gameDifficultyDamageScale;
            }
            if (float.TryParse(data["Game"]["gameDifficultyHealthScale"], NumberStyles.Any, ci, out float gameDifficultyHealthScale))
            {
                valheimPlusConfiguration.gameDifficultyHealthScale = gameDifficultyHealthScale;
            }
            if (int.TryParse(data["Game"]["extraPlayerCountNearby"], out int extraPlayerCountNearby))
            {
                valheimPlusConfiguration.extraPlayerCountNearby = extraPlayerCountNearby;
            }
            if (int.TryParse(data["Game"]["setFixedPlayerCountTo"], out int setFixedPlayerCountTo))
            {
                valheimPlusConfiguration.setFixedPlayerCountTo = setFixedPlayerCountTo;
            }
            if (int.TryParse(data["Game"]["difficultyScaleRange"], out int difficultyScaleRange))
            {
                valheimPlusConfiguration.difficultyScaleRange = difficultyScaleRange;
            }
            if (bool.TryParse(data["Game"]["disablePortals"], out bool disablePortals))
            {
                valheimPlusConfiguration.disablePortals = disablePortals;
            }
            if (bool.TryParse(data["Game"]["forceConsole"], out bool forceConsole))
            {
                valheimPlusConfiguration.forceConsole = forceConsole;
            }
            #endregion Game

            #region Gathering
            if (bool.TryParse(data["Gathering"]["enabled"], out bool gatheringSettingsEnabled))
            {
                valheimPlusConfiguration.gatheringSettingsEnabled = gatheringSettingsEnabled;
            }
            if (float.TryParse(data["Gathering"]["wood"], NumberStyles.Any, ci, out float woodGathering))
            {
                valheimPlusConfiguration.woodGathering = woodGathering;
            }
            if (float.TryParse(data["Gathering"]["stone"], NumberStyles.Any, ci, out float stoneGathering))
            {
                valheimPlusConfiguration.stoneGathering = stoneGathering;
            }
            if (float.TryParse(data["Gathering"]["fineWood"], NumberStyles.Any, ci, out float fineWoodGathering))
            {
                valheimPlusConfiguration.fineWoodGathering = fineWoodGathering;
            }
            if (float.TryParse(data["Gathering"]["coreWood"], NumberStyles.Any, ci, out float coreWoodGathering))
            {
                valheimPlusConfiguration.coreWoodGathering = coreWoodGathering;
            }
            if (float.TryParse(data["Gathering"]["elderBark"], NumberStyles.Any, ci, out float elderBarkGathering))
            {
                valheimPlusConfiguration.elderBarkGathering = elderBarkGathering;
            }
            if (float.TryParse(data["Gathering"]["ironScrap"], NumberStyles.Any, ci, out float ironScrapGathering))
            {
                valheimPlusConfiguration.ironScrapGathering = ironScrapGathering;
            }
            if (float.TryParse(data["Gathering"]["tinOre"], NumberStyles.Any, ci, out float tinOreGathering))
            {
                valheimPlusConfiguration.tinOreGathering = tinOreGathering;
            }
            if (float.TryParse(data["Gathering"]["copperOre"], NumberStyles.Any, ci, out float copperOreGathering))
            {
                valheimPlusConfiguration.copperOreGathering = copperOreGathering;
            }
            if (float.TryParse(data["Gathering"]["silverOre"], NumberStyles.Any, ci, out float silverOreGathering))
            {
                valheimPlusConfiguration.silverOreGathering = silverOreGathering;
            }
            if (float.TryParse(data["Gathering"]["chitin"], NumberStyles.Any, ci, out float chitinGathering))
            {
                valheimPlusConfiguration.chitinGathering = chitinGathering;
            }
            if (float.TryParse(data["Gathering"]["dropChance"], NumberStyles.Any, ci, out float dropChanceGathering))
            {
                valheimPlusConfiguration.dropChanceGathering = dropChanceGathering;
            }
            #endregion Gathering

            #region GridAlignment
            if (bool.TryParse(data["GridAlignment"]["enabled"], out bool gridAlignmentSettingsEnabled))
            {
                valheimPlusConfiguration.gridAlignmentSettingsEnabled = gridAlignmentSettingsEnabled;
            }
            if (data["GridAlignment"]["align"] != null)
            {
                valheimPlusConfiguration.align = data["GridAlignment"]["align"];
            }
            if (data["GridAlignment"]["alignToggle"] != null)
            {
                valheimPlusConfiguration.alignToggle = data["GridAlignment"]["alignToggle"];
            }
            if (data["GridAlignment"]["changeDefaultAlignment"] != null)
            {
                valheimPlusConfiguration.changeDefaultAlignment = data["GridAlignment"]["changeDefaultAlignment"];
            }
            #endregion GridAlignment

            #region Hotkeys
            if (bool.TryParse(data["Hotkeys"]["enabled"], out bool hotkeysSettingsEnabled))
            {
                valheimPlusConfiguration.hotkeysSettingsEnabled = hotkeysSettingsEnabled;
            }
            if (data["Hotkeys"]["rollForwards"] != null)
            {
                valheimPlusConfiguration.rollForwards = data["Hotkeys"]["rollForwards"];
            }
            if (data["Hotkeys"]["rollBackwards"] != null)
            {
                valheimPlusConfiguration.rollBackwards = data["Hotkeys"]["rollBackwards"];
            }
            #endregion Hotkeys

            #region HUD
            if (bool.TryParse(data["Hud"]["enabled"], out bool hudSettingsEnabled))
            {
                valheimPlusConfiguration.hudSettingsEnabled = hudSettingsEnabled;
            }
            if (bool.TryParse(data["Hud"]["showRequiredItems"], out bool showRequiredItems))
            {
                valheimPlusConfiguration.showRequiredItems = showRequiredItems;
            }
            if (bool.TryParse(data["Hud"]["experienceGainedNotifications"], out bool experienceGainedNotifications))
            {
                valheimPlusConfiguration.experienceGainedNotifications = experienceGainedNotifications;
            }
            if (bool.TryParse(data["Hud"]["displayStaminaValue"], out bool displayStaminaValue))
            {
                valheimPlusConfiguration.displayStaminaValue = displayStaminaValue;
            }
            if (bool.TryParse(data["Hud"]["removeDamageFlash"], out bool removeDamageFlash))
            {
                valheimPlusConfiguration.removeDamageFlash = removeDamageFlash;
            }
            #endregion HUD

            #region Inventory
            if (bool.TryParse(data["Inventory"]["enabled"], out bool inventorySettingsEnabled))
            {
                valheimPlusConfiguration.inventorySettingsEnabled = inventorySettingsEnabled;
            }
            if (bool.TryParse(data["Inventory"]["inventoryFillTopToBottom"], out bool inventoryFillTopToBottom))
            {
                valheimPlusConfiguration.inventoryFillTopToBottom = inventoryFillTopToBottom;
            }
            if (bool.TryParse(data["Inventory"]["mergeWithExistingStacks"], out bool mergeWithExistingStacks))
            {
                valheimPlusConfiguration.mergeWithExistingStacks = mergeWithExistingStacks;
            }
            if (int.TryParse(data["Inventory"]["playerInventoryRows"], out int playerInventoryRows))
            {
                valheimPlusConfiguration.playerInventoryRows = playerInventoryRows;
            }
            if (int.TryParse(data["Inventory"]["woodChestColumns"], out int woodChestColumns))
            {
                valheimPlusConfiguration.woodChestColumns = woodChestColumns;
            }
            if (int.TryParse(data["Inventory"]["woodChestRows"], out int woodChestRows))
            {
                valheimPlusConfiguration.woodChestRows = woodChestRows;
            }
            if (int.TryParse(data["Inventory"]["personalChestColumns"], out int personalChestColumns))
            {
                valheimPlusConfiguration.personalChestColumns = personalChestColumns;
            }
            if (int.TryParse(data["Inventory"]["personalChestRows"], out int personalChestRows))
            {
                valheimPlusConfiguration.personalChestRows = personalChestRows;
            }
            if (int.TryParse(data["Inventory"]["ironChestColumns"], out int ironChestColumns))
            {
                valheimPlusConfiguration.ironChestColumns = ironChestColumns;
            }
            if (int.TryParse(data["Inventory"]["ironChestRows"], out int ironChestRows))
            {
                valheimPlusConfiguration.ironChestRows = ironChestRows;
            }
            if (int.TryParse(data["Inventory"]["cartInventoryRows"], out int cartInventoryRows))
            {
                valheimPlusConfiguration.cartInventoryRows = cartInventoryRows;
            }
            if (int.TryParse(data["Inventory"]["cartInventoryColumns"], out int cartInventoryColumns))
            {
                valheimPlusConfiguration.cartInventoryColumns = cartInventoryColumns;
            }
            if (int.TryParse(data["Inventory"]["karveInventoryColumns"], out int karveInventoryColumns))
            {
                valheimPlusConfiguration.karveInventoryColumns = karveInventoryColumns;
            }
            if (int.TryParse(data["Inventory"]["karveInventoryRows"], out int karveInventoryRows))
            {
                valheimPlusConfiguration.karveInventoryRows = karveInventoryRows;
            }
            if (int.TryParse(data["Inventory"]["longboatInventoryColumns"], out int longboatInventoryColumns))
            {
                valheimPlusConfiguration.longboatInventoryColumns = longboatInventoryColumns;
            }
            if (int.TryParse(data["Inventory"]["longboatInventoryRows"], out int longboatInventoryRows))
            {
                valheimPlusConfiguration.longboatInventoryRows = longboatInventoryRows;
            }
            #endregion Inventory

            #region Items
            if (bool.TryParse(data["Items"]["enabled"], out bool itemsSettingsEnabled))
            {
                valheimPlusConfiguration.itemsSettingsEnabled = itemsSettingsEnabled;
            }
            if (bool.TryParse(data["Items"]["noTeleportPrevention"], out bool noTeleportPrevention))
            {
                valheimPlusConfiguration.noTeleportPrevention = noTeleportPrevention;
            }
            if (float.TryParse(data["Items"]["baseItemWeightReduction"], NumberStyles.Any, ci, out float baseItemWeightReduction))
            {
                valheimPlusConfiguration.baseItemWeightReduction = baseItemWeightReduction;
            }
            if (float.TryParse(data["Items"]["itemStackMultiplier"], NumberStyles.Any, ci, out float itemStackMultiplier))
            {
                valheimPlusConfiguration.itemStackMultiplier = itemStackMultiplier;
            }
            if (float.TryParse(data["Items"]["droppedItemOnGroundDurationInSeconds"], NumberStyles.Any, ci, out float droppedItemOnGroundDurationInSeconds))
            {
                valheimPlusConfiguration.droppedItemOnGroundDurationInSeconds = droppedItemOnGroundDurationInSeconds;
            }
            #endregion Items

            #region Kiln
            if (bool.TryParse(data["Kiln"]["enabled"], out bool kilnSettingsEnabled))
            {
                valheimPlusConfiguration.kilnSettingsEnabled = kilnSettingsEnabled;
            }
            if (int.TryParse(data["Kiln"]["maximumWood"], out int maximumWood))
            {
                valheimPlusConfiguration.maximumWood = maximumWood;
            }
            if (bool.TryParse(data["Kiln"]["dontProcessFineWood"], out bool dontProcessFineWoodKiln))
            {
                valheimPlusConfiguration.dontProcessFineWoodKiln = dontProcessFineWoodKiln;
            }
            if (bool.TryParse(data["Kiln"]["dontProcessRoundLog"], out bool dontProcessRoundLogKiln))
            {
                valheimPlusConfiguration.dontProcessRoundLogKiln = dontProcessRoundLogKiln;
            }
            if (int.TryParse(data["Kiln"]["productionSpeed"], out int kilnProductionSpeed))
            {
                valheimPlusConfiguration.kilnProductionSpeed = kilnProductionSpeed;
            }
            if (bool.TryParse(data["Kiln"]["autoDeposit"], out bool autoDepositKiln))
            {
                valheimPlusConfiguration.autoDepositKiln = autoDepositKiln;
            }
            if (bool.TryParse(data["Kiln"]["autoFuel"], out bool autoFuelKiln))
            {
                valheimPlusConfiguration.autoFuelKiln = autoFuelKiln;
            }
            if (int.TryParse(data["Kiln"]["stopAutoFuelThreshold"], out int stopAutoFuelThresholdKiln))
            {
                valheimPlusConfiguration.stopAutoFuelThresholdKiln = stopAutoFuelThresholdKiln;
            }
            if (bool.TryParse(data["Kiln"]["ignorePrivateArea"], out bool ignorePrivateAreaCheckKiln))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckKiln = ignorePrivateAreaCheckKiln;
            }
            if (float.TryParse(data["Kiln"]["autoRange"], NumberStyles.Any, ci, out float autoDepositRangeKiln))
            {
                valheimPlusConfiguration.autoDepositRangeKiln = autoDepositRangeKiln;
            }
            #endregion Kiln

            #region Map
            if (bool.TryParse(data["Map"]["enabled"], out bool mapSettingsEnabled))
            {
                valheimPlusConfiguration.mapSettingsEnabled = mapSettingsEnabled;
            }
            if (bool.TryParse(data["Map"]["shareMapProgression"], out bool shareMapProgression))
            {
                valheimPlusConfiguration.shareMapProgression = shareMapProgression;
            }
            if (int.TryParse(data["Map"]["exploreRadius"], out int exploreRadius))
            {
                valheimPlusConfiguration.exploreRadius = exploreRadius;
            }
            if (bool.TryParse(data["Map"]["preventPlayerFromTurningOffPublicPosition"], out bool preventPlayerFromTurningOffPublicPosition))
            {
                valheimPlusConfiguration.preventPlayerFromTurningOffPublicPosition = preventPlayerFromTurningOffPublicPosition;
            }
            #endregion Map

            #region Player
            if (bool.TryParse(data["Player"]["enabled"], out bool playerSettingsEnabled))
            {
                valheimPlusConfiguration.playerSettingsEnabled = playerSettingsEnabled;
            }
            if (int.TryParse(data["Player"]["baseMaximumWeight"], out int baseMaximumWeight))
            {
                valheimPlusConfiguration.baseMaximumWeight = baseMaximumWeight;
            }
            if (int.TryParse(data["Player"]["baseMegingjordBuff"], out int baseMegingjordBuff))
            {
                valheimPlusConfiguration.baseMegingjordBuff = baseMegingjordBuff;
            }
            if (int.TryParse(data["Player"]["baseAutoPickUpRange"], out int baseAutoPickUpRange))
            {
                valheimPlusConfiguration.baseAutoPickUpRange = baseAutoPickUpRange;
            }
            if (bool.TryParse(data["Player"]["disableCameraShake"], out bool disableCameraShake))
            {
                valheimPlusConfiguration.disableCameraShake = disableCameraShake;
            }
            if (float.TryParse(data["Player"]["baseUnarmedDamage"], NumberStyles.Any, ci, out float baseUnarmedDamage))
            {
                valheimPlusConfiguration.baseUnarmedDamage = baseUnarmedDamage;
            }
            if (bool.TryParse(data["Player"]["cropNotifier"], out bool cropNotifier))
            {
                valheimPlusConfiguration.cropNotifier = cropNotifier;
            }
            if (float.TryParse(data["Player"]["restSecondsPerComfortLevel"], NumberStyles.Any, ci, out float restSecondsPerComfortLevel))
            {
                valheimPlusConfiguration.restSecondsPerComfortLevel = restSecondsPerComfortLevel;
            }
            if (float.TryParse(data["Player"]["deathPenaltyMultiplier"], NumberStyles.Any, ci, out float deathPenaltyMultiplier))
            {
                valheimPlusConfiguration.deathPenaltyMultiplier = deathPenaltyMultiplier;
            }
            if (bool.TryParse(data["Player"]["autoRepair"], out bool autoRepair))
            {
                valheimPlusConfiguration.autoRepair = autoRepair;
            }
            if (float.TryParse(data["Player"]["guardianBuffDuration"], NumberStyles.Any, ci, out float guardianBuffDuration))
            {
                valheimPlusConfiguration.guardianBuffDuration = guardianBuffDuration;
            }
            if (float.TryParse(data["Player"]["guardianBuffCooldown"], NumberStyles.Any, ci, out float guardianBuffCooldown))
            {
                valheimPlusConfiguration.guardianBuffCooldown = guardianBuffCooldown;
            }
            if (bool.TryParse(data["Player"]["disableGuardianBuffAnimation"], out bool disableGuardianBuffAnimation))
            {
                valheimPlusConfiguration.disableGuardianBuffAnimation = disableGuardianBuffAnimation;
            }
            if (bool.TryParse(data["Player"]["autoEquipShield"], out bool autoEquipShield))
            {
                valheimPlusConfiguration.autoEquipShield = autoEquipShield;
            }
            if (bool.TryParse(data["Player"]["queueWeaponChanges"], out bool queueWeaponChanges))
            {
                valheimPlusConfiguration.queueWeaponChanges = queueWeaponChanges;
            }
            if (bool.TryParse(data["Player"]["skipIntro"], out bool skipIntro))
            {
                valheimPlusConfiguration.skipIntro = skipIntro;
            }
            if (bool.TryParse(data["Player"]["iHaveArrivedOnSpawn"], out bool iHaveArrivedOnSpawn))
            {
                valheimPlusConfiguration.iHaveArrivedOnSpawn = iHaveArrivedOnSpawn;
            }
            if (bool.TryParse(data["Player"]["reequipItemsAfterSwimming"], out bool reequipItemsAfterSwimming))
            {
                valheimPlusConfiguration.reequipItemsAfterSwimming = reequipItemsAfterSwimming;
            }
            #endregion Player

            #region Server
            if (bool.TryParse(data["Server"]["enabled"], out bool serverSettingsEnabled))
            {
                valheimPlusConfiguration.serverSettingsEnabled = serverSettingsEnabled;
            }
            if (int.TryParse(data["Server"]["maxPlayers"], out int maxPlayers))
            {
                valheimPlusConfiguration.maxPlayers = maxPlayers;
            }
            if (bool.TryParse(data["Server"]["disableServerPassword"], out bool disableServerPassword))
            {
                valheimPlusConfiguration.disableServerPassword = disableServerPassword;
            }
            if (bool.TryParse(data["Server"]["enforceMod"], out bool enforceMod))
            {
                valheimPlusConfiguration.enforceMod = enforceMod;
            }
            if (bool.TryParse(data["Server"]["serverSyncHotkeys"], out bool serverSyncHotkeys))
            {
                valheimPlusConfiguration.serverSyncHotkeys = serverSyncHotkeys;
            }
            //if (int.TryParse(data["Server"]["dataRate"], out int dataRate))
            //{
            //    valheimPlusConfiguration.dataRate = dataRate;
            //}
            #endregion Server

            #region Shields
            if (bool.TryParse(data["Shields"]["enabled"], out bool shieldsSettingsEnabled))
            {
                valheimPlusConfiguration.shieldsSettingsEnabled = shieldsSettingsEnabled;
            }
            if (int.TryParse(data["Shields"]["blockRating"], out int blockRating))
            {
                valheimPlusConfiguration.blockRating = blockRating;
            }
            #endregion Shields

            #region Smelter
            if (bool.TryParse(data["Smelter"]["enabled"], out bool smelterSettingsEnabled))
            {
                valheimPlusConfiguration.smelterSettingsEnabled = smelterSettingsEnabled;
            }
            if (int.TryParse(data["Smelter"]["maximumOre"], out int smelterMaximumOre))
            {
                valheimPlusConfiguration.smelterMaximumOre = smelterMaximumOre;
            }
            if (int.TryParse(data["Smelter"]["maximumCoal"], out int smelterMaximumCoal))
            {
                valheimPlusConfiguration.smelterMaximumCoal = smelterMaximumCoal;
            }
            if (int.TryParse(data["Smelter"]["coalUsedPerProduct"], out int smelterCoalUsedPerProduct))
            {
                valheimPlusConfiguration.smelterCoalUsedPerProduct = smelterCoalUsedPerProduct;
            }
            if (int.TryParse(data["Smelter"]["productionSpeed"], out int smelterProductionSpeed))
            {
                valheimPlusConfiguration.smelterProductionSpeed = smelterProductionSpeed;
            }
            if (float.TryParse(data["Smelter"]["autoRange"], NumberStyles.Any, ci, out float smelterAutoDepositRange))
            {
                valheimPlusConfiguration.smelterAutoDepositRange = smelterAutoDepositRange;
            }
            if (bool.TryParse(data["Smelter"]["autoDeposit"], out bool smelterAutoDeposit))
            {
                valheimPlusConfiguration.smelterAutoDeposit = smelterAutoDeposit;
            }
            if (bool.TryParse(data["Smelter"]["autoFuel"], out bool autoFuelSmelter))
            {
                valheimPlusConfiguration.autoFuelSmelter = autoFuelSmelter;
            }
            if (bool.TryParse(data["Smelter"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckSmelter))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckSmelter = ignorePrivateAreaCheckSmelter;
            }
            #endregion Smelter

            #region SpinningWheel
            if (bool.TryParse(data["SpinningWheel"]["enabled"], out bool spinningWheelSettingsEnabled))
            {
                valheimPlusConfiguration.spinningWheelSettingsEnabled = spinningWheelSettingsEnabled;
            }
            if (int.TryParse(data["SpinningWheel"]["maximumFlax"], out int maximumFlaxSpinningWheel))
            {
                valheimPlusConfiguration.maximumFlaxSpinningWheel = maximumFlaxSpinningWheel;
            }
            if (float.TryParse(data["SpinningWheel"]["productionSpeed"], NumberStyles.Any, ci, out float productionSpeedSpinningWheel))
            {
                valheimPlusConfiguration.productionSpeedSpinningWheel = productionSpeedSpinningWheel;
            }
            if (bool.TryParse(data["SpinningWheel"]["autoDeposit"], out bool autoDepositSpinningWheel))
            {
                valheimPlusConfiguration.autoDepositSpinningWheel = autoDepositSpinningWheel;
            }
            if (bool.TryParse(data["SpinningWheel"]["autoFuel"], out bool autoFuelSpinningWheel))
            {
                valheimPlusConfiguration.autoFuelSpinningWheel = autoFuelSpinningWheel;
            }
            if (bool.TryParse(data["SpinningWheel"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckSpinningWheel))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckSpinningWheel = ignorePrivateAreaCheckSpinningWheel;
            }
            if (float.TryParse(data["SpinningWheel"]["autoRange"], NumberStyles.Any, ci, out float autoRangeSpinningWheel))
            {
                valheimPlusConfiguration.autoRangeSpinningWheel = autoRangeSpinningWheel;
            }
            #endregion SpinningWheel

            #region Stamina
            if (bool.TryParse(data["Stamina"]["enabled"], out bool staminaSettingsEnabled))
            {
                valheimPlusConfiguration.staminaSettingsEnabled = staminaSettingsEnabled;
            }
            if (int.TryParse(data["Stamina"]["dodgeStaminaUsage"], out int dodgeStaminaUsage))
            {
                valheimPlusConfiguration.dodgeStaminaUsage = dodgeStaminaUsage;
            }
            if (int.TryParse(data["Stamina"]["encumberedStaminaDrain"], out int encumberedStaminaDrain))
            {
                valheimPlusConfiguration.encumberedStaminaDrain = encumberedStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["jumpStaminaDrain"], out int jumpStaminaDrain))
            {
                valheimPlusConfiguration.jumpStaminaDrain = jumpStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["runStaminaDrain"], out int runStaminaDrain))
            {
                valheimPlusConfiguration.runStaminaDrain = runStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["sneakStaminaDrain"], out int sneakStaminaDrain))
            {
                valheimPlusConfiguration.sneakStaminaDrain = sneakStaminaDrain;
            }
            if (int.TryParse(data["Stamina"]["staminaRegen"], out int staminaRegen))
            {
                valheimPlusConfiguration.staminaRegen = staminaRegen;
            }
            if (float.TryParse(data["Stamina"]["staminaRegenDelay"], NumberStyles.Any, ci, out float staminaRegenDelay))
            {
                valheimPlusConfiguration.staminaRegenDelay = staminaRegenDelay;
            }
            if (int.TryParse(data["Stamina"]["swimStaminaDrain"], out int swimStaminaDrain))
            {
                valheimPlusConfiguration.swimStaminaDrain = swimStaminaDrain;
            }
            #endregion Stamina

            #region StaminaUsage
            if (bool.TryParse(data["StaminaUsage"]["enabled"], out bool staminaUsageSettingsEnabled))
            {
                valheimPlusConfiguration.staminaUsageSettingsEnabled = staminaUsageSettingsEnabled;
            }
            if (int.TryParse(data["StaminaUsage"]["axes"], out int axes))
            {
                valheimPlusConfiguration.axes = axes;
            }
            if (int.TryParse(data["StaminaUsage"]["bows"], out int bows))
            {
                valheimPlusConfiguration.bows = bows;
            }
            if (int.TryParse(data["StaminaUsage"]["clubs"], out int clubs))
            {
                valheimPlusConfiguration.clubs = clubs;
            }
            if (int.TryParse(data["StaminaUsage"]["knives"], out int knives))
            {
                valheimPlusConfiguration.knives = knives;
            }
            if (int.TryParse(data["StaminaUsage"]["pickaxes"], out int pickaxes))
            {
                valheimPlusConfiguration.pickaxes = pickaxes;
            }
            if (int.TryParse(data["StaminaUsage"]["polearms"], out int polearms))
            {
                valheimPlusConfiguration.polearms = polearms;
            }
            if (int.TryParse(data["StaminaUsage"]["spears"], out int spears))
            {
                valheimPlusConfiguration.spears = spears;
            }
            if (int.TryParse(data["StaminaUsage"]["swords"], out int swords))
            {
                valheimPlusConfiguration.swords = swords;
            }
            if (int.TryParse(data["StaminaUsage"]["unarmed"], out int unarmed))
            {
                valheimPlusConfiguration.unarmed = unarmed;
            }
            if (int.TryParse(data["StaminaUsage"]["hammer"], out int hammer))
            {
                valheimPlusConfiguration.hammer = hammer;
            }
            if (int.TryParse(data["StaminaUsage"]["hoe"], out int hoe))
            {
                valheimPlusConfiguration.hoe = hoe;
            }
            if (int.TryParse(data["StaminaUsage"]["cultivator"], out int cultivator))
            {
                valheimPlusConfiguration.cultivator = cultivator;
            }
            #endregion StaminaUsage

            #region StructuralIntegrity
            if (bool.TryParse(data["StructuralIntegrity"]["enabled"], out bool structuralIntegritySettingsEnabled))
            {
                valheimPlusConfiguration.structuralIntegritySettingsEnabled = structuralIntegritySettingsEnabled;
            }
            if (bool.TryParse(data["StructuralIntegrity"]["disableStructuralIntegrity"], out bool disableStructuralIntegrity))
            {
                valheimPlusConfiguration.disableStructuralIntegrity = disableStructuralIntegrity;
            }
            if (int.TryParse(data["StructuralIntegrity"]["wood"], out int wood))
            {
                valheimPlusConfiguration.wood = wood;
            }
            if (int.TryParse(data["StructuralIntegrity"]["stone"], out int stone))
            {
                valheimPlusConfiguration.stone = stone;
            }
            if (int.TryParse(data["StructuralIntegrity"]["iron"], out int iron))
            {
                valheimPlusConfiguration.iron = iron;
            }
            if (int.TryParse(data["StructuralIntegrity"]["hardWood"], out int hardWood))
            {
                valheimPlusConfiguration.hardWood = hardWood;
            }
            if (bool.TryParse(data["StructuralIntegrity"]["disableDamageToPlayerStructures"], out bool disableDamageToPlayerStructures))
            {
                valheimPlusConfiguration.disableDamageToPlayerStructures = disableDamageToPlayerStructures;
            }
            if (bool.TryParse(data["StructuralIntegrity"]["disableDamageToPlayerBoats"], out bool disableDamageToPlayerBoats))
            {
                valheimPlusConfiguration.disableDamageToPlayerBoats = disableDamageToPlayerBoats;
            }
            if (bool.TryParse(data["StructuralIntegrity"]["disableWaterDamageToPlayerBoats"], out bool disableWaterDamageToPlayerBoats))
            {
                valheimPlusConfiguration.disableWaterDamageToPlayerBoats = disableWaterDamageToPlayerBoats;
            }
            #endregion StructuralIntegrity

            #region Time
            //if (bool.TryParse(data["Time"]["enabled"], out bool timeSettingsEnabled))
            //{
            //    valheimPlusConfiguration.timeSettingsEnabled = timeSettingsEnabled;
            //}
            //if (int.TryParse(data["Time"]["totalDayTimeInSeconds"], out int totalDayTimeInSeconds))
            //{
            //    valheimPlusConfiguration.totalDayTimeInSeconds = totalDayTimeInSeconds;
            //}
            //if (int.TryParse(data["Time"]["nightTimeSpeedMultiplier"], out int nightTimeSpeedMultiplier))
            //{
            //    valheimPlusConfiguration.nightTimeSpeedMultiplier = nightTimeSpeedMultiplier;
            //}
            #endregion Time

            #region ValheimPlus
            if (bool.TryParse(data["ValheimPlus"]["enabled"], out bool valheimPlusConfigurationEnabled))
            {
                valheimPlusConfiguration.valheimPlusConfigurationEnabled = valheimPlusConfigurationEnabled;
            }
            if (bool.TryParse(data["ValheimPlus"]["mainMenuLogo"], out bool mainMenuLogo))
            {
                valheimPlusConfiguration.mainMenuLogo = mainMenuLogo;
            }
            if (bool.TryParse(data["ValheimPlus"]["serverBrowserAdvertisement"], out bool serverBrowserAdvertisement))
            {
                valheimPlusConfiguration.serverBrowserAdvertisement = serverBrowserAdvertisement;
            }
            #endregion ValheimPlus

            #region Wagon
            if (bool.TryParse(data["Wagon"]["enabled"], out bool wagonSettingsEnabled))
            {
                valheimPlusConfiguration.wagonSettingsEnabled = wagonSettingsEnabled;
            }
            if (Int32.TryParse(data["Wagon"]["wagonBaseMass"], out int wagonBaseMass))
            {
                valheimPlusConfiguration.wagonBaseMass = wagonBaseMass;
            }
            if (Int32.TryParse(data["Wagon"]["wagonExtraMassFromItems"], out int wagonExtraMassFromItems))
            {
                valheimPlusConfiguration.wagonExtraMassFromItems = wagonExtraMassFromItems;
            }
            #endregion Wagon

            #region Ward
            if (bool.TryParse(data["Ward"]["enabled"], out bool wardSettingsEnabled))
            {
                valheimPlusConfiguration.wardSettingsEnabled = wardSettingsEnabled;
            }
            if (int.TryParse(data["Ward"]["wardRange"], out int wardRange))
            {
                valheimPlusConfiguration.wardRange = wardRange;
            }
            #endregion Ward

            #region Windmill
            if (bool.TryParse(data["Windmill"]["enabled"], out bool windmillConfigurationEnabled))
            {
                valheimPlusConfiguration.windmillConfigurationEnabled = windmillConfigurationEnabled;
            }
            if (int.TryParse(data["Windmill"]["maximumBarley"], out int maximumBarleyWindmill))
            {
                valheimPlusConfiguration.maximumBarleyWindmill = maximumBarleyWindmill;
            }
            if (float.TryParse(data["Windmill"]["productionSpeed"], NumberStyles.Any, ci, out float productionSpeedWindmill))
            {
                valheimPlusConfiguration.productionSpeedWindmill = productionSpeedWindmill;
            }
            if (float.TryParse(data["Windmill"]["autoRange"], NumberStyles.Any, ci, out float autoRangeWindmill))
            {
                valheimPlusConfiguration.autoRangeWindmill = autoRangeWindmill;
            }
            if (bool.TryParse(data["Windmill"]["ignoreWindIntensity"], out bool ignoreWindIntensityWindmill))
            {
                valheimPlusConfiguration.ignoreWindIntensityWindmill = ignoreWindIntensityWindmill;
            }
            if (bool.TryParse(data["Windmill"]["autoDeposit"], out bool autoDepositWindmill))
            {
                valheimPlusConfiguration.autoDepositWindmill = autoDepositWindmill;
            }
            if (bool.TryParse(data["Windmill"]["autoFuel"], out bool autoFuelWindmill))
            {
                valheimPlusConfiguration.autoFuelWindmill = autoFuelWindmill;
            }
            if (bool.TryParse(data["Windmill"]["ignorePrivateAreaCheck"], out bool ignorePrivateAreaCheckWindmill))
            {
                valheimPlusConfiguration.ignorePrivateAreaCheckWindmill = ignorePrivateAreaCheckWindmill;
            }
            #endregion Windmill

            #region Workbench
            if (bool.TryParse(data["Workbench"]["enabled"], out bool workbenchSettingsEnabled))
            {
                valheimPlusConfiguration.workbenchSettingsEnabled = workbenchSettingsEnabled;
            }
            if (int.TryParse(data["Workbench"]["workbenchRange"], out int workbenchRange))
            {
                valheimPlusConfiguration.workbenchRange = workbenchRange;
            }
            if (int.TryParse(data["Workbench"]["workbenchAttachmentRange"], out int workbenchAttachmentRange))
            {
                valheimPlusConfiguration.workbenchAttachmentRange = workbenchAttachmentRange;
            }
            if (bool.TryParse(data["Workbench"]["disableRoofCheck"], out bool disableRoofCheck))
            {
                valheimPlusConfiguration.disableRoofCheck = disableRoofCheck;
            }
            #endregion Workbench

            return valheimPlusConfiguration;
        }

        public static bool WriteConfigFile(ValheimPlusConf valheimPlusConfiguration, bool manageClient)
        {
            Settings settings = SettingsDAL.GetSettings();
            IniData data;

            var parser = new FileIniDataParser();
            IniParserConfiguration iniParserConfiguration = parser.Parser.Configuration;
            iniParserConfiguration.AllowCreateSectionsOnFly = true;

            // Reading the current configuration file
            if (manageClient)
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ClientInstallationPath));
            }
            else
            {
                data = parser.ReadFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ServerInstallationPath));
            }

            #region Advanced building mode
            data["AdvancedBuildingMode"]["enabled"] = valheimPlusConfiguration.advancedBuildingModeEnabled.ToString().ToLower();
            data["AdvancedBuildingMode"]["enterAdvancedBuildingMode"] = valheimPlusConfiguration.enterAdvancedBuildingMode.ToString();
            data["AdvancedBuildingMode"]["exitAdvancedBuildingMode"] = valheimPlusConfiguration.exitAdvancedBuildingMode.ToString();
            data["AdvancedBuildingMode"]["copyObjectRotation"] = valheimPlusConfiguration.copyObjectRotation.ToString();
            data["AdvancedBuildingMode"]["pasteObjectRotation"] = valheimPlusConfiguration.pasteObjectRotation.ToString();
            data["AdvancedBuildingMode"]["increaseScrollSpeed"] = valheimPlusConfiguration.increaseScrollSpeed.ToString();
            data["AdvancedBuildingMode"]["decreaseScrollSpeed"] = valheimPlusConfiguration.decreaseScrollSpeed.ToString();
            #endregion Advanced building mode

            #region Advanced editing mode
            data["AdvancedEditingMode"]["enabled"] = valheimPlusConfiguration.advancedEditingModeEnabled.ToString().ToLower();
            data["AdvancedEditingMode"]["enterAdvancedEditingMode"] = valheimPlusConfiguration.enterAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["resetAdvancedEditingMode"] = valheimPlusConfiguration.resetAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["abortAndExitAdvancedEditingMode"] = valheimPlusConfiguration.abortAndExitAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["confirmPlacementOfAdvancedEditingMode"] = valheimPlusConfiguration.confirmPlacementOfAdvancedEditingMode.ToString();
            data["AdvancedEditingMode"]["copyObjectRotation"] = valheimPlusConfiguration.copyObjectRotationAEM.ToString();
            data["AdvancedEditingMode"]["pasteObjectRotation"] = valheimPlusConfiguration.pasteObjectRotationAEM.ToString();
            data["AdvancedEditingMode"]["increaseScrollSpeed"] = valheimPlusConfiguration.increaseScrollSpeedAEM.ToString();
            data["AdvancedEditingMode"]["decreaseScrollSpeed"] = valheimPlusConfiguration.decreaseScrollSpeedAEM.ToString();
            #endregion Advanced editing mode

            #region Armor
            data["Armor"]["enabled"] = valheimPlusConfiguration.armorSettingsEnabled.ToString().ToLower();
            data["Armor"]["helmets"] = valheimPlusConfiguration.helmetsArmor.ToString();
            data["Armor"]["chests"] = valheimPlusConfiguration.chestsArmor.ToString();
            data["Armor"]["legs"] = valheimPlusConfiguration.legsArmor.ToString();
            data["Armor"]["capes"] = valheimPlusConfiguration.capesArmor.ToString();
            #endregion Armor

            #region Beehive
            data["Beehive"]["enabled"] = valheimPlusConfiguration.beehiveSettingsEnabled.ToString().ToLower();
            data["Beehive"]["honeyProductionSpeed"] = valheimPlusConfiguration.honeyProductionSpeed.ToString();
            data["Beehive"]["maximumHoneyPerBeehive"] = valheimPlusConfiguration.maximumHoneyPerBeehive.ToString();
            data["Beehive"]["autoRange"] = valheimPlusConfiguration.autoDepositHoneyRange.ToString();
            data["Beehive"]["autoDepositRange"] = valheimPlusConfiguration.autoDepositHoney.ToString().ToLower();
            data["Beehive"]["showDuration"] = valheimPlusConfiguration.showDurationBeehive.ToString().ToLower();
            #endregion Beehive

            #region Bed
            data["Bed"]["enabled"] = valheimPlusConfiguration.beehiveSettingsEnabled.ToString().ToLower();
            data["Bed"]["sleepWithoutSpawn"] = valheimPlusConfiguration.sleepWithoutSpawn.ToString().ToLower();
            data["Bed"]["unclaimedBedsOnly"] = valheimPlusConfiguration.unclaimedBedsOnly.ToString().ToLower();
            #endregion Bed

            #region Building
            data["Building"]["enabled"] = valheimPlusConfiguration.buildingSettingsEnabled.ToString().ToLower();
            data["Building"]["maximumPlacementDistance"] = valheimPlusConfiguration.maximumPlacementDistance.ToString().ToLower();
            data["Building"]["noWeatherDamage"] = valheimPlusConfiguration.noWeatherDamage.ToString();
            data["Building"]["noInvalidPlacementRestriction"] = valheimPlusConfiguration.noInvalidPlacementRestriction.ToString();
            data["Building"]["noMysticalForcesPreventPlacementRestriction"] = valheimPlusConfiguration.noMysticalForcesPreventPlacementRestriction.ToString();
            data["Building"]["pieceComfortRadius"] = valheimPlusConfiguration.pieceComfortRadius.ToString();
            data["Building"]["alwaysDropResources"] = valheimPlusConfiguration.alwaysDropResources.ToString().ToLower();
            data["Building"]["alwaysDropExcludedResources"] = valheimPlusConfiguration.alwaysDropExcludedResources.ToString().ToLower();
            data["Building"]["enableAreaRepair"] = valheimPlusConfiguration.enableAreaRepair.ToString().ToLower();
            data["Building"]["areaRepairRadius"] = valheimPlusConfiguration.areaRepairRadius.ToString();
            #endregion Building

            #region Camera
            data["Camera"]["enabled"] = valheimPlusConfiguration.cameraSettingsEnabled.ToString().ToLower();
            data["Camera"]["cameraMaximumZoomDistance"] = valheimPlusConfiguration.cameraMaximumZoomDistance.ToString();
            data["Camera"]["cameraBoatMaximumZoomDistance"] = valheimPlusConfiguration.cameraBoatMaximumZoomDistance.ToString();
            data["Camera"]["cameraFOV"] = valheimPlusConfiguration.cameraFOV.ToString();
            #endregion Camera

            #region CraftFromChest
            data["CraftFromChest"]["enabled"] = valheimPlusConfiguration.craftFromChestSettingsEnabled.ToString().ToLower();
            data["CraftFromChest"]["range"] = valheimPlusConfiguration.rangeCraftFromChest.ToString();
            data["CraftFromChest"]["lookupInterval"] = valheimPlusConfiguration.lookupIntervalCraftFromChest.ToString();
            data["CraftFromChest"]["disableCookingStation"] = valheimPlusConfiguration.disableCookingStationCraftFromChest.ToString().ToLower();
            data["CraftFromChest"]["checkFromWorkbench"] = valheimPlusConfiguration.checkFromWorkbenchCraftFromChest.ToString().ToLower();
            data["CraftFromChest"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckCraftFromChest.ToString().ToLower();
            #endregion CraftFromChest

            #region Durability
            data["Durability"]["enabled"] = valheimPlusConfiguration.durabilitySettingsEnabled.ToString().ToLower();
            data["Durability"]["axes"] = valheimPlusConfiguration.axesDurability.ToString();
            data["Durability"]["pickaxes"] = valheimPlusConfiguration.pickaxesDurability.ToString();
            data["Durability"]["hammer"] = valheimPlusConfiguration.hammerDurability.ToString();
            data["Durability"]["cultivator"] = valheimPlusConfiguration.cultivatorDurability.ToString();
            data["Durability"]["hoe"] = valheimPlusConfiguration.hoeDurability.ToString();
            data["Durability"]["weapons"] = valheimPlusConfiguration.weaponsDurability.ToString();
            data["Durability"]["armor"] = valheimPlusConfiguration.armorDurability.ToString();
            data["Durability"]["bows"] = valheimPlusConfiguration.bowsDurability.ToString();
            data["Durability"]["shields"] = valheimPlusConfiguration.shieldsDurability.ToString();
            data["Durability"]["torch"] = valheimPlusConfiguration.torchDurability.ToString();
            #endregion Durability

            #region Experience
            data["Experience"]["enabled"] = valheimPlusConfiguration.experienceSettingsEnabled.ToString().ToLower();
            data["Experience"]["swords"] = valheimPlusConfiguration.experienceSwords.ToString();
            data["Experience"]["knives"] = valheimPlusConfiguration.experienceKnives.ToString();
            data["Experience"]["clubs"] = valheimPlusConfiguration.experienceClubs.ToString();
            data["Experience"]["polearms"] = valheimPlusConfiguration.experiencePolearms.ToString();
            data["Experience"]["spears"] = valheimPlusConfiguration.experienceSpears.ToString();
            data["Experience"]["blocking"] = valheimPlusConfiguration.experienceBlocking.ToString();
            data["Experience"]["axes"] = valheimPlusConfiguration.experienceAxes.ToString();
            data["Experience"]["bows"] = valheimPlusConfiguration.experienceBows.ToString();
            data["Experience"]["fireMagic"] = valheimPlusConfiguration.experienceFireMagic.ToString();
            data["Experience"]["frostMagic"] = valheimPlusConfiguration.experienceFrostMagic.ToString();
            data["Experience"]["unarmed"] = valheimPlusConfiguration.experienceUnarmed.ToString();
            data["Experience"]["pickaxes"] = valheimPlusConfiguration.experiencePickaxes.ToString();
            data["Experience"]["woodCutting"] = valheimPlusConfiguration.experienceWoodCutting.ToString();
            data["Experience"]["jump"] = valheimPlusConfiguration.experienceJump.ToString();
            data["Experience"]["sneak"] = valheimPlusConfiguration.experienceSneak.ToString();
            data["Experience"]["run"] = valheimPlusConfiguration.experienceRun.ToString();
            data["Experience"]["swim"] = valheimPlusConfiguration.experienceSwim.ToString();
            data["Experience"]["hammer"] = valheimPlusConfiguration.experienceHammer.ToString();
            data["Experience"]["hoe"] = valheimPlusConfiguration.experienceHoe.ToString();
            #endregion Experience

            #region Fermenter
            data["Fermenter"]["enabled"] = valheimPlusConfiguration.fermenterSettingsEnabled.ToString().ToLower();
            data["Fermenter"]["fermenterDuration"] = valheimPlusConfiguration.fermenterDuration.ToString();
            data["Fermenter"]["fermenterItemsProduced"] = valheimPlusConfiguration.fermenterItemsProduced.ToString();
            data["Fermenter"]["showDuration"] = valheimPlusConfiguration.showFermenterDuration.ToString().ToLower();
            data["Fermenter"]["autoDeposit"] = valheimPlusConfiguration.autoDepositFermenter.ToString().ToLower();
            data["Fermenter"]["autoFuel"] = valheimPlusConfiguration.autoFuelFermenter.ToString().ToLower();
            data["Fermenter"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckFermenter.ToString().ToLower();
            data["Fermenter"]["autoRange"] = valheimPlusConfiguration.autoRangeFermenter.ToString();
            #endregion Fermenter

            #region FireSource
            data["FireSource"]["enabled"] = valheimPlusConfiguration.fireSourceSettingsEnabled.ToString().ToLower();
            data["FireSource"]["torches"] = valheimPlusConfiguration.torchesFireSource.ToString().ToLower();
            data["FireSource"]["fires"] = valheimPlusConfiguration.firesFireSource.ToString().ToLower();
            data["FireSource"]["autoFuel"] = valheimPlusConfiguration.autoFuelFireSource.ToString().ToLower();
            data["FireSource"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckFireSource.ToString().ToLower();
            data["FireSource"]["autoRange"] = valheimPlusConfiguration.autoRangeFireSource.ToString();
            #endregion FireSource

            #region FirstPerson
            data["FirstPerson"]["enabled"] = valheimPlusConfiguration.firstPersonSettingsEnabled.ToString().ToLower();
            data["FirstPerson"]["hotkey"] = valheimPlusConfiguration.hotkey.ToString();
            data["FirstPerson"]["defaultFOV"] = valheimPlusConfiguration.defaultFOV.ToString();
            data["FirstPerson"]["raiseFOVHotkey"] = valheimPlusConfiguration.raiseFOVHotkey.ToString();
            data["FirstPerson"]["lowerFOVHotkey"] = valheimPlusConfiguration.lowerFOVHotkey.ToString();
            #endregion FirstPerson

            #region Food
            data["Food"]["enabled"] = valheimPlusConfiguration.foodSettingsEnabled.ToString().ToLower();
            data["Food"]["foodDurationMultiplier"] = valheimPlusConfiguration.foodDurationMultiplier.ToString();
            data["Food"]["disableFoodDegradation"] = valheimPlusConfiguration.disableFoodDegradation.ToString().ToLower();
            #endregion Food

            #region FreePlacementRotation
            data["FreePlacementRotation"]["enabled"] = valheimPlusConfiguration.freePlacementRotationSettingsEnabled.ToString().ToLower();
            data["FreePlacementRotation"]["rotateY"] = valheimPlusConfiguration.rotateY.ToString();
            data["FreePlacementRotation"]["rotateX"] = valheimPlusConfiguration.rotateX.ToString();
            data["FreePlacementRotation"]["rotateZ"] = valheimPlusConfiguration.rotateZ.ToString();
            data["FreePlacementRotation"]["copyRotationParallel"] = valheimPlusConfiguration.copyRotationParallel.ToString();
            data["FreePlacementRotation"]["copyRotationPerpendicular"] = valheimPlusConfiguration.copyRotationPerpendicular.ToString();
            #endregion FreePlacementRotation

            #region Furnace
            data["Furnace"]["enabled"] = valheimPlusConfiguration.furnaceSettingsEnabled.ToString().ToLower();
            data["Furnace"]["maximumOre"] = valheimPlusConfiguration.maximumOre.ToString();
            data["Furnace"]["maximumCoal"] = valheimPlusConfiguration.maximumCoal.ToString();
            data["Furnace"]["coalUsedPerProduct"] = valheimPlusConfiguration.coalUsedPerProduct.ToString();
            data["Furnace"]["productionSpeed"] = valheimPlusConfiguration.furnaceProductionSpeed.ToString();
            data["Furnace"]["autoDeposit"] = valheimPlusConfiguration.autoDepositFurnace.ToString().ToLower();
            data["Furnace"]["autoRange"] = valheimPlusConfiguration.autoDepositRangeFurnace.ToString();
            data["Furnace"]["autoFuel"] = valheimPlusConfiguration.autoFuelFurnace.ToString().ToLower();
            data["Furnace"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckFurnace.ToString().ToLower();
            #endregion Furnace

            #region Game
            data["Game"]["enabled"] = valheimPlusConfiguration.gameSettingsEnabled.ToString().ToLower();
            data["Game"]["gameDifficultyDamageScale"] = valheimPlusConfiguration.gameDifficultyDamageScale.ToString();
            data["Game"]["gameDifficultyHealthScale"] = valheimPlusConfiguration.gameDifficultyHealthScale.ToString();
            data["Game"]["extraPlayerCountNearby"] = valheimPlusConfiguration.extraPlayerCountNearby.ToString();
            data["Game"]["setFixedPlayerCountTo"] = valheimPlusConfiguration.setFixedPlayerCountTo.ToString();
            data["Game"]["difficultyScaleRange"] = valheimPlusConfiguration.difficultyScaleRange.ToString();
            data["Game"]["disablePortals"] = valheimPlusConfiguration.disablePortals.ToString().ToLower();
            data["Game"]["forceConsole"] = valheimPlusConfiguration.forceConsole.ToString().ToLower();
            #endregion Game

            #region Gathering
            data["Gathering"]["enabled"] = valheimPlusConfiguration.gatheringSettingsEnabled.ToString().ToLower();
            data["Gathering"]["wood"] = valheimPlusConfiguration.woodGathering.ToString();
            data["Gathering"]["stone"] = valheimPlusConfiguration.stoneGathering.ToString();
            data["Gathering"]["fineWood"] = valheimPlusConfiguration.fineWoodGathering.ToString();
            data["Gathering"]["coreWood"] = valheimPlusConfiguration.coreWoodGathering.ToString();
            data["Gathering"]["elderBark"] = valheimPlusConfiguration.elderBarkGathering.ToString();
            data["Gathering"]["ironScrap"] = valheimPlusConfiguration.ironScrapGathering.ToString();
            data["Gathering"]["tinOre"] = valheimPlusConfiguration.tinOreGathering.ToString();
            data["Gathering"]["copperOre"] = valheimPlusConfiguration.copperOreGathering.ToString();
            data["Gathering"]["silverOre"] = valheimPlusConfiguration.silverOreGathering.ToString();
            data["Gathering"]["chitin"] = valheimPlusConfiguration.chitinGathering.ToString();
            data["Gathering"]["dropChance"] = valheimPlusConfiguration.dropChanceGathering.ToString();
            #endregion Gathering

            #region GridAlignment
            data["GridAlignment"]["enabled"] = valheimPlusConfiguration.gridAlignmentSettingsEnabled.ToString().ToLower();
            data["GridAlignment"]["align"] = valheimPlusConfiguration.align.ToString();
            data["GridAlignment"]["alignToggle"] = valheimPlusConfiguration.alignToggle.ToString();
            data["GridAlignment"]["changeDefaultAlignment"] = valheimPlusConfiguration.changeDefaultAlignment.ToString();
            #endregion GridAlignment

            #region Hotkeys
            data["Hotkeys"]["enabled"] = valheimPlusConfiguration.hotkeysSettingsEnabled.ToString().ToLower();
            data["Hotkeys"]["rollForwards"] = valheimPlusConfiguration.rollForwards.ToString();
            data["Hotkeys"]["rollBackwards"] = valheimPlusConfiguration.rollBackwards.ToString();
            #endregion Hotkeys

            #region HUD
            data["Hud"]["enabled"] = valheimPlusConfiguration.hudSettingsEnabled.ToString().ToLower();
            data["Hud"]["showRequiredItems"] = valheimPlusConfiguration.showRequiredItems.ToString().ToLower();
            data["Hud"]["experienceGainedNotifications"] = valheimPlusConfiguration.experienceGainedNotifications.ToString().ToLower();
            data["Hud"]["displayStaminaValue"] = valheimPlusConfiguration.displayStaminaValue.ToString().ToLower();
            data["Hud"]["removeDamageFlash"] = valheimPlusConfiguration.removeDamageFlash.ToString().ToLower();
            #endregion HUD

            #region Inventory
            data["Inventory"]["enabled"] = valheimPlusConfiguration.inventorySettingsEnabled.ToString().ToLower();
            data["Inventory"]["inventoryFillTopToBottom"] = valheimPlusConfiguration.inventoryFillTopToBottom.ToString().ToLower();
            data["Inventory"]["mergeWithExistingStacks"] = valheimPlusConfiguration.mergeWithExistingStacks.ToString().ToLower();
            data["Inventory"]["playerInventoryRows"] = valheimPlusConfiguration.playerInventoryRows.ToString();
            data["Inventory"]["personalChestRows"] = valheimPlusConfiguration.personalChestRows.ToString();
            data["Inventory"]["personalChestColumns"] = valheimPlusConfiguration.personalChestColumns.ToString();
            data["Inventory"]["woodChestColumns"] = valheimPlusConfiguration.woodChestColumns.ToString();
            data["Inventory"]["woodChestRows"] = valheimPlusConfiguration.woodChestRows.ToString();
            data["Inventory"]["ironChestColumns"] = valheimPlusConfiguration.ironChestColumns.ToString();
            data["Inventory"]["ironChestRows"] = valheimPlusConfiguration.ironChestRows.ToString();
            #endregion Inventory

            #region Items
            data["Items"]["enabled"] = valheimPlusConfiguration.itemsSettingsEnabled.ToString().ToLower();
            data["Items"]["noTeleportPrevention"] = valheimPlusConfiguration.noTeleportPrevention.ToString().ToLower();
            data["Items"]["baseItemWeightReduction"] = valheimPlusConfiguration.baseItemWeightReduction.ToString();
            data["Items"]["itemStackMultiplier"] = valheimPlusConfiguration.itemStackMultiplier.ToString();
            data["Items"]["droppedItemOnGroundDurationInSeconds"] = valheimPlusConfiguration.droppedItemOnGroundDurationInSeconds.ToString();
            #endregion Items

            #region Kiln
            data["Kiln"]["enabled"] = valheimPlusConfiguration.kilnSettingsEnabled.ToString().ToLower();
            data["Kiln"]["maximumWood"] = valheimPlusConfiguration.maximumWood.ToString();
            data["Kiln"]["dontProcessFineWood"] = valheimPlusConfiguration.dontProcessFineWoodKiln.ToString().ToLower();
            data["Kiln"]["dontProcessRoundLog"] = valheimPlusConfiguration.dontProcessRoundLogKiln.ToString().ToLower();
            data["Kiln"]["productionSpeed"] = valheimPlusConfiguration.kilnProductionSpeed.ToString();
            data["Kiln"]["autoDeposit"] = valheimPlusConfiguration.autoDepositKiln.ToString().ToLower();
            data["Kiln"]["autoFuel"] = valheimPlusConfiguration.autoFuelKiln.ToString().ToLower();
            data["Kiln"]["stopAutoFuelThreshold"] = valheimPlusConfiguration.stopAutoFuelThresholdKiln.ToString();
            data["Kiln"]["ignorePrivateArea"] = valheimPlusConfiguration.ignorePrivateAreaCheckKiln.ToString().ToLower();
            data["Kiln"]["autoRange"] = valheimPlusConfiguration.autoDepositRangeKiln.ToString();
            #endregion Kiln

            #region Map
            data["Map"]["enabled"] = valheimPlusConfiguration.mapSettingsEnabled.ToString().ToLower();
            data["Map"]["shareMapProgression"] = valheimPlusConfiguration.shareMapProgression.ToString().ToLower();
            data["Map"]["exploreRadius"] = valheimPlusConfiguration.exploreRadius.ToString();
            data["Map"]["preventPlayerFromTurningOffPublicPosition"] = valheimPlusConfiguration.preventPlayerFromTurningOffPublicPosition.ToString().ToLower();
            #endregion Map

            #region Player
            data["Player"]["enabled"] = valheimPlusConfiguration.playerSettingsEnabled.ToString().ToLower();
            data["Player"]["baseMaximumWeight"] = valheimPlusConfiguration.baseMaximumWeight.ToString();
            data["Player"]["baseMegingjordBuff"] = valheimPlusConfiguration.baseMegingjordBuff.ToString();
            data["Player"]["baseAutoPickUpRange"] = valheimPlusConfiguration.baseAutoPickUpRange.ToString();
            data["Player"]["disableCameraShake"] = valheimPlusConfiguration.disableCameraShake.ToString().ToLower();
            data["Player"]["baseUnarmedDamage"] = valheimPlusConfiguration.baseUnarmedDamage.ToString();
            data["Player"]["cropNotifier"] = valheimPlusConfiguration.cropNotifier.ToString().ToLower();
            data["Player"]["restSecondsPerComfortLevel"] = valheimPlusConfiguration.restSecondsPerComfortLevel.ToString();
            data["Player"]["deathPenaltyMultiplier"] = valheimPlusConfiguration.deathPenaltyMultiplier.ToString();
            data["Player"]["autoRepair"] = valheimPlusConfiguration.autoRepair.ToString().ToLower();
            data["Player"]["guardianBuffDuration"] = valheimPlusConfiguration.guardianBuffDuration.ToString();
            data["Player"]["guardianBuffCooldown"] = valheimPlusConfiguration.guardianBuffCooldown.ToString();
            data["Player"]["disableGuardianBuffAnimation"] = valheimPlusConfiguration.disableGuardianBuffAnimation.ToString().ToLower();
            data["Player"]["autoEquipShield"] = valheimPlusConfiguration.autoEquipShield.ToString().ToLower();
            data["Player"]["queueWeaponChanges"] = valheimPlusConfiguration.queueWeaponChanges.ToString().ToLower();
            data["Player"]["skipIntro"] = valheimPlusConfiguration.skipIntro.ToString().ToLower();
            data["Player"]["iHaveArrivedOnSpawn"] = valheimPlusConfiguration.iHaveArrivedOnSpawn.ToString().ToLower();
            data["Player"]["reequipItemsAfterSwimming"] = valheimPlusConfiguration.reequipItemsAfterSwimming.ToString().ToLower();
            #endregion Player

            #region Server
            data["Server"]["enabled"] = valheimPlusConfiguration.serverSettingsEnabled.ToString().ToLower();
            data["Server"]["maxPlayers"] = valheimPlusConfiguration.maxPlayers.ToString();
            data["Server"]["disableServerPassword"] = valheimPlusConfiguration.disableServerPassword.ToString().ToLower();
            data["Server"]["enforceMod"] = valheimPlusConfiguration.enforceMod.ToString().ToLower();
            data["Server"]["serverSyncHotkeys"] = valheimPlusConfiguration.serverSyncHotkeys.ToString().ToLower();
            //data["Server"]["dataRate"] = valheimPlusConfiguration.dataRate.ToString();
            #endregion Server

            #region Shields
            data["Shields"]["enabled"] = valheimPlusConfiguration.shieldsSettingsEnabled.ToString().ToLower();
            data["Shields"]["blockRating"] = valheimPlusConfiguration.blockRating.ToString();
            #endregion Shields

            #region Smelter
            data["Smelter"]["enabled"] = valheimPlusConfiguration.smelterSettingsEnabled.ToString().ToLower();
            data["Smelter"]["maximumOre"] = valheimPlusConfiguration.smelterMaximumOre.ToString();
            data["Smelter"]["maximumCoal"] = valheimPlusConfiguration.smelterMaximumCoal.ToString();
            data["Smelter"]["coalUsedPerProduct"] = valheimPlusConfiguration.smelterCoalUsedPerProduct.ToString();
            data["Smelter"]["productionSpeed"] = valheimPlusConfiguration.smelterProductionSpeed.ToString();
            data["Smelter"]["autoDeposit"] = valheimPlusConfiguration.smelterAutoDeposit.ToString().ToLower();
            data["Smelter"]["autoRange"] = valheimPlusConfiguration.smelterAutoDepositRange.ToString();
            data["Smelter"]["autoFuel"] = valheimPlusConfiguration.autoFuelSmelter.ToString().ToLower();
            data["Smelter"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckSmelter.ToString().ToLower();
            #endregion Smelter

            #region SpinningWheel
            data["SpinningWheel"]["enabled"] = valheimPlusConfiguration.spinningWheelSettingsEnabled.ToString().ToLower();
            data["SpinningWheel"]["maximumFlax"] = valheimPlusConfiguration.maximumFlaxSpinningWheel.ToString();
            data["SpinningWheel"]["productionSpeed"] = valheimPlusConfiguration.productionSpeedSpinningWheel.ToString();
            data["SpinningWheel"]["autoDeposit"] = valheimPlusConfiguration.autoDepositSpinningWheel.ToString().ToLower();
            data["SpinningWheel"]["autoFuel"] = valheimPlusConfiguration.autoFuelSpinningWheel.ToString().ToLower();
            data["SpinningWheel"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckSpinningWheel.ToString().ToLower();
            data["SpinningWheel"]["autoRange"] = valheimPlusConfiguration.autoRangeSpinningWheel.ToString();
            #endregion SpinningWheel

            #region Stamina
            data["Stamina"]["enabled"] = valheimPlusConfiguration.staminaSettingsEnabled.ToString().ToLower();
            data["Stamina"]["dodgeStaminaUsage"] = valheimPlusConfiguration.dodgeStaminaUsage.ToString();
            data["Stamina"]["encumberedStaminaDrain"] = valheimPlusConfiguration.encumberedStaminaDrain.ToString();
            data["Stamina"]["jumpStaminaDrain"] = valheimPlusConfiguration.jumpStaminaDrain.ToString();
            data["Stamina"]["runStaminaDrain"] = valheimPlusConfiguration.runStaminaDrain.ToString();
            data["Stamina"]["sneakStaminaDrain"] = valheimPlusConfiguration.sneakStaminaDrain.ToString();
            data["Stamina"]["staminaRegen"] = valheimPlusConfiguration.staminaRegen.ToString();
            data["Stamina"]["staminaRegenDelay"] = valheimPlusConfiguration.staminaRegenDelay.ToString();
            data["Stamina"]["swimStaminaDrain"] = valheimPlusConfiguration.swimStaminaDrain.ToString();
            #endregion Stamina

            #region StaminaUsage
            data["StaminaUsage"]["enabled"] = valheimPlusConfiguration.staminaUsageSettingsEnabled.ToString().ToLower();
            data["StaminaUsage"]["axes"] = valheimPlusConfiguration.axes.ToString();
            data["StaminaUsage"]["bows"] = valheimPlusConfiguration.bows.ToString();
            data["StaminaUsage"]["clubs"] = valheimPlusConfiguration.clubs.ToString();
            data["StaminaUsage"]["knives"] = valheimPlusConfiguration.knives.ToString();
            data["StaminaUsage"]["pickaxes"] = valheimPlusConfiguration.pickaxes.ToString();
            data["StaminaUsage"]["polearms"] = valheimPlusConfiguration.polearms.ToString();
            data["StaminaUsage"]["spears"] = valheimPlusConfiguration.spears.ToString();
            data["StaminaUsage"]["swords"] = valheimPlusConfiguration.swords.ToString();
            data["StaminaUsage"]["unarmed"] = valheimPlusConfiguration.unarmed.ToString();
            data["StaminaUsage"]["hammer"] = valheimPlusConfiguration.hammer.ToString();
            data["StaminaUsage"]["hoe"] = valheimPlusConfiguration.hoe.ToString();
            data["StaminaUsage"]["cultivator"] = valheimPlusConfiguration.cultivator.ToString();
            #endregion StaminaUsage

            #region StructuralIntegrity
            data["StructuralIntegrity"]["enabled"] = valheimPlusConfiguration.structuralIntegritySettingsEnabled.ToString().ToLower();
            data["StructuralIntegrity"]["wood"] = valheimPlusConfiguration.wood.ToString();
            data["StructuralIntegrity"]["stone"] = valheimPlusConfiguration.stone.ToString();
            data["StructuralIntegrity"]["iron"] = valheimPlusConfiguration.iron.ToString();
            data["StructuralIntegrity"]["hardWood"] = valheimPlusConfiguration.hardWood.ToString();
            data["StructuralIntegrity"]["disableStructuralIntegrity"] = valheimPlusConfiguration.disableStructuralIntegrity.ToString().ToLower();
            data["StructuralIntegrity"]["disableDamageToPlayerStructures"] = valheimPlusConfiguration.disableDamageToPlayerStructures.ToString().ToLower();
            data["StructuralIntegrity"]["disableDamageToPlayerBoats"] = valheimPlusConfiguration.disableDamageToPlayerBoats.ToString().ToLower();
            data["StructuralIntegrity"]["disableWaterDamageToPlayerBoats"] = valheimPlusConfiguration.disableWaterDamageToPlayerBoats.ToString().ToLower();
            #endregion StructuralIntegrity

            #region Time
            //data["Time"]["enabled"] = valheimPlusConfiguration.timeSettingsEnabled.ToString().ToLower();
            //data["Time"]["totalDayTimeInSeconds"] = valheimPlusConfiguration.totalDayTimeInSeconds.ToString();
            //data["Time"]["nightTimeSpeedMultiplier"] = valheimPlusConfiguration.nightTimeSpeedMultiplier.ToString();
            #endregion Time

            #region ValheimPlus
            data["ValheimPlus"]["enabled"] = valheimPlusConfiguration.valheimPlusConfigurationEnabled.ToString().ToLower();
            data["ValheimPlus"]["mainMenuLogo"] = valheimPlusConfiguration.mainMenuLogo.ToString().ToLower();
            data["ValheimPlus"]["serverBrowserAdvertisement"] = valheimPlusConfiguration.serverBrowserAdvertisement.ToString().ToLower();
            #endregion ValheimPlus

            #region Wagon
            data["Wagon"]["enabled"] = valheimPlusConfiguration.wagonSettingsEnabled.ToString().ToLower();
            data["Wagon"]["wagonBaseMass"] = valheimPlusConfiguration.wagonBaseMass.ToString();
            data["Wagon"]["wagonExtraMassFromItems"] = valheimPlusConfiguration.wagonExtraMassFromItems.ToString();
            #endregion Wagon

            #region Ward
            data["Ward"]["enabled"] = valheimPlusConfiguration.wardSettingsEnabled.ToString().ToLower();
            data["Ward"]["wardRange"] = valheimPlusConfiguration.wardRange.ToString();
            #endregion Ward

            #region Windmill
            data["Windmill"]["enabled"] = valheimPlusConfiguration.windmillConfigurationEnabled.ToString().ToLower();
            data["Windmill"]["maximumBarley"] = valheimPlusConfiguration.maximumBarleyWindmill.ToString();
            data["Windmill"]["productionSpeed"] = valheimPlusConfiguration.productionSpeedWindmill.ToString();
            data["Windmill"]["autoRange"] = valheimPlusConfiguration.autoRangeWindmill.ToString();
            data["Windmill"]["ignoreWindIntensity"] = valheimPlusConfiguration.ignoreWindIntensityWindmill.ToString().ToLower();
            data["Windmill"]["autoDeposit"] = valheimPlusConfiguration.autoDepositWindmill.ToString().ToLower();
            data["Windmill"]["autoFuel"] = valheimPlusConfiguration.autoFuelWindmill.ToString().ToLower();
            data["Windmill"]["ignorePrivateAreaCheck"] = valheimPlusConfiguration.ignorePrivateAreaCheckWindmill.ToString().ToLower();
            #endregion Windmill

            #region Workbench
            data["Workbench"]["enabled"] = valheimPlusConfiguration.workbenchSettingsEnabled.ToString().ToLower();
            data["Workbench"]["workbenchRange"] = valheimPlusConfiguration.workbenchRange.ToString();
            data["Workbench"]["workbenchAttachmentRange"] = valheimPlusConfiguration.workbenchAttachmentRange.ToString();
            data["Workbench"]["disableRoofCheck"] = valheimPlusConfiguration.disableRoofCheck.ToString().ToLower();
            #endregion Workbench

            // Writing the new settings to configuration file
            try
            {
                if (manageClient)
                {
                    parser.WriteFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ClientInstallationPath), data);
                }
                else
                {
                    parser.WriteFile(string.Format("{0}BepInEx/config/valheim_plus.cfg", settings.ServerInstallationPath), data);
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private ConfigManager()
        {
        }
        private static ConfigManager instance = null;
        public static ConfigManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigManager();
                }
                return instance;
            }
        }
    }
}
