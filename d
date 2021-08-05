[33mcommit cc710f5543048c614ba058028e9f1f33fa43ec71[m[33m ([m[1;36mHEAD -> [m[1;32mdevelopment[m[33m, [m[1;31morigin/feature/InitiliazeLocalField[m[33m, [m[1;31morigin/development[m[33m, [m[1;32mfeature/InitiliazeLocalField[m[33m)[m
Author: Trell <doboniy03@gmail.com>
Date:   Wed Aug 4 16:26:40 2021 +0300

    delete logs

[1mdiff --git a/Logs/AssetImportWorker0-prev.log b/Logs/AssetImportWorker0-prev.log[m
[1mdeleted file mode 100644[m
[1mindex 9a1e563..0000000[m
[1m--- a/Logs/AssetImportWorker0-prev.log[m
[1m+++ /dev/null[m
[36m@@ -1,195 +0,0 @@[m
[31m-Using pre-set license[m
[31m-Built from '2020.3/release' branch; Version is '2020.3.15f2 (6cf78cb77498) revision 7141260'; Using compiler version '192528614'; Build Type 'Release'[m
[31m-OS: 'Windows 10 Pro; OS build 19042.1110; Version 2009; 64bit' Language: 'en' Physical Memory: 8066 MB[m
[31m-BatchMode: 1, IsHumanControllingUs: 0, StartBugReporterOnCrash: 0, Is64bit: 1, IsPro: 0[m
[31m-[m
[31m- COMMAND LINE ARGUMENTS:[m
[31m-D:\Programs\Unities\2020.3.15f2\Editor\Unity.exe[m
[31m--adb2[m
[31m--batchMode[m
[31m--noUpm[m
[31m--name[m
[31m-AssetImportWorker0[m
[31m--projectPath[m
[31m-D:/Projects/DarkLegion[m
[31m--logFile[m
[31m-Logs/AssetImportWorker0.log[m
[31m--srvPort[m
[31m-61338[m
[31m-Successfully changed project path to: D:/Projects/DarkLegion[m
[31m-D:/Projects/DarkLegion[m
[31m-Using Asset Import Pipeline V2.[m
[31m-Refreshing native plugins compatible for Editor in 51.56 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Initialize engine version: 2020.3.15f2 (6cf78cb77498)[m
[31m-[Subsystems] Discovering subsystems at path D:/Programs/Unities/2020.3.15f2/Editor/Data/Resources/UnitySubsystems[m
[31m-[Subsystems] Discovering subsystems at path D:/Projects/DarkLegion/Assets[m
[31m-GfxDevice: creating device client; threaded=0[m
[31m-Direct3D:[m
[31m-    Version:  Direct3D 11.0 [level 11.0][m
[31m-    Renderer: NVIDIA GeForce 940MX (ID=0x134d)[m
[31m-    Vendor:   [m
[31m-    VRAM:     2020 MB[m
[31m-    Driver:   23.21.13.8875[m
[31m-Initialize mono[m
[31m-Mono path[0] = 'D:/Programs/Unities/2020.3.15f2/Editor/Data/Managed'[m
[31m-Mono path[1] = 'D:/Programs/Unities/2020.3.15f2/Editor/Data/MonoBleedingEdge/lib/mono/unityjit'[m
[31m-Mono config path = 'D:/Programs/Unities/2020.3.15f2/Editor/Data/MonoBleedingEdge/etc'[m
[31m-Using monoOptions --debugger-agent=transport=dt_socket,embedding=1,server=y,suspend=n,address=127.0.0.1:56900[m
[31m-Begin MonoManager ReloadAssembly[m
[31m-Registering precompiled unity dll's ...[m
[31m-Register platform support module: D:/Programs/Unities/2020.3.15f2/Editor/Data/PlaybackEngines/WindowsStandaloneSupport/UnityEditor.WindowsStandalone.Extensions.dll[m
[31m-Registered in 0.468573 seconds.[m
[31m-Native extension for WindowsStandalone target not found[m
[31m-Refreshing native plugins compatible for Editor in 49.18 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Mono: successfully reloaded assembly[m
[31m-- Completed reload, in  1.923 seconds[m
[31m-Domain Reload Profiling:[m
[31m-	ReloadAssembly (1924ms)[m
[31m-		BeginReloadAssembly (62ms)[m
[31m-			ExecutionOrderSort (0ms)[m
[31m-			DisableScriptedObjects (0ms)[m
[31m-			BackupInstance (0ms)[m
[31m-			ReleaseScriptingObjects (0ms)[m
[31m-			CreateAndSetChildDomain (1ms)[m
[31m-		EndReloadAssembly (799ms)[m
[31m-			LoadAssemblies (62ms)[m
[31m-			RebuildTransferFunctionScriptingTraits (0ms)[m
[31m-			SetupTypeCache (208ms)[m
[31m-			ReleaseScriptCaches (0ms)[m
[31m-			RebuildScriptCaches (40ms)[m
[31m-			SetupLoadedEditorAssemblies (377ms)[m
[31m-				LogAssemblyErrors (0ms)[m
[31m-				InitializePlatformSupportModulesInManaged (5ms)[m
[31m-				SetLoadedEditorAssemblies (0ms)[m
[31m-				RefreshPlugins (49ms)[m
[31m-				BeforeProcessingInitializeOnLoad (160ms)[m
[31m-				ProcessInitializeOnLoadAttributes (121ms)[m
[31m-				ProcessInitializeOnLoadMethodAttributes (42ms)[m
[31m-				AfterProcessingInitializeOnLoad (0ms)[m
[31m-				EditorAssembliesLoaded (0ms)[m
[31m-			ExecutionOrderSort2 (0ms)[m
[31m-			AwakeInstancesAfterBackupRestoration (0ms)[m
[31m-Platform modules already initialized, skipping[m
[31m-Registering precompiled user dll's ...[m
[31m-Registered in 0.081700 seconds.[m
[31m-Begin MonoManager ReloadAssembly[m
[31m-Native extension for WindowsStandalone target not found[m
[31m-Refreshing native plugins compatible for Editor in 99.45 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Mono: successfully reloaded assembly[m
[31m-- Completed reload, in  3.346 seconds[m
[31m-Domain Reload Profiling:[m
[31m-	ReloadAssembly (3348ms)[m
[31m-		BeginReloadAssembly (168ms)[m
[31m-			ExecutionOrderSort (0ms)[m
[31m-			DisableScriptedObjects (5ms)[m
[31m-			BackupInstance (0ms)[m
[31m-			ReleaseScriptingObjects (0ms)[m
[31m-			CreateAndSetChildDomain (22ms)[m
[31m-		EndReloadAssembly (3100ms)[m
[31m-			LoadAssemblies (1232ms)[m
[31m-			RebuildTransferFunctionScriptingTraits (0ms)[m
[31m-			SetupTypeCache (404ms)[m
[31m-			ReleaseScriptCaches (1ms)[m
[31m-			RebuildScriptCaches (64ms)[m
[31m-			SetupLoadedEditorAssemblies (1188ms)[m
[31m-				LogAssemblyErrors (0ms)[m
[31m-				InitializePlatformSupportModulesInManaged (7ms)[m
[31m-				SetLoadedEditorAssemblies (0ms)[m
[31m-				RefreshPlugins (100ms)[m
[31m-				BeforeProcessingInitializeOnLoad (217ms)[m
[31m-				ProcessInitializeOnLoadAttributes (838ms)[m
[31m-				ProcessInitializeOnLoadMethodAttributes (23ms)[m
[31m-				AfterProcessingInitializeOnLoad (3ms)[m
[31m-				EditorAssembliesLoaded (0ms)[m
[31m-			ExecutionOrderSort2 (0ms)[m
[31m-			AwakeInstancesAfterBackupRestoration (16ms)[m
[31m-Platform modules already initialized, skipping[m
[31m-========================================================================[m
[31m-Worker process is ready to serve import requests[m
[31m-Launched and connected shader compiler UnityShaderCompiler.exe after 0.42 seconds[m
[31m-Refreshing native plugins compatible for Editor in 1.22 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Unloading 2090 Unused Serialized files (Serialized files now loaded: 0)[m
[31m-System memory in use before: 93.2 MB.[m
[31m-System memory in use after: 93.1 MB.[m
[31m-[m
[31m-Unloading 33 unused Assets to reduce memory usage. Loaded Objects now: 2523.[m
[31m-Total: 50.736600 ms (FindLiveObjects: 0.621900 ms CreateObjectMapping: 0.142100 ms MarkObjects: 49.490900 ms  DeleteObjects: 0.478300 ms)[m
[31m-[m
[31m-AssetImportParameters requested are different than current active one (requested -> active):[m
[31m-  custom:framework-win-MediaFoundation: 216162199b28c13a410421893ffa2e32 -> [m
[31m-  custom:video-decoder-ogg-theora: a1e56fd34408186e4bbccfd4996cb3dc -> [m
[31m-  custom:container-muxer-webm: aa71ff27fc2769a1b78a27578f13a17b -> [m
[31m-  custom:container-demuxer-webm: 4f35f7cbe854078d1ac9338744f61a02 -> [m
[31m-  custom:container-demuxer-ogg: 62fdf1f143b41e24485cea50d1cbac27 -> [m
[31m-  custom:video-encoder-webm-vp8: eb34c28f22e8b96e1ab97ce403110664 -> [m
[31m-  custom:video-decoder-webm-vp8: 9c59270c3fd7afecdb556c50c9e8de78 -> [m
[31m-  custom:audio-decoder-ogg-vorbis: bf7c407c2cedff20999df2af8eb42d56 -> [m
[31m-  custom:audio-encoder-webm-vorbis: bf7c407c2cedff20999df2af8eb42d56 -> [m
[31m-========================================================================[m
[31m-Received Import Request.[m
[31m-  path: Assets[m
[31m-  artifactKey: Guid(00000000000000001000000000000000) Importer(815301076,1909f56bfc062723c751e8b465ee728b)[m
[31m-Start importing Assets using Guid(00000000000000001000000000000000) Importer(815301076,1909f56bfc062723c751e8b465ee728b)  -> (artifact id: '42d402b061de3733987d63b9cc3b64de') in 0.372497 seconds [m
[31m-  Import took 0.674227 seconds .[m
[31m-[m
[31m-========================================================================[m
[31m-Received Prepare[m
[31m-Registering precompiled user dll's ...[m
[31m-Registered in 0.004960 seconds.[m
[31m-Begin MonoManager ReloadAssembly[m
[31m-Native extension for WindowsStandalone target not found[m
[31m-Refreshing native plugins compatible for Editor in 54.59 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Mono: successfully reloaded assembly[m
[31m-- Completed reload, in  1.004 seconds[m
[31m-Domain Reload Profiling:[m
[31m-	ReloadAssembly (1004ms)[m
[31m-		BeginReloadAssembly (127ms)[m
[31m-			ExecutionOrderSort (0ms)[m
[31m-			DisableScriptedObjects (7ms)[m
[31m-			BackupInstance (0ms)[m
[31m-			ReleaseScriptingObjects (0ms)[m
[31m-			CreateAndSetChildDomain (40ms)[m
[31m-		EndReloadAssembly (809ms)[m
[31m-			LoadAssemblies (91ms)[m
[31m-			RebuildTransferFunctionScriptingTraits (0ms)[m
[31m-			SetupTypeCache (277ms)[m
[31m-			ReleaseScriptCaches (1ms)[m
[31m-			RebuildScriptCaches (33ms)[m
[31m-			SetupLoadedEditorAssemblies (231ms)[m
[31m-				LogAssemblyErrors (0ms)[m
[31m-				InitializePlatformSupportModulesInManaged (5ms)[m
[31m-				SetLoadedEditorAssemblies (0ms)[m
[31m-				RefreshPlugins (55ms)[m
[31m-				BeforeProcessingInitializeOnLoad (66ms)[m
[31m-				ProcessInitializeOnLoadAttributes (97ms)[m
[31m-				ProcessInitializeOnLoadMethodAttributes (4ms)[m
[31m-				AfterProcessingInitializeOnLoad (3ms)[m
[31m-				EditorAssembliesLoaded (0ms)[m
[31m-			ExecutionOrderSort2 (0ms)[m
[31m-			AwakeInstancesAfterBackupRestoration (7ms)[m
[31m-Platform modules already initialized, skipping[m
[31m-Refreshing native plugins compatible for Editor in 0.77 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Unloading 2381 Unused Serialized files (Serialized files now loaded: 0)[m
[31m-System memory in use before: 102.3 MB.[m
[31m-System memory in use after: 102.4 MB.[m
[31m-[m
[31m-Unloading 19 unused Assets to reduce memory usage. Loaded Objects now: 2816.[m
[31m-Total: 2.249400 ms (FindLiveObjects: 0.316500 ms CreateObjectMapping: 0.197000 ms MarkObjects: 1.614800 ms  DeleteObjects: 0.119700 ms)[m
[31m-[m
[31m-AssetImportParameters requested are different than current active one (requested -> active):[m
[31m-  custom:framework-win-MediaFoundation: 216162199b28c13a410421893ffa2e32 -> [m
[31m-  custom:video-decoder-ogg-theora: a1e56fd34408186e4bbccfd4996cb3dc -> [m
[31m-  custom:container-muxer-webm: aa71ff27fc2769a1b78a27578f13a17b -> [m
[31m-  custom:container-demuxer-webm: 4f35f7cbe854078d1ac9338744f61a02 -> [m
[31m-  custom:container-demuxer-ogg: 62fdf1f143b41e24485cea50d1cbac27 -> [m
[31m-  custom:video-encoder-webm-vp8: eb34c28f22e8b96e1ab97ce403110664 -> [m
[31m-  custom:video-decoder-webm-vp8: 9c59270c3fd7afecdb556c50c9e8de78 -> [m
[31m-  custom:audio-decoder-ogg-vorbis: bf7c407c2cedff20999df2af8eb42d56 -> [m
[31m-  custom:audio-encoder-webm-vorbis: bf7c407c2cedff20999df2af8eb42d56 -> [m
[31m-AssetImportWorkerClient::OnTransportError - code=2 error=End of file[m
[1mdiff --git a/Logs/AssetImportWorker0.log b/Logs/AssetImportWorker0.log[m
[1mdeleted file mode 100644[m
[1mindex a033ba5..0000000[m
[1m--- a/Logs/AssetImportWorker0.log[m
[1m+++ /dev/null[m
[36m@@ -1,994 +0,0 @@[m
[31m-Using pre-set license[m
[31m-Built from '2020.3/release' branch; Version is '2020.3.15f2 (6cf78cb77498) revision 7141260'; Using compiler version '192528614'; Build Type 'Release'[m
[31m-OS: 'Windows 10 Pro; OS build 19042.1110; Version 2009; 64bit' Language: 'en' Physical Memory: 8066 MB[m
[31m-BatchMode: 1, IsHumanControllingUs: 0, StartBugReporterOnCrash: 0, Is64bit: 1, IsPro: 0[m
[31m-[m
[31m- COMMAND LINE ARGUMENTS:[m
[31m-D:\Programs\Unities\2020.3.15f2\Editor\Unity.exe[m
[31m--adb2[m
[31m--batchMode[m
[31m--noUpm[m
[31m--name[m
[31m-AssetImportWorker0[m
[31m--projectPath[m
[31m-D:/Projects/DarkLegion[m
[31m--logFile[m
[31m-Logs/AssetImportWorker0.log[m
[31m--srvPort[m
[31m-63478[m
[31m-Successfully changed project path to: D:/Projects/DarkLegion[m
[31m-D:/Projects/DarkLegion[m
[31m-Using Asset Import Pipeline V2.[m
[31m-Refreshing native plugins compatible for Editor in 61.35 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Initialize engine version: 2020.3.15f2 (6cf78cb77498)[m
[31m-[Subsystems] Discovering subsystems at path D:/Programs/Unities/2020.3.15f2/Editor/Data/Resources/UnitySubsystems[m
[31m-[Subsystems] Discovering subsystems at path D:/Projects/DarkLegion/Assets[m
[31m-GfxDevice: creating device client; threaded=0[m
[31m-Direct3D:[m
[31m-    Version:  Direct3D 11.0 [level 11.0][m
[31m-    Renderer: NVIDIA GeForce 940MX (ID=0x134d)[m
[31m-    Vendor:   [m
[31m-    VRAM:     2020 MB[m
[31m-    Driver:   23.21.13.8875[m
[31m-Initialize mono[m
[31m-Mono path[0] = 'D:/Programs/Unities/2020.3.15f2/Editor/Data/Managed'[m
[31m-Mono path[1] = 'D:/Programs/Unities/2020.3.15f2/Editor/Data/MonoBleedingEdge/lib/mono/unityjit'[m
[31m-Mono config path = 'D:/Programs/Unities/2020.3.15f2/Editor/Data/MonoBleedingEdge/etc'[m
[31m-Using monoOptions --debugger-agent=transport=dt_socket,embedding=1,server=y,suspend=n,address=127.0.0.1:56496[m
[31m-Begin MonoManager ReloadAssembly[m
[31m-Registering precompiled unity dll's ...[m
[31m-Register platform support module: D:/Programs/Unities/2020.3.15f2/Editor/Data/PlaybackEngines/WindowsStandaloneSupport/UnityEditor.WindowsStandalone.Extensions.dll[m
[31m-Registered in 0.001210 seconds.[m
[31m-Native extension for WindowsStandalone target not found[m
[31m-Refreshing native plugins compatible for Editor in 56.54 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Mono: successfully reloaded assembly[m
[31m-- Completed reload, in  1.101 seconds[m
[31m-Domain Reload Profiling:[m
[31m-	ReloadAssembly (1101ms)[m
[31m-		BeginReloadAssembly (65ms)[m
[31m-			ExecutionOrderSort (0ms)[m
[31m-			DisableScriptedObjects (0ms)[m
[31m-			BackupInstance (0ms)[m
[31m-			ReleaseScriptingObjects (0ms)[m
[31m-			CreateAndSetChildDomain (1ms)[m
[31m-		EndReloadAssembly (547ms)[m
[31m-			LoadAssemblies (64ms)[m
[31m-			RebuildTransferFunctionScriptingTraits (0ms)[m
[31m-			SetupTypeCache (191ms)[m
[31m-			ReleaseScriptCaches (0ms)[m
[31m-			RebuildScriptCaches (38ms)[m
[31m-			SetupLoadedEditorAssemblies (208ms)[m
[31m-				LogAssemblyErrors (0ms)[m
[31m-				InitializePlatformSupportModulesInManaged (5ms)[m
[31m-				SetLoadedEditorAssemblies (0ms)[m
[31m-				RefreshPlugins (57ms)[m
[31m-				BeforeProcessingInitializeOnLoad (16ms)[m
[31m-				ProcessInitializeOnLoadAttributes (96ms)[m
[31m-				ProcessInitializeOnLoadMethodAttributes (34ms)[m
[31m-				AfterProcessingInitializeOnLoad (0ms)[m
[31m-				EditorAssembliesLoaded (0ms)[m
[31m-			ExecutionOrderSort2 (0ms)[m
[31m-			AwakeInstancesAfterBackupRestoration (0ms)[m
[31m-Platform modules already initialized, skipping[m
[31m-Registering precompiled user dll's ...[m
[31m-Registered in 0.003787 seconds.[m
[31m-Begin MonoManager ReloadAssembly[m
[31m-Native extension for WindowsStandalone target not found[m
[31m-Refreshing native plugins compatible for Editor in 59.54 ms, found 3 plugins.[m
[31m-Preloading 0 native plugins for Editor in 0.00 ms.[m
[31m-Mono: successfully reloaded assembly[m
[31m-- Completed reload, in  1.979 seconds[m
[31m-Domain Reload Profiling:[m
[31m-	ReloadAssembly (1981ms)[m
[31m-		BeginReloadAssembly (260ms)[m
[31m-			ExecutionOrderSort (0ms)[m
[31m-			DisableScriptedObjects (9ms)[m
[31m-			BackupInstance (0ms)[m
[31m-			ReleaseScriptingObjects (0ms)[m
[31m-			CreateAndSetChildDomain (29ms)[m
[31m-		EndReloadAssembly (1614ms)[m
[31m-			LoadAssemblies (164ms)[m
[31m-			RebuildTransferFunctionScriptingTraits (0ms)[m
[31m-			SetupTypeCache (455ms)[m
[31m-			ReleaseScriptCaches (1ms)[m
[31m-			RebuildScriptCaches (61ms)[m
[31m-			SetupLoadedEditorAssemblies (806ms)[m
[31m-				LogAssemblyE