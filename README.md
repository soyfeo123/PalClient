# PalClient
PalClient is a Roblox Launcher which makes customizing Roblox easier.
Inspired by Minecraft Clients (Lunar Client etc), this launcher will let you launch roblox from different UI, and change options too, quick and easy without having to go inside Roblox's files!
This launcher doesn't just change your Roblox client, it can replace your Roblox UI completely by using PalClient Play (BETA)!

# Requirements
Windows 10 19xx or later.
Dark theme recommended (Visual glitches may happen while in Light Mode).
A decent GPU (Not that powerful) since this app uses something called "Acrylic" which makes some cool effects (background blur) at the cost of a slightly slower experience if not good enough.

# Installation
This app is a UWP app, so it cannot be installed/opened in the normal way.

First, go to Settings and enable "Developer Mode" ( ms-settings:developers ).
This way, Windows will allow loose UWP files to install to your PC.

In the releases tab, download the latest version.

Extract the contents, then you'll see some files, none of which are EXEs, but they do contain the app.

Check if you have enough space in the C drive (this app is pretty small, so no worries there) and execute "Install.ps1" by right-clicking the file and clicked "Run with PowerShell".
(If the 'Run with PowerShell" option does not appear, you may need to update PowerShell or Windows, or install PowerShell.)

After that, you may access PalClient by searching it in the search menu.
NOTE: In order to use PalClient Play you need RoPro to be installed in your main browser!

# Compile process
Install Visual Studio 2022 (2022, not any other version) and with it install "Universal Windows Platform" in the Visual Studio Installer.
Then, clone this repo and compile it as you would any other app.
But for distrubution, you need to go to "Project", go through "Publish" and select "Create App Packages".
Select "Sideloading" and not "Microsoft Store", since you may have to pay, and who would want to pay to upload a cloned app.
Also, don't enable Automatic Updates. You'll have to go through a whole process.
Then, click "Next".
Create or select a certificate, and then from there it's your preference.
Once finished, you'll be given almost the same files as the official PalClient, Install.ps1 and stuff.
It's the same installation process.

# FAQ
Q: How does this client even work?
A: It uses a combination of file modification and app parameters. It may also use web browsers and extensions.

Q: Did you copy (insert another roblox launcher here)?
A: No, I didn't. I imagined it while changing ClientSettings, and Calming Client was born. I was experimenting on making an extension to go along with the client, but I gave up due to Roblox's protection against automatic clicks. After that I was thinking on what to do, when I saw a UWP app and thought "Hmmm, yeah! I should completely throw away I learned about Unity and its extensions to make this app that probably won't be used!" and PalClient was born.

Q: Yeah so my PC is lagging a lot while using PalClient.
A: That most likely is the acrylic effect lagging you, can't do much about it except hope you get a decent GPU.

Q: Windows won't let me install PalClient.
A: Make sure you have Developer Mode on, or just search for PalClient in the search bar. Install.ps1 may throw an error, but ignore it. It'll still install.

Q: When will you make a MacOS or Linux release?
A: No.

