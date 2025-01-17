<h1>
    <a href="#--------------------hedge-mod-manager">
        <img width="48" align="left" src="https://github.com/thesupersonic16/HedgeModManager/raw/rewrite/HedgeModManager/Resources/Graphics/icon256.png">
    </a>
    Hedge Mod Manager
    <img src="https://github.com/thesupersonic16/HedgeModManager/actions/workflows/build.yml/badge.svg">
</h1>

The goal of this project is to better support **HedgeModManager** on Linux, *without* using Wine.

Primary focus is to simplify the process on Steam Deck, but can be built for any distribution.

### Future Supported Games
- [Sonic Generations](https://store.steampowered.com/app/71340)
- [Sonic Lost World](https://store.steampowered.com/app/329440)
- [Sonic Forces](https://store.steampowered.com/app/637100)
- [Puyo Puyo Tetris 2](https://store.steampowered.com/app/1259790)
- [Olympic Games Tokyo 2020](https://store.steampowered.com/app/981890)
- Sonic Colours: Ultimate ([Steam](https://store.steampowered.com/app/2055290), [Epic Games Store](https://www.epicgames.com/store/p/sonic-colors-ultimate))
- Sonic Origins ([Steam](https://store.steampowered.com/app/1794960), [Epic Games Store](https://store.epicgames.com/en-US/p/sonic-origins))
- [Sonic Frontiers](https://store.steampowered.com/app/1237320)

## How is this accomplished?
Currently, this project is in early development. A native Linux port is being tested using [Mono](https://www.mono-project.com/) and [Gtk#](https://github.com/GtkSharp/GtkSharp). The final release is expected to contain UI limitations differentiating from the official HedgeModManager. However, mods and code injection will function as expected. 

It is likely that [Protontricks](https://github.com/Matoking/protontricks) may still be required to install Windows dependencies in your *game's* Proton prefix.

Several methods are being experimented with to accomplish this port, among other developers. Please expect changes to be made.

## How can I contribute?
All contributions will be greatly appreciated! The project outline is not finalized, so please be patient as guidelines are developed.

## So how do I use this?
### Steam Deck (steamOS)
Primary support for this project is designed to simplify the modding experience on Steam Deck, and will be provided as it develops.

### Other Linux Distros
In case you currently wish to use HedgeModManager on Linux/Steam Deck, check out [this guide](https://github.com/thesupersonic16/HedgeModManager/wiki/Running-on-Linux-(Wine)) on the original wiki.

### Windows
Please grab the latest release from the [original repository](https://github.com/thesupersonic16/HedgeModManager).

## How do I install mods?
There are multiple ways of installing mods, one of the easy ways of installing mods is by dragging its zip/7z/rar/folder into the mod list along with also being able to drag and drop multiple files and/or folders.

You can also install mods using [GameBanana](https://gamebanana.com)'s 1-Click Install button. 

Once you're done, you can start checking the checkbox(es) of the mods and codes you want to play and click "Save and Play".

## How do I release mods for this?
**The following section is for mod developers only. If all you want to do is play with some mods made by others, simply follow the above steps.**

Please check the [HedgeModManager Wiki](https://github.com/thesupersonic16/HedgeModManager/wiki) for information on releasing mods and updating.
