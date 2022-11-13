# GC4RVLoader

A tool for setting up GameCube games to run on a softmodded Wii via RVLoader.

### What does it do?

[RVLoader](https://github.com/Aurelio92/RVLoader) is a tool created by [Aurelio](https://github.com/Aurelio92) for the Wii modding community to load games from a USB drive (among many other features), bypassing the need for a physical disk drive. This is useful for projects like portable Wiis, which are capable of playing GameCube games.

GC4RVLoader is a tool to take ISO files (GameCube disk images) and convert them to a format that RVLoader understands, as well as downloading cover art for each game.

### Usage
Run `GC4RVLoader.exe` in the same folder as your .iso files.

Given the following folder structure:
```
root/
    Mario Kart - Double Dash!!.iso
    Kirby Air Ride.iso
    Luigi's Mansion.iso
```
...this tool can convert it into this folder structure:
```
root/
    games/
        Mario Kart - Double Dash!!/
            game.iso
        Kirby Air Ride/
            game.iso
        Luigi's Mansion/
            game.iso
    rvloader/
        covers/
            GKYE01.png
            GLME01.png
            GM4E01.png
```
At which point, `games/` and `rvloader/` can be dragged into the root of your USB drive, merging with the existing files.

### Notes

- Functionality for Wii games is not supported.
- .nkit iso files are not supported. To convert them back into ISO format, use [NKit](https://vimm.net/vault/?p=nkit).
- This has only been tested on Windows platform. 