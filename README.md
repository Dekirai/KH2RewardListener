# KH2RewardListener

Viewers can interact with your KH2 session by using Channel Points on Twitch!

## What exactly is KH2RewardListener?
KH2RewardListener is a program developed by Dekirai where users on twitch can interact on your current Kingdom Hearts II Final Mix (PC) session using their Channel Points.  
There are **over 30 rewards** (and more to come) you can set up on your stream and viewers can use. 
You got the full control of the settings of the rewards. You can name them yourself and put in a custom duration on how long a reward should last if it is supported.  
**I strongly recommend to set up delays directly via Twitch's channel reward settings so the rewards can't be spamed by users.**

## Requirements

 - Latest version of Kingdom Hearts 1.5+2.5 HD ReMIX on Epic Games
 - Topaz' Re:Fined works too!
 - [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Information
You can read a full reward breakdown in the [Wiki](https://github.com/Dekirai/KH2RewardListener/wiki/Rewards).    
There you can see what exactly each reward does in your game!  

Upon first time launching the program, it will generate a **config_rewards.ini** file where a config for every reward will get generated.  
**The program will close itself afterwards which means you have to restart it after you see the file appearing.**

## Packages
[TwitchLib](https://github.com/TwitchLib/TwitchLib)  
[KH2MemLibrary](https://github.com/Dekirai/KHMemLibrary) by Dekirai  
[Memory.dll](https://github.com/erfg12/memory.dll) by erfg12  
[MadMilkman.ini](https://github.com/MarioZ/MadMilkman.Ini) by MarioZ  

## Tutorial

 1.  Once the program is open, head over to "Settings Tab".
 2.  Make sure your Streamer Account is logged in on Twitch currently.
 3.  Hit "Generate" and authorize the app.
 4.  Now the "Streamer Account" Box should be filled out in the 3 boxes.
 5.  Now click on "Create App" while being logged in on Twitch.
 6.  Click on "Register your Application".
 7.  Name the app whatever you want.
 8.  As "OAuth Redirect URL" you set it to http://localhost:8080/redirect/
 9.  As "Category" you set it to "Application Integration".
 10. Hit "Create".  
 11. Go back to the overview and click on your created app's name.
 12. Copy "Client ID" and paste it in the program where it says "Client ID".
 13. Click on "New Secret" and copy and paste it in the program where it says "Client Secret".
 14. You should now be ready to go and click on "Start Bot". (Don't forget to type in your channel's name)

## Preview

![Image1](https://i.imgur.com/YwHbhPO.png)![Image2](https://i.imgur.com/gemrJC4.png) ![Image3](https://i.imgur.com/ffUnPgZ.png) ![Image4](https://i.imgur.com/45R5hFP.png)

## Credits and Thanks
 - WaterKH - For the [Re:Write](https://github.com/WaterKH/ReWrite) inspiration and trying to help me
  - TopazTK - For telling me to not store 1000+ lines of code in a single file. :)
