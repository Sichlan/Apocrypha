-- --------------------------------------------------------
-- Host:                         www.apocrypha-dnd.org
-- Server-Version:               8.0.29-0ubuntu0.20.04.3 - (Ubuntu)
-- Server-Betriebssystem:        Linux
-- HeidiSQL Version:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Exportiere Struktur von Tabelle Development.ActionTimeIndicator
CREATE TABLE IF NOT EXISTS `ActionTimeIndicator` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.ActionTimeIndicator: ~0 rows (ungefähr)
DELETE FROM `ActionTimeIndicator`;

-- Exportiere Struktur von Tabelle Development.ActionTimeIndicatorTranslation
CREATE TABLE IF NOT EXISTS `ActionTimeIndicatorTranslation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ActionTimeIndicatorId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_ActionTimeIndicatorTranslation_ActionTimeIndicatorId` (`ActionTimeIndicatorId`),
  CONSTRAINT `FK_ActionTimeIndicatorTranslation_ActionTimeIndicator_ActionTim~` FOREIGN KEY (`ActionTimeIndicatorId`) REFERENCES `ActionTimeIndicator` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.ActionTimeIndicatorTranslation: ~0 rows (ungefähr)
DELETE FROM `ActionTimeIndicatorTranslation`;

-- Exportiere Struktur von Tabelle Development.Allignments
CREATE TABLE IF NOT EXISTS `Allignments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Allignments: ~9 rows (ungefähr)
DELETE FROM `Allignments`;
INSERT INTO `Allignments` (`Id`, `Abbreviation`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'LG', 'Lawful Good', NULL),
	(2, 'NG', 'Neutral Good', NULL),
	(3, 'CG', 'Chaotic Good', NULL),
	(4, 'LN', 'Lawful Neutral', NULL),
	(5, 'TN', 'True Neutral', NULL),
	(6, 'CN', 'Chaotic Neutral', NULL),
	(7, 'LE', 'Lawful Evil', NULL),
	(8, 'NE', 'Neutral Evil', NULL),
	(9, 'CE', 'Chaotic Evil', NULL);

-- Exportiere Struktur von Tabelle Development.AllignmentTranslations
CREATE TABLE IF NOT EXISTS `AllignmentTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AllignmentId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AllignmentTranslations_AllignmentId` (`AllignmentId`),
  CONSTRAINT `FK_AllignmentTranslations_Allignments_AllignmentId` FOREIGN KEY (`AllignmentId`) REFERENCES `Allignments` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.AllignmentTranslations: ~18 rows (ungefähr)
DELETE FROM `AllignmentTranslations`;
INSERT INTO `AllignmentTranslations` (`Id`, `AllignmentId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Lawful Good', NULL, 'en'),
	(2, 1, 'Rechtschaffen Gut', NULL, 'de'),
	(3, 2, 'Neutral Good', NULL, 'en'),
	(4, 2, 'Neutral Gut', NULL, 'de'),
	(5, 3, 'Chaotic Good', NULL, 'en'),
	(6, 3, 'Chaotisch Gut', NULL, 'de'),
	(7, 4, 'Lawful Neutral', NULL, 'en'),
	(8, 4, 'Rechtschaffen Neutral', NULL, 'de'),
	(9, 5, 'True Neutral', NULL, 'en'),
	(10, 5, 'Neutral', NULL, 'de'),
	(11, 6, 'Chaotic Neutral', NULL, 'en'),
	(12, 6, 'Chaotisch Neutral', NULL, 'de'),
	(13, 7, 'Lawful Evil', NULL, 'en'),
	(14, 7, 'Rechtschaffen Böse', NULL, 'de'),
	(15, 8, 'Neutral Evil', NULL, 'en'),
	(16, 8, 'Neutral Böse', NULL, 'de'),
	(17, 9, 'Chaotic Evil', NULL, 'en'),
	(18, 9, 'Chaotisch Böse', NULL, 'de');

-- Exportiere Struktur von Tabelle Development.Alphabets
CREATE TABLE IF NOT EXISTS `Alphabets` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Alphabets: ~7 rows (ungefähr)
DELETE FROM `Alphabets`;
INSERT INTO `Alphabets` (`Id`, `FallbackDescription`, `FallbackName`) VALUES
	(1, '', 'Common'),
	(2, '', 'Celestial'),
	(3, '', 'Draconic'),
	(4, '', 'Druidic'),
	(5, '', 'Dwarven'),
	(6, '', 'Elven'),
	(7, '', 'Infernal');

-- Exportiere Struktur von Tabelle Development.AlphabetTranslations
CREATE TABLE IF NOT EXISTS `AlphabetTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlphabetId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AlphabetTranslations_AlphabetId` (`AlphabetId`),
  CONSTRAINT `FK_AlphabetTranslations_Alphabets_AlphabetId` FOREIGN KEY (`AlphabetId`) REFERENCES `Alphabets` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.AlphabetTranslations: ~7 rows (ungefähr)
