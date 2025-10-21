🦊 S1ySt34lthSPTTrainer
The Ultimate Offline Tarkov Utility Trainer for SPT-AKI

Created by S1yc00p3r

⚠️ Disclaimer:
This tool is designed exclusively for use with SPT-AKI (Single Player Tarkov).
Do not use it in live Tarkov — BattleState Games or BattlEye will ban your account.
Use responsibly, offline, and at your own risk.

💡 Overview

S1ySt34lthSPTTrainer is an advanced, feature-rich trainer designed specifically for SPT-AKI builds of Escape From Tarkov.
It includes powerful utilities, a full in-game GUI, and customizable configurations — all built for safe offline use.

🧠 Default GUI Key: Right-Alt
✅ Compatible with SPT 4.0.0+ and EFT 0.16.9.40087

⚙️ Installation
🔹 Option 1: Universal Installer (Recommended)

Just run the Universal Installer — it will automatically detect your SPT installation and configure everything for you.

S1ySt34lthSPTTrainer.exe


Make sure you’ve launched SPT at least once before installing, as the game patches its binaries during the first startup.

🔹 Option 2: Manual Build

If you prefer to compile yourself:

dotnet publish Installer\Installer.csproj -c Release -r win-x64 -p:PublishSingleFile=true -p:PublishTrimmed=false -o .\out


Clean your project (bin, obj) after upgrading EFT/SPT to avoid reference mismatches.

🎯 Core Features
Category	Command / GUI Section	Description
🎯 Aimbot	aimbot	Adjustable FOV, smoothing, silent aim, and shot delay.
🚀 Speed / Fly	speed	Move faster or phase through walls safely.
🧍 Players ESP	players	Highlights players (BEAR, USEC, SCAV, Bosses, Cultists) with full info, skeletons, and colors.
💎 Loot ESP	loot	Track specific loot, wishlist items, or by rarity — even inside containers.
🗺️ Map & Radar	map, radar	Full-screen map, radar overlay, and exfil markers.
💀 Godmode	health	Infinite health, stamina, hydration, and energy.
🔫 No Recoil / Sway	norecoil, nosway	Perfect aim with zero weapon shake or recoil.
💥 WallShoot	wallshoot	Bullets penetrate all materials with minimal deviation.
💡 Thermal / NVG	thermal, night	Toggle vision modes instantly.
💰 Skills & Mastery	skills	Instantly max out all skills and weapon mastery.
💼 Quests / Exfil / Hideout	quest, stash	Show quest POIs, stash locations, and exfil status.
🎮 GUI Console	commands	Popup control panel for toggling any feature.
🛠️ Configuration

All trainer settings are saved in trainer.ini and can be managed via in-game console or GUI.

Example:

ammo on
norecoil on
radar on
save

Load & Save

save – saves current settings to trainer.ini

load – loads saved configuration

🌍 Languages

Available in:

English 🇬🇧

French 🇫🇷

Japanese 🇯🇵

Simplified Chinese 🇨🇳

Set language via installer flag, e.g.:

Installer.exe -l zh-cn


You can also customize translations manually in /Lang.

🔧 Troubleshooting

If your game freezes at the startup screen or shows type/token errors, it means:

Your binaries are out of sync with your trainer build.

Delete your /bin and /obj folders and recompile.

Ensure SPT has been launched at least once before compiling.

Log path:

%LOCALAPPDATA%\Low\Battlestate Games\EscapeFromTarkov\Player.log

🧩 Compatibility
EFT Version	SPT Version	Branch	Status
0.16.9.40087	4.0.0+	master	✅ Supported
Other Versions	Varies	Check releases	⚙️ Coming Soon
📦 Download

Direct Download (Latest Release):
S1ySt34lthSPTTrainer_v1.0.0.zip

🧾 License

This project is distributed under the MIT License.
Feel free to fork, modify, and experiment for personal offline use.

❤️ Credits

Special thanks to the SPT-AKI community and open-source modders for their inspiration and tools that made this trainer possible.