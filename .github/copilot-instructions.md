# Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose
This mod, titled "Industrialisation," aims to expand the technological capabilities of a RimWorld colony by introducing advanced machinery and systems, including new power sources and structures to significantly alter gameplay strategy. The primary purpose is to enhance the industrial and technological progression of a colony with an emphasis on nuclear and drilling technologies.

## Key Features and Systems
1. **Nuclear Power Plant:**
   - Introduces a new building, `Building_NuclearPowerPlant`, designed to provide a significant power boost to colonies.
   
2. **Skydriller Technology:**
   - Structures associated with calling and utilizing Skydrillers (`Building_SkydrillerCallmaker_Calling` and `Building_SkydrillerCallmaker_Drilling`) that can unlock deep earth resources.
   - The Skydriller system involves complex interactions utilizing drilling and plasma technology.
   
3. **Advanced Projectiles:**
   - The `Projectile_PlasmaDrillBullet` class represents a high-impact projectile used in resource extraction and defense scenarios.
   
4. **Weather Event Integration:**
   - Adds the `Skydriller_PlasmaBeam`, a game-changing weather event affecting the map, introduced through the Skydriller system.

## Coding Patterns and Conventions

- **Class Accessibility:**
  - Utilize `public` for classes and methods intended for broad use across multiple areas of the mod.
  - Employ `internal` for classes when encapsulation within the assembly is intentional.

- **Method Naming:**
  - Follow PascalCase for method names, ensuring clarity and conformity with C# standards.

- **Code Documentation:**
  - Provide XML comments for class and method descriptions to aid comprehension and maintenance.

## XML Integration
XML is crucial for defining in-game data related to the new objects and structures. Integrate XML for item definitions, recipes, and texture mappings to harmonize with the default RimWorld content. Ensure correct XML pathing for any newly added assets to prevent loading errors.

## Harmony Patching
- **Harmony Usage:**
  - Employ Harmony patches to modify or extend existing game mechanics without altering the original game files.
  - Focus patches on methods within core gameplay that your mod aims to enhance or modify.
  - Follow safe patching practices by prefixing/suffixing methods and ensuring compatibility with other mods.

## Suggestions for Copilot

1. **Function Implementation:**
   - When implementing new functions, encourage auto-generation suggestions to align with existing code patterns and conventions.
   
2. **Class Structure:**
   - Copilot can assist in crafting the structure of new classes, suggesting boilerplate and common method patterns.

3. **Harmony Patch Guidelines:**
   - Suggest starting templates for creating prefixes and suffixes in Harmony patches.
   
4. **XML File Management:**
   - Recommend automation scripts for handling XML integration, ensuring paths and references are correctly structured.

5. **Debugging Assistance:**
   - Leverage Copilot to write unit tests or debug lines to check the functionality of new components.

By leveraging these instructions, you can efficiently expand upon the Industrialisation mod, ensuring consistency, readability, and seamless integration into RimWorld's ecosystem.
