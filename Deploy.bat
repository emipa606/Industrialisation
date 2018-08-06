set Rimworld_Path=C:\Steam\Rimworld
set Mod_Version=1.0.1969
set Mod_Folder=Industrialisation_%Mod_Version%
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\About"
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\Assemblies"
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\Defs"
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\Languages"
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\Patches"
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\Sounds"
REM rd /s /q "%Rimworld_Path%\Mods\%Mod_Folder%\Textures"
xcopy About                     "%Rimworld_Path%\Mods\%Mod_Folder%\About" /e /d /i /y
mkdir                           "%Rimworld_Path%\Mods\%Mod_Folder%\Assemblies"
xcopy Assemblies\Ind*.dll       "%Rimworld_Path%\Mods\%Mod_Folder%\Assemblies" /e /d /i /y
xcopy Defs                      "%Rimworld_Path%\Mods\%Mod_Folder%\Defs" /e /d /i /y
xcopy Languages                 "%Rimworld_Path%\Mods\%Mod_Folder%\Languages" /e /d /i /y
xcopy Patches                   "%Rimworld_Path%\Mods\%Mod_Folder%\Patches" /e /d /i /y
xcopy Sounds                    "%Rimworld_Path%\Mods\%Mod_Folder%\Sounds" /e /d /i /y
xcopy Textures                  "%Rimworld_Path%\Mods\%Mod_Folder%\Textures" /e /d /i /y
copy LICENSE                    "%Rimworld_Path%\Mods\%Mod_Folder%\LICENSE" /y