DELETE FROM `AlphabetTranslations`;
INSERT INTO `AlphabetTranslations` (`Id`, `AlphabetId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Common', '', 'en'),
	(2, 2, 'Celestial', '', 'en'),
	(3, 3, 'Draconic', '', 'en'),
	(4, 4, 'Druidic', '', 'en'),
	(5, 5, 'Dwarven', '', 'en'),
	(6, 6, 'Elven', '', 'en'),
	(7, 7, 'Infernal', '', 'en');

-- Exportiere Struktur von Tabelle Development.CharacterItems
CREATE TABLE IF NOT EXISTS `CharacterItems` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ItemId` int DEFAULT NULL,
  `OwnerId` int DEFAULT NULL,
  `Quantity` int NOT NULL,
  `AquiredAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CharacterItems_ItemId` (`ItemId`),
  KEY `IX_CharacterItems_OwnerId` (`OwnerId`),
  CONSTRAINT `FK_CharacterItems_Characters_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `Characters` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_CharacterItems_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `Items` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CharacterItems: ~0 rows (ungefähr)
DELETE FROM `CharacterItems`;

-- Exportiere Struktur von Tabelle Development.Characters
CREATE TABLE IF NOT EXISTS `Characters` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatorUserId` int DEFAULT NULL,
  `TrueAllignmentId` int DEFAULT NULL,
  `Budget` int NOT NULL,
  `CreationDateTime` datetime(6) NOT NULL,
  `LastModifiedDateTime` datetime(6) NOT NULL,
  `DisableNonPlaytimeEditing` tinyint(1) NOT NULL,
  `CharacterName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Characters_CreatorUserId` (`CreatorUserId`),
  KEY `IX_Characters_TrueAllignmentId` (`TrueAllignmentId`),
  CONSTRAINT `FK_Characters_Allignments_TrueAllignmentId` FOREIGN KEY (`TrueAllignmentId`) REFERENCES `Allignments` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Characters_Users_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Characters: ~3 rows (ungefähr)
DELETE FROM `Characters`;
INSERT INTO `Characters` (`Id`, `CreatorUserId`, `TrueAllignmentId`, `Budget`, `CreationDateTime`, `LastModifiedDateTime`, `DisableNonPlaytimeEditing`, `CharacterName`, `DisplayName`) VALUES
	(1, 1, 9, 0, '2022-07-15 20:19:11.502991', '2022-07-15 20:29:07.337951', 0, 'Test Char', NULL),
	(2, 1, NULL, 0, '2022-07-15 20:19:56.527495', '2022-07-16 18:44:56.962943', 0, 'lol', NULL),
	(3, 1, NULL, 0, '2022-07-15 20:23:05.294534', '0001-01-01 00:00:00.000000', 0, NULL, NULL),
	(4, 1, NULL, 0, '2022-08-29 21:45:39.596935', '0001-01-01 00:00:00.000000', 0, NULL, NULL);

-- Exportiere Struktur von Tabelle Development.CreatureSizeCategories
CREATE TABLE IF NOT EXISTS `CreatureSizeCategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AttackAndArmorClassModifier` int NOT NULL,
  `SpecialAttackModifier` int NOT NULL,
  `HideModifier` int NOT NULL,
  `HeightOrLengthMin` double DEFAULT NULL,
  `HeightOrLengthMax` double DEFAULT NULL,
  `WeightMin` double DEFAULT NULL,
  `WeightMax` double DEFAULT NULL,
  `Space` double NOT NULL,
  `NaturalReachTall` int NOT NULL,
  `NaturalReachLong` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CreatureSizeCategories: ~9 rows (ungefähr)
DELETE FROM `CreatureSizeCategories`;
INSERT INTO `CreatureSizeCategories` (`Id`, `AttackAndArmorClassModifier`, `SpecialAttackModifier`, `HideModifier`, `HeightOrLengthMin`, `HeightOrLengthMax`, `WeightMin`, `WeightMax`, `Space`, `NaturalReachTall`, `NaturalReachLong`, `FallbackName`) VALUES
	(1, 8, -16, 16, NULL, 0.5, 0, 0.125, 0.5, 0, 0, 'Fine'),
	(2, 4, -12, 12, 0.5, 1, 0.125, 1, 1, 0, 0, 'Diminutive'),
	(3, 2, -8, 8, 1, 2, 1, 8, 2.5, 0, 0, 'Tiny'),
	(4, 1, -4, 4, 2, 4, 8, 60, 5, 5, 5, 'Small'),
	(5, 0, 0, 0, 4, 8, 60, 500, 5, 5, 5, 'Medium'),
	(6, -1, 4, -4, 8, 16, 500, 4000, 10, 10, 5, 'Large'),
	(7, -2, 8, -8, 16, 32, 4000, 32000, 15, 15, 10, 'Huge'),
	(8, -4, 12, -12, 32, 64, 32000, 250000, 20, 20, 15, 'Gargantuan'),
	(9, -8, 16, -16, 64, NULL, 250000, NULL, 30, 30, 20, 'Colossal');

-- Exportiere Struktur von Tabelle Development.CreatureSizeCategoryTranslations
CREATE TABLE IF NOT EXISTS `CreatureSizeCategoryTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureSizeCategoryId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureSizeCategoryTranslations_CreatureSizeCategoryId` (`CreatureSizeCategoryId`),
  CONSTRAINT `FK_CreatureSizeCategoryTranslations_CreatureSizeCategories_Crea~` FOREIGN KEY (`CreatureSizeCategoryId`) REFERENCES `CreatureSizeCategories` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CreatureSizeCategoryTranslations: ~9 rows (ungefähr)
DELETE FROM `CreatureSizeCategoryTranslations`;
INSERT INTO `CreatureSizeCategoryTranslations` (`Id`, `CreatureSizeCategoryId`, `Name`, `CultureName`, `Description`) VALUES
	(1, 1, 'Fine', 'en', NULL),
	(2, 2, 'Diminutive', 'en', NULL),
	(3, 3, 'Tiny', 'en', NULL),
	(4, 4, 'Small', 'en', NULL),
	(5, 5, 'Medium', 'en', NULL),
	(6, 6, 'Large', 'en', NULL),
	(7, 7, 'Huge', 'en', NULL),
	(8, 8, 'Gargantuan', 'en', NULL),
	(9, 9, 'Colossal', 'en', NULL);

-- Exportiere Struktur von Tabelle Development.CreatureSubTypes
CREATE TABLE IF NOT EXISTS `CreatureSubTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CreatureSubTypes: ~25 rows (ungefähr)
DELETE FROM `CreatureSubTypes`;
INSERT INTO `CreatureSubTypes` (`Id`, `FallbackName`, `FallbackDescription`) VALUES
	(1, 'Air', 'This subtype usually is used for elementals and outsiders with a connection to the Elemental Plane Air. Air creatures always have fly speeds and usually have perfect maneuverability.'),
	(2, 'Angel', 'Angels are a race of celestials, or good outsiders, native to the good-aligned Outer Planes.'),
	(3, 'Aquatic', 'These creatures always have swim speeds and thus can move in water without making Swim checks. An aquatic creature can breathe underwater. It cannot also breathe air unless it has the amphibious special quality.'),
	(4, 'Archon', 'Archons are a race of celestials, or good outsiders, native to lawful good-aligned Outer Planes.'),
	(5, 'Augmented', 'A creature receives this subtype whenever something happens to change its original type. Some creatures (those with an inherited template) are born with this subtype; others acquire it when they take on an acquired template. The augmented subtype is always paired with the creature\'s original type. A creature with the augmented subtype usually has the traits of its current type, but the features of its original type.'),
	(6, 'Chaotic', 'A subtype usually applied only to outsiders native to the chaotic-aligned Outer Planes. Most creatures that have this subtype also have chaotic alignments; however, if their alignments change they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has a chaotic alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the chaotic subtype overcomes damage reduction as if its natural weapons and any weapons it wields were chaotic-aligned.'),
	(7, 'Cold', 'A creature with the cold subtype has immunity to cold. It has vulnerability to fire, which means it takes half again as much (+50%) damage as normal from fire, regardless of whether a saving throw is allowed, or if the save is a success or failure.'),
	(8, 'Earth', 'This subtype usually is used for elementals and outsiders with a connection to the Elemental Plane of Earth. Earth creatures usually have burrow speeds, and most earth creatures can burrow through solid rock.'),
	(9, 'Evil', 'A subtype usually applied only to outsiders native to the evil-aligned Outer Planes. Evil outsiders are also called fiends. Most creatures that have this subtype also have evil alignments; however, if their alignments change, they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has an evil alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the evil subtype overcomes damage reduction as if its natural weapons and any weapons it wields were evil-aligned.'),
	(10, 'Extraplanar', 'A subtype applied to any creature when it is on a plane other than its native plane. A creature that travels the planes can gain or lose this subtype as it goes from plane to plane. Monster entries assume that encounters with creatures take place on the Material Plane, and every creature whose native plane is not the Material Plane has the extraplanar subtype (but would not have when on its home plane). Every extraplanar creature in this book has a home plane mentioned in its description. Creatures not labeled as extraplanar are natives of the Material Plane, and they gain the extraplanar subtype if they leave the Material Plane. No creature has the extraplanar subtype when it is on a transitive plane, such as the Astral Plane, the Ethereal Plane, and the Plane of Shadow.'),
	(11, 'Fire', 'A creature with the fire subtype has immunity to fire. It has vulnerability to cold, which means it takes half again as much (+50%) damage as normal from cold, regardless of whether a saving throw is allowed, or if the save is a success or failure.'),
	(12, 'Goblinoid', 'Goblinoids are stealthy humanoids who live by hunting and raiding and who all speak Goblin.'),
	(13, 'Good', 'A subtype usually applied only to outsiders native to the good-aligned Outer Planes. Most creatures that have this subtype also have good alignments; however, if their alignments change, they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has a good alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the good subtype overcomes damage reduction as if its natural weapons and any weapons it wields were good-aligned (see Damage Reduction, above).'),
	(14, 'Incorporeal', 'An incorporeal creature has no physical body. It can be harmed only by other incorporeal creatures, magic weapons or creatures that strike as magic weapons, and spells, spell-like abilities, or supernatural abilities. It is immune to all nonmagical attack forms. Even when hit by spells or magic weapons, it has a 50% chance to ignore any damage from a corporeal source (except for positive energy, negative energy, force effects such as magic missile, or attacks made with ghost touch weapons). Although it is not a magical attack, holy water can affect incorporeal undead, but a hit with holy water has a 50% chance of not affecting an incorporeal creature.\r\n\r\nAn incorporeal creature has no natural armor bonus but has a deflection bonus equal to its Charisma bonus (always at least +1, even if the creature\'s Charisma score does not normally provide a bonus).\r\n\r\nAn incorporeal creature can enter or pass through solid objects, but must remain adjacent to the object\'s exterior, and so cannot pass entirely through an object whose space is larger than its own. It can sense the presence of creatures or objects within a square adjacent to its current location, but enemies have total concealment (50% miss chance) from an incorporeal creature that is inside an object. In order to see farther from the object it is in and attack normally, the incorporeal creature must emerge. An incorporeal creature inside an object has total cover, but when it attacks a creature outside the object it only has cover, so a creature outside with a readied action could strike at it as it attacks. An incorporeal creature cannot pass through a force effect.\r\n\r\nAn incorporeal creature\'s attacks pass through (ignore) natural armor, armor, and shields, although deflection bonuses and force effects (such as mage armor) work normally against it. Incorporeal creatures pass through and operate in water as easily as they do in air. Incorporeal creatures cannot fall or take falling damage. Incorporeal creatures cannot make trip or grapple attacks, nor can they be tripped or grappled. In fact, they cannot take any physical action that would move or manipulate an opponent or its equipment, nor are they subject to such actions. Incorporeal creatures have no weight and do not set off traps that are triggered by weight.\r\n\r\nAn incorporeal creature moves silently and cannot be heard with Listen checks if it doesn\'t wish to be. It has no Strength score, so its Dexterity modifier applies to both its melee attacks and its ranged attacks. Non-visual senses, such as scent and blindsight, are either ineffective or only partly effective with regard to incorporeal creatures. Incorporeal creatures have an innate sense of direction and can move at full speed even when they cannot see.'),
	(15, 'Lawful', 'A subtype usually applied only to outsiders native to the lawful-aligned Outer Planes. Most creatures that have this subtype also have lawful alignments; however, if their alignments change, they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has a lawful alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the lawful subtype overcomes damage reduction as if its natural weapons and any weapons it wields were lawful-aligned (see Damage Reduction, above).'),
	(16, 'Native', 'A subtype applied only to outsiders. These creatures have mortal ancestors or a strong connection to the Material Plane and can be raised, reincarnated, or resurrected just as other living creatures can be. Creatures with this subtype are native to the Material Plane (hence the subtype\'s name). Unlike true outsiders, native outsiders need to eat and sleep.'),
	(17, 'Reptilian', 'These creatures are scaly and usually coldblooded. The reptilian subtype is only used to describe a set of humanoid races, not all animals and monsters that are truly reptiles.'),
	(18, 'Shape-changer', 'A shape-changer has the supernatural ability to assume one or more alternate forms. Many magical effects allow some kind of shape shifting, and not every creature that can change shape has the shape-changer subtype.'),
	(19, 'Swarm', 'A swarm is a collection of Fine, Diminutive, or Tiny creatures that acts as a single creature. A swarm has the characteristics of its type, except as noted here. A swarm has a single pool of Hit Dice and hit points, a single initiative modifier, a single speed, and a single Armor Class. A swarm makes saving throws as a single creature. A single swarm occupies a square (if it is made up of nonflying creatures) or a cube (of flying creatures) 10 feet on a side, but its reach is 0 feet, like its component creatures. In order to attack, it moves into an opponent\'s space, which provokes an attack of opportunity. It can occupy the same space as a creature of any size, since it crawls all over its prey. A swarm can move through squares occupied by enemies and vice versa without impediment, although the swarm provokes an attack of opportunity if it does so. A swarm can move through cracks or holes large enough for its component creatures.\r\n\r\nA swarm of Tiny creatures consists of 300 nonflying creatures or 1,000 flying creatures. A swarm of Diminutive creatures consists of 1,500 nonflying creatures or 5,000 flying creatures. A swarm of Fine creatures consists of 10,000 creatures, whether they are flying or not. Swarms of nonflying creatures include many more creatures than could normally fit in a 10-foot square based on their normal space, because creatures in a swarm are packed tightly together and generally crawl over each other and their prey when moving or attacking. Larger swarms are represented by multiples of single swarms. The area occupied by a large swarm is completely shapeable, though the swarm usually remains in contiguous squares.'),
	(20, 'Water', 'This subtype usually is used for elementals and outsiders with a connection to the Elemental Plane of Water. Creatures with the water subtype always have swim speeds and can move in water without making Swim checks. A water creature can breathe underwater and usually can breathe air as well.'),
	(21, 'Human', 'A human.'),
	(22, 'Dwarf', 'A dwarf.'),
	(23, 'Elf', 'An elf.'),
	(24, 'Gnoll', 'A gnoll.'),
	(25, 'Gnome', 'A gnome.'),
	(26, 'Halfling', 'A halfling.'),
	(27, 'Orc', 'An orc.');

-- Exportiere Struktur von Tabelle Development.CreatureSubTypeTranslations
CREATE TABLE IF NOT EXISTS `CreatureSubTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureSubTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureSubTypeTranslations_CreatureSubTypeId` (`CreatureSubTypeId`),
  CONSTRAINT `FK_CreatureSubTypeTranslations_CreatureSubTypes_CreatureSubType~` FOREIGN KEY (`CreatureSubTypeId`) REFERENCES `CreatureSubTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CreatureSubTypeTranslations: ~25 rows (ungefähr)
DELETE FROM `CreatureSubTypeTranslations`;
INSERT INTO `CreatureSubTypeTranslations` (`Id`, `CreatureSubTypeId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Air', 'This subtype usually is used for elementals and outsiders with a connection to the Elemental Plane Air. Air creatures always have fly speeds and usually have perfect maneuverability.', 'en'),
	(2, 2, 'Angel', 'Angels are a race of celestials, or good outsiders, native to the good-aligned Outer Planes.', 'en'),
	(3, 3, 'Aquatic', 'These creatures always have swim speeds and thus can move in water without making Swim checks. An aquatic creature can breathe underwater. It cannot also breathe air unless it has the amphibious special quality.', 'en'),
	(4, 4, 'Archon', 'Archons are a race of celestials, or good outsiders, native to lawful good-aligned Outer Planes.', 'en'),
	(5, 5, 'Augmented', 'A creature receives this subtype whenever something happens to change its original type. Some creatures (those with an inherited template) are born with this subtype; others acquire it when they take on an acquired template. The augmented subtype is always paired with the creature\'s original type. A creature with the augmented subtype usually has the traits of its current type, but the features of its original type.', 'en'),
	(6, 6, 'Chaotic', 'A subtype usually applied only to outsiders native to the chaotic-aligned Outer Planes. Most creatures that have this subtype also have chaotic alignments; however, if their alignments change they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has a chaotic alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the chaotic subtype overcomes damage reduction as if its natural weapons and any weapons it wields were chaotic-aligned.', 'en'),
	(7, 7, 'Cold', 'A creature with the cold subtype has immunity to cold. It has vulnerability to fire, which means it takes half again as much (+50%) damage as normal from fire, regardless of whether a saving throw is allowed, or if the save is a success or failure.', 'en'),
	(8, 8, 'Earth', 'This subtype usually is used for elementals and outsiders with a connection to the Elemental Plane of Earth. Earth creatures usually have burrow speeds, and most earth creatures can burrow through solid rock.', 'en'),
	(9, 9, 'Evil', 'A subtype usually applied only to outsiders native to the evil-aligned Outer Planes. Evil outsiders are also called fiends. Most creatures that have this subtype also have evil alignments; however, if their alignments change, they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has an evil alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the evil subtype overcomes damage reduction as if its natural weapons and any weapons it wields were evil-aligned.', 'en'),
	(10, 10, 'Extraplanar', 'A subtype applied to any creature when it is on a plane other than its native plane. A creature that travels the planes can gain or lose this subtype as it goes from plane to plane. Monster entries assume that encounters with creatures take place on the Material Plane, and every creature whose native plane is not the Material Plane has the extraplanar subtype (but would not have when on its home plane). Every extraplanar creature in this book has a home plane mentioned in its description. Creatures not labeled as extraplanar are natives of the Material Plane, and they gain the extraplanar subtype if they leave the Material Plane. No creature has the extraplanar subtype when it is on a transitive plane, such as the Astral Plane, the Ethereal Plane, and the Plane of Shadow.', 'en'),
	(11, 11, 'Fire', 'A creature with the fire subtype has immunity to fire. It has vulnerability to cold, which means it takes half again as much (+50%) damage as normal from cold, regardless of whether a saving throw is allowed, or if the save is a success or failure.', 'en'),
	(12, 12, 'Goblinoid', 'Goblinoids are stealthy humanoids who live by hunting and raiding and who all speak Goblin.', 'en'),
	(13, 13, 'Good', 'A subtype usually applied only to outsiders native to the good-aligned Outer Planes. Most creatures that have this subtype also have good alignments; however, if their alignments change, they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has a good alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the good subtype overcomes damage reduction as if its natural weapons and any weapons it wields were good-aligned (see Damage Reduction, above).', 'en'),
	(14, 14, 'Incorporeal', 'An incorporeal creature has no physical body. It can be harmed only by other incorporeal creatures, magic weapons or creatures that strike as magic weapons, and spells, spell-like abilities, or supernatural abilities. It is immune to all nonmagical attack forms. Even when hit by spells or magic weapons, it has a 50% chance to ignore any damage from a corporeal source (except for positive energy, negative energy, force effects such as magic missile, or attacks made with ghost touch weapons). Although it is not a magical attack, holy water can affect incorporeal undead, but a hit with holy water has a 50% chance of not affecting an incorporeal creature.\r\n\r\nAn incorporeal creature has no natural armor bonus but has a deflection bonus equal to its Charisma bonus (always at least +1, even if the creature\'s Charisma score does not normally provide a bonus).\r\n\r\nAn incorporeal creature can enter or pass through solid objects, but must remain adjacent to the object\'s exterior, and so cannot pass entirely through an object whose space is larger than its own. It can sense the presence of creatures or objects within a square adjacent to its current location, but enemies have total concealment (50% miss chance) from an incorporeal creature that is inside an object. In order to see farther from the object it is in and attack normally, the incorporeal creature must emerge. An incorporeal creature inside an object has total cover, but when it attacks a creature outside the object it only has cover, so a creature outside with a readied action could strike at it as it attacks. An incorporeal creature cannot pass through a force effect.\r\n\r\nAn incorporeal creature\'s attacks pass through (ignore) natural armor, armor, and shields, although deflection bonuses and force effects (such as mage armor) work normally against it. Incorporeal creatures pass through and operate in water as easily as they do in air. Incorporeal creatures cannot fall or take falling damage. Incorporeal creatures cannot make trip or grapple attacks, nor can they be tripped or grappled. In fact, they cannot take any physical action that would move or manipulate an opponent or its equipment, nor are they subject to such actions. Incorporeal creatures have no weight and do not set off traps that are triggered by weight.\r\n\r\nAn incorporeal creature moves silently and cannot be heard with Listen checks if it doesn\'t wish to be. It has no Strength score, so its Dexterity modifier applies to both its melee attacks and its ranged attacks. Non-visual senses, such as scent and blindsight, are either ineffective or only partly effective with regard to incorporeal creatures. Incorporeal creatures have an innate sense of direction and can move at full speed even when they cannot see.', 'en'),
	(15, 15, 'Lawful', 'A subtype usually applied only to outsiders native to the lawful-aligned Outer Planes. Most creatures that have this subtype also have lawful alignments; however, if their alignments change, they still retain the subtype. Any effect that depends on alignment affects a creature with this subtype as if the creature has a lawful alignment, no matter what its alignment actually is. The creature also suffers effects according to its actual alignment. A creature with the lawful subtype overcomes damage reduction as if its natural weapons and any weapons it wields were lawful-aligned (see Damage Reduction, above).', 'en'),
	(16, 16, 'Native', 'A subtype applied only to outsiders. These creatures have mortal ancestors or a strong connection to the Material Plane and can be raised, reincarnated, or resurrected just as other living creatures can be. Creatures with this subtype are native to the Material Plane (hence the subtype\'s name). Unlike true outsiders, native outsiders need to eat and sleep.', 'en'),
	(17, 17, 'Reptilian', 'These creatures are scaly and usually coldblooded. The reptilian subtype is only used to describe a set of humanoid races, not all animals and monsters that are truly reptiles.', 'en'),
	(18, 18, 'Shape-changer', 'A shape-changer has the supernatural ability to assume one or more alternate forms. Many magical effects allow some kind of shape shifting, and not every creature that can change shape has the shape-changer subtype.', 'en'),
	(19, 19, 'Swarm', 'A swarm is a collection of Fine, Diminutive, or Tiny creatures that acts as a single creature. A swarm has the characteristics of its type, except as noted here. A swarm has a single pool of Hit Dice and hit points, a single initiative modifier, a single speed, and a single Armor Class. A swarm makes saving throws as a single creature. A single swarm occupies a square (if it is made up of nonflying creatures) or a cube (of flying creatures) 10 feet on a side, but its reach is 0 feet, like its component creatures. In order to attack, it moves into an opponent\'s space, which provokes an attack of opportunity. It can occupy the same space as a creature of any size, since it crawls all over its prey. A swarm can move through squares occupied by enemies and vice versa without impediment, although the swarm provokes an attack of opportunity if it does so. A swarm can move through cracks or holes large enough for its component creatures.\r\n\r\nA swarm of Tiny creatures consists of 300 nonflying creatures or 1,000 flying creatures. A swarm of Diminutive creatures consists of 1,500 nonflying creatures or 5,000 flying creatures. A swarm of Fine creatures consists of 10,000 creatures, whether they are flying or not. Swarms of nonflying creatures include many more creatures than could normally fit in a 10-foot square based on their normal space, because creatures in a swarm are packed tightly together and generally crawl over each other and their prey when moving or attacking. Larger swarms are represented by multiples of single swarms. The area occupied by a large swarm is completely shapeable, though the swarm usually remains in contiguous squares.', 'en'),
	(20, 20, 'Water', 'This subtype usually is used for elementals and outsiders with a connection to the Elemental Plane of Water. Creatures with the water subtype always have swim speeds and can move in water without making Swim checks. A water creature can breathe underwater and usually can breathe air as well.', 'en'),
	(21, 21, 'Human', 'A human.', 'en'),
	(22, 22, 'Dwarf', 'A dwarf.', 'en'),
	(23, 23, 'Elf', 'An elf.', 'en'),
	(24, 24, 'Gnoll', 'A gnoll.', 'en'),
	(25, 25, 'Gnome', 'A gnome.', 'en'),
	(26, 26, 'Halfling', 'A halfling.', 'en'),
	(27, 27, 'Orc', 'An orc.', 'en');

-- Exportiere Struktur von Tabelle Development.CreatureTypes
CREATE TABLE IF NOT EXISTS `CreatureTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CreatureTypes: ~15 rows (ungefähr)
DELETE FROM `CreatureTypes`;
INSERT INTO `CreatureTypes` (`Id`, `FallbackName`, `FallbackDescription`) VALUES
	(1, 'Aberration', 'An aberration has a bizarre anatomy, strange abilities, an alien mindset, or any combination of the three.'),
	(2, 'Animal', 'An animal is a living, nonhuman creature, usually a vertebrate with no magical abilities and no innate capacity for language or culture.'),
	(3, 'Construct', 'A construct is an animated object or artificially constructed creature.'),
	(4, 'Dragon', 'A dragon is a reptile-like creature, usually winged, with magical or unusual abilities.'),
	(5, 'Elemental', 'An elemental is a being composed of one of the four classical elements: air, earth, fire, or water.'),
	(6, 'Fey', 'A fey is a creature with supernatural abilities and connections to nature or to some other force or place. Fey are usually human-shaped.'),
	(7, 'Giant', 'A giant is a humanoid-shaped creature of great strength, usually of at least Large size.'),
	(8, 'Humanoid', 'A humanoid usually has two arms, two legs, and one head, or a human-like torso, arms, and a head. Humanoids have few or no supernatural or extraordinary abilities, but most can speak and usually have well-developed societies. They usually are Small or Medium. Every humanoid creature also has a subtype.'),
	(9, 'Magical Beast', 'Magical beasts are similar to animals but can have Intelligence scores higher than 2. Magical beasts usually have supernatural or extraordinary abilities, but sometimes are merely bizarre in appearance or habits.'),
	(10, 'Monstrous Humanoid', 'Monstrous humanoids are similar to humanoids, but with monstrous or animalistic features. They often have magical abilities as well.'),
	(11, 'Ooze', 'An ooze is an amorphous or mutable creature, usually mindless.'),
	(12, 'Outsider', 'An outsider is at least partially composed of the essence (but not necessarily the material) of some plane other than the Material Plane. Some creatures start out as some other type and become outsiders when they attain a higher (or lower) state of spiritual existence.'),
	(13, 'Plant', 'This type comprises vegetable creatures. Note that regular plants, such as one finds growing in gardens and fields, lack Wisdom and Charisma scores (see Nonabilities) and are not creatures, but objects, even though they are alive.'),
	(14, 'Undead', 'Undead are once-living creatures animated by spiritual or supernatural forces.'),
	(15, 'Vermin', 'This type includes insects, arachnids, other arthropods, worms, and similar invertebrates.');

-- Exportiere Struktur von Tabelle Development.CreatureTypeTranslations
CREATE TABLE IF NOT EXISTS `CreatureTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureTypeTranslations_CreatureTypeId` (`CreatureTypeId`),
  CONSTRAINT `FK_CreatureTypeTranslations_CreatureTypes_CreatureTypeId` FOREIGN KEY (`CreatureTypeId`) REFERENCES `CreatureTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.CreatureTypeTranslations: ~15 rows (ungefähr)
DELETE FROM `CreatureTypeTranslations`;
INSERT INTO `CreatureTypeTranslations` (`Id`, `CreatureTypeId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Aberration', 'An aberration has a bizarre anatomy, strange abilities, an alien mindset, or any combination of the three.', 'en'),
	(2, 2, 'Animal', 'An animal is a living, nonhuman creature, usually a vertebrate with no magical abilities and no innate capacity for language or culture.', 'en'),
	(3, 3, 'Construct', 'A construct is an animated object or artificially constructed creature.', 'en'),
	(4, 4, 'Dragon', 'A dragon is a reptile-like creature, usually winged, with magical or unusual abilities.', 'en'),
	(5, 5, 'Elemental', 'An elemental is a being composed of one of the four classical elements: air, earth, fire, or water.', 'en'),
	(6, 6, 'Fey', 'A fey is a creature with supernatural abilities and connections to nature or to some other force or place. Fey are usually human-shaped.', 'en'),
	(7, 7, 'Giant', 'A giant is a humanoid-shaped creature of great strength, usually of at least Large size.', 'en'),
	(8, 8, 'Humanoid', 'A humanoid usually has two arms, two legs, and one head, or a human-like torso, arms, and a head. Humanoids have few or no supernatural or extraordinary abilities, but most can speak and usually have well-developed societies. They usually are Small or Medium. Every humanoid creature also has a subtype.', 'en'),
	(9, 9, 'Magical Beast', 'Magical beasts are similar to animals but can have Intelligence scores higher than 2. Magical beasts usually have supernatural or extraordinary abilities, but sometimes are merely bizarre in appearance or habits.', 'en'),
	(10, 10, 'Monstrous Humanoid', 'Monstrous humanoids are similar to humanoids, but with monstrous or animalistic features. They often have magical abilities as well.', 'en'),
	(11, 11, 'Ooze', 'An ooze is an amorphous or mutable creature, usually mindless.', 'en'),
	(12, 12, 'Outsider', 'An outsider is at least partially composed of the essence (but not necessarily the material) of some plane other than the Material Plane. Some creatures start out as some other type and become outsiders when they attain a higher (or lower) state of spiritual existence.', 'en'),
	(13, 13, 'Plant', 'This type comprises vegetable creatures. Note that regular plants, such as one finds growing in gardens and fields, lack Wisdom and Charisma scores (see Nonabilities) and are not creatures, but objects, even though they are alive.', 'en'),
	(14, 14, 'Undead', 'Undead are once-living creatures animated by spiritual or supernatural forces.', 'en'),
	(15, 15, 'Vermin', 'This type includes insects, arachnids, other arthropods, worms, and similar invertebrates.', 'en');

-- Exportiere Struktur von Tabelle Development.Editions
CREATE TABLE IF NOT EXISTS `Editions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `System` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Core` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Editions: ~17 rows (ungefähr)
DELETE FROM `Editions`;
INSERT INTO `Editions` (`Id`, `Name`, `System`, `Core`) VALUES
	(1, 'Core (3.0)', 'DnD 3.0', 1),
	(2, 'Realms (3.0)', 'DnD 3.0', 0),
	(3, 'Generic (3.0)', 'DnD 3.0', 0),
	(4, 'Dark Sun (3.0)', 'DnD 3.0', 0),
	(5, 'Class (3.0)', 'DnD 3.0', 0),
	(6, 'Greyhawk (3.0)', 'DnD 3.0', 0),
	(7, 'Core (3.5)', 'DnD 3.5', 1),
	(8, 'Realms (3.5)', 'DnD 3.5', 0),
	(9, 'Generic (3.5)', 'DnD 3.5', 0),
	(10, 'Dark Sun (3.5)', 'DnD 3.5', 0),
	(11, 'Class (3.5)', 'DnD 3.5', 0),
	(12, 'Greyhawk (3.5)', 'DnD 3.5', 0),
	(13, 'Dragonlance (3.5)', 'DnD 3.5', 0),
	(14, 'Eberron (3.5)', 'DnD 3.5', 0),
	(15, 'Environment (3.5)', 'DnD 3.5', 0),
	(16, 'Planescape (3.5)', 'DnD 3.5', 0),
	(17, 'Races (3.5)', 'DnD 3.5', 0);

-- Exportiere Struktur von Tabelle Development.FeatOptions
CREATE TABLE IF NOT EXISTS `FeatOptions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdList` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RaceId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FeatOptions_RaceId` (`RaceId`),
  CONSTRAINT `FK_FeatOptions_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.FeatOptions: ~0 rows (ungefähr)
DELETE FROM `FeatOptions`;

-- Exportiere Struktur von Tabelle Development.Items
CREATE TABLE IF NOT EXISTS `Items` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Price` int NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Items: ~0 rows (ungefähr)
DELETE FROM `Items`;

-- Exportiere Struktur von Tabelle Development.Languages
CREATE TABLE IF NOT EXISTS `Languages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlphabetId` int DEFAULT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Languages_AlphabetId` (`AlphabetId`),
  CONSTRAINT `FK_Languages_Alphabets_AlphabetId` FOREIGN KEY (`AlphabetId`) REFERENCES `Alphabets` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Languages: ~20 rows (ungefähr)
DELETE FROM `Languages`;
INSERT INTO `Languages` (`Id`, `AlphabetId`, `FallbackName`, `FallbackDescription`) VALUES
	(1, 1, 'Common', ''),
	(2, 7, 'Abyssal', ''),
	(3, 6, 'Aquan', ''),
	(4, 3, 'Auran', ''),
	(5, 2, 'Celestial', ''),
	(6, 3, 'Draconic', ''),
	(7, 4, 'Druidic', ''),
	(8, 5, 'Dwarven', ''),
	(9, 6, 'Elven', ''),
	(10, 5, 'Giant', ''),
	(11, 1, 'Gnoll', ''),
	(12, 5, 'Gnome', ''),
	(13, 5, 'Goblin', ''),
	(14, 1, 'Halfling', ''),
	(15, 3, 'Ignan', ''),
	(16, 7, 'Infernal', ''),
	(17, 5, 'Orc', ''),
	(18, 6, 'Sylvan', ''),
	(19, 5, 'Terran', ''),
	(20, 6, 'Undercommon', '');

-- Exportiere Struktur von Tabelle Development.LanguageTranslations
CREATE TABLE IF NOT EXISTS `LanguageTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LanguageId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_LanguageTranslations_LanguageId` (`LanguageId`),
  CONSTRAINT `FK_LanguageTranslations_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.LanguageTranslations: ~20 rows (ungefähr)
DELETE FROM `LanguageTranslations`;
INSERT INTO `LanguageTranslations` (`Id`, `LanguageId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Common', '', 'en'),
	(2, 2, 'Abyssal', '', 'en'),
	(3, 3, 'Aquan', '', 'en'),
	(4, 4, 'Auran', '', 'en'),
	(5, 5, 'Celestial', '', 'en'),
	(6, 6, 'Draconic', '', 'en'),
	(7, 7, 'Druidic', '', 'en'),
	(8, 8, 'Dwarven', '', 'en'),
	(9, 9, 'Elven', '', 'en'),
	(10, 10, 'Giant', '', 'en'),
	(11, 11, 'Gnoll', '', 'en'),
	(12, 12, 'Gnome', '', 'en'),
	(13, 13, 'Goblin', '', 'en'),
	(14, 14, 'Halfling', '', 'en'),
	(15, 15, 'Ignan', '', 'en'),
	(16, 16, 'Infernal', '', 'en'),
	(17, 17, 'Orc', '', 'en'),
	(18, 18, 'Sylvan', '', 'en'),
	(19, 19, 'Terran', '', 'en'),
	(20, 20, 'Undercommon', '', 'en');

-- Exportiere Struktur von Tabelle Development.MovementManeuverabilities
CREATE TABLE IF NOT EXISTS `MovementManeuverabilities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.MovementManeuverabilities: ~5 rows (ungefähr)
DELETE FROM `MovementManeuverabilities`;
INSERT INTO `MovementManeuverabilities` (`Id`, `FallbackName`, `FallbackDescription`) VALUES
	(1, 'Perfect', 'The creature can perform almost any aerial maneuver it wishes. It moves through the air as well as a human moves over smooth ground.'),
	(2, 'Good', 'The creature is very agile in the air (like a housefly or a hummingbird), but cannot change direction as readily as those with perfect maneuverability.'),
	(3, 'Average', 'The creature can fly as adroitly as a small bird.'),
	(4, 'Poor', 'The creature flies as well as a very large bird.'),
	(5, 'Clumsy', 'The creature can barely maneuver at all.');

-- Exportiere Struktur von Tabelle Development.MovementManeuverabilityTranslations
CREATE TABLE IF NOT EXISTS `MovementManeuverabilityTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MovementManeuverabilityId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_MovementManeuverabilityTranslations_MovementManeuverabilityId` (`MovementManeuverabilityId`),
  CONSTRAINT `FK_MovementManeuverabilityTranslations_MovementManeuverabilitie~` FOREIGN KEY (`MovementManeuverabilityId`) REFERENCES `MovementManeuverabilities` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.MovementManeuverabilityTranslations: ~5 rows (ungefähr)
DELETE FROM `MovementManeuverabilityTranslations`;
INSERT INTO `MovementManeuverabilityTranslations` (`Id`, `MovementManeuverabilityId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Perfect', 'The creature can perform almost any aerial maneuver it wishes. It moves through the air as well as a human moves over smooth ground.', 'en'),
	(2, 2, 'Good', 'The creature is very agile in the air (like a housefly or a hummingbird), but cannot change direction as readily as those with perfect maneuverability.', 'en'),
	(3, 3, 'Average', 'The creature can fly as adroitly as a small bird.', 'en'),
	(4, 4, 'Poor', 'The creature flies as well as a very large bird.', 'en'),
	(5, 5, 'Clumsy', 'The creature can barely maneuver at all.', 'en');

-- Exportiere Struktur von Tabelle Development.MovementModes
CREATE TABLE IF NOT EXISTS `MovementModes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.MovementModes: ~5 rows (ungefähr)
DELETE FROM `MovementModes`;
INSERT INTO `MovementModes` (`Id`, `FallbackName`, `FallbackDescription`) VALUES
	(1, 'Land', 'Normal movement on land.'),
	(2, 'Burrow', 'A creature with a burrow speed can tunnel through dirt, but not through rock unless the descriptive text says otherwise. Creatures cannot charge or run while burrowing. Most burrowing creatures do not leave behind tunnels other creatures can use (either because the material they tunnel through fills in behind them or because they do not actually dislocate any material when burrowing); see the individual creature descriptions for details.'),
	(3, 'Climb', 'A creature with a climb speed has a +8 racial bonus on all Climb checks. The creature must make a Climb check to climb any wall or slope with a DC of more than 0, but it always can choose to take 10 even if rushed or threatened while climbing. The creature climbs at the given speed while climbing. If it chooses an accelerated climb it moves at double the given climb speed (or its base land speed, whichever is lower) and makes a single Climb check at a –5 penalty. Creatures cannot run while climbing. A creature retains its Dexterity bonus to Armor Class (if any) while climbing, and opponents get no special bonus on their attacks against a climbing creature.'),
	(4, 'Fly', 'A creature with a fly speed can move through the air at the indicated speed if carrying no more than a light load. (Note that medium armor does not necessarily constitute a medium load.)\r\n\r\nA creature that flies can make dive attacks. A dive attack works just like a charge, but the diving creature must move a minimum of 30 feet and descend at least 10 feet. It can make only claw or talon attacks, but these deal double damage. A creature can use the run action while flying, provided it flies in a straight line.'),
	(5, 'Swim', 'A creature with a swim speed can move through water at its swim speed without making Swim checks. It has a +8 racial bonus on any Swim check to perform some special action or avoid a hazard. The creature can always can choose to take 10 on a Swim check, even if distracted or endangered. The creature can use the run action while swimming, provided it swims in a straight line.');

-- Exportiere Struktur von Tabelle Development.MovementModeTranslations
CREATE TABLE IF NOT EXISTS `MovementModeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MovementModeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_MovementModeTranslations_MovementModeId` (`MovementModeId`),
  CONSTRAINT `FK_MovementModeTranslations_MovementModes_MovementModeId` FOREIGN KEY (`MovementModeId`) REFERENCES `MovementModes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.MovementModeTranslations: ~5 rows (ungefähr)
DELETE FROM `MovementModeTranslations`;
INSERT INTO `MovementModeTranslations` (`Id`, `MovementModeId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Land', 'Normal movement on land.', 'en'),
	(2, 2, 'Burrow', 'A creature with a burrow speed can tunnel through dirt, but not through rock unless the descriptive text says otherwise. Creatures cannot charge or run while burrowing. Most burrowing creatures do not leave behind tunnels other creatures can use (either because the material they tunnel through fills in behind them or because they do not actually dislocate any material when burrowing); see the individual creature descriptions for details.', 'en'),
	(3, 3, 'Climb', 'A creature with a climb speed has a +8 racial bonus on all Climb checks. The creature must make a Climb check to climb any wall or slope with a DC of more than 0, but it always can choose to take 10 even if rushed or threatened while climbing. The creature climbs at the given speed while climbing. If it chooses an accelerated climb it moves at double the given climb speed (or its base land speed, whichever is lower) and makes a single Climb check at a –5 penalty. Creatures cannot run while climbing. A creature retains its Dexterity bonus to Armor Class (if any) while climbing, and opponents get no special bonus on their attacks against a climbing creature.', 'en'),
	(4, 4, 'Fly', 'A creature with a fly speed can move through the air at the indicated speed if carrying no more than a light load. (Note that medium armor does not necessarily constitute a medium load.)\r\n\r\nA creature that flies can make dive attacks. A dive attack works just like a charge, but the diving creature must move a minimum of 30 feet and descend at least 10 feet. It can make only claw or talon attacks, but these deal double damage. A creature can use the run action while flying, provided it flies in a straight line.', 'en'),
	(5, 5, 'Swim', 'A creature with a swim speed can move through water at its swim speed without making Swim checks. It has a +8 racial bonus on any Swim check to perform some special action or avoid a hazard. The creature can always can choose to take 10 on a Swim check, even if distracted or endangered. The creature can use the run action while swimming, provided it swims in a straight line.', 'en');

-- Exportiere Struktur von Tabelle Development.RaceAdditionalLanguages
CREATE TABLE IF NOT EXISTS `RaceAdditionalLanguages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `LanguageId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceAdditionalLanguages_LanguageId` (`LanguageId`),
  KEY `IX_RaceAdditionalLanguages_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceAdditionalLanguages_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceAdditionalLanguages_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceAdditionalLanguages: ~0 rows (ungefähr)
DELETE FROM `RaceAdditionalLanguages`;

-- Exportiere Struktur von Tabelle Development.RaceBonusLanguages
CREATE TABLE IF NOT EXISTS `RaceBonusLanguages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `LanguageId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceBonusLanguages_LanguageId` (`LanguageId`),
  KEY `IX_RaceBonusLanguages_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceBonusLanguages_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceBonusLanguages_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceBonusLanguages: ~0 rows (ungefähr)
DELETE FROM `RaceBonusLanguages`;

-- Exportiere Struktur von Tabelle Development.RaceMovementModes
CREATE TABLE IF NOT EXISTS `RaceMovementModes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `MovementModeId` int DEFAULT NULL,
  `MovementManeuverabilityId` int DEFAULT NULL,
  `Distance` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceMovementModes_MovementManeuverabilityId` (`MovementManeuverabilityId`),
  KEY `IX_RaceMovementModes_MovementModeId` (`MovementModeId`),
  KEY `IX_RaceMovementModes_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceMovementModes_MovementManeuverabilities_MovementManeuver~` FOREIGN KEY (`MovementManeuverabilityId`) REFERENCES `MovementManeuverabilities` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceMovementModes_MovementModes_MovementModeId` FOREIGN KEY (`MovementModeId`) REFERENCES `MovementModes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceMovementModes_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceMovementModes: ~0 rows (ungefähr)
DELETE FROM `RaceMovementModes`;

-- Exportiere Struktur von Tabelle Development.Races
CREATE TABLE IF NOT EXISTS `Races` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RuleBookId` int DEFAULT NULL,
  `RuleBookPage` int DEFAULT NULL,
  `CreatureTypeId` int DEFAULT NULL,
  `CreatureSubTypeId` int DEFAULT NULL,
  `CreatureSizeCategoryId` int DEFAULT NULL,
  `StrengthBonus` int NOT NULL,
  `DexterityBonus` int NOT NULL,
  `ConstitutionBonus` int NOT NULL,
  `IntelligenceBonus` int NOT NULL,
  `WisdomBonus` int NOT NULL,
  `CharismaBonus` int NOT NULL,
  `AdditionalSkillPoints` int NOT NULL,
  `LevelAdjustment` int DEFAULT NULL,
  `ChallengeRating` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Races_RuleBookId` (`RuleBookId`),
  KEY `IX_Races_CreatureSizeCategoryId` (`CreatureSizeCategoryId`),
  KEY `IX_Races_CreatureSubTypeId` (`CreatureSubTypeId`),
  KEY `IX_Races_CreatureTypeId` (`CreatureTypeId`),
  CONSTRAINT `FK_Races_CreatureSizeCategories_CreatureSizeCategoryId` FOREIGN KEY (`CreatureSizeCategoryId`) REFERENCES `CreatureSizeCategories` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_CreatureSubTypes_CreatureSubTypeId` FOREIGN KEY (`CreatureSubTypeId`) REFERENCES `CreatureSubTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_CreatureTypes_CreatureTypeId` FOREIGN KEY (`CreatureTypeId`) REFERENCES `CreatureTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Races: ~2 rows (ungefähr)
DELETE FROM `Races`;
INSERT INTO `Races` (`Id`, `RuleBookId`, `RuleBookPage`, `CreatureTypeId`, `CreatureSubTypeId`, `CreatureSizeCategoryId`, `StrengthBonus`, `DexterityBonus`, `ConstitutionBonus`, `IntelligenceBonus`, `WisdomBonus`, `CharismaBonus`, `AdditionalSkillPoints`, `LevelAdjustment`, `ChallengeRating`, `FallbackName`, `FallbackDescription`) VALUES
	(1, 6, 12, 8, 21, 5, 0, 0, 0, 0, 0, 0, 1, 0, 0, 'Human', 'Humans typically stand from 5 feet to a little over 6 feet tall and weigh from 125 to 250 pounds, with men noticeably taller and heavier than women. Thanks to their penchant for migration and conquest, and to their short life spans, humans are more physically diverse than other common races. Their skin shades range from nearly black to very pale, their hair from black to blond (curly, kinky, or straight), and their facial hair (for men) from sparse to thick. Plenty of humans have a dash of nonhuman blood, and they may demonstrate hints of elf, orc, or other lineages. Members of this race are often ostentatious or unorthodox in their grooming and dress, sporting unusual hairstyles, fanciful clothes, tattoos, body piercings, and the like. Humans have short life spans, reaching adulthood at about age 15 and rarely living even a single century.'),
	(2, 6, 14, 8, 22, 5, 0, 0, 2, 0, 0, -2, 0, NULL, 0, 'Dwarf', 'Dwarves stand only 4 to 4-1/2 feet tall, but they are so broad and compact that they are, on average, almost as heavy as humans. Dwarf men are slightly taller and noticeably heavier than dwarf women. Dwarves\' skin is typically deep tan or light brown, and their eyes are dark. Their hair is usually black, gray, or brown, and worn long. Dwarf men value their beards highly and groom them very carefully. Dwarves favor simple styles for their hair, beards, and clothes. Dwarves are considered adults at about age 40, and they can live to be more than 400 years old.');

-- Exportiere Struktur von Tabelle Development.RaceSenses
CREATE TABLE IF NOT EXISTS `RaceSenses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `SenseId` int DEFAULT NULL,
  `Distance` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSenses_RaceId` (`RaceId`),
  KEY `IX_RaceSenses_SenseId` (`SenseId`),
  CONSTRAINT `FK_RaceSenses_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceSenses_Senses_SenseId` FOREIGN KEY (`SenseId`) REFERENCES `Senses` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceSenses: ~0 rows (ungefähr)
DELETE FROM `RaceSenses`;

-- Exportiere Struktur von Tabelle Development.RaceSpecialAbilities
CREATE TABLE IF NOT EXISTS `RaceSpecialAbilities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSpecialAbilities_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceSpecialAbilities_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceSpecialAbilities: ~0 rows (ungefähr)
DELETE FROM `RaceSpecialAbilities`;

-- Exportiere Struktur von Tabelle Development.RaceSpecialAbilityTranslations
CREATE TABLE IF NOT EXISTS `RaceSpecialAbilityTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceSpecialAbilityId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSpecialAbilityTranslations_RaceSpecialAbilityId` (`RaceSpecialAbilityId`),
  CONSTRAINT `FK_RaceSpecialAbilityTranslations_RaceSpecialAbilities_RaceSpec~` FOREIGN KEY (`RaceSpecialAbilityId`) REFERENCES `RaceSpecialAbilities` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceSpecialAbilityTranslations: ~0 rows (ungefähr)
DELETE FROM `RaceSpecialAbilityTranslations`;

-- Exportiere Struktur von Tabelle Development.RaceTranslations
CREATE TABLE IF NOT EXISTS `RaceTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceTranslations_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceTranslations_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RaceTranslations: ~2 rows (ungefähr)
DELETE FROM `RaceTranslations`;
INSERT INTO `RaceTranslations` (`Id`, `RaceId`, `Name`, `Description`, `CultureName`) VALUES
	(5, 1, 'Human', 'Humans typically stand from 5 feet to a little over 6 feet tall and weigh from 125 to 250 pounds, with men noticeably taller and heavier than women. Thanks to their penchant for migration and conquest, and to their short life spans, humans are more physically diverse than other common races. Their skin shades range from nearly black to very pale, their hair from black to blond (curly, kinky, or straight), and their facial hair (for men) from sparse to thick. Plenty of humans have a dash of nonhuman blood, and they may demonstrate hints of elf, orc, or other lineages. Members of this race are often ostentatious or unorthodox in their grooming and dress, sporting unusual hairstyles, fanciful clothes, tattoos, body piercings, and the like. Humans have short life spans, reaching adulthood at about age 15 and rarely living even a single century.', 'en'),
	(6, 2, 'Dwarf', 'Dwarves stand only 4 to 4-1/2 feet tall, but they are so broad and compact that they are, on average, almost as heavy as humans. Dwarf men are slightly taller and noticeably heavier than dwarf women. Dwarves\' skin is typically deep tan or light brown, and their eyes are dark. Their hair is usually black, gray, or brown, and worn long. Dwarf men value their beards highly and groom them very carefully. Dwarves favor simple styles for their hair, beards, and clothes. Dwarves are considered adults at about age 40, and they can live to be more than 400 years old.', 'en');

-- Exportiere Struktur von Tabelle Development.RuleBooks
CREATE TABLE IF NOT EXISTS `RuleBooks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EditionId` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PublishedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RuleBooks_EditionId` (`EditionId`),
  CONSTRAINT `FK_RuleBooks_Editions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `Editions` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=114 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RuleBooks: ~110 rows (ungefähr)
DELETE FROM `RuleBooks`;
INSERT INTO `RuleBooks` (`Id`, `EditionId`, `FallbackName`, `Abbreviation`, `FallbackDescription`, `PublishedAt`) VALUES
	(4, 7, 'Dungeon Master\'s Guide I', 'DMG', 'Weave exciting tales of heroism filled with magic and monsters. Within these pages, you\'ll discover the tools and options you need to create detailed worlds and dynamic adventures for your players to experience in the Dungeons & Dragons roleplaying game.\nThe revised Dungeon Master\'s Guide is an essential rulebook for Dungeon Masters of the D&D game. The Dungeon Master\'s Guide has been reorganized to be more user friendly. It features information on running a D&D game, adjudicating play, writing adventures, non-player characters (including non-player character classes), running a campaign, characters, magic items (including intelligent and cursed items, and artifacts), and a dictionary of special abilities and conditions. Changes have been made to the item creation rules and pricing, and prestige classes new to the Dungeon Master\'s Guide are included (over 10 prestige classes). The revision includes expanded advice on how to run a campaign and instructs players on how to take full advantage of the tie-in D&D miniatures line.', NULL),
	(5, 7, 'Monster Manual I', 'MM', 'Fearsome and formidable foes lurk within. Encounter a horde of monsters armed and ready to battle your boldest heroes or fight alongside them. The fully illustrated pages of this book are overrun with all the creatures, statistics, spells, and strategies you need to challenge the heroic characters of any Dungeons & Dragons role-playing game.\nOver 200 creeps, critters, and creatures keep players on their toes. From aboleths to zombies, the revised Monster Manual holds a diverse cast of enemies and allies essential for any Dungeons & Dragons campaign. There are hundreds of monsters ready for action, including many new creatures never seen before. The revised Monster Manual now contains an adjusted layout that makes monster statistics easier to understand and use. It has 31 new illustrations and a new index, and contains expanded information on monster classes and playing monsters as heroes, along with information on how to take full advantage of the tie-in D&D miniatures line planned for the fall of 2003 from Wizards of the Coast, Inc.', NULL),
	(6, 7, 'Player\'s Handbook I', 'PH', '', NULL),
	(7, 13, 'Dragonmarked', 'Dra', ' Dragonmarked offers an in-depth look at the power of dragonmarks and the thirteen dragonmarked houses of the Eberron world. It also provides exciting new options for players with dragonmarked characters, including role-playing hooks, new feats, new prestige classes, and new spells.', NULL),
	(8, 13, 'Faiths of Eberron', 'FE', '', NULL),
	(9, 13, 'Magic of Eberron', 'MoE', '', NULL),
	(10, 13, 'Races of Eberron', 'RE', 'Races of Eberron expands on the information presented about the four new Eberron races (warforged, shifter, changeling and kalashtar) as well as giving more information regarding the common races and how they differ on Eberron. It also features the ubiquitous slew of feats, prestige classes, spells and magic items to immerse your character more fully in the Eberron world.', NULL),
	(11, 13, 'Sharn: City of Towers', 'Sh', '', NULL),
	(12, 13, 'Eberron Campaign Setting', 'ECS', '', NULL),
	(13, 13, 'Player\'s Guide to Eberron', 'PE', '', NULL),
	(14, 13, 'Secrets of Sarlona', 'SoS', 'Secrets of Sarlona explores the continent of Sarlona for the first time. It gives players and Dungeon Masters their first real glimpse inside the empire of Riedra, home of the Inspired and the kalashtar. It also explores the mysteries of Adar, a nation isolated from the rest of the world, and never-before seen locations. Secrets of Sarlona also presents new options (feats, prestige classes, spells, and magic items) available to Sarlonan characters and characters with psionics. ', NULL),
	(15, 13, 'Secrets of Xen\'drik', 'SX', '', NULL),
	(16, 8, 'City of Splendors: Waterdeep', 'CSW', '*City of Splendors: Waterdeep* offers an in-depth examination of the great city of Waterdeep in the Forgotten Realms setting. An overview of the city includes history, a who?s who, information on laws, and rules for running and playing in a Watered havian campaign. Information on the people of Waterdeep covers non-player characters, arcane schools, armed forces, guilds, nobility, prestige classes specific to the city, and more. Also included in the book are discussions of specific Waterdeep locales, adventure locales, and new monsters. An extensive appendix gives information on new equipment, magic items,  psionic powers, poisons, spells, and more.', NULL),
	(17, 3, 'Enemies and Allies', 'EA', '', NULL),
	(18, 2, 'Faiths & Pantheons', 'FP', '', NULL),
	(19, 2, 'Forgotten Realms Campaign Setting', 'FRCS', '', NULL),
	(20, 2, 'Magic of Faerun', 'Mag', '', NULL),
	(21, 2, 'Monster Compendium: Monsters of Faerûn', 'Mon', '', NULL),
	(22, 8, 'Player\'s Guide to Faerûn', 'PG', '', NULL),
	(23, 2, 'Races of Faerun', 'Rac', '', NULL),
	(24, 8, 'Serpent Kingdoms', 'SK', 'Chilling fireside tales describe the fell plans and foul actions of the horrors known as the Scaled Ones: lizardfolk, nagas, yuan-ti, and their sinister creator race, the sarrukh. Infinitely patient and ruthless, the insidious serpentfolk seek to enslave all of Faer?n\'s other races to breed them like cattle. For those bold enough to peer within, Serpent Kingdoms offers an unsettlingly detailed look at the malevolent serpentfolk and lizard races of the Forgotten Realms game setting.', NULL),
	(25, 8, 'Shining South', 'ShS', '', NULL),
	(26, 8, 'Dragons of Faerun', 'DrF', '', NULL),
	(27, 8, 'Champions of Ruin', 'CR', '', NULL),
	(28, 8, 'Champions of Valor', 'CV', '', NULL),
	(29, 8, 'Lost Empires of Faerun', 'LE', '', NULL),
	(30, 8, 'Power of Faerun', 'PF', '', NULL),
	(31, 2, 'Unapproachable East', 'Una', 'Tales from beyond the Easting Reach are told with awed voices and hushed tones. Known to most of Faerun as the homeland of the Simbul, the hathrans, and the Red Wizards, the Unapproachable East is filled with dark secrets, insidious plots, and untold adventure. Discover the people, politics, cities, and societies of the region, along with the monsters, nefarious organizations, and other perils that await unwary travelers in this treacherous corner of the Forgotten Realms game setting.', NULL),
	(32, 8, 'Underdark', 'Und', '', NULL),
	(33, 3, 'Arms and Equipment Guide', 'AE', '', NULL),
	(34, 3, 'Book of Challenges: Dungeon Rooms, Puzzles, and Traps', 'BC', 'Danger Around Every Corner and Behind Every Screen!\nThe greatest threat to any adventuring party is a devious Dungeon Master. This book is spring-loaded with ideas, both subtle and sinister, that will ensure every gaming session is appropriately hazardous, including:\n* Over fifty encounters designed to be dropped into any campaign.\n* Scalable scenarios that can be pitted against characters from 1st to 20th level.\n* Advice for creating your own deceptive and deadly situations.\nDungeon Masters who want to keep their players on their toes will be inspired by the invaluable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual.', NULL),
	(35, 3, 'Book of Vile Darkness', 'BV', '"Only the most indomitable minds dare to look upon the malevolent thoughts and forbidden secrets bound herein. This corrupt tome is filled with deplorable wisdom, malignant ideas, and descriptions of creatures, rites, and practices most foul. Evil permeates every word and image inscribed within it."\n-- Orcus, Demon Prince of the Undead\nThis sourcebook for the Dungeons & Dragons game is intended for mature audiences and provides a Dungeon Master with unflinching access to subject matter that will broaden any campaign. Included in a detailed look at the nature of evil and the complex challenge of confronting the many dilemmas found within its deepest shadows. Along with wicked spells, wondrous items, and artifacts, Book of Vile Darkness also provides descriptions and statistics for a host of abominable monsters, archdevils, and demon princes to pit againt the noblest of heroes.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual.', NULL),
	(36, 5, 'Defenders of the Faith: A Guidebook to Clerics and Paladins', 'DF', 'Divine dedication powers these crusaders.\nThis book spotlights the champions of deities in the D&D game, clerics and paladins. It\'s packed with ways to customize cleric and paladin characters, including: \n* New feats, prestige classes, weapons, and equipment\n* More uses for turning checks, and new magic items and spells designed specially for clerics and paladins\n* Information about special organizations such as the Laughing Knives and the Stargazers\n* Detailed maps of temples that players and Dungeon Masters can use as bases of operation or as enemy structures that must be brought down\n\n\nIndispensable to both players and Dungeon Masters, this book adds excitement to any campaign.', NULL),
	(37, 3, 'Deities and Demigods', 'DD', 'Source of All Divine Power\nThe names of Pelor, Loki, Athena, Osiris, and their kind are invoked by the devout as well as the desperate. With abilities that reach nearly beyond the scope of mortal imagination, the splendor of the gods humbles even the greatest of heroes.\nThis supplement for the D&D game provides everything you need to create and call upon the most powerful beings in your campaign. Included are descriptions and statistics for over seventy gods from four fully detailed pantheons. Along with suggestions for creating your own gods, Deities and Demigods also includes information on advancing characters to godhood.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(38, 7, 'Dungeon Master\'s Guide II', 'DMG2', '', NULL),
	(39, 3, 'Epic Level Handbook', 'EL', 'Legends Begin Here\nSongs are sung and tales are told of heroes who have advanced beyond most adventuring careers. They confront mightier enemies and face deadlier challenges, using powers and abilities that rival even the gods.\nThis supplement for the D&D game provides everything you need to transcend the first twenty levels of experience and advance characters to virtually unlimited levels of play. Along with epic magic items, epic monsters, and advice on running an epic campaign, the Epic Level Handbook also features epic NPCs from the Forgotten Realms and Greyhawk campaign settings.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(40, 9, 'Fiend Folio', 'FF', '', NULL),
	(41, 3, 'Manual of the Planes', 'MP', 'Visit New Dimensions\nThe most powerful adventurers know that great rewards--and great perils--await them beyond the world they call home. From the depths of Hell to the heights of Mount Celestia, from the clockwork world of Mechanus to the swirling chaos of Limbo, these strange and terrifying dimensions provide new challenges to adventurers who travel there. Manual of the Planes is your guidebook on a tour of the multiverse.\nThis supplement for the D&D game provides everything you need to know before you visit other planes of existence. Included are new prestige classes, spells, monsters, and magic items. Along with descriptions of dozens of new dimensions, Manual of the Planes includes rules for creating your own planes.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(42, 5, 'Masters of the Wild: A Guidebook to Barbarians, Druids, and Rangers', 'MW', 'These Forces of Nature Can Weather Any Storm\nBarbarians, druids, and rangers are the rugged and noble champions of untamed lands. This book teems with new ways to customize even the most seasoned characters, including:\n\n\n* New feats, weapons, spells, and magic items.\n* Improved, more detailed rules for the wild shape ability.\n* New prestige classes such as the frenzied berserker, the windrider, and the oozemaster.\n* A new type of magic item -- the infusion.\n\n\nDungeon Masters and players who want to add a new dimension to their barbarians, druids, and rangers will uncover a cache of indispensable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(43, 7, 'Monster Manual II', 'MM2', 'Even Greater Threats Await!\nAs heroes grow in power, they seek out more formidable adversaries. Whether sinister or seductive, ferocious or foul, the creatures lurking within these pages will challenge the most experienced characters of any campaign.\nThis supplement for the D&D game unleashes a horde of monsters to confront characters at all levels of play, including several with Challenge Ratings of 21 or higher. Inside are old favorites such as the death knight and the gem dragons, as well as all-new creatures such as the bronze serpent, the effigy, and the fiendwurm. Along with updated and expanded monster creation rules, Monster Manual II provides an inexhaustible source of ways to keep even the toughest heroes fighting and running for their lives.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook and the Dungeon Master\'s Guide. A player needs only the Player\'s Handbook.', NULL),
	(44, 3, 'Psionics Handbook', 'PsH3', '', NULL),
	(45, 3, 'Savage Species', 'SS', 'A New Breed of Adventurer\nWhether wondrous or wicked, some monsters have a calling that reaches beyond the ordinary existence of their kind. Traveling alongside other intrepid characters, these heroic creatures carve their places in legend with sword, spell, tooth, and claw.\nThis supplement for the D&D game provides everything you need to play a monster as a character or to make the monsters your heroes fight even more formidable. Inside are over 50 all-new monster classes that show how creatures develop their characteristics and abilities as they gain levels. Along with new prestige classes and monster templates, Savage Species also features new feats, spells, magic items, and more.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook and the Monster Manual.', NULL),
	(46, 5, 'Song and Silence: A Guidebook to Bards and Rogues', 'SaS', 'Finesse and Versatility Make Powerful Allies\nBards and rogues rely on a stunning array of skills and abilities to give them an edge over any adversary. Packed with new ways to customize even the most artful characters this book includes:\n\n* New feats, prestige classes, weapons, spells, magic items, and equipment.\n* Complete guidelines for trapmaking, including 90 sample traps.\n* Descriptions of a wide range of thieves\' guilds and bardic colleges.\n* Detailed rules for flanking opponents in combat.\n\nDungeon Masters and players who want to add a new dimension to their bards and rogues will find a wealth of indispensable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(47, 3, 'Stronghold Builder\'s Guidebook', 'SB', 'Defenses Wrought of Mortar and Magic\nHeroes need impregnable fortresses to assault, wondrous towers to explore, and majestic castles to protect. This book is stocked with everything needed to design any fortified structure imaginable, including:\n\n* Over 150 new magic items\n* More than two dozen magical augmentations for stronghold walls\n* Rules for magic portals, mobile strongholds, and trap creation\n* Five complete strongholds, including maps, ready for immediate use\n\nPlayers and Dungeon Masters who want to create customized strongholds will find all the construction materials they need within these pages.\nTo use this accessory, a player or Dungeon Master also needs the Player\'s Handbook.', NULL),
	(48, 5, 'Sword and Fist: A Guidebook to Monks and Fighters', 'SF', '', NULL),
	(49, 5, 'Tome and Blood: A Guidebook to Wizards and Sorcerers', 'TB', 'A Spell Is Better than a Thousand Words\nEvery mystic library reserves a place for this single potent volume of arcane lore. It\'s packed with ways to customize sorcerer and wizard characters, including:\n\n* New feats, spells, and magic items.\n* New prestige classes, including the dragon disciple, fatespinner, and pale master.\n* Information about special organizations such as the Broken Wands and the Arcane Order.\n* Maps of a mages\' guildhall and a home that a sorcerer and a wizard share.\n\nTome and Blood is indispensable to players and Dungeon Masters who want to add a new dimension to sorcerers and wizards.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(50, 9, 'Book of Exalted Deeds', 'BE', 'Strike Down Evil with the Sword of Enlightenment\nOnly those who are pure in word, thought, and deed may look upon the knowledge gathered within this blessed tome. For the blinding truths inscribed within offer nothing but redemption or destruction for the wicked. May these consecrated pages forever illuminate the paths of the righteous.\n-- Raziel the Crusader, ruler of the Platinum Heaven\nAs the Book of Vile Darkness was a resource book on the most evil elements of campaign play, the Book of Exalted Deeds focuses instead on the availability of good resources and features in the D&D spectrum.\nIncluded are new exalted feats, prestige classes, races, spells, magic items, and descriptions and statistics for a host of creatures and celestial paragons to ally with virtuous characters. The Book of Exalted Deeds also provides descriptions and statistics for a host of creatures and celestial paragons to ally with virtuous characters.\nBook of Exalted Deeds is the second title in the line of Dungeons & Dragons products specifically aimed at a mature audience. \nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(51, 14, 'CityScape', 'Ci', 'As Deadly as Any Dungeon\nThere\'s more to adventuring than crawling around in dungeons. The city holds many avenues of peril and intrigue. It teems with adventure and offers unsurpassed opportunities and challenges. Dark alleys, busy guildhalls, rowdy taverns, fetid sewers, and palatial manors hold secrets to be discovered and mysteries to be explored.\nThis supplement for the DUNGEONS & DRAGONS game reveals the city in all its grandeur and grimness. It makes the urban dungeon feel alive with politics and power, especially through influential guilds. This tome also describes new feats, spells, urban terrain, hazards, and monsters guaranteed to make the party\'s next visit to the city a vibrant and exhilarating event.', NULL),
	(52, 11, 'Complete Adventurer', 'CAd', 'Sharpen Your Survival Skills\nTaverns are filled with tales of talented heroes and their breathtaking exploits. The prowess and ingenuity of these remarkable characters gives them the edge to succeed where others cannot.\nThis supplement for the D&D game provides everything you need to sharpen the skills and enhance the abilities of characters of any class. Along with new base classes, prestige classes, feats, spells, monsters, and magic items, Complete Adventurer provides alternate uses for skills and other options that expand the capabilities of the most versatile heroes.', NULL),
	(53, 11, 'Complete Arcane', 'CAr', 'Master Eldritch Secrets and Formidable Power\nMyth and mystery surround those who wield the awe-inspiring might of arcane magic. Whether through ancient knowledge, innate talent, or supernatural gift, these formidable and versatile spell-casters command powers beyond measure.\nThis supplement for the D&D game provides everything you need to expand the power of arcane magic for characters of any class. Along with new base classes, prestige classes, feats, spells, monsters, and magic items, Complete Arcane provides guidelines for spell duels, arcane organizations, and other aspects of a campaign world imbued with magic.', NULL),
	(54, 11, 'Complete Divine', 'CD', 'Wield Power Granted by the Gods\nLegends tell of brave champions whose unwavering faith earned them the favor of the gods. Empowered by the might and magic of their deity, these devoted characters transcend the realm of mere heroes.\nThis supplement for the D&D game provides everything you need to create divinely inspired characters of any class. Along with new base classes, prestige classes, feats, spells, magic items, and relics, Complete Divine also provides guidelines for incorporating religion -- from mysterious cults to powerful theocracies -- into your campaign.\nCover Illustration: Matt Cavotta. (The credits in the printed product incorrectly credited the cover art to another artist. We apologize to Matt for this error.)', NULL),
	(55, 11, 'Complete Champion', 'CC', 'New options for heroes with a divine cause.\nComplete Champion focuses on the divine champion archetype and provides new rules options for characters who enjoy battling for a cause, defeating foes using divine power, and going on quests that mean more than simply defeating the bad guy and grabbing the treasure. This book also helps Dungeon Masters run quest-themed campaigns and adventures.\nIn addition to providing various archetypes for characters, Complete Champion includes new feats and prestige classes. The book features dozens of deity- and belief-themed organizations, turning religion and holy (or unholy) power into something characters of all classes can use. For the Dungeon Master, this book contains information on constructing and running quests and holy missions. It assists the DM in helping all characters in the party to pursue divine paths simultaneously.', NULL),
	(56, 11, 'Complete Mage', 'CM', 'Arcane Power at Your Fingertips\nEvery sentient creature is born with some potential to work magic. However, true mastery of arcane magic requires skill, practice, and power beyond the reach of common folk specifically, the power to harness raw magic and shape it into a desired effect. You are among those gifted few who have learned to channel arcane magic, shaping it to serve your creative or destructive whims.\nThis D&D supplement is intended for players and Dungeon Masters. In addition to providing the definitive treatise on arcane magic, it expands the character options available to users of arcane magic, including bards, sorcerers, wizards, assassins, warlocks, and wu jen. Herein you\'ll find never-before-seen prestige classes, spells and invocations, magic items, alchemical items, heritage feats, and reserve feats (a new type of feat that grants special abilities to those who remain charged with magical power). Alternative class features give other character classes from the barbarian to the rogue a little taste of what it\'s like to be an arcanist without sacrificing their core identities.', NULL),
	(57, 11, 'Complete Psionic', 'CP', '', NULL),
	(58, 11, 'Complete Scoundrel', 'CS', 'Fair Fights are for Suckers\nIn a world filled with monsters and villains, a little deception and boldness goes a long way. You know how to take advantage of every situation, and you don\'t mind getting your hands dirty. Take the gloves off? Ha! You never put them on. You infuriate your foes and amaze your allies with your ingenuity, resourcefulness, and style. For you, every new predicament is an opportunity in disguise, and with each sweet victory your notoriety grows. That is how legends are made.\nThis D&D supplement gives you everything you need to get the drop on your foes and escape sticky situations. In addition to new feats, spells, items, and prestige classes, Complete Scoundrel presents new mechanics that put luck on your side and a special system of skill tricks that allow any character to play the part of a scoundrel. Tricky tactics aren\'t just for rogues anymore. ', NULL),
	(59, 11, 'Complete Warrior', 'CW', 'Forge your name in battle!\nThe Complete Warrior provides you with an in-depth look at combat and provides detailed information on how to prepare a character for confrontation.\nThis title was not only compiled from various D&D sources, but contains new things as well, including new battle-oriented character classes, prestige classes, combat maneuvers, feats, spells, magic items, and equipment. The prestige classes included have been revised and updated based on player feedback, and there are rules for unusual combat situations. The Complete Warrior will assist all class types, including those classes not typically associated with melee combat. There are also tips on running a martially focused campaign and advice on how to make your own prestige classes and feats.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(60, 9, 'Dragon Magic', 'DM', '', NULL),
	(61, 14, 'Dungeonscape', 'Du', 'Welcome to the Dungeon!\nSince the dawn of the DUNGEONS & DRAGONS game, the dungeon has remained a place of mystery, excitement, and danger. Purple worms burrow through the earth, eager for their next meal. Savage orcs lurk within the darkness, ready to surge forth and lay waste to civilized lands. Strange cults, mutated monsters, and forgotten gods hide within the choking darkness of the dungeon\'s halls. Nowhere else offers greater prospects for wealth, magic, and power. Yet the horrors that lurk beneath the world never give up their treasures without a fight....\nThis D&D supplement presents a refreshing new take on dungeon adventures. It shows Dungeon Masters how to inject excitement, innovation, and thrilling adventure into their dungeons. New rules for encounter traps allow DMs to build deadly snares to catch the unwary. For players, the factotum class is a cunning wanderer, a jack-of-all-trades who can cope with anything the dungeon throws at him. New equipment, feats, and prestige classes give adventurers the tools they need to survive the dark beneath the earth.', NULL),
	(62, 9, 'Exemplars of Evil', 'EE', 'The Exemplars of Evil supplement shows Dungeon Masters how to construct memorable campaign villains and presents nine ready-to-play villains of various levels that can be easily incorporated into any D&D campaign. Each villainous entry provides complete statistics for the villain (or villains), as well as adventure seeds, campaign hooks, pregenerated minions, and a fully detailed lair.\nROBERT J. SCHWALB is a staff designer and developer for Green Ronin Publishing. His design credits for Wizards include the Player\'s Handbook II, Tome of Magic, and Fiendish Codex II: Tyrants of the Nine Hells supplements. Robert lives in Tennessee with his patient wife and pride of cats.', NULL),
	(63, 9, 'Expanded Psionics Handbook', 'XPH', 'Tap into the power of the mind.\nThrough sheer force of will, a psionic character can unleash awesome powers that rival any physical force or magical energy. Within these pages, you will discover the secrets of unlocking the magic of the mind -- the art of psionics.\nWith updated and increased content, including a newly balanced psionics power system, the Expanded Psionics Handbook easily integrates psionic characters, powers, and monsters into any Dungeons & Dragons campaign.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(64, 9, 'Fiendish Codex I: Hordes of the Abyss', 'FCI', '', NULL),
	(65, 9, 'Fiendish Codex II: Tyrants of the Nine Hells', 'FCII', 'The evil that finds you might not be the one that you expect. Learn more about devils and their insidious ways in Fiendish Codex II, where both Dungeon Masters and players alike can find something useful to either enhance the evil of their devilish villains or fight it. For a sample of what\'s in store for you in this tome, take a look at Dis, a list of new feats, the hellfire warlock prestige class, a list of new spells, and the assassin devil.', NULL),
	(66, 14, 'Frostburn', 'Fr', 'Survival at Sub-Zero\nMarrow-chilling conditions, deadly hazards, and other dangers threaten explorers of frostfell environments. Whether traveling through polar regions and frozen mountaintops to ice-glazed dungeons and the Ice Wastes of the Abyss, a wintry grave awaits those who venture forth unprepared.\nThis supplement for the D&D game explores the impact of arctic conditions and extreme cold-weather environments on every aspect of game play. Along with rules for adapting to, navigating through, and surviving hazardous cold-weather conditions and terrain, Frostburn also includes new spells, feats, magic items, prestige classes, and monsters associated with icy realms.', NULL),
	(67, 9, 'Heroes of Battle', 'HB', 'Prepare for WarGreat conflicts erupt between rival nations and threaten to sweep across entire continents. As armies clash in epic battles, the actions of a handful of bold heroes can turn the tide of war. Whether in the thick of combat or on a secret mission of dire importance, brave champions have an impact that echoes across the battlefield and resounds through the ages.\nThis supplement for the D&D game reveals the pivotal roles characters can play in the midst of great battles. With rules and options for creating or playing adventures on and around battlefields, Heroes of Battle plunges characters into wartime situations and challenges them with climactic battles of epic proportions.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook and Dungeon Master\'s Guide. A player needs only the Player\'s Handbook.\nHeroes of Battle provides everything one needs to know to play a battle-oriented D&D campaign. You can build military characters with new feats, spells, uses for traditional spells, and prestige classes. Information is given on tools specific to the battlefield, including siege engines, weapons, magic items, steeds, and other exotic mounts. Battlefield terrain aspects are discussed with plenty of illustrative maps and new rules. Specific types of battlefield encounters are discussed in detail, and the book provides specific detail on designing battlefields.', NULL),
	(68, 9, 'Heroes of Horror', 'HH', 'Heroes of Horror  provides everything players and Dungeon Masters need to play and run a horror-oriented campaign or integrate elements of creepiness & tension into their existing campaigns. Players can develop heroes or anti-heroes using new feats, new spells, new base classes and prestige classes, and new magic items. The book presents new mechanics for different types of horror, including rules for dread and tainted characters, as well as plenty of new horrific monsters and adventure seeds. Different types and genres of horror are discussed in detail.', NULL),
	(69, 9, 'Libris Mortis: The Book of the Dead', 'LM', 'Nightmares from Beyond the Grave\nHushed voices tell spine-chilling tales of encounters with the walking dead and other unliving horrors. No other creatures have evoked such fear and fascination as this dreadful menagerie of malevolent spirits and mindless shells.\nThis supplement for the D&D game presents a comprehensive overview of the undead. You\'ll uncover information for creating, customizing, and combating undead characters and monsters -- including strategies and tactics commonly employed by undead and those who hunt them. Libris Mortis: The Book of Undead also provides new rules, feats, spells, and prestige classes, along with a host of new monsters and monster templates.', NULL),
	(70, 9, 'Lords of Madness', 'LoM', 'Unnatural Creatures of Unspeakable Evil\nTrembling hands have recorded horrifying stories of encounters with aboleths, beholders, mind flayers, and other aberrations. The victims of these alien creatures are quickly overwhelmed by mind-numbing terror -- their only comfort is the hope for a quick death.\nThis supplement for the D&D game presents a comprehensive look at some of the most bizarre creatures ever to invade the world of fantasy roleplaying. Along with information about the physiology, psychology, society, and schemes of these strange beings, you\'ll find spells, feats, tactics, and tools commonly employed by those who hunt them. Lords of Madness: The Book of Aberrations also provides new rules, prestige classes, monsters, sample encounters, and fully developed NPCs ready to instill fear in any hero.', NULL),
	(71, 9, 'Magic Item Compendium', 'MIC', '', NULL),
	(72, 9, 'Magic of Incarnum', 'MoI', 'This supplement introduces a magical substance called incarnum into the D&D game. With this book, the players characters can meld incarnum the power of souls living, dead, and unborn into magical items and even their own bodies, granting them special attacks, defenses, and other abilities (much as magic items and spells do). Incarnum can be shaped and reshaped into new forms, giving characters tremendous versatility in the dungeon and on any battlefield.\n This book also features new classes, prestige classes, feats, and other options for characters wishing to explore the secrets of incarnum, as well as rules and advice for including incarnum in a D&D campaign.', NULL),
	(73, 9, 'Miniatures Handbook', 'MH', 'Cries of battle fill the air!\nThe Miniatures Handbook gives you expanded rules for regular Dungeons & Dragons game play as well as guidelines for skirmishes and mass combats.\nIncluded are new base classes, new prestige classes, 30 new feats, more than 65 new spells, new magic items, and weapon special abilities. Also, there are more than 35 new monsters, including formidable aspects of deities and archfiends.\nExpand your battlefield with complete rules for skirmishes, squad-based fights, and even mass battles. There are also mechanics for random dungeons and rules for miniatures battle campaigns.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(74, 7, 'Monster Manual III', 'MM3', 'Encounter additional adversaries and allies\nLairing within these pages is an unstoppable wave of creatures ranging from ambush drake to zezir. A menagerie of beasts, behemoths and other ferocious beings, the monsters presented here are well prepared to battle or befriend the characters of any campaign.\nThis supplement for the D&D game offers a fully illustrated array of new creatures such as the boneclaw, eldritch giant, and web golem. Also included are advanced versions of some monsters as well as tactics sections to help DMs effectively run more complex creatures. Additionally, many entries contain information about where monsters are likely to appear in the Forgotten Realms and Eberron campaign settings.', NULL),
	(75, 7, 'Monster Manual IV', 'MM4', 'An indispensable resource containing new monsters suitable for any Dungeons & Dragons game.\nMonster Manual IV is the most recent volume in the bestselling Monster Manual line. Sure to be popular with both Dungeon Masters and players, this supplement to the D&D game provides descriptions for a vast array of new creatures. Each monster is illustrated and features a new stat block format that facilitates faster gameplay. In addition, the book includes sample encounters, pregenerated treasure hoards, and sidebars on how to incorporate the creatures in a Forgotten Realms or Eberron campaign. This product is tied to 2006\'s Year of Dragons theme, which is a key marketing platform across the D&D RPG, novels, and miniatures brands.', NULL),
	(76, 7, 'Monster Manual V', 'MM5', 'New monsters ideal for any Dungeons & Dragons game.\nMonster Manual V is the most recent volume in the best-selling Monster Manual line. This 224-page D&D supplement presents a fully illustrated horde of new monsters, as well as ready-to-play variations of previously existing monsters. In addition, this supplement features maps of monster lairs, sample encounters, and tactics sections to help Dungeon Masters run the more complex creatures. Additionally, many entries contain information about where monsters are likely to appear in the Forgotten Realms and Eberron campaign settings.', NULL),
	(77, 9, 'Planar Handbook', 'PlH', 'Explore Never-Ending Realms of Adventure\nOnly the most exceptional characters dare tread the infinite paths of the planes. From Sigil, the City of Doors, to the Blinding Tower at the heart of the Plane of Shadow, to the Elemental Plane of Fire\'s storied City of Brass, countless perilous locations in the multiverse await bold heroes armed with remarkable talents and abilities, more than a little courage, and above all, knowledge.\nThis supplement for the D&D game provides everything you need to create and play characters prepared for the odyssey of planar travel, including new planar races, feats, equipment, spells, and magic items. The Planar Handbook also introduces the power of planar touchstones, along with details and advice for visiting dozens of planar sites.', NULL),
	(78, 7, 'Player\'s Handbook II', 'PH2', 'A follow-up to the Player\'s Handbook designed to aid players and provide more character options.\nThe Player\'s Handbook II builds upon existing materials in the Player\'s Handbook. This is the first direct followup to the best-selling and most used D&D rulebook. It is specifically designed to expand the options available for players by both providing new material and increasing the uses for existing rules. Included are chapters on character race, background, classes, feats, spells, character creation, and character advancement. New rules include racial affiliations that make race matter as a character advances in level, new character classes and alternate class features for existing classes, new feats, tools for rapid character creation, and additional organization and teamwork benefits -- an option first introduced in Dungeon Master\'s Guide II and Heroes of Battle.', NULL),
	(79, 16, 'Races of Destiny', 'RD', 'Heroes Adapted to Adventure\nHailing from towns and villages in every corner of the world, resourceful and resilient adventurers emerge from among the races of destiny: humans, half-elves, half-orcs, and illumians. With an unparalleled drive to explore and experience, these diverse individuals have created names to last throughout the ages.\nThis supplement for the D&D game provides detailed information on the psychology, society, culture, behavior, religion, folklore, and other aspects of the races of destiny, including the illumians -- a new race presented here. In addition to new subraces and monster races playable as characters, Races of Destiny also provides new prestige classes, feats, spells, magic items, equipment, and guidelines for crafting memorable adventures within human settlements.', NULL),
	(80, 16, 'Races of Stone', 'RS', '', NULL),
	(81, 16, 'Races of the Dragon', 'RDr', ' A new D&D sourcebook detailing races descended from dragons. \n Races of the Dragon provides D&D players and Dungeon Masters with an in-depth look at races descended from or related to dragons. In addition to exploring the fan-favorite kobold race, Races of the Dragon introduces two new races, dragonborn and spellscales, and provides information on half-dragons. The dragonborn are a transitive race, an exciting new concept that allows players to transform from their initial race into a new one. This book also includes a wealth of cultural information and new prestige classes, feats, equipment, spells, and magic items. \n Gwendolyn F.M. Kestrel works for Wizards of the Coast, Inc. as a game designer. Her previous design credits include the Races of Eberron (tm), Monster Manual (tm) III, and Underdark (tm) roleplaying games. Jennifer Clarke Wilkes is an editor for Wizards of the Coast, Inc. She works primarily on the Dungeons & Dragons Miniatures line but has edited various roleplaying game books. She co-authored Savage Species (tm) and Sandstorm (tm). \n Kolja Raven Liquette is best known for authoring The Waking Lands web site. He has also published articles in Dragon Magazine. His previous publishing credits include Weapons of Legacy (tm). ', NULL),
	(82, 16, 'Races of the Wild', 'RW', 'Heroes Tempered by Nature\nFrom within verdant forests, among nomadic caravans, or atop soaring cliffsides, courageous adventurers arise from the people known as the races of the wild: elves, halflings, and raptorans. Living in harmony with the natural world, these noble individuals embark on grand adventures that become fireside tales for generations to come.\nThis supplement for the D&D game provides detailed information on the psychology, society, culture, behavior, religion, folklore, and other aspects of the races of the wild, including raptorans -- a new race presented here. In addition to new humanoids and monster races playable as characters, Races of the Wild also provides new prestige classes, feats, spells, magic items, equipment, and guidelines for crafting adventures and campaigns within the communities of these tenacious folk.', NULL),
	(83, 14, 'Sandstorm', 'Sa', 'Take the Heat\nSweltering temperatures, bone-scouring windstorms, and other dangers threaten explorers in waste environments. From arid deserts and volcanic regions to ash-choked dungeons and the lava-filled layers of Gehenna, unwary travelers may fall victim to the unrelenting hazards that await.\nThis supplement for the D&D game explores the impact of desert conditions and extreme hot-weather environments on every aspect of game play. Along with rules for adapting to, navigating through, and surviving hazardous hot-weather conditions and terrain, Sandstorm also includes new races, spells, feats, magic items, prestige classes, and monsters associated with deserts and other wastelands.', NULL),
	(84, 9, 'Spell Compendium', 'Sc', '', NULL),
	(85, 14, 'Stormwrack', 'Sto', '', NULL),
	(86, 9, 'Tome of Battle: The Book of Nine Swords', 'ToB', 'New combat options for any D&D campaign.\nTome of Battle: The Book of Nine Swords introduces new rules for players who want interesting combat options for their characters. The nine martial disciplines presented within allow a character with the proper knowledge and focus to perform special combat maneuvers and nearly magical effects. Three new martial classes allow a character to develop his or her discipline even further. Also included are new feats and prestige classes that build on the disciplines, new magic items and spells, and new monsters and organizations.', NULL),
	(87, 9, 'Tome of Magic', 'TM', 'Three new magic systems for any D&D campaign.\nTome of Magic introduces three new magic subsystems for the D&D game. Any or all of these systems can easily be inserted into a campaign. Pact magic gives characters the ability to channel lost souls, harnessing their abilities to gain supernatural powers. Shadow magic draws power from the mysterious Plane of Shadow. Truename magic gives characters that learn and properly use the true name of a creature or object immense power over it. All three systems introduce new base classes and spellcasting mechanics. Also included are new feats, prestige classes, magic items, and spells.', NULL),
	(88, 9, 'Unearthed Arcana', 'UA', 'A new guide to variant rules for the Dungeons & Dragons roleplaying game.\nThis all-new sourcebook provides D&D players and Dungeon Masters with a wide choice of variant rules for alternate roleplaying in a D&D campaign. Designed to expand the options available for customizing gameplay, these variant rules are modular and can be imported into any campaign in any amount desired. Examples of variant rules include playing core classes as prestige classes and alternate damage systems. Brand-new rules include a new system of metamagic feats and a new spell system.', NULL),
	(89, 9, 'Weapons of Legacy', 'WL', '', NULL),
	(90, 9, 'Draconomicon', 'Dr', '', NULL),
	(91, 8, 'Drow of the Underdark', 'DrU', '', NULL),
	(92, 3, 'Ghostwalk', 'Gh', 'The city of Manifest rests atop ruins from ancient times and far above the entrance to the land of the dead. Here, the world of the living is shared equally with the deceased, who linger in physical form before finally passing through the Veil. Whether currently living or dead, residents and visitors are assured of an eternity of action and intrigue.\n\nGhostwalk contains everything needed to run a stand-alone campaign in and around the city of Manifest, or to integrate it into an existing world, including:\n\n- Complete rules for playing ghost characters and advancing in the new Eidolon and Eidoloncer classes\n- New prestige classes, such as the Bone Collector and the Ghost Slayer\n- Over 70 new feats and 65 new spells, including Ghost Hand, Incorporeal Target Fighting, Death Armor, and Ectoplasmic Decay\n- Three complete adventures, four highly detailed encounter sites, and fourteen new monsters and templates', NULL),
	(93, 2, 'Lords of Darkness', 'LD', '', NULL),
	(94, 3, 'Oriental Adventures', 'OA', 'Asian magic, combat, mystery, and monsters, all with a D&D twist. It\'s a beautiful book that takes its graphic inspiration from the texture of handmade papers and the grace of calligraphy mixed with the kickin\' edge of the new D&D style. Check out this new gallery of art drawn from the book, and if you haven\'t bought it yet, what\'s keeping you? All the great classes and races from the original 1st edition AD&D are back and much, much more. And there are more weird, wonderful, mysterious Asian-inspired monsters than ever before -- from all the varieties of lung dragon, to the grisly mamono (wouldn\'t want to shake hands with one of those), to the classic hopping vampire (check him out in the Oriental Adventures excerpt). Get yourself warmed up with Chinese Ghost Story and Crouching Tiger, Hidden Dragon and then join the rest of your gaming group as they crack open their copies of the book and dive in for some serious Asian fantasy roleplaying.', NULL),
	(95, 2, 'Silver Marches', 'SM', '', NULL),
	(96, 13, 'Dragonlance Campaign Setting', 'DCS', '', NULL),
	(97, 9, 'Expedition to the Demonweb Pits', 'EDP', '', NULL),
	(98, 13, 'Explorer\'s Handbook', 'EH', '', NULL),
	(99, 13, 'Five Nations', 'FN', '', NULL),
	(100, 9, 'Expedition to Castle Ravenloft', 'Rav', '', NULL),
	(101, 9, 'Return to the Temple of Elemental Evil', 'RT', '', NULL),
	(102, 9, 'The Shattered Gates of Slaughtergarde', 'ShG', '', NULL),
	(103, 13, 'The Forge of War', 'FoW', '', NULL),
	(104, 1, 'Player\'s Handbook', 'PHB', '', NULL),
	(105, 1, 'Monster Manual', 'MM', '', NULL),
	(106, 9, 'Web', 'Web', 'Found on wizards.com or another source.\nFor example: Font of Inspiration', NULL),
	(107, 9, 'Dragon Compendium', 'DC', '', NULL),
	(108, 9, 'Elder Evils', 'EE', 'When elder evils stir, the world groans; when they awaken, the world weeps. Buried in the deepest bowels of the Underdark, hidden in the farthest reaches of the multiverse, or lost in the gulfs between realities are terrible things that exist only to destroy or horribly remake creation. So mighty are these ancient beings that even the gods think twice about standing against them. Mortals who are aware\nof their existence viciously suppress that knowledge and destroy any who would serve such things. Even if an elder evil can be forced back to whence it came, its mere presence changes the world forever. In short, it is a campaign ender.', NULL),
	(109, 9, 'Feats', 'Feats', 'The definitive guidebook to feats, containing over a thousand. It contains both commonly used feats, and some more obscure ones', NULL),
	(110, 13, 'Dragons of Ebberon', 'DE', 'Dragons of Eberron delves into the mysterious Draconic Prophecy and various draconic organizations. It introduces the continent of Argonnessen, homeland of the dragons, and describes various adventure sites and other places of interest that have never before been presented. The remainder of the book explores dragons on the continents of Khorvaire, Sarlona, and Xen\'drik and provides several ready-to-play dragons, complete with stat blocks, lairs, encounters, and adventure hooks. ', NULL),
	(111, 9, 'Eyes of the Lich Queen', 'EotLQ', 'What begins as a simple expedition to explore an ancient jungle temple sends adventurers headlong into a search for the Dragon\'s Eye, an artifact created ages ago by demons in order to gain power over dragons. But where exactly is this mysterious artifact, and why do the Cloudreavers and the Emerald Claw think the adventurers already have it? Only Lady Vol knows the truth. Her deadly cat-and-mouse game leads the characters from the wilderness of Q\'barra to the wild coasts of the Lhazaar Principalities and the soaring peaks of Argonnessen. There, at last, they can learn the secret of the Dragon\'s Eye and foil the lich queen\'s plans... if they survive!\nThe "Eyes of the Lich Queen" adventure for the Dungeons & Dragons game draws on the richness of the Eberron campaign setting. Designed for heroes of 5th level, the adventure sends them on a world-spanning journey as they battle cultists, pirates, long-dead spirits, and even dragons in their search for the enigmatic Dragon\'s Eye.', NULL),
	(112, 9, 'Shadowdale: The Scouring of the Land', 'S:TSotL', 'Elminster?s tower lies in ruins, and the town of Shadowdale has been conquered by evil Sharrans and the nefarious forces of Zhentil Keep. To drive the villains out of Shadowdale, the heroes must organize and lead a desperate revolt of Dalesfolk against their conquerors, as well as thwart the sinister designs of Shar?s servants and the Zhent garrison.', NULL),
	(113, 9, 'Red Hand of Doom', 'RH', 'The Red Hand of Doom is an exciting super-adventure that pits heroes against an army bent on domination. Rampaging hobgoblins and their allies threaten to destroy the realm and all who stand before them. Characters who dare confront the horde soon discover that these particular hobgoblins worship Tiamat, the evil queen of dragons, and eventually come face-to-face with her draconic minions. The excerpts below include the introduction and adventure outline, two sample encounters, and statistics for the encounters. (Crafty DMs may find the encounters and their relevant statistics useful in other ways, too!)', NULL);

-- Exportiere Struktur von Tabelle Development.RuleBookTranslations
CREATE TABLE IF NOT EXISTS `RuleBookTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RuleBookId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RuleBookTranslations_RuleBookId` (`RuleBookId`),
  CONSTRAINT `FK_RuleBookTranslations_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.RuleBookTranslations: ~9 rows (ungefähr)
DELETE FROM `RuleBookTranslations`;
INSERT INTO `RuleBookTranslations` (`Id`, `RuleBookId`, `Name`, `CultureName`, `Description`) VALUES
	(1, 6, NULL, 'en', NULL),
	(2, 76, NULL, 'en', NULL),
	(3, 78, NULL, 'en', NULL),
	(4, 5, NULL, 'en', NULL),
	(5, 38, NULL, 'en', NULL),
	(6, 4, NULL, 'en', NULL),
	(7, 74, NULL, 'en', NULL),
	(8, 75, NULL, 'en', NULL),
	(9, 43, NULL, 'en', NULL);

-- Exportiere Struktur von Tabelle Development.Senses
CREATE TABLE IF NOT EXISTS `Senses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Senses: ~0 rows (ungefähr)
DELETE FROM `Senses`;

-- Exportiere Struktur von Tabelle Development.SenseTranslations
CREATE TABLE IF NOT EXISTS `SenseTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SenseId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SenseTranslations_SenseId` (`SenseId`),
  CONSTRAINT `FK_SenseTranslations_Senses_SenseId` FOREIGN KEY (`SenseId`) REFERENCES `Senses` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SenseTranslations: ~0 rows (ungefähr)
DELETE FROM `SenseTranslations`;

-- Exportiere Struktur von Tabelle Development.SpellComponents
CREATE TABLE IF NOT EXISTS `SpellComponents` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellComponentTypeId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `MinimalItemGoldValue` decimal(65,30) DEFAULT NULL,
  `Count` int DEFAULT NULL,
  `CountIndicator` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OtherComponentText` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OtherComponentName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SpellVariantId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellComponents_ItemId` (`ItemId`),
  KEY `IX_SpellComponents_SpellComponentTypeId` (`SpellComponentTypeId`),
  KEY `IX_SpellComponents_SpellVariantId` (`SpellVariantId`),
  CONSTRAINT `FK_SpellComponents_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `Items` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellComponents_SpellComponentTypes_SpellComponentTypeId` FOREIGN KEY (`SpellComponentTypeId`) REFERENCES `SpellComponentTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellComponents_SpellVariants_SpellVariantId` FOREIGN KEY (`SpellVariantId`) REFERENCES `SpellVariants` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellComponents: ~0 rows (ungefähr)
DELETE FROM `SpellComponents`;

-- Exportiere Struktur von Tabelle Development.SpellComponentTypes
CREATE TABLE IF NOT EXISTS `SpellComponentTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AbbreviationFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellComponentTypes: ~6 rows (ungefähr)
DELETE FROM `SpellComponentTypes`;
INSERT INTO `SpellComponentTypes` (`Id`, `NameFallback`, `DescriptionFallback`, `AbbreviationFallback`) VALUES
	(1, 'Verbal', 'A verbal component is a spoken incantation. To provide a verbal component, you must be able to speak in a strong voice. A silence spell or a gag spoils the incantation (and thus the spell). A spell-caster who has been deafened has a 20% chance to spoil any spell with a verbal component that he or she tries to cast.', 'V'),
	(2, 'Somatic', 'A somatic component is a measured and precise movement of the hand. You must have at least one hand free to provide a somatic component.', 'S'),
	(3, 'Material', 'A material component is one or more physical substances or objects that are annihilated by the spell energies in the casting process. Unless a cost is given for a material component, the cost is negligible. Don\'t bother to keep track of material components with negligible cost. Assume you have all you need as long as you have your spell component pouch.', 'M'),
	(4, 'Arcane Focus', 'An arcane focus component is a prop of some sort. Unlike a material component, a focus is not consumed when the spell is cast and can be reused. As with material components, the cost for a focus is negligible unless a price is given. Assume that focus components of negligible cost are in your spell component pouch.', 'AF'),
	(5, 'Divine Focus', 'A divine focus component is an item of spiritual significance. The divine focus for a cleric or a paladin is a holy symbol appropriate to the character\'s faith.', 'DF'),
	(6, 'Experience', 'Some powerful spells entail an experience point cost to you. No spell can restore the XP lost in this manner. You cannot spend so much XP that you lose a level, so you cannot cast the spell unless you have enough XP to spare. However, you may, on gaining enough XP to attain a new level, use those XP for casting a spell rather than keeping them and advancing a level. The XP are treated just like a material component—expended when you cast the spell, whether or not the casting succeeds.', 'XP');

-- Exportiere Struktur von Tabelle Development.SpellComponentTypeTranslations
CREATE TABLE IF NOT EXISTS `SpellComponentTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellComponentTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellComponentTypeTranslations_SpellComponentTypeId` (`SpellComponentTypeId`),
  CONSTRAINT `FK_SpellComponentTypeTranslations_SpellComponentTypes_SpellComp~` FOREIGN KEY (`SpellComponentTypeId`) REFERENCES `SpellComponentTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellComponentTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellComponentTypeTranslations`;

-- Exportiere Struktur von Tabelle Development.SpellDescriptors
CREATE TABLE IF NOT EXISTS `SpellDescriptors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellDescriptors: ~19 rows (ungefähr)
DELETE FROM `SpellDescriptors`;
INSERT INTO `SpellDescriptors` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Acid', NULL),
	(2, 'Air', NULL),
	(3, 'Chaotic', NULL),
	(4, 'Cold', NULL),
	(5, 'Darkness', NULL),
	(6, 'Death', NULL),
	(7, 'Earth', NULL),
	(8, 'Electricity', NULL),
	(9, 'Evil', NULL),
	(10, 'Fear', NULL),
	(11, 'Fire', NULL),
	(12, 'Force', NULL),
	(13, 'Good', NULL),
	(14, 'Language-Dependant', NULL),
	(15, 'Lawful', NULL),
	(16, 'Light', NULL),
	(17, 'Mind-Affecting', NULL),
	(18, 'Sonic', NULL),
	(19, 'Water', NULL);

-- Exportiere Struktur von Tabelle Development.SpellDescriptorSpellVariant
CREATE TABLE IF NOT EXISTS `SpellDescriptorSpellVariant` (
  `SpellDescriptorsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellDescriptorsId`,`SpellVariantsId`),
  KEY `IX_SpellDescriptorSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellDescriptorSpellVariant_SpellDescriptors_SpellDescriptor~` FOREIGN KEY (`SpellDescriptorsId`) REFERENCES `SpellDescriptors` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellDescriptorSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellDescriptorSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellDescriptorSpellVariant`;

-- Exportiere Struktur von Tabelle Development.SpellDescriptorTranslations
CREATE TABLE IF NOT EXISTS `SpellDescriptorTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellDescriptorId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellDescriptorTranslations_SpellDescriptorId` (`SpellDescriptorId`),
  CONSTRAINT `FK_SpellDescriptorTranslations_SpellDescriptors_SpellDescriptor~` FOREIGN KEY (`SpellDescriptorId`) REFERENCES `SpellDescriptors` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellDescriptorTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellDescriptorTranslations`;

-- Exportiere Struktur von Tabelle Development.SpellRangeTypes
CREATE TABLE IF NOT EXISTS `SpellRangeTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellRangeTypes: ~0 rows (ungefähr)
DELETE FROM `SpellRangeTypes`;

-- Exportiere Struktur von Tabelle Development.SpellRangeTypeTranslations
CREATE TABLE IF NOT EXISTS `SpellRangeTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellRangeTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellRangeTypeTranslations_SpellRangeTypeId` (`SpellRangeTypeId`),
  CONSTRAINT `FK_SpellRangeTypeTranslations_SpellRangeTypes_SpellRangeTypeId` FOREIGN KEY (`SpellRangeTypeId`) REFERENCES `SpellRangeTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellRangeTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellRangeTypeTranslations`;

-- Exportiere Struktur von Tabelle Development.Spells
CREATE TABLE IF NOT EXISTS `Spells` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Spells: ~0 rows (ungefähr)
DELETE FROM `Spells`;

-- Exportiere Struktur von Tabelle Development.SpellSchools
CREATE TABLE IF NOT EXISTS `SpellSchools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellSchools: ~9 rows (ungefähr)
DELETE FROM `SpellSchools`;
INSERT INTO `SpellSchools` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Abjuration', 'Abjurations are protective spells. They create physical or magical barriers, negate magical or physical abilities, harm trespassers, or even banish the subject of the spell to another plane of existence.'),
	(2, 'Conjuration', 'Each conjuration spell belongs to one of five subschools. Conjurations bring manifestations of objects, creatures, or some form of energy to you (the summoning subschool), actually transport creatures from another plane of existence to your plane (calling), heal (healing), transport creatures or objects over great distances (teleportation), or create objects or effects on the spot (creation). Creatures you conjure usually, but not always, obey your commands.'),
	(3, 'Divination', 'Divination spells enable you to learn secrets long forgotten, to predict the future, to find hidden things, and to foil deceptive spells.'),
	(4, 'Enchantment', 'Enchantment spells affect the minds of others, influencing or controlling their behavior.'),
	(5, 'Evocation', 'Evocation spells manipulate energy or tap an unseen source of power to produce a desired end. In effect, they create something out of nothing. Many of these spells produce spectacular effects, and evocation spells can deal large amounts of damage.'),
	(6, 'Illusion', 'Illusion spells deceive the senses or minds of others. They cause people to see things that are not there, not see things that are there, hear phantom noises, or remember things that never happened.'),
	(7, 'Necromancy', 'Necromancy spells manipulate the power of death, unlife, and the life force. Spells involving undead creatures make up a large part of this school.'),
	(8, 'Transmutation', 'Transmutation spells change the properties of some creature, thing, or condition.'),
	(9, 'Universal', 'A small number of spells are universal, effectively belonging to no school.');

-- Exportiere Struktur von Tabelle Development.SpellSchoolSpellVariant
CREATE TABLE IF NOT EXISTS `SpellSchoolSpellVariant` (
  `SpellSchoolsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellSchoolsId`,`SpellVariantsId`),
  KEY `IX_SpellSchoolSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellSchoolSpellVariant_SpellSchools_SpellSchoolsId` FOREIGN KEY (`SpellSchoolsId`) REFERENCES `SpellSchools` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellSchoolSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellSchoolSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellSchoolSpellVariant`;

-- Exportiere Struktur von Tabelle Development.SpellSchoolTranslations
CREATE TABLE IF NOT EXISTS `SpellSchoolTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellSchoolId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellSchoolTranslations_SpellSchoolId` (`SpellSchoolId`),
  CONSTRAINT `FK_SpellSchoolTranslations_SpellSchools_SpellSchoolId` FOREIGN KEY (`SpellSchoolId`) REFERENCES `SpellSchools` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellSchoolTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellSchoolTranslations`;

-- Exportiere Struktur von Tabelle Development.SpellSubSchools
CREATE TABLE IF NOT EXISTS `SpellSubSchools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellSubSchools: ~13 rows (ungefähr)
DELETE FROM `SpellSubSchools`;
INSERT INTO `SpellSubSchools` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Calling', 'A calling spell transports a creature from another plane to the plane you are on. The spell grants the creature the one-time ability to return to its plane of origin, although the spell may limit the circumstances under which this is possible. Creatures who are called actually die when they are killed; they do not disappear and reform, as do those brought by a summoning spell (see below). The duration of a calling spell is instantaneous, which means that the called creature can\'t be dispelled.'),
	(2, 'Creation', 'A creation spell manipulates matter to create an object or creature in the place the spell-caster designates (subject to the limits noted above). If the spell has a duration other than instantaneous, magic holds the creation together, and when the spell ends, the conjured creature or object vanishes without a trace. If the spell has an instantaneous duration, the created object or creature is merely assembled through magic. It lasts indefinitely and does not depend on magic for its existence.'),
	(3, 'Healing', 'Certain divine conjurations heal creatures or even bring them back to life.'),
	(4, 'Summoning', 'A summoning spell instantly brings a creature or object to a place you designate. When the spell ends or is dispelled, a summoned creature is instantly sent back to where it came from, but a summoned object is not sent back unless the spell description specifically indicates this. A summoned creature also goes away if it is killed or if its hit points drop to 0 or lower. It is not really dead. It takes 24 hours for the creature to reform, during which time it can\'t be summoned again.'),
	(5, 'Teleportation', 'A teleportation spell transports one or more creatures or objects a great distance. The most powerful of these spells can cross planar boundaries. Unlike summoning spells, the transportation is (unless otherwise noted) one-way and not dispellable. Teleportation is instantaneous travel through the Astral Plane. Anything that blocks astral travel also blocks teleportation.'),
	(6, 'Scrying', 'A scrying spell creates an invisible magical sensor that sends you information. Unless noted otherwise, the sensor has the same powers of sensory acuity that you possess. This level of acuity includes any spells or effects that target you, but not spells or effects that emanate from you. However, the sensor is treated as a separate, independent sensory organ of yours, and thus it functions normally even if you have been blinded, deafened, or otherwise suffered sensory impairment. Any creature with an Intelligence score of 12 or higher can notice the sensor by making a DC 20 Intelligence check. The sensor can be dispelled as if it were an active spell.'),
	(7, 'Charm', 'A charm spell changes how the subject views you, typically making it see you as a good friend.'),
	(8, 'Compulsion', 'A compulsion spell forces the subject to act in some manner or changes the way her mind works. Some compulsion spells determine the subject\'s actions or the effects on the subject, some compulsion spells allow you to determine the subject\'s actions when you cast the spell, and others give you ongoing control over the subject.'),
	(9, 'Figment', 'A figment spell creates a false sensation. Those who perceive the figment perceive the same thing, not their own slightly different versions of the figment. (It is not a personalized mental impression.) Figments cannot make something seem to be something else. A figment that includes audible effects cannot duplicate intelligible speech unless the spell description specifically says it can. If intelligible speech is possible, it must be in a language you can speak. If you try to duplicate a language you cannot speak, the image produces gibberish. Likewise, you cannot make a visual copy of something unless you know what it looks like.'),
	(10, 'Glamer', 'A glamer spell changes a subject\'s sensory qualities, making it look, feel, taste, smell, or sound like something else, or even seem to disappear.'),
	(11, 'Pattern', 'Like a figment, a pattern spell creates an image that others can see, but a pattern also affects the minds of those who see it or are caught in it. All patterns are mind-affecting spells.'),
	(12, 'Phantasm', 'A phantasm spell creates a mental image that usually only the caster and the subject (or subjects) of the spell can perceive. This impression is totally in the minds of the subjects. It is a personalized mental impression. (It\'s all in their heads and not a fake picture or something that they actually see.) Third parties viewing or studying the scene don\'t notice the phantasm. All phantasms are mind-affecting spells.'),
	(13, 'Shadow', 'A shadow spell creates something that is partially real from extradimensional energy. Such illusions can have real effects. Damage dealt by a shadow illusion is real.');

-- Exportiere Struktur von Tabelle Development.SpellSubSchoolSpellVariant
CREATE TABLE IF NOT EXISTS `SpellSubSchoolSpellVariant` (
  `SpellSubSchoolsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellSubSchoolsId`,`SpellVariantsId`),
  KEY `IX_SpellSubSchoolSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellSubSchoolSpellVariant_SpellSubSchools_SpellSubSchoolsId` FOREIGN KEY (`SpellSubSchoolsId`) REFERENCES `SpellSubSchools` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellSubSchoolSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellSubSchoolSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellSubSchoolSpellVariant`;

-- Exportiere Struktur von Tabelle Development.SpellSubSchoolTranslations
CREATE TABLE IF NOT EXISTS `SpellSubSchoolTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellSubSchoolId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellSubSchoolTranslations_SpellSubSchoolId` (`SpellSubSchoolId`),
  CONSTRAINT `FK_SpellSubSchoolTranslations_SpellSubSchools_SpellSubSchoolId` FOREIGN KEY (`SpellSubSchoolId`) REFERENCES `SpellSubSchools` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellSubSchoolTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellSubSchoolTranslations`;

-- Exportiere Struktur von Tabelle Development.SpellTranslations
CREATE TABLE IF NOT EXISTS `SpellTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellTranslations_SpellId` (`SpellId`),
  CONSTRAINT `FK_SpellTranslations_Spells_SpellId` FOREIGN KEY (`SpellId`) REFERENCES `Spells` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellTranslations`;

-- Exportiere Struktur von Tabelle Development.SpellVariants
CREATE TABLE IF NOT EXISTS `SpellVariants` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellId` int DEFAULT NULL,
  `RuleBookId` int DEFAULT NULL,
  `RuleBookPage` int DEFAULT NULL,
  `CastingTimeValue` int NOT NULL,
  `CastingTimeIndicatorId` int DEFAULT NULL,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SpellRangeTypeId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellVariants_CastingTimeIndicatorId` (`CastingTimeIndicatorId`),
  KEY `IX_SpellVariants_RuleBookId` (`RuleBookId`),
  KEY `IX_SpellVariants_SpellId` (`SpellId`),
  KEY `IX_SpellVariants_SpellRangeTypeId` (`SpellRangeTypeId`),
  CONSTRAINT `FK_SpellVariants_ActionTimeIndicator_CastingTimeIndicatorId` FOREIGN KEY (`CastingTimeIndicatorId`) REFERENCES `ActionTimeIndicator` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_SpellRangeTypes_SpellRangeTypeId` FOREIGN KEY (`SpellRangeTypeId`) REFERENCES `SpellRangeTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_Spells_SpellId` FOREIGN KEY (`SpellId`) REFERENCES `Spells` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellVariants: ~0 rows (ungefähr)
DELETE FROM `SpellVariants`;

-- Exportiere Struktur von Tabelle Development.SpellVariantTranslations
CREATE TABLE IF NOT EXISTS `SpellVariantTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellVariantId` int DEFAULT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellVariantTranslations_SpellVariantId` (`SpellVariantId`),
  CONSTRAINT `FK_SpellVariantTranslations_SpellVariants_SpellVariantId` FOREIGN KEY (`SpellVariantId`) REFERENCES `SpellVariants` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.SpellVariantTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellVariantTranslations`;

-- Exportiere Struktur von Tabelle Development.Users
CREATE TABLE IF NOT EXISTS `Users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DateJoined` datetime(6) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsAdmin` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.Users: ~2 rows (ungefähr)
DELETE FROM `Users`;
INSERT INTO `Users` (`Id`, `Email`, `Username`, `DateJoined`, `PasswordHash`, `IsAdmin`) VALUES
	(1, 'test@testmail.com', 'test', '2022-07-11 19:05:28.582312', 'AJx3gwE7oqp4UjO/jxTOoF6ph4eGFN0kC3gSa8nkSfLgVkTUCIhZd4vhczCdoqHNzA==', 0),
	(2, 'test', 'test2', '2022-08-29 20:48:52.472724', 'AC0ps6jfhdrUSK9Aic3368rOhkzfP/fvHj5N1f4YtuCfoPiN7g6uzNAEuvWM6wSeuA==', 0);

-- Exportiere Struktur von Tabelle Development.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Development.__EFMigrationsHistory: ~8 rows (ungefähr)
DELETE FROM `__EFMigrationsHistory`;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
	('20220711164424_initial', '5.0.17'),
	('20220712181000_add_race', '5.0.17'),
	('20220713162442_add_fallbacks_to_alphabet', '5.0.17'),
	('20220715173657_update_feat_options', '5.0.17'),
	('20220715174731_rename_race_feat_option', '5.0.17'),
	('20220716141655_update_race_references', '5.0.17'),
	('20220716152721_update_race_property_name', '5.0.17'),
	('20220717182818_update_translations', '5.0.17'),
	('20220721175435_migrate_to_dotnet6', '6.0.7');

-- Exportiere Struktur von Tabelle Production.ActionTimeIndicator
CREATE TABLE IF NOT EXISTS `ActionTimeIndicator` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.ActionTimeIndicator: ~0 rows (ungefähr)
DELETE FROM `ActionTimeIndicator`;

-- Exportiere Struktur von Tabelle Production.ActionTimeIndicatorTranslation
CREATE TABLE IF NOT EXISTS `ActionTimeIndicatorTranslation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ActionTimeIndicatorId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_ActionTimeIndicatorTranslation_ActionTimeIndicatorId` (`ActionTimeIndicatorId`),
  CONSTRAINT `FK_ActionTimeIndicatorTranslation_ActionTimeIndicator_ActionTim~` FOREIGN KEY (`ActionTimeIndicatorId`) REFERENCES `ActionTimeIndicator` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.ActionTimeIndicatorTranslation: ~0 rows (ungefähr)
DELETE FROM `ActionTimeIndicatorTranslation`;

-- Exportiere Struktur von Tabelle Production.Allignments
CREATE TABLE IF NOT EXISTS `Allignments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Allignments: ~9 rows (ungefähr)
DELETE FROM `Allignments`;
INSERT INTO `Allignments` (`Id`, `Abbreviation`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'LG', 'Lawful Good', NULL),
	(2, 'NG', 'Neutral Good', NULL),
	(3, 'CG', 'Chaotic Good', NULL),
	(4, 'LN', 'Lawful Neutral', NULL),
	(5, 'TN', 'True Neutral', NULL),
	(6, 'CN', 'Chaotic Neutral', NULL),
	(7, 'LE', 'Lawful Evil', NULL),
	(8, 'NE', 'Neutral Evil', NULL),
	(9, 'CE', 'Chaotic Evil', NULL);

-- Exportiere Struktur von Tabelle Production.AllignmentTranslations
CREATE TABLE IF NOT EXISTS `AllignmentTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AllignmentId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AllignmentTranslations_AllignmentId` (`AllignmentId`),
  CONSTRAINT `FK_AllignmentTranslations_Allignments_AllignmentId` FOREIGN KEY (`AllignmentId`) REFERENCES `Allignments` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.AllignmentTranslations: ~18 rows (ungefähr)
DELETE FROM `AllignmentTranslations`;
INSERT INTO `AllignmentTranslations` (`Id`, `AllignmentId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Lawful Good', NULL, 'en'),
	(2, 1, 'Rechtschaffen Gut', NULL, 'de'),
	(3, 2, 'Neutral Good', NULL, 'en'),
	(4, 2, 'Neutral Gut', NULL, 'de'),
	(5, 3, 'Chaotic Good', NULL, 'en'),
	(6, 3, 'Chaotisch Gut', NULL, 'de'),
	(7, 4, 'Lawful Neutral', NULL, 'en'),
	(8, 4, 'Rechtschaffen Neutral', NULL, 'de'),
	(9, 5, 'True Neutral', NULL, 'en'),
	(10, 5, 'Neutral', NULL, 'de'),
	(11, 6, 'Chaotic Neutral', NULL, 'en'),
	(12, 6, 'Chaotisch Neutral', NULL, 'de'),
	(13, 7, 'Lawful Evil', NULL, 'en'),
	(14, 7, 'Rechtschaffen Böse', NULL, 'de'),
	(15, 8, 'Neutral Evil', NULL, 'en'),
	(16, 8, 'Neutral Böse', NULL, 'de'),
	(17, 9, 'Chaotic Evil', NULL, 'en'),
	(18, 9, 'Chaotisch Böse', NULL, 'de');

-- Exportiere Struktur von Tabelle Production.Alphabets
CREATE TABLE IF NOT EXISTS `Alphabets` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Alphabets: ~0 rows (ungefähr)
DELETE FROM `Alphabets`;

-- Exportiere Struktur von Tabelle Production.AlphabetTranslations
CREATE TABLE IF NOT EXISTS `AlphabetTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlphabetId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AlphabetTranslations_AlphabetId` (`AlphabetId`),
  CONSTRAINT `FK_AlphabetTranslations_Alphabets_AlphabetId` FOREIGN KEY (`AlphabetId`) REFERENCES `Alphabets` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.AlphabetTranslations: ~0 rows (ungefähr)
DELETE FROM `AlphabetTranslations`;

-- Exportiere Struktur von Tabelle Production.CharacterItems
CREATE TABLE IF NOT EXISTS `CharacterItems` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ItemId` int DEFAULT NULL,
  `OwnerId` int DEFAULT NULL,
  `Quantity` int NOT NULL,
  `AquiredAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CharacterItems_ItemId` (`ItemId`),
  KEY `IX_CharacterItems_OwnerId` (`OwnerId`),
  CONSTRAINT `FK_CharacterItems_Characters_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `Characters` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_CharacterItems_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `Items` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CharacterItems: ~0 rows (ungefähr)
DELETE FROM `CharacterItems`;

-- Exportiere Struktur von Tabelle Production.Characters
CREATE TABLE IF NOT EXISTS `Characters` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatorUserId` int DEFAULT NULL,
  `TrueAllignmentId` int DEFAULT NULL,
  `Budget` int NOT NULL,
  `CreationDateTime` datetime(6) NOT NULL,
  `LastModifiedDateTime` datetime(6) NOT NULL,
  `DisableNonPlaytimeEditing` tinyint(1) NOT NULL,
  `CharacterName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Characters_CreatorUserId` (`CreatorUserId`),
  KEY `IX_Characters_TrueAllignmentId` (`TrueAllignmentId`),
  CONSTRAINT `FK_Characters_Allignments_TrueAllignmentId` FOREIGN KEY (`TrueAllignmentId`) REFERENCES `Allignments` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Characters_Users_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Characters: ~0 rows (ungefähr)
DELETE FROM `Characters`;

-- Exportiere Struktur von Tabelle Production.CreatureSizeCategories
CREATE TABLE IF NOT EXISTS `CreatureSizeCategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AttackAndArmorClassModifier` int NOT NULL,
  `SpecialAttackModifier` int NOT NULL,
  `HideModifier` int NOT NULL,
  `HeightOrLengthMin` double DEFAULT NULL,
  `HeightOrLengthMax` double DEFAULT NULL,
  `WeightMin` double DEFAULT NULL,
  `WeightMax` double DEFAULT NULL,
  `Space` double NOT NULL,
  `NaturalReachTall` int NOT NULL,
  `NaturalReachLong` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CreatureSizeCategories: ~0 rows (ungefähr)
DELETE FROM `CreatureSizeCategories`;

-- Exportiere Struktur von Tabelle Production.CreatureSizeCategoryTranslations
CREATE TABLE IF NOT EXISTS `CreatureSizeCategoryTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureSizeCategoryId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureSizeCategoryTranslations_CreatureSizeCategoryId` (`CreatureSizeCategoryId`),
  CONSTRAINT `FK_CreatureSizeCategoryTranslations_CreatureSizeCategories_Crea~` FOREIGN KEY (`CreatureSizeCategoryId`) REFERENCES `CreatureSizeCategories` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CreatureSizeCategoryTranslations: ~0 rows (ungefähr)
DELETE FROM `CreatureSizeCategoryTranslations`;

-- Exportiere Struktur von Tabelle Production.CreatureSubTypes
CREATE TABLE IF NOT EXISTS `CreatureSubTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CreatureSubTypes: ~0 rows (ungefähr)
DELETE FROM `CreatureSubTypes`;

-- Exportiere Struktur von Tabelle Production.CreatureSubTypeTranslations
CREATE TABLE IF NOT EXISTS `CreatureSubTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureSubTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureSubTypeTranslations_CreatureSubTypeId` (`CreatureSubTypeId`),
  CONSTRAINT `FK_CreatureSubTypeTranslations_CreatureSubTypes_CreatureSubType~` FOREIGN KEY (`CreatureSubTypeId`) REFERENCES `CreatureSubTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CreatureSubTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `CreatureSubTypeTranslations`;

-- Exportiere Struktur von Tabelle Production.CreatureTypes
CREATE TABLE IF NOT EXISTS `CreatureTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CreatureTypes: ~0 rows (ungefähr)
DELETE FROM `CreatureTypes`;

-- Exportiere Struktur von Tabelle Production.CreatureTypeTranslations
CREATE TABLE IF NOT EXISTS `CreatureTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureTypeTranslations_CreatureTypeId` (`CreatureTypeId`),
  CONSTRAINT `FK_CreatureTypeTranslations_CreatureTypes_CreatureTypeId` FOREIGN KEY (`CreatureTypeId`) REFERENCES `CreatureTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.CreatureTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `CreatureTypeTranslations`;

-- Exportiere Struktur von Tabelle Production.Editions
CREATE TABLE IF NOT EXISTS `Editions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `System` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Core` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Editions: ~17 rows (ungefähr)
DELETE FROM `Editions`;
INSERT INTO `Editions` (`Id`, `Name`, `System`, `Core`) VALUES
	(1, 'Core (3.0)', 'DnD 3.0', 1),
	(2, 'Realms (3.0)', 'DnD 3.0', 0),
	(3, 'Generic (3.0)', 'DnD 3.0', 0),
	(4, 'Dark Sun (3.0)', 'DnD 3.0', 0),
	(5, 'Class (3.0)', 'DnD 3.0', 0),
	(6, 'Greyhawk (3.0)', 'DnD 3.0', 0),
	(7, 'Core (3.5)', 'DnD 3.5', 1),
	(8, 'Realms (3.5)', 'DnD 3.5', 0),
	(9, 'Generic (3.5)', 'DnD 3.5', 0),
	(10, 'Dark Sun (3.5)', 'DnD 3.5', 0),
	(11, 'Class (3.5)', 'DnD 3.5', 0),
	(12, 'Greyhawk (3.5)', 'DnD 3.5', 0),
	(13, 'Dragonlance (3.5)', 'DnD 3.5', 0),
	(14, 'Eberron (3.5)', 'DnD 3.5', 0),
	(15, 'Environment (3.5)', 'DnD 3.5', 0),
	(16, 'Planescape (3.5)', 'DnD 3.5', 0),
	(17, 'Races (3.5)', 'DnD 3.5', 0);

-- Exportiere Struktur von Tabelle Production.FeatOptions
CREATE TABLE IF NOT EXISTS `FeatOptions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdList` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RaceId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FeatOptions_RaceId` (`RaceId`),
  CONSTRAINT `FK_FeatOptions_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.FeatOptions: ~0 rows (ungefähr)
DELETE FROM `FeatOptions`;

-- Exportiere Struktur von Tabelle Production.Items
CREATE TABLE IF NOT EXISTS `Items` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Price` int NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Items: ~0 rows (ungefähr)
DELETE FROM `Items`;

-- Exportiere Struktur von Tabelle Production.Languages
CREATE TABLE IF NOT EXISTS `Languages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlphabetId` int DEFAULT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Languages_AlphabetId` (`AlphabetId`),
  CONSTRAINT `FK_Languages_Alphabets_AlphabetId` FOREIGN KEY (`AlphabetId`) REFERENCES `Alphabets` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Languages: ~0 rows (ungefähr)
DELETE FROM `Languages`;

-- Exportiere Struktur von Tabelle Production.LanguageTranslations
CREATE TABLE IF NOT EXISTS `LanguageTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LanguageId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_LanguageTranslations_LanguageId` (`LanguageId`),
  CONSTRAINT `FK_LanguageTranslations_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.LanguageTranslations: ~0 rows (ungefähr)
DELETE FROM `LanguageTranslations`;

-- Exportiere Struktur von Tabelle Production.MovementManeuverabilities
CREATE TABLE IF NOT EXISTS `MovementManeuverabilities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.MovementManeuverabilities: ~0 rows (ungefähr)
DELETE FROM `MovementManeuverabilities`;

-- Exportiere Struktur von Tabelle Production.MovementManeuverabilityTranslations
CREATE TABLE IF NOT EXISTS `MovementManeuverabilityTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MovementManeuverabilityId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_MovementManeuverabilityTranslations_MovementManeuverabilityId` (`MovementManeuverabilityId`),
  CONSTRAINT `FK_MovementManeuverabilityTranslations_MovementManeuverabilitie~` FOREIGN KEY (`MovementManeuverabilityId`) REFERENCES `MovementManeuverabilities` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.MovementManeuverabilityTranslations: ~0 rows (ungefähr)
DELETE FROM `MovementManeuverabilityTranslations`;

-- Exportiere Struktur von Tabelle Production.MovementModes
CREATE TABLE IF NOT EXISTS `MovementModes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.MovementModes: ~0 rows (ungefähr)
DELETE FROM `MovementModes`;

-- Exportiere Struktur von Tabelle Production.MovementModeTranslations
CREATE TABLE IF NOT EXISTS `MovementModeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MovementModeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_MovementModeTranslations_MovementModeId` (`MovementModeId`),
  CONSTRAINT `FK_MovementModeTranslations_MovementModes_MovementModeId` FOREIGN KEY (`MovementModeId`) REFERENCES `MovementModes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.MovementModeTranslations: ~0 rows (ungefähr)
DELETE FROM `MovementModeTranslations`;

-- Exportiere Struktur von Tabelle Production.RaceAdditionalLanguages
CREATE TABLE IF NOT EXISTS `RaceAdditionalLanguages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `LanguageId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceAdditionalLanguages_LanguageId` (`LanguageId`),
  KEY `IX_RaceAdditionalLanguages_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceAdditionalLanguages_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceAdditionalLanguages_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceAdditionalLanguages: ~0 rows (ungefähr)
DELETE FROM `RaceAdditionalLanguages`;

-- Exportiere Struktur von Tabelle Production.RaceBonusLanguages
CREATE TABLE IF NOT EXISTS `RaceBonusLanguages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `LanguageId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceBonusLanguages_LanguageId` (`LanguageId`),
  KEY `IX_RaceBonusLanguages_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceBonusLanguages_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceBonusLanguages_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceBonusLanguages: ~0 rows (ungefähr)
DELETE FROM `RaceBonusLanguages`;

-- Exportiere Struktur von Tabelle Production.RaceMovementModes
CREATE TABLE IF NOT EXISTS `RaceMovementModes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `MovementModeId` int DEFAULT NULL,
  `MovementManeuverabilityId` int DEFAULT NULL,
  `Distance` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceMovementModes_MovementManeuverabilityId` (`MovementManeuverabilityId`),
  KEY `IX_RaceMovementModes_MovementModeId` (`MovementModeId`),
  KEY `IX_RaceMovementModes_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceMovementModes_MovementManeuverabilities_MovementManeuver~` FOREIGN KEY (`MovementManeuverabilityId`) REFERENCES `MovementManeuverabilities` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceMovementModes_MovementModes_MovementModeId` FOREIGN KEY (`MovementModeId`) REFERENCES `MovementModes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceMovementModes_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceMovementModes: ~0 rows (ungefähr)
DELETE FROM `RaceMovementModes`;

-- Exportiere Struktur von Tabelle Production.Races
CREATE TABLE IF NOT EXISTS `Races` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RuleBookId` int DEFAULT NULL,
  `RuleBookPage` int DEFAULT NULL,
  `CreatureTypeId` int DEFAULT NULL,
  `CreatureSubTypeId` int DEFAULT NULL,
  `CreatureSizeCategoryId` int DEFAULT NULL,
  `StrengthBonus` int NOT NULL,
  `DexterityBonus` int NOT NULL,
  `ConstitutionBonus` int NOT NULL,
  `IntelligenceBonus` int NOT NULL,
  `WisdomBonus` int NOT NULL,
  `CharismaBonus` int NOT NULL,
  `AdditionalSkillPoints` int NOT NULL,
  `LevelAdjustment` int DEFAULT NULL,
  `ChallengeRating` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Races_RuleBookId` (`RuleBookId`),
  KEY `IX_Races_CreatureSizeCategoryId` (`CreatureSizeCategoryId`),
  KEY `IX_Races_CreatureSubTypeId` (`CreatureSubTypeId`),
  KEY `IX_Races_CreatureTypeId` (`CreatureTypeId`),
  CONSTRAINT `FK_Races_CreatureSizeCategories_CreatureSizeCategoryId` FOREIGN KEY (`CreatureSizeCategoryId`) REFERENCES `CreatureSizeCategories` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_CreatureSubTypes_CreatureSubTypeId` FOREIGN KEY (`CreatureSubTypeId`) REFERENCES `CreatureSubTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_CreatureTypes_CreatureTypeId` FOREIGN KEY (`CreatureTypeId`) REFERENCES `CreatureTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Races: ~0 rows (ungefähr)
DELETE FROM `Races`;

-- Exportiere Struktur von Tabelle Production.RaceSenses
CREATE TABLE IF NOT EXISTS `RaceSenses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `SenseId` int DEFAULT NULL,
  `Distance` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSenses_RaceId` (`RaceId`),
  KEY `IX_RaceSenses_SenseId` (`SenseId`),
  CONSTRAINT `FK_RaceSenses_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceSenses_Senses_SenseId` FOREIGN KEY (`SenseId`) REFERENCES `Senses` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceSenses: ~0 rows (ungefähr)
DELETE FROM `RaceSenses`;

-- Exportiere Struktur von Tabelle Production.RaceSpecialAbilities
CREATE TABLE IF NOT EXISTS `RaceSpecialAbilities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSpecialAbilities_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceSpecialAbilities_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceSpecialAbilities: ~0 rows (ungefähr)
DELETE FROM `RaceSpecialAbilities`;

-- Exportiere Struktur von Tabelle Production.RaceSpecialAbilityTranslations
CREATE TABLE IF NOT EXISTS `RaceSpecialAbilityTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceSpecialAbilityId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSpecialAbilityTranslations_RaceSpecialAbilityId` (`RaceSpecialAbilityId`),
  CONSTRAINT `FK_RaceSpecialAbilityTranslations_RaceSpecialAbilities_RaceSpec~` FOREIGN KEY (`RaceSpecialAbilityId`) REFERENCES `RaceSpecialAbilities` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceSpecialAbilityTranslations: ~0 rows (ungefähr)
DELETE FROM `RaceSpecialAbilityTranslations`;

-- Exportiere Struktur von Tabelle Production.RaceTranslations
CREATE TABLE IF NOT EXISTS `RaceTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceTranslations_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceTranslations_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RaceTranslations: ~0 rows (ungefähr)
DELETE FROM `RaceTranslations`;

-- Exportiere Struktur von Tabelle Production.RuleBooks
CREATE TABLE IF NOT EXISTS `RuleBooks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EditionId` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PublishedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RuleBooks_EditionId` (`EditionId`),
  CONSTRAINT `FK_RuleBooks_Editions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `Editions` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=114 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RuleBooks: ~110 rows (ungefähr)
DELETE FROM `RuleBooks`;
INSERT INTO `RuleBooks` (`Id`, `EditionId`, `FallbackName`, `Abbreviation`, `FallbackDescription`, `PublishedAt`) VALUES
	(4, 7, 'Dungeon Master\'s Guide I', 'DMG', 'Weave exciting tales of heroism filled with magic and monsters. Within these pages, you\'ll discover the tools and options you need to create detailed worlds and dynamic adventures for your players to experience in the Dungeons & Dragons roleplaying game.\nThe revised Dungeon Master\'s Guide is an essential rulebook for Dungeon Masters of the D&D game. The Dungeon Master\'s Guide has been reorganized to be more user friendly. It features information on running a D&D game, adjudicating play, writing adventures, non-player characters (including non-player character classes), running a campaign, characters, magic items (including intelligent and cursed items, and artifacts), and a dictionary of special abilities and conditions. Changes have been made to the item creation rules and pricing, and prestige classes new to the Dungeon Master\'s Guide are included (over 10 prestige classes). The revision includes expanded advice on how to run a campaign and instructs players on how to take full advantage of the tie-in D&D miniatures line.', NULL),
	(5, 7, 'Monster Manual I', 'MM', 'Fearsome and formidable foes lurk within. Encounter a horde of monsters armed and ready to battle your boldest heroes or fight alongside them. The fully illustrated pages of this book are overrun with all the creatures, statistics, spells, and strategies you need to challenge the heroic characters of any Dungeons & Dragons role-playing game.\nOver 200 creeps, critters, and creatures keep players on their toes. From aboleths to zombies, the revised Monster Manual holds a diverse cast of enemies and allies essential for any Dungeons & Dragons campaign. There are hundreds of monsters ready for action, including many new creatures never seen before. The revised Monster Manual now contains an adjusted layout that makes monster statistics easier to understand and use. It has 31 new illustrations and a new index, and contains expanded information on monster classes and playing monsters as heroes, along with information on how to take full advantage of the tie-in D&D miniatures line planned for the fall of 2003 from Wizards of the Coast, Inc.', NULL),
	(6, 7, 'Player\'s Handbook I', 'PH', '', NULL),
	(7, 13, 'Dragonmarked', 'Dra', ' Dragonmarked offers an in-depth look at the power of dragonmarks and the thirteen dragonmarked houses of the Eberron world. It also provides exciting new options for players with dragonmarked characters, including role-playing hooks, new feats, new prestige classes, and new spells.', NULL),
	(8, 13, 'Faiths of Eberron', 'FE', '', NULL),
	(9, 13, 'Magic of Eberron', 'MoE', '', NULL),
	(10, 13, 'Races of Eberron', 'RE', 'Races of Eberron expands on the information presented about the four new Eberron races (warforged, shifter, changeling and kalashtar) as well as giving more information regarding the common races and how they differ on Eberron. It also features the ubiquitous slew of feats, prestige classes, spells and magic items to immerse your character more fully in the Eberron world.', NULL),
	(11, 13, 'Sharn: City of Towers', 'Sh', '', NULL),
	(12, 13, 'Eberron Campaign Setting', 'ECS', '', NULL),
	(13, 13, 'Player\'s Guide to Eberron', 'PE', '', NULL),
	(14, 13, 'Secrets of Sarlona', 'SoS', 'Secrets of Sarlona explores the continent of Sarlona for the first time. It gives players and Dungeon Masters their first real glimpse inside the empire of Riedra, home of the Inspired and the kalashtar. It also explores the mysteries of Adar, a nation isolated from the rest of the world, and never-before seen locations. Secrets of Sarlona also presents new options (feats, prestige classes, spells, and magic items) available to Sarlonan characters and characters with psionics. ', NULL),
	(15, 13, 'Secrets of Xen\'drik', 'SX', '', NULL),
	(16, 8, 'City of Splendors: Waterdeep', 'CSW', '*City of Splendors: Waterdeep* offers an in-depth examination of the great city of Waterdeep in the Forgotten Realms setting. An overview of the city includes history, a who?s who, information on laws, and rules for running and playing in a Watered havian campaign. Information on the people of Waterdeep covers non-player characters, arcane schools, armed forces, guilds, nobility, prestige classes specific to the city, and more. Also included in the book are discussions of specific Waterdeep locales, adventure locales, and new monsters. An extensive appendix gives information on new equipment, magic items,  psionic powers, poisons, spells, and more.', NULL),
	(17, 3, 'Enemies and Allies', 'EA', '', NULL),
	(18, 2, 'Faiths & Pantheons', 'FP', '', NULL),
	(19, 2, 'Forgotten Realms Campaign Setting', 'FRCS', '', NULL),
	(20, 2, 'Magic of Faerun', 'Mag', '', NULL),
	(21, 2, 'Monster Compendium: Monsters of Faerûn', 'Mon', '', NULL),
	(22, 8, 'Player\'s Guide to Faerûn', 'PG', '', NULL),
	(23, 2, 'Races of Faerun', 'Rac', '', NULL),
	(24, 8, 'Serpent Kingdoms', 'SK', 'Chilling fireside tales describe the fell plans and foul actions of the horrors known as the Scaled Ones: lizardfolk, nagas, yuan-ti, and their sinister creator race, the sarrukh. Infinitely patient and ruthless, the insidious serpentfolk seek to enslave all of Faer?n\'s other races to breed them like cattle. For those bold enough to peer within, Serpent Kingdoms offers an unsettlingly detailed look at the malevolent serpentfolk and lizard races of the Forgotten Realms game setting.', NULL),
	(25, 8, 'Shining South', 'ShS', '', NULL),
	(26, 8, 'Dragons of Faerun', 'DrF', '', NULL),
	(27, 8, 'Champions of Ruin', 'CR', '', NULL),
	(28, 8, 'Champions of Valor', 'CV', '', NULL),
	(29, 8, 'Lost Empires of Faerun', 'LE', '', NULL),
	(30, 8, 'Power of Faerun', 'PF', '', NULL),
	(31, 2, 'Unapproachable East', 'Una', 'Tales from beyond the Easting Reach are told with awed voices and hushed tones. Known to most of Faerun as the homeland of the Simbul, the hathrans, and the Red Wizards, the Unapproachable East is filled with dark secrets, insidious plots, and untold adventure. Discover the people, politics, cities, and societies of the region, along with the monsters, nefarious organizations, and other perils that await unwary travelers in this treacherous corner of the Forgotten Realms game setting.', NULL),
	(32, 8, 'Underdark', 'Und', '', NULL),
	(33, 3, 'Arms and Equipment Guide', 'AE', '', NULL),
	(34, 3, 'Book of Challenges: Dungeon Rooms, Puzzles, and Traps', 'BC', 'Danger Around Every Corner and Behind Every Screen!\nThe greatest threat to any adventuring party is a devious Dungeon Master. This book is spring-loaded with ideas, both subtle and sinister, that will ensure every gaming session is appropriately hazardous, including:\n* Over fifty encounters designed to be dropped into any campaign.\n* Scalable scenarios that can be pitted against characters from 1st to 20th level.\n* Advice for creating your own deceptive and deadly situations.\nDungeon Masters who want to keep their players on their toes will be inspired by the invaluable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual.', NULL),
	(35, 3, 'Book of Vile Darkness', 'BV', '"Only the most indomitable minds dare to look upon the malevolent thoughts and forbidden secrets bound herein. This corrupt tome is filled with deplorable wisdom, malignant ideas, and descriptions of creatures, rites, and practices most foul. Evil permeates every word and image inscribed within it."\n-- Orcus, Demon Prince of the Undead\nThis sourcebook for the Dungeons & Dragons game is intended for mature audiences and provides a Dungeon Master with unflinching access to subject matter that will broaden any campaign. Included in a detailed look at the nature of evil and the complex challenge of confronting the many dilemmas found within its deepest shadows. Along with wicked spells, wondrous items, and artifacts, Book of Vile Darkness also provides descriptions and statistics for a host of abominable monsters, archdevils, and demon princes to pit againt the noblest of heroes.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual.', NULL),
	(36, 5, 'Defenders of the Faith: A Guidebook to Clerics and Paladins', 'DF', 'Divine dedication powers these crusaders.\nThis book spotlights the champions of deities in the D&D game, clerics and paladins. It\'s packed with ways to customize cleric and paladin characters, including: \n* New feats, prestige classes, weapons, and equipment\n* More uses for turning checks, and new magic items and spells designed specially for clerics and paladins\n* Information about special organizations such as the Laughing Knives and the Stargazers\n* Detailed maps of temples that players and Dungeon Masters can use as bases of operation or as enemy structures that must be brought down\n\n\nIndispensable to both players and Dungeon Masters, this book adds excitement to any campaign.', NULL),
	(37, 3, 'Deities and Demigods', 'DD', 'Source of All Divine Power\nThe names of Pelor, Loki, Athena, Osiris, and their kind are invoked by the devout as well as the desperate. With abilities that reach nearly beyond the scope of mortal imagination, the splendor of the gods humbles even the greatest of heroes.\nThis supplement for the D&D game provides everything you need to create and call upon the most powerful beings in your campaign. Included are descriptions and statistics for over seventy gods from four fully detailed pantheons. Along with suggestions for creating your own gods, Deities and Demigods also includes information on advancing characters to godhood.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(38, 7, 'Dungeon Master\'s Guide II', 'DMG2', '', NULL),
	(39, 3, 'Epic Level Handbook', 'EL', 'Legends Begin Here\nSongs are sung and tales are told of heroes who have advanced beyond most adventuring careers. They confront mightier enemies and face deadlier challenges, using powers and abilities that rival even the gods.\nThis supplement for the D&D game provides everything you need to transcend the first twenty levels of experience and advance characters to virtually unlimited levels of play. Along with epic magic items, epic monsters, and advice on running an epic campaign, the Epic Level Handbook also features epic NPCs from the Forgotten Realms and Greyhawk campaign settings.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(40, 9, 'Fiend Folio', 'FF', '', NULL),
	(41, 3, 'Manual of the Planes', 'MP', 'Visit New Dimensions\nThe most powerful adventurers know that great rewards--and great perils--await them beyond the world they call home. From the depths of Hell to the heights of Mount Celestia, from the clockwork world of Mechanus to the swirling chaos of Limbo, these strange and terrifying dimensions provide new challenges to adventurers who travel there. Manual of the Planes is your guidebook on a tour of the multiverse.\nThis supplement for the D&D game provides everything you need to know before you visit other planes of existence. Included are new prestige classes, spells, monsters, and magic items. Along with descriptions of dozens of new dimensions, Manual of the Planes includes rules for creating your own planes.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(42, 5, 'Masters of the Wild: A Guidebook to Barbarians, Druids, and Rangers', 'MW', 'These Forces of Nature Can Weather Any Storm\nBarbarians, druids, and rangers are the rugged and noble champions of untamed lands. This book teems with new ways to customize even the most seasoned characters, including:\n\n\n* New feats, weapons, spells, and magic items.\n* Improved, more detailed rules for the wild shape ability.\n* New prestige classes such as the frenzied berserker, the windrider, and the oozemaster.\n* A new type of magic item -- the infusion.\n\n\nDungeon Masters and players who want to add a new dimension to their barbarians, druids, and rangers will uncover a cache of indispensable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(43, 7, 'Monster Manual II', 'MM2', 'Even Greater Threats Await!\nAs heroes grow in power, they seek out more formidable adversaries. Whether sinister or seductive, ferocious or foul, the creatures lurking within these pages will challenge the most experienced characters of any campaign.\nThis supplement for the D&D game unleashes a horde of monsters to confront characters at all levels of play, including several with Challenge Ratings of 21 or higher. Inside are old favorites such as the death knight and the gem dragons, as well as all-new creatures such as the bronze serpent, the effigy, and the fiendwurm. Along with updated and expanded monster creation rules, Monster Manual II provides an inexhaustible source of ways to keep even the toughest heroes fighting and running for their lives.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook and the Dungeon Master\'s Guide. A player needs only the Player\'s Handbook.', NULL),
	(44, 3, 'Psionics Handbook', 'PsH3', '', NULL),
	(45, 3, 'Savage Species', 'SS', 'A New Breed of Adventurer\nWhether wondrous or wicked, some monsters have a calling that reaches beyond the ordinary existence of their kind. Traveling alongside other intrepid characters, these heroic creatures carve their places in legend with sword, spell, tooth, and claw.\nThis supplement for the D&D game provides everything you need to play a monster as a character or to make the monsters your heroes fight even more formidable. Inside are over 50 all-new monster classes that show how creatures develop their characteristics and abilities as they gain levels. Along with new prestige classes and monster templates, Savage Species also features new feats, spells, magic items, and more.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook and the Monster Manual.', NULL),
	(46, 5, 'Song and Silence: A Guidebook to Bards and Rogues', 'SaS', 'Finesse and Versatility Make Powerful Allies\nBards and rogues rely on a stunning array of skills and abilities to give them an edge over any adversary. Packed with new ways to customize even the most artful characters this book includes:\n\n* New feats, prestige classes, weapons, spells, magic items, and equipment.\n* Complete guidelines for trapmaking, including 90 sample traps.\n* Descriptions of a wide range of thieves\' guilds and bardic colleges.\n* Detailed rules for flanking opponents in combat.\n\nDungeon Masters and players who want to add a new dimension to their bards and rogues will find a wealth of indispensable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(47, 3, 'Stronghold Builder\'s Guidebook', 'SB', 'Defenses Wrought of Mortar and Magic\nHeroes need impregnable fortresses to assault, wondrous towers to explore, and majestic castles to protect. This book is stocked with everything needed to design any fortified structure imaginable, including:\n\n* Over 150 new magic items\n* More than two dozen magical augmentations for stronghold walls\n* Rules for magic portals, mobile strongholds, and trap creation\n* Five complete strongholds, including maps, ready for immediate use\n\nPlayers and Dungeon Masters who want to create customized strongholds will find all the construction materials they need within these pages.\nTo use this accessory, a player or Dungeon Master also needs the Player\'s Handbook.', NULL),
	(48, 5, 'Sword and Fist: A Guidebook to Monks and Fighters', 'SF', '', NULL),
	(49, 5, 'Tome and Blood: A Guidebook to Wizards and Sorcerers', 'TB', 'A Spell Is Better than a Thousand Words\nEvery mystic library reserves a place for this single potent volume of arcane lore. It\'s packed with ways to customize sorcerer and wizard characters, including:\n\n* New feats, spells, and magic items.\n* New prestige classes, including the dragon disciple, fatespinner, and pale master.\n* Information about special organizations such as the Broken Wands and the Arcane Order.\n* Maps of a mages\' guildhall and a home that a sorcerer and a wizard share.\n\nTome and Blood is indispensable to players and Dungeon Masters who want to add a new dimension to sorcerers and wizards.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(50, 9, 'Book of Exalted Deeds', 'BE', 'Strike Down Evil with the Sword of Enlightenment\nOnly those who are pure in word, thought, and deed may look upon the knowledge gathered within this blessed tome. For the blinding truths inscribed within offer nothing but redemption or destruction for the wicked. May these consecrated pages forever illuminate the paths of the righteous.\n-- Raziel the Crusader, ruler of the Platinum Heaven\nAs the Book of Vile Darkness was a resource book on the most evil elements of campaign play, the Book of Exalted Deeds focuses instead on the availability of good resources and features in the D&D spectrum.\nIncluded are new exalted feats, prestige classes, races, spells, magic items, and descriptions and statistics for a host of creatures and celestial paragons to ally with virtuous characters. The Book of Exalted Deeds also provides descriptions and statistics for a host of creatures and celestial paragons to ally with virtuous characters.\nBook of Exalted Deeds is the second title in the line of Dungeons & Dragons products specifically aimed at a mature audience. \nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(51, 14, 'CityScape', 'Ci', 'As Deadly as Any Dungeon\nThere\'s more to adventuring than crawling around in dungeons. The city holds many avenues of peril and intrigue. It teems with adventure and offers unsurpassed opportunities and challenges. Dark alleys, busy guildhalls, rowdy taverns, fetid sewers, and palatial manors hold secrets to be discovered and mysteries to be explored.\nThis supplement for the DUNGEONS & DRAGONS game reveals the city in all its grandeur and grimness. It makes the urban dungeon feel alive with politics and power, especially through influential guilds. This tome also describes new feats, spells, urban terrain, hazards, and monsters guaranteed to make the party\'s next visit to the city a vibrant and exhilarating event.', NULL),
	(52, 11, 'Complete Adventurer', 'CAd', 'Sharpen Your Survival Skills\nTaverns are filled with tales of talented heroes and their breathtaking exploits. The prowess and ingenuity of these remarkable characters gives them the edge to succeed where others cannot.\nThis supplement for the D&D game provides everything you need to sharpen the skills and enhance the abilities of characters of any class. Along with new base classes, prestige classes, feats, spells, monsters, and magic items, Complete Adventurer provides alternate uses for skills and other options that expand the capabilities of the most versatile heroes.', NULL),
	(53, 11, 'Complete Arcane', 'CAr', 'Master Eldritch Secrets and Formidable Power\nMyth and mystery surround those who wield the awe-inspiring might of arcane magic. Whether through ancient knowledge, innate talent, or supernatural gift, these formidable and versatile spellcasters command powers beyond measure.\nThis supplement for the D&D game provides everything you need to expand the power of arcane magic for characters of any class. Along with new base classes, prestige classes, feats, spells, monsters, and magic items, Complete Arcane provides guidelines for spell duels, arcane organizations, and other aspects of a campaign world imbued with magic.', NULL),
	(54, 11, 'Complete Divine', 'CD', 'Wield Power Granted by the Gods\nLegends tell of brave champions whose unwavering faith earned them the favor of the gods. Empowered by the might and magic of their deity, these devoted characters transcend the realm of mere heroes.\nThis supplement for the D&D game provides everything you need to create divinely inspired characters of any class. Along with new base classes, prestige classes, feats, spells, magic items, and relics, Complete Divine also provides guidelines for incorporating religion -- from mysterious cults to powerful theocracies -- into your campaign.\nCover Illustration: Matt Cavotta. (The credits in the printed product incorrectly credited the cover art to another artist. We apologize to Matt for this error.)', NULL),
	(55, 11, 'Complete Champion', 'CC', 'New options for heroes with a divine cause.\nComplete Champion focuses on the divine champion archetype and provides new rules options for characters who enjoy battling for a cause, defeating foes using divine power, and going on quests that mean more than simply defeating the bad guy and grabbing the treasure. This book also helps Dungeon Masters run quest-themed campaigns and adventures.\nIn addition to providing various archetypes for characters, Complete Champion includes new feats and prestige classes. The book features dozens of deity- and belief-themed organizations, turning religion and holy (or unholy) power into something characters of all classes can use. For the Dungeon Master, this book contains information on constructing and running quests and holy missions. It assists the DM in helping all characters in the party to pursue divine paths simultaneously.', NULL),
	(56, 11, 'Complete Mage', 'CM', 'Arcane Power at Your Fingertips\nEvery sentient creature is born with some potential to work magic. However, true mastery of arcane magic requires skill, practice, and power beyond the reach of common folk specifically, the power to harness raw magic and shape it into a desired effect. You are among those gifted few who have learned to channel arcane magic, shaping it to serve your creative or destructive whims.\nThis D&D supplement is intended for players and Dungeon Masters. In addition to providing the definitive treatise on arcane magic, it expands the character options available to users of arcane magic, including bards, sorcerers, wizards, assassins, warlocks, and wu jen. Herein you\'ll find never-before-seen prestige classes, spells and invocations, magic items, alchemical items, heritage feats, and reserve feats (a new type of feat that grants special abilities to those who remain charged with magical power). Alternative class features give other character classes from the barbarian to the rogue a little taste of what it\'s like to be an arcanist without sacrificing their core identities.', NULL),
	(57, 11, 'Complete Psionic', 'CP', '', NULL),
	(58, 11, 'Complete Scoundrel', 'CS', 'Fair Fights are for Suckers\nIn a world filled with monsters and villains, a little deception and boldness goes a long way. You know how to take advantage of every situation, and you don\'t mind getting your hands dirty. Take the gloves off? Ha! You never put them on. You infuriate your foes and amaze your allies with your ingenuity, resourcefulness, and style. For you, every new predicament is an opportunity in disguise, and with each sweet victory your notoriety grows. That is how legends are made.\nThis D&D supplement gives you everything you need to get the drop on your foes and escape sticky situations. In addition to new feats, spells, items, and prestige classes, Complete Scoundrel presents new mechanics that put luck on your side and a special system of skill tricks that allow any character to play the part of a scoundrel. Tricky tactics aren\'t just for rogues anymore. ', NULL),
	(59, 11, 'Complete Warrior', 'CW', 'Forge your name in battle!\nThe Complete Warrior provides you with an in-depth look at combat and provides detailed information on how to prepare a character for confrontation.\nThis title was not only compiled from various D&D sources, but contains new things as well, including new battle-oriented character classes, prestige classes, combat maneuvers, feats, spells, magic items, and equipment. The prestige classes included have been revised and updated based on player feedback, and there are rules for unusual combat situations. The Complete Warrior will assist all class types, including those classes not typically associated with melee combat. There are also tips on running a martially focused campaign and advice on how to make your own prestige classes and feats.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(60, 9, 'Dragon Magic', 'DM', '', NULL),
	(61, 14, 'Dungeonscape', 'Du', 'Welcome to the Dungeon!\nSince the dawn of the DUNGEONS & DRAGONS game, the dungeon has remained a place of mystery, excitement, and danger. Purple worms burrow through the earth, eager for their next meal. Savage orcs lurk within the darkness, ready to surge forth and lay waste to civilized lands. Strange cults, mutated monsters, and forgotten gods hide within the choking darkness of the dungeon\'s halls. Nowhere else offers greater prospects for wealth, magic, and power. Yet the horrors that lurk beneath the world never give up their treasures without a fight....\nThis D&D supplement presents a refreshing new take on dungeon adventures. It shows Dungeon Masters how to inject excitement, innovation, and thrilling adventure into their dungeons. New rules for encounter traps allow DMs to build deadly snares to catch the unwary. For players, the factotum class is a cunning wanderer, a jack-of-all-trades who can cope with anything the dungeon throws at him. New equipment, feats, and prestige classes give adventurers the tools they need to survive the dark beneath the earth.', NULL),
	(62, 9, 'Exemplars of Evil', 'EE', 'The Exemplars of Evil supplement shows Dungeon Masters how to construct memorable campaign villains and presents nine ready-to-play villains of various levels that can be easily incorporated into any D&D campaign. Each villainous entry provides complete statistics for the villain (or villains), as well as adventure seeds, campaign hooks, pregenerated minions, and a fully detailed lair.\nROBERT J. SCHWALB is a staff designer and developer for Green Ronin Publishing. His design credits for Wizards include the Player\'s Handbook II, Tome of Magic, and Fiendish Codex II: Tyrants of the Nine Hells supplements. Robert lives in Tennessee with his patient wife and pride of cats.', NULL),
	(63, 9, 'Expanded Psionics Handbook', 'XPH', 'Tap into the power of the mind.\nThrough sheer force of will, a psionic character can unleash awesome powers that rival any physical force or magical energy. Within these pages, you will discover the secrets of unlocking the magic of the mind -- the art of psionics.\nWith updated and increased content, including a newly balanced psionics power system, the Expanded Psionics Handbook easily integrates psionic characters, powers, and monsters into any Dungeons & Dragons campaign.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(64, 9, 'Fiendish Codex I: Hordes of the Abyss', 'FCI', '', NULL),
	(65, 9, 'Fiendish Codex II: Tyrants of the Nine Hells', 'FCII', 'The evil that finds you might not be the one that you expect. Learn more about devils and their insidious ways in Fiendish Codex II, where both Dungeon Masters and players alike can find something useful to either enhance the evil of their devilish villains or fight it. For a sample of what\'s in store for you in this tome, take a look at Dis, a list of new feats, the hellfire warlock prestige class, a list of new spells, and the assassin devil.', NULL),
	(66, 14, 'Frostburn', 'Fr', 'Survival at Sub-Zero\nMarrow-chilling conditions, deadly hazards, and other dangers threaten explorers of frostfell environments. Whether traveling through polar regions and frozen mountaintops to ice-glazed dungeons and the Ice Wastes of the Abyss, a wintry grave awaits those who venture forth unprepared.\nThis supplement for the D&D game explores the impact of arctic conditions and extreme cold-weather environments on every aspect of game play. Along with rules for adapting to, navigating through, and surviving hazardous cold-weather conditions and terrain, Frostburn also includes new spells, feats, magic items, prestige classes, and monsters associated with icy realms.', NULL),
	(67, 9, 'Heroes of Battle', 'HB', 'Prepare for WarGreat conflicts erupt between rival nations and threaten to sweep across entire continents. As armies clash in epic battles, the actions of a handful of bold heroes can turn the tide of war. Whether in the thick of combat or on a secret mission of dire importance, brave champions have an impact that echoes across the battlefield and resounds through the ages.\nThis supplement for the D&D game reveals the pivotal roles characters can play in the midst of great battles. With rules and options for creating or playing adventures on and around battlefields, Heroes of Battle plunges characters into wartime situations and challenges them with climactic battles of epic proportions.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook and Dungeon Master\'s Guide. A player needs only the Player\'s Handbook.\nHeroes of Battle provides everything one needs to know to play a battle-oriented D&D campaign. You can build military characters with new feats, spells, uses for traditional spells, and prestige classes. Information is given on tools specific to the battlefield, including siege engines, weapons, magic items, steeds, and other exotic mounts. Battlefield terrain aspects are discussed with plenty of illustrative maps and new rules. Specific types of battlefield encounters are discussed in detail, and the book provides specific detail on designing battlefields.', NULL),
	(68, 9, 'Heroes of Horror', 'HH', 'Heroes of Horror  provides everything players and Dungeon Masters need to play and run a horror-oriented campaign or integrate elements of creepiness & tension into their existing campaigns. Players can develop heroes or anti-heroes using new feats, new spells, new base classes and prestige classes, and new magic items. The book presents new mechanics for different types of horror, including rules for dread and tainted characters, as well as plenty of new horrific monsters and adventure seeds. Different types and genres of horror are discussed in detail.', NULL),
	(69, 9, 'Libris Mortis: The Book of the Dead', 'LM', 'Nightmares from Beyond the Grave\nHushed voices tell spine-chilling tales of encounters with the walking dead and other unliving horrors. No other creatures have evoked such fear and fascination as this dreadful menagerie of malevolent spirits and mindless shells.\nThis supplement for the D&D game presents a comprehensive overview of the undead. You\'ll uncover information for creating, customizing, and combating undead characters and monsters -- including strategies and tactics commonly employed by undead and those who hunt them. Libris Mortis: The Book of Undead also provides new rules, feats, spells, and prestige classes, along with a host of new monsters and monster templates.', NULL),
	(70, 9, 'Lords of Madness', 'LoM', 'Unnatural Creatures of Unspeakable Evil\nTrembling hands have recorded horrifying stories of encounters with aboleths, beholders, mind flayers, and other aberrations. The victims of these alien creatures are quickly overwhelmed by mind-numbing terror -- their only comfort is the hope for a quick death.\nThis supplement for the D&D game presents a comprehensive look at some of the most bizarre creatures ever to invade the world of fantasy roleplaying. Along with information about the physiology, psychology, society, and schemes of these strange beings, you\'ll find spells, feats, tactics, and tools commonly employed by those who hunt them. Lords of Madness: The Book of Aberrations also provides new rules, prestige classes, monsters, sample encounters, and fully developed NPCs ready to instill fear in any hero.', NULL),
	(71, 9, 'Magic Item Compendium', 'MIC', '', NULL),
	(72, 9, 'Magic of Incarnum', 'MoI', 'This supplement introduces a magical substance called incarnum into the D&D game. With this book, the players characters can meld incarnum the power of souls living, dead, and unborn into magical items and even their own bodies, granting them special attacks, defenses, and other abilities (much as magic items and spells do). Incarnum can be shaped and reshaped into new forms, giving characters tremendous versatility in the dungeon and on any battlefield.\n This book also features new classes, prestige classes, feats, and other options for characters wishing to explore the secrets of incarnum, as well as rules and advice for including incarnum in a D&D campaign.', NULL),
	(73, 9, 'Miniatures Handbook', 'MH', 'Cries of battle fill the air!\nThe Miniatures Handbook gives you expanded rules for regular Dungeons & Dragons game play as well as guidelines for skirmishes and mass combats.\nIncluded are new base classes, new prestige classes, 30 new feats, more than 65 new spells, new magic items, and weapon special abilities. Also, there are more than 35 new monsters, including formidable aspects of deities and archfiends.\nExpand your battlefield with complete rules for skirmishes, squad-based fights, and even mass battles. There are also mechanics for random dungeons and rules for miniatures battle campaigns.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(74, 7, 'Monster Manual III', 'MM3', 'Encounter additional adversaries and allies\nLairing within these pages is an unstoppable wave of creatures ranging from ambush drake to zezir. A menagerie of beasts, behemoths and other ferocious beings, the monsters presented here are well prepared to battle or befriend the characters of any campaign.\nThis supplement for the D&D game offers a fully illustrated array of new creatures such as the boneclaw, eldritch giant, and web golem. Also included are advanced versions of some monsters as well as tactics sections to help DMs effectively run more complex creatures. Additionally, many entries contain information about where monsters are likely to appear in the Forgotten Realms and Eberron campaign settings.', NULL),
	(75, 7, 'Monster Manual IV', 'MM4', 'An indispensable resource containing new monsters suitable for any Dungeons & Dragons game.\nMonster Manual IV is the most recent volume in the bestselling Monster Manual line. Sure to be popular with both Dungeon Masters and players, this supplement to the D&D game provides descriptions for a vast array of new creatures. Each monster is illustrated and features a new stat block format that facilitates faster gameplay. In addition, the book includes sample encounters, pregenerated treasure hoards, and sidebars on how to incorporate the creatures in a Forgotten Realms or Eberron campaign. This product is tied to 2006\'s Year of Dragons theme, which is a key marketing platform across the D&D RPG, novels, and miniatures brands.', NULL),
	(76, 7, 'Monster Manual V', 'MM5', 'New monsters ideal for any Dungeons & Dragons game.\nMonster Manual V is the most recent volume in the best-selling Monster Manual line. This 224-page D&D supplement presents a fully illustrated horde of new monsters, as well as ready-to-play variations of previously existing monsters. In addition, this supplement features maps of monster lairs, sample encounters, and tactics sections to help Dungeon Masters run the more complex creatures. Additionally, many entries contain information about where monsters are likely to appear in the Forgotten Realms and Eberron campaign settings.', NULL),
	(77, 9, 'Planar Handbook', 'PlH', 'Explore Never-Ending Realms of Adventure\nOnly the most exceptional characters dare tread the infinite paths of the planes. From Sigil, the City of Doors, to the Blinding Tower at the heart of the Plane of Shadow, to the Elemental Plane of Fire\'s storied City of Brass, countless perilous locations in the multiverse await bold heroes armed with remarkable talents and abilities, more than a little courage, and above all, knowledge.\nThis supplement for the D&D game provides everything you need to create and play characters prepared for the odyssey of planar travel, including new planar races, feats, equipment, spells, and magic items. The Planar Handbook also introduces the power of planar touchstones, along with details and advice for visiting dozens of planar sites.', NULL),
	(78, 7, 'Player\'s Handbook II', 'PH2', 'A follow-up to the Player\'s Handbook designed to aid players and provide more character options.\nThe Player\'s Handbook II builds upon existing materials in the Player\'s Handbook. This is the first direct followup to the best-selling and most used D&D rulebook. It is specifically designed to expand the options available for players by both providing new material and increasing the uses for existing rules. Included are chapters on character race, background, classes, feats, spells, character creation, and character advancement. New rules include racial affiliations that make race matter as a character advances in level, new character classes and alternate class features for existing classes, new feats, tools for rapid character creation, and additional organization and teamwork benefits -- an option first introduced in Dungeon Master\'s Guide II and Heroes of Battle.', NULL),
	(79, 16, 'Races of Destiny', 'RD', 'Heroes Adapted to Adventure\nHailing from towns and villages in every corner of the world, resourceful and resilient adventurers emerge from among the races of destiny: humans, half-elves, half-orcs, and illumians. With an unparalleled drive to explore and experience, these diverse individuals have created names to last throughout the ages.\nThis supplement for the D&D game provides detailed information on the psychology, society, culture, behavior, religion, folklore, and other aspects of the races of destiny, including the illumians -- a new race presented here. In addition to new subraces and monster races playable as characters, Races of Destiny also provides new prestige classes, feats, spells, magic items, equipment, and guidelines for crafting memorable adventures within human settlements.', NULL),
	(80, 16, 'Races of Stone', 'RS', '', NULL),
	(81, 16, 'Races of the Dragon', 'RDr', ' A new D&D sourcebook detailing races descended from dragons. \n Races of the Dragon provides D&D players and Dungeon Masters with an in-depth look at races descended from or related to dragons. In addition to exploring the fan-favorite kobold race, Races of the Dragon introduces two new races, dragonborn and spellscales, and provides information on half-dragons. The dragonborn are a transitive race, an exciting new concept that allows players to transform from their initial race into a new one. This book also includes a wealth of cultural information and new prestige classes, feats, equipment, spells, and magic items. \n Gwendolyn F.M. Kestrel works for Wizards of the Coast, Inc. as a game designer. Her previous design credits include the Races of Eberron (tm), Monster Manual (tm) III, and Underdark (tm) roleplaying games. Jennifer Clarke Wilkes is an editor for Wizards of the Coast, Inc. She works primarily on the Dungeons & Dragons Miniatures line but has edited various roleplaying game books. She co-authored Savage Species (tm) and Sandstorm (tm). \n Kolja Raven Liquette is best known for authoring The Waking Lands web site. He has also published articles in Dragon Magazine. His previous publishing credits include Weapons of Legacy (tm). ', NULL),
	(82, 16, 'Races of the Wild', 'RW', 'Heroes Tempered by Nature\nFrom within verdant forests, among nomadic caravans, or atop soaring cliffsides, courageous adventurers arise from the people known as the races of the wild: elves, halflings, and raptorans. Living in harmony with the natural world, these noble individuals embark on grand adventures that become fireside tales for generations to come.\nThis supplement for the D&D game provides detailed information on the psychology, society, culture, behavior, religion, folklore, and other aspects of the races of the wild, including raptorans -- a new race presented here. In addition to new humanoids and monster races playable as characters, Races of the Wild also provides new prestige classes, feats, spells, magic items, equipment, and guidelines for crafting adventures and campaigns within the communities of these tenacious folk.', NULL),
	(83, 14, 'Sandstorm', 'Sa', 'Take the Heat\nSweltering temperatures, bone-scouring windstorms, and other dangers threaten explorers in waste environments. From arid deserts and volcanic regions to ash-choked dungeons and the lava-filled layers of Gehenna, unwary travelers may fall victim to the unrelenting hazards that await.\nThis supplement for the D&D game explores the impact of desert conditions and extreme hot-weather environments on every aspect of game play. Along with rules for adapting to, navigating through, and surviving hazardous hot-weather conditions and terrain, Sandstorm also includes new races, spells, feats, magic items, prestige classes, and monsters associated with deserts and other wastelands.', NULL),
	(84, 9, 'Spell Compendium', 'Sc', '', NULL),
	(85, 14, 'Stormwrack', 'Sto', '', NULL),
	(86, 9, 'Tome of Battle: The Book of Nine Swords', 'ToB', 'New combat options for any D&D campaign.\nTome of Battle: The Book of Nine Swords introduces new rules for players who want interesting combat options for their characters. The nine martial disciplines presented within allow a character with the proper knowledge and focus to perform special combat maneuvers and nearly magical effects. Three new martial classes allow a character to develop his or her discipline even further. Also included are new feats and prestige classes that build on the disciplines, new magic items and spells, and new monsters and organizations.', NULL),
	(87, 9, 'Tome of Magic', 'TM', 'Three new magic systems for any D&D campaign.\nTome of Magic introduces three new magic subsystems for the D&D game. Any or all of these systems can easily be inserted into a campaign. Pact magic gives characters the ability to channel lost souls, harnessing their abilities to gain supernatural powers. Shadow magic draws power from the mysterious Plane of Shadow. Truename magic gives characters that learn and properly use the true name of a creature or object immense power over it. All three systems introduce new base classes and spellcasting mechanics. Also included are new feats, prestige classes, magic items, and spells.', NULL),
	(88, 9, 'Unearthed Arcana', 'UA', 'A new guide to variant rules for the Dungeons & Dragons roleplaying game.\nThis all-new sourcebook provides D&D players and Dungeon Masters with a wide choice of variant rules for alternate roleplaying in a D&D campaign. Designed to expand the options available for customizing gameplay, these variant rules are modular and can be imported into any campaign in any amount desired. Examples of variant rules include playing core classes as prestige classes and alternate damage systems. Brand-new rules include a new system of metamagic feats and a new spell system.', NULL),
	(89, 9, 'Weapons of Legacy', 'WL', '', NULL),
	(90, 9, 'Draconomicon', 'Dr', '', NULL),
	(91, 8, 'Drow of the Underdark', 'DrU', '', NULL),
	(92, 3, 'Ghostwalk', 'Gh', 'The city of Manifest rests atop ruins from ancient times and far above the entrance to the land of the dead. Here, the world of the living is shared equally with the deceased, who linger in physical form before finally passing through the Veil. Whether currently living or dead, residents and visitors are assured of an eternity of action and intrigue.\n\nGhostwalk contains everything needed to run a stand-alone campaign in and around the city of Manifest, or to integrate it into an existing world, including:\n\n- Complete rules for playing ghost characters and advancing in the new Eidolon and Eidoloncer classes\n- New prestige classes, such as the Bone Collector and the Ghost Slayer\n- Over 70 new feats and 65 new spells, including Ghost Hand, Incorporeal Target Fighting, Death Armor, and Ectoplasmic Decay\n- Three complete adventures, four highly detailed encounter sites, and fourteen new monsters and templates', NULL),
	(93, 2, 'Lords of Darkness', 'LD', '', NULL),
	(94, 3, 'Oriental Adventures', 'OA', 'Asian magic, combat, mystery, and monsters, all with a D&D twist. It\'s a beautiful book that takes its graphic inspiration from the texture of handmade papers and the grace of calligraphy mixed with the kickin\' edge of the new D&D style. Check out this new gallery of art drawn from the book, and if you haven\'t bought it yet, what\'s keeping you? All the great classes and races from the original 1st edition AD&D are back and much, much more. And there are more weird, wonderful, mysterious Asian-inspired monsters than ever before -- from all the varieties of lung dragon, to the grisly mamono (wouldn\'t want to shake hands with one of those), to the classic hopping vampire (check him out in the Oriental Adventures excerpt). Get yourself warmed up with Chinese Ghost Story and Crouching Tiger, Hidden Dragon and then join the rest of your gaming group as they crack open their copies of the book and dive in for some serious Asian fantasy roleplaying.', NULL),
	(95, 2, 'Silver Marches', 'SM', '', NULL),
	(96, 13, 'Dragonlance Campaign Setting', 'DCS', '', NULL),
	(97, 9, 'Expedition to the Demonweb Pits', 'EDP', '', NULL),
	(98, 13, 'Explorer\'s Handbook', 'EH', '', NULL),
	(99, 13, 'Five Nations', 'FN', '', NULL),
	(100, 9, 'Expedition to Castle Ravenloft', 'Rav', '', NULL),
	(101, 9, 'Return to the Temple of Elemental Evil', 'RT', '', NULL),
	(102, 9, 'The Shattered Gates of Slaughtergarde', 'ShG', '', NULL),
	(103, 13, 'The Forge of War', 'FoW', '', NULL),
	(104, 1, 'Player\'s Handbook', 'PHB', '', NULL),
	(105, 1, 'Monster Manual', 'MM', '', NULL),
	(106, 9, 'Web', 'Web', 'Found on wizards.com or another source.\nFor example: Font of Inspiration', NULL),
	(107, 9, 'Dragon Compendium', 'DC', '', NULL),
	(108, 9, 'Elder Evils', 'EE', 'When elder evils stir, the world groans; when they awaken, the world weeps. Buried in the deepest bowels of the Underdark, hidden in the farthest reaches of the multiverse, or lost in the gulfs between realities are terrible things that exist only to destroy or horribly remake creation. So mighty are these ancient beings that even the gods think twice about standing against them. Mortals who are aware\nof their existence viciously suppress that knowledge and destroy any who would serve such things. Even if an elder evil can be forced back to whence it came, its mere presence changes the world forever. In short, it is a campaign ender.', NULL),
	(109, 9, 'Feats', 'Feats', 'The definitive guidebook to feats, containing over a thousand. It contains both commonly used feats, and some more obscure ones', NULL),
	(110, 13, 'Dragons of Ebberon', 'DE', 'Dragons of Eberron delves into the mysterious Draconic Prophecy and various draconic organizations. It introduces the continent of Argonnessen, homeland of the dragons, and describes various adventure sites and other places of interest that have never before been presented. The remainder of the book explores dragons on the continents of Khorvaire, Sarlona, and Xen\'drik and provides several ready-to-play dragons, complete with stat blocks, lairs, encounters, and adventure hooks. ', NULL),
	(111, 9, 'Eyes of the Lich Queen', 'EotLQ', 'What begins as a simple expedition to explore an ancient jungle temple sends adventurers headlong into a search for the Dragon\'s Eye, an artifact created ages ago by demons in order to gain power over dragons. But where exactly is this mysterious artifact, and why do the Cloudreavers and the Emerald Claw think the adventurers already have it? Only Lady Vol knows the truth. Her deadly cat-and-mouse game leads the characters from the wilderness of Q\'barra to the wild coasts of the Lhazaar Principalities and the soaring peaks of Argonnessen. There, at last, they can learn the secret of the Dragon\'s Eye and foil the lich queen\'s plans... if they survive!\nThe "Eyes of the Lich Queen" adventure for the Dungeons & Dragons game draws on the richness of the Eberron campaign setting. Designed for heroes of 5th level, the adventure sends them on a world-spanning journey as they battle cultists, pirates, long-dead spirits, and even dragons in their search for the enigmatic Dragon\'s Eye.', NULL),
	(112, 9, 'Shadowdale: The Scouring of the Land', 'S:TSotL', 'Elminster?s tower lies in ruins, and the town of Shadowdale has been conquered by evil Sharrans and the nefarious forces of Zhentil Keep. To drive the villains out of Shadowdale, the heroes must organize and lead a desperate revolt of Dalesfolk against their conquerors, as well as thwart the sinister designs of Shar?s servants and the Zhent garrison.', NULL),
	(113, 9, 'Red Hand of Doom', 'RH', 'The Red Hand of Doom is an exciting super-adventure that pits heroes against an army bent on domination. Rampaging hobgoblins and their allies threaten to destroy the realm and all who stand before them. Characters who dare confront the horde soon discover that these particular hobgoblins worship Tiamat, the evil queen of dragons, and eventually come face-to-face with her draconic minions. The excerpts below include the introduction and adventure outline, two sample encounters, and statistics for the encounters. (Crafty DMs may find the encounters and their relevant statistics useful in other ways, too!)', NULL);

-- Exportiere Struktur von Tabelle Production.RuleBookTranslations
CREATE TABLE IF NOT EXISTS `RuleBookTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RuleBookId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RuleBookTranslations_RuleBookId` (`RuleBookId`),
  CONSTRAINT `FK_RuleBookTranslations_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.RuleBookTranslations: ~0 rows (ungefähr)
DELETE FROM `RuleBookTranslations`;

-- Exportiere Struktur von Tabelle Production.Senses
CREATE TABLE IF NOT EXISTS `Senses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Senses: ~0 rows (ungefähr)
DELETE FROM `Senses`;

-- Exportiere Struktur von Tabelle Production.SenseTranslations
CREATE TABLE IF NOT EXISTS `SenseTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SenseId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SenseTranslations_SenseId` (`SenseId`),
  CONSTRAINT `FK_SenseTranslations_Senses_SenseId` FOREIGN KEY (`SenseId`) REFERENCES `Senses` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SenseTranslations: ~0 rows (ungefähr)
DELETE FROM `SenseTranslations`;

-- Exportiere Struktur von Tabelle Production.SpellComponents
CREATE TABLE IF NOT EXISTS `SpellComponents` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellComponentTypeId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `MinimalItemGoldValue` decimal(65,30) DEFAULT NULL,
  `Count` int DEFAULT NULL,
  `CountIndicator` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OtherComponentText` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OtherComponentName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SpellVariantId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellComponents_ItemId` (`ItemId`),
  KEY `IX_SpellComponents_SpellComponentTypeId` (`SpellComponentTypeId`),
  KEY `IX_SpellComponents_SpellVariantId` (`SpellVariantId`),
  CONSTRAINT `FK_SpellComponents_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `Items` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellComponents_SpellComponentTypes_SpellComponentTypeId` FOREIGN KEY (`SpellComponentTypeId`) REFERENCES `SpellComponentTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellComponents_SpellVariants_SpellVariantId` FOREIGN KEY (`SpellVariantId`) REFERENCES `SpellVariants` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellComponents: ~0 rows (ungefähr)
DELETE FROM `SpellComponents`;

-- Exportiere Struktur von Tabelle Production.SpellComponentTypes
CREATE TABLE IF NOT EXISTS `SpellComponentTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AbbreviationFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellComponentTypes: ~6 rows (ungefähr)
DELETE FROM `SpellComponentTypes`;
INSERT INTO `SpellComponentTypes` (`Id`, `NameFallback`, `DescriptionFallback`, `AbbreviationFallback`) VALUES
	(1, 'Verbal', 'A verbal component is a spoken incantation. To provide a verbal component, you must be able to speak in a strong voice. A silence spell or a gag spoils the incantation (and thus the spell). A spellcaster who has been deafened has a 20% chance to spoil any spell with a verbal component that he or she tries to cast.', 'V'),
	(2, 'Somatic', 'A somatic component is a measured and precise movement of the hand. You must have at least one hand free to provide a somatic component.', 'S'),
	(3, 'Material', 'A material component is one or more physical substances or objects that are annihilated by the spell energies in the casting process. Unless a cost is given for a material component, the cost is negligible. Don’t bother to keep track of material components with negligible cost. Assume you have all you need as long as you have your spell component pouch.', 'M'),
	(4, 'Arcane Focus', 'An arcane focus component is a prop of some sort. Unlike a material component, a focus is not consumed when the spell is cast and can be reused. As with material components, the cost for a focus is negligible unless a price is given. Assume that focus components of negligible cost are in your spell component pouch.', 'AF'),
	(5, 'Divine Focus', 'A divine focus component is an item of spiritual significance. The divine focus for a cleric or a paladin is a holy symbol appropriate to the character’s faith.', 'DF'),
	(6, 'Experience', 'Some powerful spells entail an experience point cost to you. No spell can restore the XP lost in this manner. You cannot spend so much XP that you lose a level, so you cannot cast the spell unless you have enough XP to spare. However, you may, on gaining enough XP to attain a new level, use those XP for casting a spell rather than keeping them and advancing a level. The XP are treated just like a material component—expended when you cast the spell, whether or not the casting succeeds.', 'XP');

-- Exportiere Struktur von Tabelle Production.SpellComponentTypeTranslations
CREATE TABLE IF NOT EXISTS `SpellComponentTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellComponentTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellComponentTypeTranslations_SpellComponentTypeId` (`SpellComponentTypeId`),
  CONSTRAINT `FK_SpellComponentTypeTranslations_SpellComponentTypes_SpellComp~` FOREIGN KEY (`SpellComponentTypeId`) REFERENCES `SpellComponentTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellComponentTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellComponentTypeTranslations`;

-- Exportiere Struktur von Tabelle Production.SpellDescriptors
CREATE TABLE IF NOT EXISTS `SpellDescriptors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellDescriptors: ~19 rows (ungefähr)
DELETE FROM `SpellDescriptors`;
INSERT INTO `SpellDescriptors` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Acid', NULL),
	(2, 'Air', NULL),
	(3, 'Chaotic', NULL),
	(4, 'Cold', NULL),
	(5, 'Darkness', NULL),
	(6, 'Death', NULL),
	(7, 'Earth', NULL),
	(8, 'Electricity', NULL),
	(9, 'Evil', NULL),
	(10, 'Fear', NULL),
	(11, 'Fire', NULL),
	(12, 'Force', NULL),
	(13, 'Good', NULL),
	(14, 'Language-Dependant', NULL),
	(15, 'Lawful', NULL),
	(16, 'Light', NULL),
	(17, 'Mind-Affecting', NULL),
	(18, 'Sonic', NULL),
	(19, 'Water', NULL);

-- Exportiere Struktur von Tabelle Production.SpellDescriptorSpellVariant
CREATE TABLE IF NOT EXISTS `SpellDescriptorSpellVariant` (
  `SpellDescriptorsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellDescriptorsId`,`SpellVariantsId`),
  KEY `IX_SpellDescriptorSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellDescriptorSpellVariant_SpellDescriptors_SpellDescriptor~` FOREIGN KEY (`SpellDescriptorsId`) REFERENCES `SpellDescriptors` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellDescriptorSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellDescriptorSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellDescriptorSpellVariant`;

-- Exportiere Struktur von Tabelle Production.SpellDescriptorTranslations
CREATE TABLE IF NOT EXISTS `SpellDescriptorTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellDescriptorId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellDescriptorTranslations_SpellDescriptorId` (`SpellDescriptorId`),
  CONSTRAINT `FK_SpellDescriptorTranslations_SpellDescriptors_SpellDescriptor~` FOREIGN KEY (`SpellDescriptorId`) REFERENCES `SpellDescriptors` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellDescriptorTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellDescriptorTranslations`;

-- Exportiere Struktur von Tabelle Production.SpellRangeTypes
CREATE TABLE IF NOT EXISTS `SpellRangeTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellRangeTypes: ~0 rows (ungefähr)
DELETE FROM `SpellRangeTypes`;

-- Exportiere Struktur von Tabelle Production.SpellRangeTypeTranslations
CREATE TABLE IF NOT EXISTS `SpellRangeTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellRangeTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellRangeTypeTranslations_SpellRangeTypeId` (`SpellRangeTypeId`),
  CONSTRAINT `FK_SpellRangeTypeTranslations_SpellRangeTypes_SpellRangeTypeId` FOREIGN KEY (`SpellRangeTypeId`) REFERENCES `SpellRangeTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellRangeTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellRangeTypeTranslations`;

-- Exportiere Struktur von Tabelle Production.Spells
CREATE TABLE IF NOT EXISTS `Spells` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Spells: ~0 rows (ungefähr)
DELETE FROM `Spells`;

-- Exportiere Struktur von Tabelle Production.SpellSchools
CREATE TABLE IF NOT EXISTS `SpellSchools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellSchools: ~9 rows (ungefähr)
DELETE FROM `SpellSchools`;
INSERT INTO `SpellSchools` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Abjuration', 'Abjurations are protective spells. They create physical or magical barriers, negate magical or physical abilities, harm trespassers, or even banish the subject of the spell to another plane of existence.'),
	(2, 'Conjuration', 'Each conjuration spell belongs to one of five subschools. Conjurations bring manifestations of objects, creatures, or some form of energy to you (the summoning subschool), actually transport creatures from another plane of existence to your plane (calling), heal (healing), transport creatures or objects over great distances (teleportation), or create objects or effects on the spot (creation). Creatures you conjure usually, but not always, obey your commands.'),
	(3, 'Divination', 'Divination spells enable you to learn secrets long forgotten, to predict the future, to find hidden things, and to foil deceptive spells.'),
	(4, 'Enchantment', 'Enchantment spells affect the minds of others, influencing or controlling their behavior.'),
	(5, 'Evocation', 'Evocation spells manipulate energy or tap an unseen source of power to produce a desired end. In effect, they create something out of nothing. Many of these spells produce spectacular effects, and evocation spells can deal large amounts of damage.'),
	(6, 'Illusion', 'Illusion spells deceive the senses or minds of others. They cause people to see things that are not there, not see things that are there, hear phantom noises, or remember things that never happened.'),
	(7, 'Necromancy', 'Necromancy spells manipulate the power of death, unlife, and the life force. Spells involving undead creatures make up a large part of this school.'),
	(8, 'Transmutation', 'Transmutation spells change the properties of some creature, thing, or condition.'),
	(9, 'Universal', 'A small number of spells are universal, effectively belonging to no school.');

-- Exportiere Struktur von Tabelle Production.SpellSchoolSpellVariant
CREATE TABLE IF NOT EXISTS `SpellSchoolSpellVariant` (
  `SpellSchoolsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellSchoolsId`,`SpellVariantsId`),
  KEY `IX_SpellSchoolSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellSchoolSpellVariant_SpellSchools_SpellSchoolsId` FOREIGN KEY (`SpellSchoolsId`) REFERENCES `SpellSchools` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellSchoolSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellSchoolSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellSchoolSpellVariant`;

-- Exportiere Struktur von Tabelle Production.SpellSchoolTranslations
CREATE TABLE IF NOT EXISTS `SpellSchoolTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellSchoolId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellSchoolTranslations_SpellSchoolId` (`SpellSchoolId`),
  CONSTRAINT `FK_SpellSchoolTranslations_SpellSchools_SpellSchoolId` FOREIGN KEY (`SpellSchoolId`) REFERENCES `SpellSchools` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellSchoolTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellSchoolTranslations`;

-- Exportiere Struktur von Tabelle Production.SpellSubSchools
CREATE TABLE IF NOT EXISTS `SpellSubSchools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellSubSchools: ~13 rows (ungefähr)
DELETE FROM `SpellSubSchools`;
INSERT INTO `SpellSubSchools` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Calling', 'A calling spell transports a creature from another plane to the plane you are on. The spell grants the creature the one-time ability to return to its plane of origin, although the spell may limit the circumstances under which this is possible. Creatures who are called actually die when they are killed; they do not disappear and reform, as do those brought by a summoning spell (see below). The duration of a calling spell is instantaneous, which means that the called creature can’t be dispelled.'),
	(2, 'Creation', 'A creation spell manipulates matter to create an object or creature in the place the spellcaster designates (subject to the limits noted above). If the spell has a duration other than instantaneous, magic holds the creation together, and when the spell ends, the conjured creature or object vanishes without a trace. If the spell has an instantaneous duration, the created object or creature is merely assembled through magic. It lasts indefinitely and does not depend on magic for its existence.'),
	(3, 'Healing', 'Certain divine conjurations heal creatures or even bring them back to life.'),
	(4, 'Summoning', 'A summoning spell instantly brings a creature or object to a place you designate. When the spell ends or is dispelled, a summoned creature is instantly sent back to where it came from, but a summoned object is not sent back unless the spell description specifically indicates this. A summoned creature also goes away if it is killed or if its hit points drop to 0 or lower. It is not really dead. It takes 24 hours for the creature to reform, during which time it can’t be summoned again.'),
	(5, 'Teleportation', 'A teleportation spell transports one or more creatures or objects a great distance. The most powerful of these spells can cross planar boundaries. Unlike summoning spells, the transportation is (unless otherwise noted) one-way and not dispellable. Teleportation is instantaneous travel through the Astral Plane. Anything that blocks astral travel also blocks teleportation.'),
	(6, 'Scrying', 'A scrying spell creates an invisible magical sensor that sends you information. Unless noted otherwise, the sensor has the same powers of sensory acuity that you possess. This level of acuity includes any spells or effects that target you, but not spells or effects that emanate from you. However, the sensor is treated as a separate, independent sensory organ of yours, and thus it functions normally even if you have been blinded, deafened, or otherwise suffered sensory impairment. Any creature with an Intelligence score of 12 or higher can notice the sensor by making a DC 20 Intelligence check. The sensor can be dispelled as if it were an active spell.'),
	(7, 'Charm', 'A charm spell changes how the subject views you, typically making it see you as a good friend.'),
	(8, 'Compulsion', 'A compulsion spell forces the subject to act in some manner or changes the way her mind works. Some compulsion spells determine the subject’s actions or the effects on the subject, some compulsion spells allow you to determine the subject’s actions when you cast the spell, and others give you ongoing control over the subject.'),
	(9, 'Figment', 'A figment spell creates a false sensation. Those who perceive the figment perceive the same thing, not their own slightly different versions of the figment. (It is not a personalized mental impression.) Figments cannot make something seem to be something else. A figment that includes audible effects cannot duplicate intelligible speech unless the spell description specifically says it can. If intelligible speech is possible, it must be in a language you can speak. If you try to duplicate a language you cannot speak, the image produces gibberish. Likewise, you cannot make a visual copy of something unless you know what it looks like.'),
	(10, 'Glamer', 'A glamer spell changes a subject’s sensory qualities, making it look, feel, taste, smell, or sound like something else, or even seem to disappear.'),
	(11, 'Pattern', 'Like a figment, a pattern spell creates an image that others can see, but a pattern also affects the minds of those who see it or are caught in it. All patterns are mind-affecting spells.'),
	(12, 'Phantasm', 'A phantasm spell creates a mental image that usually only the caster and the subject (or subjects) of the spell can perceive. This impression is totally in the minds of the subjects. It is a personalized mental impression. (It’s all in their heads and not a fake picture or something that they actually see.) Third parties viewing or studying the scene don’t notice the phantasm. All phantasms are mind-affecting spells.'),
	(13, 'Shadow', 'A shadow spell creates something that is partially real from extradimensional energy. Such illusions can have real effects. Damage dealt by a shadow illusion is real.');

-- Exportiere Struktur von Tabelle Production.SpellSubSchoolSpellVariant
CREATE TABLE IF NOT EXISTS `SpellSubSchoolSpellVariant` (
  `SpellSubSchoolsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellSubSchoolsId`,`SpellVariantsId`),
  KEY `IX_SpellSubSchoolSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellSubSchoolSpellVariant_SpellSubSchools_SpellSubSchoolsId` FOREIGN KEY (`SpellSubSchoolsId`) REFERENCES `SpellSubSchools` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellSubSchoolSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellSubSchoolSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellSubSchoolSpellVariant`;

-- Exportiere Struktur von Tabelle Production.SpellSubSchoolTranslations
CREATE TABLE IF NOT EXISTS `SpellSubSchoolTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellSubSchoolId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellSubSchoolTranslations_SpellSubSchoolId` (`SpellSubSchoolId`),
  CONSTRAINT `FK_SpellSubSchoolTranslations_SpellSubSchools_SpellSubSchoolId` FOREIGN KEY (`SpellSubSchoolId`) REFERENCES `SpellSubSchools` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellSubSchoolTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellSubSchoolTranslations`;

-- Exportiere Struktur von Tabelle Production.SpellTranslations
CREATE TABLE IF NOT EXISTS `SpellTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellTranslations_SpellId` (`SpellId`),
  CONSTRAINT `FK_SpellTranslations_Spells_SpellId` FOREIGN KEY (`SpellId`) REFERENCES `Spells` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellTranslations`;

-- Exportiere Struktur von Tabelle Production.SpellVariants
CREATE TABLE IF NOT EXISTS `SpellVariants` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellId` int DEFAULT NULL,
  `RuleBookId` int DEFAULT NULL,
  `RuleBookPage` int DEFAULT NULL,
  `CastingTimeValue` int NOT NULL,
  `CastingTimeIndicatorId` int DEFAULT NULL,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SpellRangeTypeId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellVariants_CastingTimeIndicatorId` (`CastingTimeIndicatorId`),
  KEY `IX_SpellVariants_RuleBookId` (`RuleBookId`),
  KEY `IX_SpellVariants_SpellId` (`SpellId`),
  KEY `IX_SpellVariants_SpellRangeTypeId` (`SpellRangeTypeId`),
  CONSTRAINT `FK_SpellVariants_ActionTimeIndicator_CastingTimeIndicatorId` FOREIGN KEY (`CastingTimeIndicatorId`) REFERENCES `ActionTimeIndicator` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_SpellRangeTypes_SpellRangeTypeId` FOREIGN KEY (`SpellRangeTypeId`) REFERENCES `SpellRangeTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_Spells_SpellId` FOREIGN KEY (`SpellId`) REFERENCES `Spells` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellVariants: ~0 rows (ungefähr)
DELETE FROM `SpellVariants`;

-- Exportiere Struktur von Tabelle Production.SpellVariantTranslations
CREATE TABLE IF NOT EXISTS `SpellVariantTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellVariantId` int DEFAULT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellVariantTranslations_SpellVariantId` (`SpellVariantId`),
  CONSTRAINT `FK_SpellVariantTranslations_SpellVariants_SpellVariantId` FOREIGN KEY (`SpellVariantId`) REFERENCES `SpellVariants` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.SpellVariantTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellVariantTranslations`;

-- Exportiere Struktur von Tabelle Production.Users
CREATE TABLE IF NOT EXISTS `Users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DateJoined` datetime(6) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsAdmin` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.Users: ~0 rows (ungefähr)
DELETE FROM `Users`;

-- Exportiere Struktur von Tabelle Production.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Production.__EFMigrationsHistory: ~8 rows (ungefähr)
DELETE FROM `__EFMigrationsHistory`;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
	('20220711164424_initial', '5.0.17'),
	('20220712181000_add_race', '5.0.17'),
	('20220713162442_add_fallbacks_to_alphabet', '5.0.17'),
	('20220715173657_update_feat_options', '5.0.17'),
	('20220715174731_rename_race_feat_option', '5.0.17'),
	('20220716141655_update_race_references', '5.0.17'),
	('20220716152721_update_race_property_name', '5.0.17'),
	('20220717182818_update_translations', '5.0.17'),
	('20220721175435_migrate_to_dotnet6', '6.0.7');

-- Exportiere Struktur von Tabelle Staging.ActionTimeIndicator
CREATE TABLE IF NOT EXISTS `ActionTimeIndicator` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.ActionTimeIndicator: ~0 rows (ungefähr)
DELETE FROM `ActionTimeIndicator`;

-- Exportiere Struktur von Tabelle Staging.ActionTimeIndicatorTranslation
CREATE TABLE IF NOT EXISTS `ActionTimeIndicatorTranslation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ActionTimeIndicatorId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_ActionTimeIndicatorTranslation_ActionTimeIndicatorId` (`ActionTimeIndicatorId`),
  CONSTRAINT `FK_ActionTimeIndicatorTranslation_ActionTimeIndicator_ActionTim~` FOREIGN KEY (`ActionTimeIndicatorId`) REFERENCES `ActionTimeIndicator` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.ActionTimeIndicatorTranslation: ~0 rows (ungefähr)
DELETE FROM `ActionTimeIndicatorTranslation`;

-- Exportiere Struktur von Tabelle Staging.Allignments
CREATE TABLE IF NOT EXISTS `Allignments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Allignments: ~9 rows (ungefähr)
DELETE FROM `Allignments`;
INSERT INTO `Allignments` (`Id`, `Abbreviation`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'LG', 'Lawful Good', NULL),
	(2, 'NG', 'Neutral Good', NULL),
	(3, 'CG', 'Chaotic Good', NULL),
	(4, 'LN', 'Lawful Neutral', NULL),
	(5, 'TN', 'True Neutral', NULL),
	(6, 'CN', 'Chaotic Neutral', NULL),
	(7, 'LE', 'Lawful Evil', NULL),
	(8, 'NE', 'Neutral Evil', NULL),
	(9, 'CE', 'Chaotic Evil', NULL);

-- Exportiere Struktur von Tabelle Staging.AllignmentTranslations
CREATE TABLE IF NOT EXISTS `AllignmentTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AllignmentId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AllignmentTranslations_AllignmentId` (`AllignmentId`),
  CONSTRAINT `FK_AllignmentTranslations_Allignments_AllignmentId` FOREIGN KEY (`AllignmentId`) REFERENCES `Allignments` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.AllignmentTranslations: ~18 rows (ungefähr)
DELETE FROM `AllignmentTranslations`;
INSERT INTO `AllignmentTranslations` (`Id`, `AllignmentId`, `Name`, `Description`, `CultureName`) VALUES
	(1, 1, 'Lawful Good', NULL, 'en'),
	(2, 1, 'Rechtschaffen Gut', NULL, 'de'),
	(3, 2, 'Neutral Good', NULL, 'en'),
	(4, 2, 'Neutral Gut', NULL, 'de'),
	(5, 3, 'Chaotic Good', NULL, 'en'),
	(6, 3, 'Chaotisch Gut', NULL, 'de'),
	(7, 4, 'Lawful Neutral', NULL, 'en'),
	(8, 4, 'Rechtschaffen Neutral', NULL, 'de'),
	(9, 5, 'True Neutral', NULL, 'en'),
	(10, 5, 'Neutral', NULL, 'de'),
	(11, 6, 'Chaotic Neutral', NULL, 'en'),
	(12, 6, 'Chaotisch Neutral', NULL, 'de'),
	(13, 7, 'Lawful Evil', NULL, 'en'),
	(14, 7, 'Rechtschaffen Böse', NULL, 'de'),
	(15, 8, 'Neutral Evil', NULL, 'en'),
	(16, 8, 'Neutral Böse', NULL, 'de'),
	(17, 9, 'Chaotic Evil', NULL, 'en'),
	(18, 9, 'Chaotisch Böse', NULL, 'de');

-- Exportiere Struktur von Tabelle Staging.Alphabets
CREATE TABLE IF NOT EXISTS `Alphabets` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Alphabets: ~0 rows (ungefähr)
DELETE FROM `Alphabets`;

-- Exportiere Struktur von Tabelle Staging.AlphabetTranslations
CREATE TABLE IF NOT EXISTS `AlphabetTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlphabetId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AlphabetTranslations_AlphabetId` (`AlphabetId`),
  CONSTRAINT `FK_AlphabetTranslations_Alphabets_AlphabetId` FOREIGN KEY (`AlphabetId`) REFERENCES `Alphabets` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.AlphabetTranslations: ~0 rows (ungefähr)
DELETE FROM `AlphabetTranslations`;

-- Exportiere Struktur von Tabelle Staging.CharacterItems
CREATE TABLE IF NOT EXISTS `CharacterItems` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ItemId` int DEFAULT NULL,
  `OwnerId` int DEFAULT NULL,
  `Quantity` int NOT NULL,
  `AquiredAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CharacterItems_ItemId` (`ItemId`),
  KEY `IX_CharacterItems_OwnerId` (`OwnerId`),
  CONSTRAINT `FK_CharacterItems_Characters_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `Characters` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_CharacterItems_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `Items` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CharacterItems: ~0 rows (ungefähr)
DELETE FROM `CharacterItems`;

-- Exportiere Struktur von Tabelle Staging.Characters
CREATE TABLE IF NOT EXISTS `Characters` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatorUserId` int DEFAULT NULL,
  `TrueAllignmentId` int DEFAULT NULL,
  `Budget` int NOT NULL,
  `CreationDateTime` datetime(6) NOT NULL,
  `LastModifiedDateTime` datetime(6) NOT NULL,
  `DisableNonPlaytimeEditing` tinyint(1) NOT NULL,
  `CharacterName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Characters_CreatorUserId` (`CreatorUserId`),
  KEY `IX_Characters_TrueAllignmentId` (`TrueAllignmentId`),
  CONSTRAINT `FK_Characters_Allignments_TrueAllignmentId` FOREIGN KEY (`TrueAllignmentId`) REFERENCES `Allignments` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Characters_Users_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Characters: ~0 rows (ungefähr)
DELETE FROM `Characters`;

-- Exportiere Struktur von Tabelle Staging.CreatureSizeCategories
CREATE TABLE IF NOT EXISTS `CreatureSizeCategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AttackAndArmorClassModifier` int NOT NULL,
  `SpecialAttackModifier` int NOT NULL,
  `HideModifier` int NOT NULL,
  `HeightOrLengthMin` double DEFAULT NULL,
  `HeightOrLengthMax` double DEFAULT NULL,
  `WeightMin` double DEFAULT NULL,
  `WeightMax` double DEFAULT NULL,
  `Space` double NOT NULL,
  `NaturalReachTall` int NOT NULL,
  `NaturalReachLong` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CreatureSizeCategories: ~0 rows (ungefähr)
DELETE FROM `CreatureSizeCategories`;

-- Exportiere Struktur von Tabelle Staging.CreatureSizeCategoryTranslations
CREATE TABLE IF NOT EXISTS `CreatureSizeCategoryTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureSizeCategoryId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureSizeCategoryTranslations_CreatureSizeCategoryId` (`CreatureSizeCategoryId`),
  CONSTRAINT `FK_CreatureSizeCategoryTranslations_CreatureSizeCategories_Crea~` FOREIGN KEY (`CreatureSizeCategoryId`) REFERENCES `CreatureSizeCategories` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CreatureSizeCategoryTranslations: ~0 rows (ungefähr)
DELETE FROM `CreatureSizeCategoryTranslations`;

-- Exportiere Struktur von Tabelle Staging.CreatureSubTypes
CREATE TABLE IF NOT EXISTS `CreatureSubTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CreatureSubTypes: ~0 rows (ungefähr)
DELETE FROM `CreatureSubTypes`;

-- Exportiere Struktur von Tabelle Staging.CreatureSubTypeTranslations
CREATE TABLE IF NOT EXISTS `CreatureSubTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureSubTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureSubTypeTranslations_CreatureSubTypeId` (`CreatureSubTypeId`),
  CONSTRAINT `FK_CreatureSubTypeTranslations_CreatureSubTypes_CreatureSubType~` FOREIGN KEY (`CreatureSubTypeId`) REFERENCES `CreatureSubTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CreatureSubTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `CreatureSubTypeTranslations`;

-- Exportiere Struktur von Tabelle Staging.CreatureTypes
CREATE TABLE IF NOT EXISTS `CreatureTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CreatureTypes: ~0 rows (ungefähr)
DELETE FROM `CreatureTypes`;

-- Exportiere Struktur von Tabelle Staging.CreatureTypeTranslations
CREATE TABLE IF NOT EXISTS `CreatureTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreatureTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_CreatureTypeTranslations_CreatureTypeId` (`CreatureTypeId`),
  CONSTRAINT `FK_CreatureTypeTranslations_CreatureTypes_CreatureTypeId` FOREIGN KEY (`CreatureTypeId`) REFERENCES `CreatureTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.CreatureTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `CreatureTypeTranslations`;

-- Exportiere Struktur von Tabelle Staging.Editions
CREATE TABLE IF NOT EXISTS `Editions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `System` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Core` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Editions: ~17 rows (ungefähr)
DELETE FROM `Editions`;
INSERT INTO `Editions` (`Id`, `Name`, `System`, `Core`) VALUES
	(1, 'Core (3.0)', 'DnD 3.0', 1),
	(2, 'Realms (3.0)', 'DnD 3.0', 0),
	(3, 'Generic (3.0)', 'DnD 3.0', 0),
	(4, 'Dark Sun (3.0)', 'DnD 3.0', 0),
	(5, 'Class (3.0)', 'DnD 3.0', 0),
	(6, 'Greyhawk (3.0)', 'DnD 3.0', 0),
	(7, 'Core (3.5)', 'DnD 3.5', 1),
	(8, 'Realms (3.5)', 'DnD 3.5', 0),
	(9, 'Generic (3.5)', 'DnD 3.5', 0),
	(10, 'Dark Sun (3.5)', 'DnD 3.5', 0),
	(11, 'Class (3.5)', 'DnD 3.5', 0),
	(12, 'Greyhawk (3.5)', 'DnD 3.5', 0),
	(13, 'Dragonlance (3.5)', 'DnD 3.5', 0),
	(14, 'Eberron (3.5)', 'DnD 3.5', 0),
	(15, 'Environment (3.5)', 'DnD 3.5', 0),
	(16, 'Planescape (3.5)', 'DnD 3.5', 0),
	(17, 'Races (3.5)', 'DnD 3.5', 0);

-- Exportiere Struktur von Tabelle Staging.FeatOptions
CREATE TABLE IF NOT EXISTS `FeatOptions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdList` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RaceId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FeatOptions_RaceId` (`RaceId`),
  CONSTRAINT `FK_FeatOptions_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.FeatOptions: ~0 rows (ungefähr)
DELETE FROM `FeatOptions`;

-- Exportiere Struktur von Tabelle Staging.Items
CREATE TABLE IF NOT EXISTS `Items` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Price` int NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Items: ~0 rows (ungefähr)
DELETE FROM `Items`;

-- Exportiere Struktur von Tabelle Staging.Languages
CREATE TABLE IF NOT EXISTS `Languages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlphabetId` int DEFAULT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Languages_AlphabetId` (`AlphabetId`),
  CONSTRAINT `FK_Languages_Alphabets_AlphabetId` FOREIGN KEY (`AlphabetId`) REFERENCES `Alphabets` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Languages: ~0 rows (ungefähr)
DELETE FROM `Languages`;

-- Exportiere Struktur von Tabelle Staging.LanguageTranslations
CREATE TABLE IF NOT EXISTS `LanguageTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LanguageId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_LanguageTranslations_LanguageId` (`LanguageId`),
  CONSTRAINT `FK_LanguageTranslations_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.LanguageTranslations: ~0 rows (ungefähr)
DELETE FROM `LanguageTranslations`;

-- Exportiere Struktur von Tabelle Staging.MovementManeuverabilities
CREATE TABLE IF NOT EXISTS `MovementManeuverabilities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.MovementManeuverabilities: ~0 rows (ungefähr)
DELETE FROM `MovementManeuverabilities`;

-- Exportiere Struktur von Tabelle Staging.MovementManeuverabilityTranslations
CREATE TABLE IF NOT EXISTS `MovementManeuverabilityTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MovementManeuverabilityId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_MovementManeuverabilityTranslations_MovementManeuverabilityId` (`MovementManeuverabilityId`),
  CONSTRAINT `FK_MovementManeuverabilityTranslations_MovementManeuverabilitie~` FOREIGN KEY (`MovementManeuverabilityId`) REFERENCES `MovementManeuverabilities` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.MovementManeuverabilityTranslations: ~0 rows (ungefähr)
DELETE FROM `MovementManeuverabilityTranslations`;

-- Exportiere Struktur von Tabelle Staging.MovementModes
CREATE TABLE IF NOT EXISTS `MovementModes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.MovementModes: ~0 rows (ungefähr)
DELETE FROM `MovementModes`;

-- Exportiere Struktur von Tabelle Staging.MovementModeTranslations
CREATE TABLE IF NOT EXISTS `MovementModeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MovementModeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_MovementModeTranslations_MovementModeId` (`MovementModeId`),
  CONSTRAINT `FK_MovementModeTranslations_MovementModes_MovementModeId` FOREIGN KEY (`MovementModeId`) REFERENCES `MovementModes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.MovementModeTranslations: ~0 rows (ungefähr)
DELETE FROM `MovementModeTranslations`;

-- Exportiere Struktur von Tabelle Staging.RaceAdditionalLanguages
CREATE TABLE IF NOT EXISTS `RaceAdditionalLanguages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `LanguageId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceAdditionalLanguages_LanguageId` (`LanguageId`),
  KEY `IX_RaceAdditionalLanguages_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceAdditionalLanguages_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceAdditionalLanguages_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceAdditionalLanguages: ~0 rows (ungefähr)
DELETE FROM `RaceAdditionalLanguages`;

-- Exportiere Struktur von Tabelle Staging.RaceBonusLanguages
CREATE TABLE IF NOT EXISTS `RaceBonusLanguages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `LanguageId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceBonusLanguages_LanguageId` (`LanguageId`),
  KEY `IX_RaceBonusLanguages_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceBonusLanguages_Languages_LanguageId` FOREIGN KEY (`LanguageId`) REFERENCES `Languages` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceBonusLanguages_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceBonusLanguages: ~0 rows (ungefähr)
DELETE FROM `RaceBonusLanguages`;

-- Exportiere Struktur von Tabelle Staging.RaceMovementModes
CREATE TABLE IF NOT EXISTS `RaceMovementModes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `MovementModeId` int DEFAULT NULL,
  `MovementManeuverabilityId` int DEFAULT NULL,
  `Distance` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceMovementModes_MovementManeuverabilityId` (`MovementManeuverabilityId`),
  KEY `IX_RaceMovementModes_MovementModeId` (`MovementModeId`),
  KEY `IX_RaceMovementModes_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceMovementModes_MovementManeuverabilities_MovementManeuver~` FOREIGN KEY (`MovementManeuverabilityId`) REFERENCES `MovementManeuverabilities` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceMovementModes_MovementModes_MovementModeId` FOREIGN KEY (`MovementModeId`) REFERENCES `MovementModes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceMovementModes_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceMovementModes: ~0 rows (ungefähr)
DELETE FROM `RaceMovementModes`;

-- Exportiere Struktur von Tabelle Staging.Races
CREATE TABLE IF NOT EXISTS `Races` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RuleBookId` int DEFAULT NULL,
  `RuleBookPage` int DEFAULT NULL,
  `CreatureTypeId` int DEFAULT NULL,
  `CreatureSubTypeId` int DEFAULT NULL,
  `CreatureSizeCategoryId` int DEFAULT NULL,
  `StrengthBonus` int NOT NULL,
  `DexterityBonus` int NOT NULL,
  `ConstitutionBonus` int NOT NULL,
  `IntelligenceBonus` int NOT NULL,
  `WisdomBonus` int NOT NULL,
  `CharismaBonus` int NOT NULL,
  `AdditionalSkillPoints` int NOT NULL,
  `LevelAdjustment` int DEFAULT NULL,
  `ChallengeRating` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Races_RuleBookId` (`RuleBookId`),
  KEY `IX_Races_CreatureSizeCategoryId` (`CreatureSizeCategoryId`),
  KEY `IX_Races_CreatureSubTypeId` (`CreatureSubTypeId`),
  KEY `IX_Races_CreatureTypeId` (`CreatureTypeId`),
  CONSTRAINT `FK_Races_CreatureSizeCategories_CreatureSizeCategoryId` FOREIGN KEY (`CreatureSizeCategoryId`) REFERENCES `CreatureSizeCategories` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_CreatureSubTypes_CreatureSubTypeId` FOREIGN KEY (`CreatureSubTypeId`) REFERENCES `CreatureSubTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_CreatureTypes_CreatureTypeId` FOREIGN KEY (`CreatureTypeId`) REFERENCES `CreatureTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Races_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Races: ~0 rows (ungefähr)
DELETE FROM `Races`;

-- Exportiere Struktur von Tabelle Staging.RaceSenses
CREATE TABLE IF NOT EXISTS `RaceSenses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `SenseId` int DEFAULT NULL,
  `Distance` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSenses_RaceId` (`RaceId`),
  KEY `IX_RaceSenses_SenseId` (`SenseId`),
  CONSTRAINT `FK_RaceSenses_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_RaceSenses_Senses_SenseId` FOREIGN KEY (`SenseId`) REFERENCES `Senses` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceSenses: ~0 rows (ungefähr)
DELETE FROM `RaceSenses`;

-- Exportiere Struktur von Tabelle Staging.RaceSpecialAbilities
CREATE TABLE IF NOT EXISTS `RaceSpecialAbilities` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSpecialAbilities_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceSpecialAbilities_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceSpecialAbilities: ~0 rows (ungefähr)
DELETE FROM `RaceSpecialAbilities`;

-- Exportiere Struktur von Tabelle Staging.RaceSpecialAbilityTranslations
CREATE TABLE IF NOT EXISTS `RaceSpecialAbilityTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceSpecialAbilityId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceSpecialAbilityTranslations_RaceSpecialAbilityId` (`RaceSpecialAbilityId`),
  CONSTRAINT `FK_RaceSpecialAbilityTranslations_RaceSpecialAbilities_RaceSpec~` FOREIGN KEY (`RaceSpecialAbilityId`) REFERENCES `RaceSpecialAbilities` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceSpecialAbilityTranslations: ~0 rows (ungefähr)
DELETE FROM `RaceSpecialAbilityTranslations`;

-- Exportiere Struktur von Tabelle Staging.RaceTranslations
CREATE TABLE IF NOT EXISTS `RaceTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RaceId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RaceTranslations_RaceId` (`RaceId`),
  CONSTRAINT `FK_RaceTranslations_Races_RaceId` FOREIGN KEY (`RaceId`) REFERENCES `Races` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RaceTranslations: ~0 rows (ungefähr)
DELETE FROM `RaceTranslations`;

-- Exportiere Struktur von Tabelle Staging.RuleBooks
CREATE TABLE IF NOT EXISTS `RuleBooks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EditionId` int NOT NULL,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PublishedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RuleBooks_EditionId` (`EditionId`),
  CONSTRAINT `FK_RuleBooks_Editions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `Editions` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=114 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RuleBooks: ~110 rows (ungefähr)
DELETE FROM `RuleBooks`;
INSERT INTO `RuleBooks` (`Id`, `EditionId`, `FallbackName`, `Abbreviation`, `FallbackDescription`, `PublishedAt`) VALUES
	(4, 7, 'Dungeon Master\'s Guide I', 'DMG', 'Weave exciting tales of heroism filled with magic and monsters. Within these pages, you\'ll discover the tools and options you need to create detailed worlds and dynamic adventures for your players to experience in the Dungeons & Dragons roleplaying game.\nThe revised Dungeon Master\'s Guide is an essential rulebook for Dungeon Masters of the D&D game. The Dungeon Master\'s Guide has been reorganized to be more user friendly. It features information on running a D&D game, adjudicating play, writing adventures, non-player characters (including non-player character classes), running a campaign, characters, magic items (including intelligent and cursed items, and artifacts), and a dictionary of special abilities and conditions. Changes have been made to the item creation rules and pricing, and prestige classes new to the Dungeon Master\'s Guide are included (over 10 prestige classes). The revision includes expanded advice on how to run a campaign and instructs players on how to take full advantage of the tie-in D&D miniatures line.', NULL),
	(5, 7, 'Monster Manual I', 'MM', 'Fearsome and formidable foes lurk within. Encounter a horde of monsters armed and ready to battle your boldest heroes or fight alongside them. The fully illustrated pages of this book are overrun with all the creatures, statistics, spells, and strategies you need to challenge the heroic characters of any Dungeons & Dragons role-playing game.\nOver 200 creeps, critters, and creatures keep players on their toes. From aboleths to zombies, the revised Monster Manual holds a diverse cast of enemies and allies essential for any Dungeons & Dragons campaign. There are hundreds of monsters ready for action, including many new creatures never seen before. The revised Monster Manual now contains an adjusted layout that makes monster statistics easier to understand and use. It has 31 new illustrations and a new index, and contains expanded information on monster classes and playing monsters as heroes, along with information on how to take full advantage of the tie-in D&D miniatures line planned for the fall of 2003 from Wizards of the Coast, Inc.', NULL),
	(6, 7, 'Player\'s Handbook I', 'PH', '', NULL),
	(7, 13, 'Dragonmarked', 'Dra', ' Dragonmarked offers an in-depth look at the power of dragonmarks and the thirteen dragonmarked houses of the Eberron world. It also provides exciting new options for players with dragonmarked characters, including role-playing hooks, new feats, new prestige classes, and new spells.', NULL),
	(8, 13, 'Faiths of Eberron', 'FE', '', NULL),
	(9, 13, 'Magic of Eberron', 'MoE', '', NULL),
	(10, 13, 'Races of Eberron', 'RE', 'Races of Eberron expands on the information presented about the four new Eberron races (warforged, shifter, changeling and kalashtar) as well as giving more information regarding the common races and how they differ on Eberron. It also features the ubiquitous slew of feats, prestige classes, spells and magic items to immerse your character more fully in the Eberron world.', NULL),
	(11, 13, 'Sharn: City of Towers', 'Sh', '', NULL),
	(12, 13, 'Eberron Campaign Setting', 'ECS', '', NULL),
	(13, 13, 'Player\'s Guide to Eberron', 'PE', '', NULL),
	(14, 13, 'Secrets of Sarlona', 'SoS', 'Secrets of Sarlona explores the continent of Sarlona for the first time. It gives players and Dungeon Masters their first real glimpse inside the empire of Riedra, home of the Inspired and the kalashtar. It also explores the mysteries of Adar, a nation isolated from the rest of the world, and never-before seen locations. Secrets of Sarlona also presents new options (feats, prestige classes, spells, and magic items) available to Sarlonan characters and characters with psionics. ', NULL),
	(15, 13, 'Secrets of Xen\'drik', 'SX', '', NULL),
	(16, 8, 'City of Splendors: Waterdeep', 'CSW', '*City of Splendors: Waterdeep* offers an in-depth examination of the great city of Waterdeep in the Forgotten Realms setting. An overview of the city includes history, a who?s who, information on laws, and rules for running and playing in a Watered havian campaign. Information on the people of Waterdeep covers non-player characters, arcane schools, armed forces, guilds, nobility, prestige classes specific to the city, and more. Also included in the book are discussions of specific Waterdeep locales, adventure locales, and new monsters. An extensive appendix gives information on new equipment, magic items,  psionic powers, poisons, spells, and more.', NULL),
	(17, 3, 'Enemies and Allies', 'EA', '', NULL),
	(18, 2, 'Faiths & Pantheons', 'FP', '', NULL),
	(19, 2, 'Forgotten Realms Campaign Setting', 'FRCS', '', NULL),
	(20, 2, 'Magic of Faerun', 'Mag', '', NULL),
	(21, 2, 'Monster Compendium: Monsters of Faerûn', 'Mon', '', NULL),
	(22, 8, 'Player\'s Guide to Faerûn', 'PG', '', NULL),
	(23, 2, 'Races of Faerun', 'Rac', '', NULL),
	(24, 8, 'Serpent Kingdoms', 'SK', 'Chilling fireside tales describe the fell plans and foul actions of the horrors known as the Scaled Ones: lizardfolk, nagas, yuan-ti, and their sinister creator race, the sarrukh. Infinitely patient and ruthless, the insidious serpentfolk seek to enslave all of Faer?n\'s other races to breed them like cattle. For those bold enough to peer within, Serpent Kingdoms offers an unsettlingly detailed look at the malevolent serpentfolk and lizard races of the Forgotten Realms game setting.', NULL),
	(25, 8, 'Shining South', 'ShS', '', NULL),
	(26, 8, 'Dragons of Faerun', 'DrF', '', NULL),
	(27, 8, 'Champions of Ruin', 'CR', '', NULL),
	(28, 8, 'Champions of Valor', 'CV', '', NULL),
	(29, 8, 'Lost Empires of Faerun', 'LE', '', NULL),
	(30, 8, 'Power of Faerun', 'PF', '', NULL),
	(31, 2, 'Unapproachable East', 'Una', 'Tales from beyond the Easting Reach are told with awed voices and hushed tones. Known to most of Faerun as the homeland of the Simbul, the hathrans, and the Red Wizards, the Unapproachable East is filled with dark secrets, insidious plots, and untold adventure. Discover the people, politics, cities, and societies of the region, along with the monsters, nefarious organizations, and other perils that await unwary travelers in this treacherous corner of the Forgotten Realms game setting.', NULL),
	(32, 8, 'Underdark', 'Und', '', NULL),
	(33, 3, 'Arms and Equipment Guide', 'AE', '', NULL),
	(34, 3, 'Book of Challenges: Dungeon Rooms, Puzzles, and Traps', 'BC', 'Danger Around Every Corner and Behind Every Screen!\nThe greatest threat to any adventuring party is a devious Dungeon Master. This book is spring-loaded with ideas, both subtle and sinister, that will ensure every gaming session is appropriately hazardous, including:\n* Over fifty encounters designed to be dropped into any campaign.\n* Scalable scenarios that can be pitted against characters from 1st to 20th level.\n* Advice for creating your own deceptive and deadly situations.\nDungeon Masters who want to keep their players on their toes will be inspired by the invaluable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual.', NULL),
	(35, 3, 'Book of Vile Darkness', 'BV', '"Only the most indomitable minds dare to look upon the malevolent thoughts and forbidden secrets bound herein. This corrupt tome is filled with deplorable wisdom, malignant ideas, and descriptions of creatures, rites, and practices most foul. Evil permeates every word and image inscribed within it."\n-- Orcus, Demon Prince of the Undead\nThis sourcebook for the Dungeons & Dragons game is intended for mature audiences and provides a Dungeon Master with unflinching access to subject matter that will broaden any campaign. Included in a detailed look at the nature of evil and the complex challenge of confronting the many dilemmas found within its deepest shadows. Along with wicked spells, wondrous items, and artifacts, Book of Vile Darkness also provides descriptions and statistics for a host of abominable monsters, archdevils, and demon princes to pit againt the noblest of heroes.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual.', NULL),
	(36, 5, 'Defenders of the Faith: A Guidebook to Clerics and Paladins', 'DF', 'Divine dedication powers these crusaders.\nThis book spotlights the champions of deities in the D&D game, clerics and paladins. It\'s packed with ways to customize cleric and paladin characters, including: \n* New feats, prestige classes, weapons, and equipment\n* More uses for turning checks, and new magic items and spells designed specially for clerics and paladins\n* Information about special organizations such as the Laughing Knives and the Stargazers\n* Detailed maps of temples that players and Dungeon Masters can use as bases of operation or as enemy structures that must be brought down\n\n\nIndispensable to both players and Dungeon Masters, this book adds excitement to any campaign.', NULL),
	(37, 3, 'Deities and Demigods', 'DD', 'Source of All Divine Power\nThe names of Pelor, Loki, Athena, Osiris, and their kind are invoked by the devout as well as the desperate. With abilities that reach nearly beyond the scope of mortal imagination, the splendor of the gods humbles even the greatest of heroes.\nThis supplement for the D&D game provides everything you need to create and call upon the most powerful beings in your campaign. Included are descriptions and statistics for over seventy gods from four fully detailed pantheons. Along with suggestions for creating your own gods, Deities and Demigods also includes information on advancing characters to godhood.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(38, 7, 'Dungeon Master\'s Guide II', 'DMG2', '', NULL),
	(39, 3, 'Epic Level Handbook', 'EL', 'Legends Begin Here\nSongs are sung and tales are told of heroes who have advanced beyond most adventuring careers. They confront mightier enemies and face deadlier challenges, using powers and abilities that rival even the gods.\nThis supplement for the D&D game provides everything you need to transcend the first twenty levels of experience and advance characters to virtually unlimited levels of play. Along with epic magic items, epic monsters, and advice on running an epic campaign, the Epic Level Handbook also features epic NPCs from the Forgotten Realms and Greyhawk campaign settings.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(40, 9, 'Fiend Folio', 'FF', '', NULL),
	(41, 3, 'Manual of the Planes', 'MP', 'Visit New Dimensions\nThe most powerful adventurers know that great rewards--and great perils--await them beyond the world they call home. From the depths of Hell to the heights of Mount Celestia, from the clockwork world of Mechanus to the swirling chaos of Limbo, these strange and terrifying dimensions provide new challenges to adventurers who travel there. Manual of the Planes is your guidebook on a tour of the multiverse.\nThis supplement for the D&D game provides everything you need to know before you visit other planes of existence. Included are new prestige classes, spells, monsters, and magic items. Along with descriptions of dozens of new dimensions, Manual of the Planes includes rules for creating your own planes.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(42, 5, 'Masters of the Wild: A Guidebook to Barbarians, Druids, and Rangers', 'MW', 'These Forces of Nature Can Weather Any Storm\nBarbarians, druids, and rangers are the rugged and noble champions of untamed lands. This book teems with new ways to customize even the most seasoned characters, including:\n\n\n* New feats, weapons, spells, and magic items.\n* Improved, more detailed rules for the wild shape ability.\n* New prestige classes such as the frenzied berserker, the windrider, and the oozemaster.\n* A new type of magic item -- the infusion.\n\n\nDungeon Masters and players who want to add a new dimension to their barbarians, druids, and rangers will uncover a cache of indispensable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(43, 7, 'Monster Manual II', 'MM2', 'Even Greater Threats Await!\nAs heroes grow in power, they seek out more formidable adversaries. Whether sinister or seductive, ferocious or foul, the creatures lurking within these pages will challenge the most experienced characters of any campaign.\nThis supplement for the D&D game unleashes a horde of monsters to confront characters at all levels of play, including several with Challenge Ratings of 21 or higher. Inside are old favorites such as the death knight and the gem dragons, as well as all-new creatures such as the bronze serpent, the effigy, and the fiendwurm. Along with updated and expanded monster creation rules, Monster Manual II provides an inexhaustible source of ways to keep even the toughest heroes fighting and running for their lives.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook and the Dungeon Master\'s Guide. A player needs only the Player\'s Handbook.', NULL),
	(44, 3, 'Psionics Handbook', 'PsH3', '', NULL),
	(45, 3, 'Savage Species', 'SS', 'A New Breed of Adventurer\nWhether wondrous or wicked, some monsters have a calling that reaches beyond the ordinary existence of their kind. Traveling alongside other intrepid characters, these heroic creatures carve their places in legend with sword, spell, tooth, and claw.\nThis supplement for the D&D game provides everything you need to play a monster as a character or to make the monsters your heroes fight even more formidable. Inside are over 50 all-new monster classes that show how creatures develop their characteristics and abilities as they gain levels. Along with new prestige classes and monster templates, Savage Species also features new feats, spells, magic items, and more.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook and the Monster Manual.', NULL),
	(46, 5, 'Song and Silence: A Guidebook to Bards and Rogues', 'SaS', 'Finesse and Versatility Make Powerful Allies\nBards and rogues rely on a stunning array of skills and abilities to give them an edge over any adversary. Packed with new ways to customize even the most artful characters this book includes:\n\n* New feats, prestige classes, weapons, spells, magic items, and equipment.\n* Complete guidelines for trapmaking, including 90 sample traps.\n* Descriptions of a wide range of thieves\' guilds and bardic colleges.\n* Detailed rules for flanking opponents in combat.\n\nDungeon Masters and players who want to add a new dimension to their bards and rogues will find a wealth of indispensable material within these pages.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(47, 3, 'Stronghold Builder\'s Guidebook', 'SB', 'Defenses Wrought of Mortar and Magic\nHeroes need impregnable fortresses to assault, wondrous towers to explore, and majestic castles to protect. This book is stocked with everything needed to design any fortified structure imaginable, including:\n\n* Over 150 new magic items\n* More than two dozen magical augmentations for stronghold walls\n* Rules for magic portals, mobile strongholds, and trap creation\n* Five complete strongholds, including maps, ready for immediate use\n\nPlayers and Dungeon Masters who want to create customized strongholds will find all the construction materials they need within these pages.\nTo use this accessory, a player or Dungeon Master also needs the Player\'s Handbook.', NULL),
	(48, 5, 'Sword and Fist: A Guidebook to Monks and Fighters', 'SF', '', NULL),
	(49, 5, 'Tome and Blood: A Guidebook to Wizards and Sorcerers', 'TB', 'A Spell Is Better than a Thousand Words\nEvery mystic library reserves a place for this single potent volume of arcane lore. It\'s packed with ways to customize sorcerer and wizard characters, including:\n\n* New feats, spells, and magic items.\n* New prestige classes, including the dragon disciple, fatespinner, and pale master.\n* Information about special organizations such as the Broken Wands and the Arcane Order.\n* Maps of a mages\' guildhall and a home that a sorcerer and a wizard share.\n\nTome and Blood is indispensable to players and Dungeon Masters who want to add a new dimension to sorcerers and wizards.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, the Dungeon Master\'s Guide, and the Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(50, 9, 'Book of Exalted Deeds', 'BE', 'Strike Down Evil with the Sword of Enlightenment\nOnly those who are pure in word, thought, and deed may look upon the knowledge gathered within this blessed tome. For the blinding truths inscribed within offer nothing but redemption or destruction for the wicked. May these consecrated pages forever illuminate the paths of the righteous.\n-- Raziel the Crusader, ruler of the Platinum Heaven\nAs the Book of Vile Darkness was a resource book on the most evil elements of campaign play, the Book of Exalted Deeds focuses instead on the availability of good resources and features in the D&D spectrum.\nIncluded are new exalted feats, prestige classes, races, spells, magic items, and descriptions and statistics for a host of creatures and celestial paragons to ally with virtuous characters. The Book of Exalted Deeds also provides descriptions and statistics for a host of creatures and celestial paragons to ally with virtuous characters.\nBook of Exalted Deeds is the second title in the line of Dungeons & Dragons products specifically aimed at a mature audience. \nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(51, 14, 'CityScape', 'Ci', 'As Deadly as Any Dungeon\nThere\'s more to adventuring than crawling around in dungeons. The city holds many avenues of peril and intrigue. It teems with adventure and offers unsurpassed opportunities and challenges. Dark alleys, busy guildhalls, rowdy taverns, fetid sewers, and palatial manors hold secrets to be discovered and mysteries to be explored.\nThis supplement for the DUNGEONS & DRAGONS game reveals the city in all its grandeur and grimness. It makes the urban dungeon feel alive with politics and power, especially through influential guilds. This tome also describes new feats, spells, urban terrain, hazards, and monsters guaranteed to make the party\'s next visit to the city a vibrant and exhilarating event.', NULL),
	(52, 11, 'Complete Adventurer', 'CAd', 'Sharpen Your Survival Skills\nTaverns are filled with tales of talented heroes and their breathtaking exploits. The prowess and ingenuity of these remarkable characters gives them the edge to succeed where others cannot.\nThis supplement for the D&D game provides everything you need to sharpen the skills and enhance the abilities of characters of any class. Along with new base classes, prestige classes, feats, spells, monsters, and magic items, Complete Adventurer provides alternate uses for skills and other options that expand the capabilities of the most versatile heroes.', NULL),
	(53, 11, 'Complete Arcane', 'CAr', 'Master Eldritch Secrets and Formidable Power\nMyth and mystery surround those who wield the awe-inspiring might of arcane magic. Whether through ancient knowledge, innate talent, or supernatural gift, these formidable and versatile spell-casters command powers beyond measure.\nThis supplement for the D&D game provides everything you need to expand the power of arcane magic for characters of any class. Along with new base classes, prestige classes, feats, spells, monsters, and magic items, Complete Arcane provides guidelines for spell duels, arcane organizations, and other aspects of a campaign world imbued with magic.', NULL),
	(54, 11, 'Complete Divine', 'CD', 'Wield Power Granted by the Gods\nLegends tell of brave champions whose unwavering faith earned them the favor of the gods. Empowered by the might and magic of their deity, these devoted characters transcend the realm of mere heroes.\nThis supplement for the D&D game provides everything you need to create divinely inspired characters of any class. Along with new base classes, prestige classes, feats, spells, magic items, and relics, Complete Divine also provides guidelines for incorporating religion -- from mysterious cults to powerful theocracies -- into your campaign.\nCover Illustration: Matt Cavotta. (The credits in the printed product incorrectly credited the cover art to another artist. We apologize to Matt for this error.)', NULL),
	(55, 11, 'Complete Champion', 'CC', 'New options for heroes with a divine cause.\nComplete Champion focuses on the divine champion archetype and provides new rules options for characters who enjoy battling for a cause, defeating foes using divine power, and going on quests that mean more than simply defeating the bad guy and grabbing the treasure. This book also helps Dungeon Masters run quest-themed campaigns and adventures.\nIn addition to providing various archetypes for characters, Complete Champion includes new feats and prestige classes. The book features dozens of deity- and belief-themed organizations, turning religion and holy (or unholy) power into something characters of all classes can use. For the Dungeon Master, this book contains information on constructing and running quests and holy missions. It assists the DM in helping all characters in the party to pursue divine paths simultaneously.', NULL),
	(56, 11, 'Complete Mage', 'CM', 'Arcane Power at Your Fingertips\nEvery sentient creature is born with some potential to work magic. However, true mastery of arcane magic requires skill, practice, and power beyond the reach of common folk specifically, the power to harness raw magic and shape it into a desired effect. You are among those gifted few who have learned to channel arcane magic, shaping it to serve your creative or destructive whims.\nThis D&D supplement is intended for players and Dungeon Masters. In addition to providing the definitive treatise on arcane magic, it expands the character options available to users of arcane magic, including bards, sorcerers, wizards, assassins, warlocks, and wu jen. Herein you\'ll find never-before-seen prestige classes, spells and invocations, magic items, alchemical items, heritage feats, and reserve feats (a new type of feat that grants special abilities to those who remain charged with magical power). Alternative class features give other character classes from the barbarian to the rogue a little taste of what it\'s like to be an arcanist without sacrificing their core identities.', NULL),
	(57, 11, 'Complete Psionic', 'CP', '', NULL),
	(58, 11, 'Complete Scoundrel', 'CS', 'Fair Fights are for Suckers\nIn a world filled with monsters and villains, a little deception and boldness goes a long way. You know how to take advantage of every situation, and you don\'t mind getting your hands dirty. Take the gloves off? Ha! You never put them on. You infuriate your foes and amaze your allies with your ingenuity, resourcefulness, and style. For you, every new predicament is an opportunity in disguise, and with each sweet victory your notoriety grows. That is how legends are made.\nThis D&D supplement gives you everything you need to get the drop on your foes and escape sticky situations. In addition to new feats, spells, items, and prestige classes, Complete Scoundrel presents new mechanics that put luck on your side and a special system of skill tricks that allow any character to play the part of a scoundrel. Tricky tactics aren\'t just for rogues anymore. ', NULL),
	(59, 11, 'Complete Warrior', 'CW', 'Forge your name in battle!\nThe Complete Warrior provides you with an in-depth look at combat and provides detailed information on how to prepare a character for confrontation.\nThis title was not only compiled from various D&D sources, but contains new things as well, including new battle-oriented character classes, prestige classes, combat maneuvers, feats, spells, magic items, and equipment. The prestige classes included have been revised and updated based on player feedback, and there are rules for unusual combat situations. The Complete Warrior will assist all class types, including those classes not typically associated with melee combat. There are also tips on running a martially focused campaign and advice on how to make your own prestige classes and feats.\nTo use this accessory, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(60, 9, 'Dragon Magic', 'DM', '', NULL),
	(61, 14, 'Dungeonscape', 'Du', 'Welcome to the Dungeon!\nSince the dawn of the DUNGEONS & DRAGONS game, the dungeon has remained a place of mystery, excitement, and danger. Purple worms burrow through the earth, eager for their next meal. Savage orcs lurk within the darkness, ready to surge forth and lay waste to civilized lands. Strange cults, mutated monsters, and forgotten gods hide within the choking darkness of the dungeon\'s halls. Nowhere else offers greater prospects for wealth, magic, and power. Yet the horrors that lurk beneath the world never give up their treasures without a fight....\nThis D&D supplement presents a refreshing new take on dungeon adventures. It shows Dungeon Masters how to inject excitement, innovation, and thrilling adventure into their dungeons. New rules for encounter traps allow DMs to build deadly snares to catch the unwary. For players, the factotum class is a cunning wanderer, a jack-of-all-trades who can cope with anything the dungeon throws at him. New equipment, feats, and prestige classes give adventurers the tools they need to survive the dark beneath the earth.', NULL),
	(62, 9, 'Exemplars of Evil', 'EE', 'The Exemplars of Evil supplement shows Dungeon Masters how to construct memorable campaign villains and presents nine ready-to-play villains of various levels that can be easily incorporated into any D&D campaign. Each villainous entry provides complete statistics for the villain (or villains), as well as adventure seeds, campaign hooks, pregenerated minions, and a fully detailed lair.\nROBERT J. SCHWALB is a staff designer and developer for Green Ronin Publishing. His design credits for Wizards include the Player\'s Handbook II, Tome of Magic, and Fiendish Codex II: Tyrants of the Nine Hells supplements. Robert lives in Tennessee with his patient wife and pride of cats.', NULL),
	(63, 9, 'Expanded Psionics Handbook', 'XPH', 'Tap into the power of the mind.\nThrough sheer force of will, a psionic character can unleash awesome powers that rival any physical force or magical energy. Within these pages, you will discover the secrets of unlocking the magic of the mind -- the art of psionics.\nWith updated and increased content, including a newly balanced psionics power system, the Expanded Psionics Handbook easily integrates psionic characters, powers, and monsters into any Dungeons & Dragons campaign.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(64, 9, 'Fiendish Codex I: Hordes of the Abyss', 'FCI', '', NULL),
	(65, 9, 'Fiendish Codex II: Tyrants of the Nine Hells', 'FCII', 'The evil that finds you might not be the one that you expect. Learn more about devils and their insidious ways in Fiendish Codex II, where both Dungeon Masters and players alike can find something useful to either enhance the evil of their devilish villains or fight it. For a sample of what\'s in store for you in this tome, take a look at Dis, a list of new feats, the hellfire warlock prestige class, a list of new spells, and the assassin devil.', NULL),
	(66, 14, 'Frostburn', 'Fr', 'Survival at Sub-Zero\nMarrow-chilling conditions, deadly hazards, and other dangers threaten explorers of frostfell environments. Whether traveling through polar regions and frozen mountaintops to ice-glazed dungeons and the Ice Wastes of the Abyss, a wintry grave awaits those who venture forth unprepared.\nThis supplement for the D&D game explores the impact of arctic conditions and extreme cold-weather environments on every aspect of game play. Along with rules for adapting to, navigating through, and surviving hazardous cold-weather conditions and terrain, Frostburn also includes new spells, feats, magic items, prestige classes, and monsters associated with icy realms.', NULL),
	(67, 9, 'Heroes of Battle', 'HB', 'Prepare for WarGreat conflicts erupt between rival nations and threaten to sweep across entire continents. As armies clash in epic battles, the actions of a handful of bold heroes can turn the tide of war. Whether in the thick of combat or on a secret mission of dire importance, brave champions have an impact that echoes across the battlefield and resounds through the ages.\nThis supplement for the D&D game reveals the pivotal roles characters can play in the midst of great battles. With rules and options for creating or playing adventures on and around battlefields, Heroes of Battle plunges characters into wartime situations and challenges them with climactic battles of epic proportions.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook and Dungeon Master\'s Guide. A player needs only the Player\'s Handbook.\nHeroes of Battle provides everything one needs to know to play a battle-oriented D&D campaign. You can build military characters with new feats, spells, uses for traditional spells, and prestige classes. Information is given on tools specific to the battlefield, including siege engines, weapons, magic items, steeds, and other exotic mounts. Battlefield terrain aspects are discussed with plenty of illustrative maps and new rules. Specific types of battlefield encounters are discussed in detail, and the book provides specific detail on designing battlefields.', NULL),
	(68, 9, 'Heroes of Horror', 'HH', 'Heroes of Horror  provides everything players and Dungeon Masters need to play and run a horror-oriented campaign or integrate elements of creepiness & tension into their existing campaigns. Players can develop heroes or anti-heroes using new feats, new spells, new base classes and prestige classes, and new magic items. The book presents new mechanics for different types of horror, including rules for dread and tainted characters, as well as plenty of new horrific monsters and adventure seeds. Different types and genres of horror are discussed in detail.', NULL),
	(69, 9, 'Libris Mortis: The Book of the Dead', 'LM', 'Nightmares from Beyond the Grave\nHushed voices tell spine-chilling tales of encounters with the walking dead and other unliving horrors. No other creatures have evoked such fear and fascination as this dreadful menagerie of malevolent spirits and mindless shells.\nThis supplement for the D&D game presents a comprehensive overview of the undead. You\'ll uncover information for creating, customizing, and combating undead characters and monsters -- including strategies and tactics commonly employed by undead and those who hunt them. Libris Mortis: The Book of Undead also provides new rules, feats, spells, and prestige classes, along with a host of new monsters and monster templates.', NULL),
	(70, 9, 'Lords of Madness', 'LoM', 'Unnatural Creatures of Unspeakable Evil\nTrembling hands have recorded horrifying stories of encounters with aboleths, beholders, mind flayers, and other aberrations. The victims of these alien creatures are quickly overwhelmed by mind-numbing terror -- their only comfort is the hope for a quick death.\nThis supplement for the D&D game presents a comprehensive look at some of the most bizarre creatures ever to invade the world of fantasy roleplaying. Along with information about the physiology, psychology, society, and schemes of these strange beings, you\'ll find spells, feats, tactics, and tools commonly employed by those who hunt them. Lords of Madness: The Book of Aberrations also provides new rules, prestige classes, monsters, sample encounters, and fully developed NPCs ready to instill fear in any hero.', NULL),
	(71, 9, 'Magic Item Compendium', 'MIC', '', NULL),
	(72, 9, 'Magic of Incarnum', 'MoI', 'This supplement introduces a magical substance called incarnum into the D&D game. With this book, the players characters can meld incarnum the power of souls living, dead, and unborn into magical items and even their own bodies, granting them special attacks, defenses, and other abilities (much as magic items and spells do). Incarnum can be shaped and reshaped into new forms, giving characters tremendous versatility in the dungeon and on any battlefield.\n This book also features new classes, prestige classes, feats, and other options for characters wishing to explore the secrets of incarnum, as well as rules and advice for including incarnum in a D&D campaign.', NULL),
	(73, 9, 'Miniatures Handbook', 'MH', 'Cries of battle fill the air!\nThe Miniatures Handbook gives you expanded rules for regular Dungeons & Dragons game play as well as guidelines for skirmishes and mass combats.\nIncluded are new base classes, new prestige classes, 30 new feats, more than 65 new spells, new magic items, and weapon special abilities. Also, there are more than 35 new monsters, including formidable aspects of deities and archfiends.\nExpand your battlefield with complete rules for skirmishes, squad-based fights, and even mass battles. There are also mechanics for random dungeons and rules for miniatures battle campaigns.\nTo use this supplement, a Dungeon Master also needs the Player\'s Handbook, Dungeon Master\'s Guide, and Monster Manual. A player needs only the Player\'s Handbook.', NULL),
	(74, 7, 'Monster Manual III', 'MM3', 'Encounter additional adversaries and allies\nLairing within these pages is an unstoppable wave of creatures ranging from ambush drake to zezir. A menagerie of beasts, behemoths and other ferocious beings, the monsters presented here are well prepared to battle or befriend the characters of any campaign.\nThis supplement for the D&D game offers a fully illustrated array of new creatures such as the boneclaw, eldritch giant, and web golem. Also included are advanced versions of some monsters as well as tactics sections to help DMs effectively run more complex creatures. Additionally, many entries contain information about where monsters are likely to appear in the Forgotten Realms and Eberron campaign settings.', NULL),
	(75, 7, 'Monster Manual IV', 'MM4', 'An indispensable resource containing new monsters suitable for any Dungeons & Dragons game.\nMonster Manual IV is the most recent volume in the bestselling Monster Manual line. Sure to be popular with both Dungeon Masters and players, this supplement to the D&D game provides descriptions for a vast array of new creatures. Each monster is illustrated and features a new stat block format that facilitates faster gameplay. In addition, the book includes sample encounters, pregenerated treasure hoards, and sidebars on how to incorporate the creatures in a Forgotten Realms or Eberron campaign. This product is tied to 2006\'s Year of Dragons theme, which is a key marketing platform across the D&D RPG, novels, and miniatures brands.', NULL),
	(76, 7, 'Monster Manual V', 'MM5', 'New monsters ideal for any Dungeons & Dragons game.\nMonster Manual V is the most recent volume in the best-selling Monster Manual line. This 224-page D&D supplement presents a fully illustrated horde of new monsters, as well as ready-to-play variations of previously existing monsters. In addition, this supplement features maps of monster lairs, sample encounters, and tactics sections to help Dungeon Masters run the more complex creatures. Additionally, many entries contain information about where monsters are likely to appear in the Forgotten Realms and Eberron campaign settings.', NULL),
	(77, 9, 'Planar Handbook', 'PlH', 'Explore Never-Ending Realms of Adventure\nOnly the most exceptional characters dare tread the infinite paths of the planes. From Sigil, the City of Doors, to the Blinding Tower at the heart of the Plane of Shadow, to the Elemental Plane of Fire\'s storied City of Brass, countless perilous locations in the multiverse await bold heroes armed with remarkable talents and abilities, more than a little courage, and above all, knowledge.\nThis supplement for the D&D game provides everything you need to create and play characters prepared for the odyssey of planar travel, including new planar races, feats, equipment, spells, and magic items. The Planar Handbook also introduces the power of planar touchstones, along with details and advice for visiting dozens of planar sites.', NULL),
	(78, 7, 'Player\'s Handbook II', 'PH2', 'A follow-up to the Player\'s Handbook designed to aid players and provide more character options.\nThe Player\'s Handbook II builds upon existing materials in the Player\'s Handbook. This is the first direct followup to the best-selling and most used D&D rulebook. It is specifically designed to expand the options available for players by both providing new material and increasing the uses for existing rules. Included are chapters on character race, background, classes, feats, spells, character creation, and character advancement. New rules include racial affiliations that make race matter as a character advances in level, new character classes and alternate class features for existing classes, new feats, tools for rapid character creation, and additional organization and teamwork benefits -- an option first introduced in Dungeon Master\'s Guide II and Heroes of Battle.', NULL),
	(79, 16, 'Races of Destiny', 'RD', 'Heroes Adapted to Adventure\nHailing from towns and villages in every corner of the world, resourceful and resilient adventurers emerge from among the races of destiny: humans, half-elves, half-orcs, and illumians. With an unparalleled drive to explore and experience, these diverse individuals have created names to last throughout the ages.\nThis supplement for the D&D game provides detailed information on the psychology, society, culture, behavior, religion, folklore, and other aspects of the races of destiny, including the illumians -- a new race presented here. In addition to new subraces and monster races playable as characters, Races of Destiny also provides new prestige classes, feats, spells, magic items, equipment, and guidelines for crafting memorable adventures within human settlements.', NULL),
	(80, 16, 'Races of Stone', 'RS', '', NULL),
	(81, 16, 'Races of the Dragon', 'RDr', ' A new D&D sourcebook detailing races descended from dragons. \n Races of the Dragon provides D&D players and Dungeon Masters with an in-depth look at races descended from or related to dragons. In addition to exploring the fan-favorite kobold race, Races of the Dragon introduces two new races, dragonborn and spellscales, and provides information on half-dragons. The dragonborn are a transitive race, an exciting new concept that allows players to transform from their initial race into a new one. This book also includes a wealth of cultural information and new prestige classes, feats, equipment, spells, and magic items. \n Gwendolyn F.M. Kestrel works for Wizards of the Coast, Inc. as a game designer. Her previous design credits include the Races of Eberron (tm), Monster Manual (tm) III, and Underdark (tm) roleplaying games. Jennifer Clarke Wilkes is an editor for Wizards of the Coast, Inc. She works primarily on the Dungeons & Dragons Miniatures line but has edited various roleplaying game books. She co-authored Savage Species (tm) and Sandstorm (tm). \n Kolja Raven Liquette is best known for authoring The Waking Lands web site. He has also published articles in Dragon Magazine. His previous publishing credits include Weapons of Legacy (tm). ', NULL),
	(82, 16, 'Races of the Wild', 'RW', 'Heroes Tempered by Nature\nFrom within verdant forests, among nomadic caravans, or atop soaring cliffsides, courageous adventurers arise from the people known as the races of the wild: elves, halflings, and raptorans. Living in harmony with the natural world, these noble individuals embark on grand adventures that become fireside tales for generations to come.\nThis supplement for the D&D game provides detailed information on the psychology, society, culture, behavior, religion, folklore, and other aspects of the races of the wild, including raptorans -- a new race presented here. In addition to new humanoids and monster races playable as characters, Races of the Wild also provides new prestige classes, feats, spells, magic items, equipment, and guidelines for crafting adventures and campaigns within the communities of these tenacious folk.', NULL),
	(83, 14, 'Sandstorm', 'Sa', 'Take the Heat\nSweltering temperatures, bone-scouring windstorms, and other dangers threaten explorers in waste environments. From arid deserts and volcanic regions to ash-choked dungeons and the lava-filled layers of Gehenna, unwary travelers may fall victim to the unrelenting hazards that await.\nThis supplement for the D&D game explores the impact of desert conditions and extreme hot-weather environments on every aspect of game play. Along with rules for adapting to, navigating through, and surviving hazardous hot-weather conditions and terrain, Sandstorm also includes new races, spells, feats, magic items, prestige classes, and monsters associated with deserts and other wastelands.', NULL),
	(84, 9, 'Spell Compendium', 'Sc', '', NULL),
	(85, 14, 'Stormwrack', 'Sto', '', NULL),
	(86, 9, 'Tome of Battle: The Book of Nine Swords', 'ToB', 'New combat options for any D&D campaign.\nTome of Battle: The Book of Nine Swords introduces new rules for players who want interesting combat options for their characters. The nine martial disciplines presented within allow a character with the proper knowledge and focus to perform special combat maneuvers and nearly magical effects. Three new martial classes allow a character to develop his or her discipline even further. Also included are new feats and prestige classes that build on the disciplines, new magic items and spells, and new monsters and organizations.', NULL),
	(87, 9, 'Tome of Magic', 'TM', 'Three new magic systems for any D&D campaign.\nTome of Magic introduces three new magic subsystems for the D&D game. Any or all of these systems can easily be inserted into a campaign. Pact magic gives characters the ability to channel lost souls, harnessing their abilities to gain supernatural powers. Shadow magic draws power from the mysterious Plane of Shadow. Truename magic gives characters that learn and properly use the true name of a creature or object immense power over it. All three systems introduce new base classes and spellcasting mechanics. Also included are new feats, prestige classes, magic items, and spells.', NULL),
	(88, 9, 'Unearthed Arcana', 'UA', 'A new guide to variant rules for the Dungeons & Dragons roleplaying game.\nThis all-new sourcebook provides D&D players and Dungeon Masters with a wide choice of variant rules for alternate roleplaying in a D&D campaign. Designed to expand the options available for customizing gameplay, these variant rules are modular and can be imported into any campaign in any amount desired. Examples of variant rules include playing core classes as prestige classes and alternate damage systems. Brand-new rules include a new system of metamagic feats and a new spell system.', NULL),
	(89, 9, 'Weapons of Legacy', 'WL', '', NULL),
	(90, 9, 'Draconomicon', 'Dr', '', NULL),
	(91, 8, 'Drow of the Underdark', 'DrU', '', NULL),
	(92, 3, 'Ghostwalk', 'Gh', 'The city of Manifest rests atop ruins from ancient times and far above the entrance to the land of the dead. Here, the world of the living is shared equally with the deceased, who linger in physical form before finally passing through the Veil. Whether currently living or dead, residents and visitors are assured of an eternity of action and intrigue.\n\nGhostwalk contains everything needed to run a stand-alone campaign in and around the city of Manifest, or to integrate it into an existing world, including:\n\n- Complete rules for playing ghost characters and advancing in the new Eidolon and Eidoloncer classes\n- New prestige classes, such as the Bone Collector and the Ghost Slayer\n- Over 70 new feats and 65 new spells, including Ghost Hand, Incorporeal Target Fighting, Death Armor, and Ectoplasmic Decay\n- Three complete adventures, four highly detailed encounter sites, and fourteen new monsters and templates', NULL),
	(93, 2, 'Lords of Darkness', 'LD', '', NULL),
	(94, 3, 'Oriental Adventures', 'OA', 'Asian magic, combat, mystery, and monsters, all with a D&D twist. It\'s a beautiful book that takes its graphic inspiration from the texture of handmade papers and the grace of calligraphy mixed with the kickin\' edge of the new D&D style. Check out this new gallery of art drawn from the book, and if you haven\'t bought it yet, what\'s keeping you? All the great classes and races from the original 1st edition AD&D are back and much, much more. And there are more weird, wonderful, mysterious Asian-inspired monsters than ever before -- from all the varieties of lung dragon, to the grisly mamono (wouldn\'t want to shake hands with one of those), to the classic hopping vampire (check him out in the Oriental Adventures excerpt). Get yourself warmed up with Chinese Ghost Story and Crouching Tiger, Hidden Dragon and then join the rest of your gaming group as they crack open their copies of the book and dive in for some serious Asian fantasy roleplaying.', NULL),
	(95, 2, 'Silver Marches', 'SM', '', NULL),
	(96, 13, 'Dragonlance Campaign Setting', 'DCS', '', NULL),
	(97, 9, 'Expedition to the Demonweb Pits', 'EDP', '', NULL),
	(98, 13, 'Explorer\'s Handbook', 'EH', '', NULL),
	(99, 13, 'Five Nations', 'FN', '', NULL),
	(100, 9, 'Expedition to Castle Ravenloft', 'Rav', '', NULL),
	(101, 9, 'Return to the Temple of Elemental Evil', 'RT', '', NULL),
	(102, 9, 'The Shattered Gates of Slaughtergarde', 'ShG', '', NULL),
	(103, 13, 'The Forge of War', 'FoW', '', NULL),
	(104, 1, 'Player\'s Handbook', 'PHB', '', NULL),
	(105, 1, 'Monster Manual', 'MM', '', NULL),
	(106, 9, 'Web', 'Web', 'Found on wizards.com or another source.\nFor example: Font of Inspiration', NULL),
	(107, 9, 'Dragon Compendium', 'DC', '', NULL),
	(108, 9, 'Elder Evils', 'EE', 'When elder evils stir, the world groans; when they awaken, the world weeps. Buried in the deepest bowels of the Underdark, hidden in the farthest reaches of the multiverse, or lost in the gulfs between realities are terrible things that exist only to destroy or horribly remake creation. So mighty are these ancient beings that even the gods think twice about standing against them. Mortals who are aware\nof their existence viciously suppress that knowledge and destroy any who would serve such things. Even if an elder evil can be forced back to whence it came, its mere presence changes the world forever. In short, it is a campaign ender.', NULL),
	(109, 9, 'Feats', 'Feats', 'The definitive guidebook to feats, containing over a thousand. It contains both commonly used feats, and some more obscure ones', NULL),
	(110, 13, 'Dragons of Ebberon', 'DE', 'Dragons of Eberron delves into the mysterious Draconic Prophecy and various draconic organizations. It introduces the continent of Argonnessen, homeland of the dragons, and describes various adventure sites and other places of interest that have never before been presented. The remainder of the book explores dragons on the continents of Khorvaire, Sarlona, and Xen\'drik and provides several ready-to-play dragons, complete with stat blocks, lairs, encounters, and adventure hooks. ', NULL),
	(111, 9, 'Eyes of the Lich Queen', 'EotLQ', 'What begins as a simple expedition to explore an ancient jungle temple sends adventurers headlong into a search for the Dragon\'s Eye, an artifact created ages ago by demons in order to gain power over dragons. But where exactly is this mysterious artifact, and why do the Cloudreavers and the Emerald Claw think the adventurers already have it? Only Lady Vol knows the truth. Her deadly cat-and-mouse game leads the characters from the wilderness of Q\'barra to the wild coasts of the Lhazaar Principalities and the soaring peaks of Argonnessen. There, at last, they can learn the secret of the Dragon\'s Eye and foil the lich queen\'s plans... if they survive!\nThe "Eyes of the Lich Queen" adventure for the Dungeons & Dragons game draws on the richness of the Eberron campaign setting. Designed for heroes of 5th level, the adventure sends them on a world-spanning journey as they battle cultists, pirates, long-dead spirits, and even dragons in their search for the enigmatic Dragon\'s Eye.', NULL),
	(112, 9, 'Shadowdale: The Scouring of the Land', 'S:TSotL', 'Elminster?s tower lies in ruins, and the town of Shadowdale has been conquered by evil Sharrans and the nefarious forces of Zhentil Keep. To drive the villains out of Shadowdale, the heroes must organize and lead a desperate revolt of Dalesfolk against their conquerors, as well as thwart the sinister designs of Shar?s servants and the Zhent garrison.', NULL),
	(113, 9, 'Red Hand of Doom', 'RH', 'The Red Hand of Doom is an exciting super-adventure that pits heroes against an army bent on domination. Rampaging hobgoblins and their allies threaten to destroy the realm and all who stand before them. Characters who dare confront the horde soon discover that these particular hobgoblins worship Tiamat, the evil queen of dragons, and eventually come face-to-face with her draconic minions. The excerpts below include the introduction and adventure outline, two sample encounters, and statistics for the encounters. (Crafty DMs may find the encounters and their relevant statistics useful in other ways, too!)', NULL);

-- Exportiere Struktur von Tabelle Staging.RuleBookTranslations
CREATE TABLE IF NOT EXISTS `RuleBookTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RuleBookId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RuleBookTranslations_RuleBookId` (`RuleBookId`),
  CONSTRAINT `FK_RuleBookTranslations_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.RuleBookTranslations: ~0 rows (ungefähr)
DELETE FROM `RuleBookTranslations`;

-- Exportiere Struktur von Tabelle Staging.Senses
CREATE TABLE IF NOT EXISTS `Senses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FallbackName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FallbackDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Senses: ~0 rows (ungefähr)
DELETE FROM `Senses`;

-- Exportiere Struktur von Tabelle Staging.SenseTranslations
CREATE TABLE IF NOT EXISTS `SenseTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SenseId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SenseTranslations_SenseId` (`SenseId`),
  CONSTRAINT `FK_SenseTranslations_Senses_SenseId` FOREIGN KEY (`SenseId`) REFERENCES `Senses` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SenseTranslations: ~0 rows (ungefähr)
DELETE FROM `SenseTranslations`;

-- Exportiere Struktur von Tabelle Staging.SpellComponents
CREATE TABLE IF NOT EXISTS `SpellComponents` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellComponentTypeId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `MinimalItemGoldValue` decimal(65,30) DEFAULT NULL,
  `Count` int DEFAULT NULL,
  `CountIndicator` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OtherComponentText` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OtherComponentName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SpellVariantId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellComponents_ItemId` (`ItemId`),
  KEY `IX_SpellComponents_SpellComponentTypeId` (`SpellComponentTypeId`),
  KEY `IX_SpellComponents_SpellVariantId` (`SpellVariantId`),
  CONSTRAINT `FK_SpellComponents_Items_ItemId` FOREIGN KEY (`ItemId`) REFERENCES `Items` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellComponents_SpellComponentTypes_SpellComponentTypeId` FOREIGN KEY (`SpellComponentTypeId`) REFERENCES `SpellComponentTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellComponents_SpellVariants_SpellVariantId` FOREIGN KEY (`SpellVariantId`) REFERENCES `SpellVariants` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellComponents: ~0 rows (ungefähr)
DELETE FROM `SpellComponents`;

-- Exportiere Struktur von Tabelle Staging.SpellComponentTypes
CREATE TABLE IF NOT EXISTS `SpellComponentTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AbbreviationFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellComponentTypes: ~6 rows (ungefähr)
DELETE FROM `SpellComponentTypes`;
INSERT INTO `SpellComponentTypes` (`Id`, `NameFallback`, `DescriptionFallback`, `AbbreviationFallback`) VALUES
	(1, 'Verbal', 'A verbal component is a spoken incantation. To provide a verbal component, you must be able to speak in a strong voice. A silence spell or a gag spoils the incantation (and thus the spell). A spell-caster who has been deafened has a 20% chance to spoil any spell with a verbal component that he or she tries to cast.', 'V'),
	(2, 'Somatic', 'A somatic component is a measured and precise movement of the hand. You must have at least one hand free to provide a somatic component.', 'S'),
	(3, 'Material', 'A material component is one or more physical substances or objects that are annihilated by the spell energies in the casting process. Unless a cost is given for a material component, the cost is negligible. Don’t bother to keep track of material components with negligible cost. Assume you have all you need as long as you have your spell component pouch.', 'M'),
	(4, 'Arcane Focus', 'An arcane focus component is a prop of some sort. Unlike a material component, a focus is not consumed when the spell is cast and can be reused. As with material components, the cost for a focus is negligible unless a price is given. Assume that focus components of negligible cost are in your spell component pouch.', 'AF'),
	(5, 'Divine Focus', 'A divine focus component is an item of spiritual significance. The divine focus for a cleric or a paladin is a holy symbol appropriate to the character’s faith.', 'DF'),
	(6, 'Experience', 'Some powerful spells entail an experience point cost to you. No spell can restore the XP lost in this manner. You cannot spend so much XP that you lose a level, so you cannot cast the spell unless you have enough XP to spare. However, you may, on gaining enough XP to attain a new level, use those XP for casting a spell rather than keeping them and advancing a level. The XP are treated just like a material component—expended when you cast the spell, whether or not the casting succeeds.', 'XP');

-- Exportiere Struktur von Tabelle Staging.SpellComponentTypeTranslations
CREATE TABLE IF NOT EXISTS `SpellComponentTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellComponentTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Abbreviation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellComponentTypeTranslations_SpellComponentTypeId` (`SpellComponentTypeId`),
  CONSTRAINT `FK_SpellComponentTypeTranslations_SpellComponentTypes_SpellComp~` FOREIGN KEY (`SpellComponentTypeId`) REFERENCES `SpellComponentTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellComponentTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellComponentTypeTranslations`;

-- Exportiere Struktur von Tabelle Staging.SpellDescriptors
CREATE TABLE IF NOT EXISTS `SpellDescriptors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellDescriptors: ~19 rows (ungefähr)
DELETE FROM `SpellDescriptors`;
INSERT INTO `SpellDescriptors` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Acid', NULL),
	(2, 'Air', NULL),
	(3, 'Chaotic', NULL),
	(4, 'Cold', NULL),
	(5, 'Darkness', NULL),
	(6, 'Death', NULL),
	(7, 'Earth', NULL),
	(8, 'Electricity', NULL),
	(9, 'Evil', NULL),
	(10, 'Fear', NULL),
	(11, 'Fire', NULL),
	(12, 'Force', NULL),
	(13, 'Good', NULL),
	(14, 'Language-Dependant', NULL),
	(15, 'Lawful', NULL),
	(16, 'Light', NULL),
	(17, 'Mind-Affecting', NULL),
	(18, 'Sonic', NULL),
	(19, 'Water', NULL);

-- Exportiere Struktur von Tabelle Staging.SpellDescriptorSpellVariant
CREATE TABLE IF NOT EXISTS `SpellDescriptorSpellVariant` (
  `SpellDescriptorsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellDescriptorsId`,`SpellVariantsId`),
  KEY `IX_SpellDescriptorSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellDescriptorSpellVariant_SpellDescriptors_SpellDescriptor~` FOREIGN KEY (`SpellDescriptorsId`) REFERENCES `SpellDescriptors` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellDescriptorSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellDescriptorSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellDescriptorSpellVariant`;

-- Exportiere Struktur von Tabelle Staging.SpellDescriptorTranslations
CREATE TABLE IF NOT EXISTS `SpellDescriptorTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellDescriptorId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellDescriptorTranslations_SpellDescriptorId` (`SpellDescriptorId`),
  CONSTRAINT `FK_SpellDescriptorTranslations_SpellDescriptors_SpellDescriptor~` FOREIGN KEY (`SpellDescriptorId`) REFERENCES `SpellDescriptors` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellDescriptorTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellDescriptorTranslations`;

-- Exportiere Struktur von Tabelle Staging.SpellRangeTypes
CREATE TABLE IF NOT EXISTS `SpellRangeTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellRangeTypes: ~0 rows (ungefähr)
DELETE FROM `SpellRangeTypes`;

-- Exportiere Struktur von Tabelle Staging.SpellRangeTypeTranslations
CREATE TABLE IF NOT EXISTS `SpellRangeTypeTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellRangeTypeId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellRangeTypeTranslations_SpellRangeTypeId` (`SpellRangeTypeId`),
  CONSTRAINT `FK_SpellRangeTypeTranslations_SpellRangeTypes_SpellRangeTypeId` FOREIGN KEY (`SpellRangeTypeId`) REFERENCES `SpellRangeTypes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellRangeTypeTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellRangeTypeTranslations`;

-- Exportiere Struktur von Tabelle Staging.Spells
CREATE TABLE IF NOT EXISTS `Spells` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Spells: ~0 rows (ungefähr)
DELETE FROM `Spells`;

-- Exportiere Struktur von Tabelle Staging.SpellSchools
CREATE TABLE IF NOT EXISTS `SpellSchools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellSchools: ~9 rows (ungefähr)
DELETE FROM `SpellSchools`;
INSERT INTO `SpellSchools` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Abjuration', 'Abjurations are protective spells. They create physical or magical barriers, negate magical or physical abilities, harm trespassers, or even banish the subject of the spell to another plane of existence.'),
	(2, 'Conjuration', 'Each conjuration spell belongs to one of five subschools. Conjurations bring manifestations of objects, creatures, or some form of energy to you (the summoning subschool), actually transport creatures from another plane of existence to your plane (calling), heal (healing), transport creatures or objects over great distances (teleportation), or create objects or effects on the spot (creation). Creatures you conjure usually, but not always, obey your commands.'),
	(3, 'Divination', 'Divination spells enable you to learn secrets long forgotten, to predict the future, to find hidden things, and to foil deceptive spells.'),
	(4, 'Enchantment', 'Enchantment spells affect the minds of others, influencing or controlling their behavior.'),
	(5, 'Evocation', 'Evocation spells manipulate energy or tap an unseen source of power to produce a desired end. In effect, they create something out of nothing. Many of these spells produce spectacular effects, and evocation spells can deal large amounts of damage.'),
	(6, 'Illusion', 'Illusion spells deceive the senses or minds of others. They cause people to see things that are not there, not see things that are there, hear phantom noises, or remember things that never happened.'),
	(7, 'Necromancy', 'Necromancy spells manipulate the power of death, unlife, and the life force. Spells involving undead creatures make up a large part of this school.'),
	(8, 'Transmutation', 'Transmutation spells change the properties of some creature, thing, or condition.'),
	(9, 'Universal', 'A small number of spells are universal, effectively belonging to no school.');

-- Exportiere Struktur von Tabelle Staging.SpellSchoolSpellVariant
CREATE TABLE IF NOT EXISTS `SpellSchoolSpellVariant` (
  `SpellSchoolsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellSchoolsId`,`SpellVariantsId`),
  KEY `IX_SpellSchoolSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellSchoolSpellVariant_SpellSchools_SpellSchoolsId` FOREIGN KEY (`SpellSchoolsId`) REFERENCES `SpellSchools` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellSchoolSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellSchoolSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellSchoolSpellVariant`;

-- Exportiere Struktur von Tabelle Staging.SpellSchoolTranslations
CREATE TABLE IF NOT EXISTS `SpellSchoolTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellSchoolId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellSchoolTranslations_SpellSchoolId` (`SpellSchoolId`),
  CONSTRAINT `FK_SpellSchoolTranslations_SpellSchools_SpellSchoolId` FOREIGN KEY (`SpellSchoolId`) REFERENCES `SpellSchools` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellSchoolTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellSchoolTranslations`;

-- Exportiere Struktur von Tabelle Staging.SpellSubSchools
CREATE TABLE IF NOT EXISTS `SpellSubSchools` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NameFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellSubSchools: ~13 rows (ungefähr)
DELETE FROM `SpellSubSchools`;
INSERT INTO `SpellSubSchools` (`Id`, `NameFallback`, `DescriptionFallback`) VALUES
	(1, 'Calling', 'A calling spell transports a creature from another plane to the plane you are on. The spell grants the creature the one-time ability to return to its plane of origin, although the spell may limit the circumstances under which this is possible. Creatures who are called actually die when they are killed; they do not disappear and reform, as do those brought by a summoning spell (see below). The duration of a calling spell is instantaneous, which means that the called creature can’t be dispelled.'),
	(2, 'Creation', 'A creation spell manipulates matter to create an object or creature in the place the spell-caster designates (subject to the limits noted above). If the spell has a duration other than instantaneous, magic holds the creation together, and when the spell ends, the conjured creature or object vanishes without a trace. If the spell has an instantaneous duration, the created object or creature is merely assembled through magic. It lasts indefinitely and does not depend on magic for its existence.'),
	(3, 'Healing', 'Certain divine conjurations heal creatures or even bring them back to life.'),
	(4, 'Summoning', 'A summoning spell instantly brings a creature or object to a place you designate. When the spell ends or is dispelled, a summoned creature is instantly sent back to where it came from, but a summoned object is not sent back unless the spell description specifically indicates this. A summoned creature also goes away if it is killed or if its hit points drop to 0 or lower. It is not really dead. It takes 24 hours for the creature to reform, during which time it can’t be summoned again.'),
	(5, 'Teleportation', 'A teleportation spell transports one or more creatures or objects a great distance. The most powerful of these spells can cross planar boundaries. Unlike summoning spells, the transportation is (unless otherwise noted) one-way and not dispellable. Teleportation is instantaneous travel through the Astral Plane. Anything that blocks astral travel also blocks teleportation.'),
	(6, 'Scrying', 'A scrying spell creates an invisible magical sensor that sends you information. Unless noted otherwise, the sensor has the same powers of sensory acuity that you possess. This level of acuity includes any spells or effects that target you, but not spells or effects that emanate from you. However, the sensor is treated as a separate, independent sensory organ of yours, and thus it functions normally even if you have been blinded, deafened, or otherwise suffered sensory impairment. Any creature with an Intelligence score of 12 or higher can notice the sensor by making a DC 20 Intelligence check. The sensor can be dispelled as if it were an active spell.'),
	(7, 'Charm', 'A charm spell changes how the subject views you, typically making it see you as a good friend.'),
	(8, 'Compulsion', 'A compulsion spell forces the subject to act in some manner or changes the way her mind works. Some compulsion spells determine the subject’s actions or the effects on the subject, some compulsion spells allow you to determine the subject’s actions when you cast the spell, and others give you ongoing control over the subject.'),
	(9, 'Figment', 'A figment spell creates a false sensation. Those who perceive the figment perceive the same thing, not their own slightly different versions of the figment. (It is not a personalized mental impression.) Figments cannot make something seem to be something else. A figment that includes audible effects cannot duplicate intelligible speech unless the spell description specifically says it can. If intelligible speech is possible, it must be in a language you can speak. If you try to duplicate a language you cannot speak, the image produces gibberish. Likewise, you cannot make a visual copy of something unless you know what it looks like.'),
	(10, 'Glamer', 'A glamer spell changes a subject’s sensory qualities, making it look, feel, taste, smell, or sound like something else, or even seem to disappear.'),
	(11, 'Pattern', 'Like a figment, a pattern spell creates an image that others can see, but a pattern also affects the minds of those who see it or are caught in it. All patterns are mind-affecting spells.'),
	(12, 'Phantasm', 'A phantasm spell creates a mental image that usually only the caster and the subject (or subjects) of the spell can perceive. This impression is totally in the minds of the subjects. It is a personalized mental impression. (It’s all in their heads and not a fake picture or something that they actually see.) Third parties viewing or studying the scene don’t notice the phantasm. All phantasms are mind-affecting spells.'),
	(13, 'Shadow', 'A shadow spell creates something that is partially real from extradimensional energy. Such illusions can have real effects. Damage dealt by a shadow illusion is real.');

-- Exportiere Struktur von Tabelle Staging.SpellSubSchoolSpellVariant
CREATE TABLE IF NOT EXISTS `SpellSubSchoolSpellVariant` (
  `SpellSubSchoolsId` int NOT NULL,
  `SpellVariantsId` int NOT NULL,
  PRIMARY KEY (`SpellSubSchoolsId`,`SpellVariantsId`),
  KEY `IX_SpellSubSchoolSpellVariant_SpellVariantsId` (`SpellVariantsId`),
  CONSTRAINT `FK_SpellSubSchoolSpellVariant_SpellSubSchools_SpellSubSchoolsId` FOREIGN KEY (`SpellSubSchoolsId`) REFERENCES `SpellSubSchools` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SpellSubSchoolSpellVariant_SpellVariants_SpellVariantsId` FOREIGN KEY (`SpellVariantsId`) REFERENCES `SpellVariants` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellSubSchoolSpellVariant: ~0 rows (ungefähr)
DELETE FROM `SpellSubSchoolSpellVariant`;

-- Exportiere Struktur von Tabelle Staging.SpellSubSchoolTranslations
CREATE TABLE IF NOT EXISTS `SpellSubSchoolTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellSubSchoolId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellSubSchoolTranslations_SpellSubSchoolId` (`SpellSubSchoolId`),
  CONSTRAINT `FK_SpellSubSchoolTranslations_SpellSubSchools_SpellSubSchoolId` FOREIGN KEY (`SpellSubSchoolId`) REFERENCES `SpellSubSchools` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellSubSchoolTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellSubSchoolTranslations`;

-- Exportiere Struktur von Tabelle Staging.SpellTranslations
CREATE TABLE IF NOT EXISTS `SpellTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellId` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellTranslations_SpellId` (`SpellId`),
  CONSTRAINT `FK_SpellTranslations_Spells_SpellId` FOREIGN KEY (`SpellId`) REFERENCES `Spells` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellTranslations`;

-- Exportiere Struktur von Tabelle Staging.SpellVariants
CREATE TABLE IF NOT EXISTS `SpellVariants` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellId` int DEFAULT NULL,
  `RuleBookId` int DEFAULT NULL,
  `RuleBookPage` int DEFAULT NULL,
  `CastingTimeValue` int NOT NULL,
  `CastingTimeIndicatorId` int DEFAULT NULL,
  `DescriptionFallback` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SpellRangeTypeId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellVariants_CastingTimeIndicatorId` (`CastingTimeIndicatorId`),
  KEY `IX_SpellVariants_RuleBookId` (`RuleBookId`),
  KEY `IX_SpellVariants_SpellId` (`SpellId`),
  KEY `IX_SpellVariants_SpellRangeTypeId` (`SpellRangeTypeId`),
  CONSTRAINT `FK_SpellVariants_ActionTimeIndicator_CastingTimeIndicatorId` FOREIGN KEY (`CastingTimeIndicatorId`) REFERENCES `ActionTimeIndicator` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_RuleBooks_RuleBookId` FOREIGN KEY (`RuleBookId`) REFERENCES `RuleBooks` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_SpellRangeTypes_SpellRangeTypeId` FOREIGN KEY (`SpellRangeTypeId`) REFERENCES `SpellRangeTypes` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_SpellVariants_Spells_SpellId` FOREIGN KEY (`SpellId`) REFERENCES `Spells` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellVariants: ~0 rows (ungefähr)
DELETE FROM `SpellVariants`;

-- Exportiere Struktur von Tabelle Staging.SpellVariantTranslations
CREATE TABLE IF NOT EXISTS `SpellVariantTranslations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SpellVariantId` int DEFAULT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CultureName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_SpellVariantTranslations_SpellVariantId` (`SpellVariantId`),
  CONSTRAINT `FK_SpellVariantTranslations_SpellVariants_SpellVariantId` FOREIGN KEY (`SpellVariantId`) REFERENCES `SpellVariants` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.SpellVariantTranslations: ~0 rows (ungefähr)
DELETE FROM `SpellVariantTranslations`;

-- Exportiere Struktur von Tabelle Staging.Users
CREATE TABLE IF NOT EXISTS `Users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DateJoined` datetime(6) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsAdmin` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.Users: ~0 rows (ungefähr)
DELETE FROM `Users`;

-- Exportiere Struktur von Tabelle Staging.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Exportiere Daten aus Tabelle Staging.__EFMigrationsHistory: ~8 rows (ungefähr)
DELETE FROM `__EFMigrationsHistory`;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
	('20220711164424_initial', '5.0.17'),
	('20220712181000_add_race', '5.0.17'),
	('20220713162442_add_fallbacks_to_alphabet', '5.0.17'),
	('20220715173657_update_feat_options', '5.0.17'),
	('20220715174731_rename_race_feat_option', '5.0.17'),
	('20220716141655_update_race_references', '5.0.17'),
	('20220716152721_update_race_property_name', '5.0.17'),
	('20220717182818_update_translations', '5.0.17'),
	('20220721175435_migrate_to_dotnet6', '6.0.7');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
