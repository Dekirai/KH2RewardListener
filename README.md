


# KH2RewardListener

Viewers can interact with your KH2 session by using Channel Points on Twitch!

## What exactly is KH2RewardListener?
KH2RewardListener is a program developed by Dekirai that allows users on Twitch to interact with your current Kingdom Hearts II Final Mix (PC) session using their Channel Points.  
There are **over 30 rewards** (and more to come) that you can set up on your stream for viewers to use. 
You have full control over the settings of the rewards. You can name them yourself and set a custom duration for how long a reward should last if it is supported.  
**I strongly recommend that you set up delays directly in your channel's rewards settings on Twitch so that users can't spam your rewards.**.

## Requirements

 - Latest version of Kingdom Hearts 1.5+2.5 HD ReMIX on Epic Games
 - Windows 10+ x64
 - [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Packages
[TwitchLib](https://github.com/TwitchLib/TwitchLib) by TwitchLib  
[Memory.dll](https://github.com/erfg12/memory.dll) by erfg12

## Information
 - Most rewards will stop when the player is in a cutscene, pause menu, world map, talking to NPCs, etc
 - Each reward has it's own .json file in the Rewards folder
 - You may experience crashes when forcing drive forms, but I keep trying to fix them
 
## Media
![Image1](https://i.imgur.com/8UMhfJI.png)
![Image2](https://i.imgur.com/cUNM8s9.png)
![Image3](https://i.imgur.com/DiKKLsT.png)  

 https://user-images.githubusercontent.com/20326375/219880767-a5a2081c-2e8b-4fac-9e92-cf4610293547.mp4

## Tutorial
1. Open the program (KH2RewardListener.exe)
2. Go to the "Settings" tab
3. Click on "Create App on Twitch"
4. Click "Register your application" on the page
5. Name it whatever you want
6. Enter http://localhost:8080/redirect/ as the redirect URL
7. Set the category to "Application Integration"
8. Back to the overview, click on the name of your newly created application
9. Copy and paste the Client ID into the program
10. Create a new secret and copy it into the program
11. Now click on "Login with Twitch"
12. If everything worked, the fields in the "Streamer Account" Box should be filled in
13. You can now click on "Listen to Rewards" in the "Console" tab.
14. When you see "Successfully connected to client" and "Successfully connected to PubSub server", you are ready to configure your rewards
15. Go to Twitch and create or edit an existing reward
16. Once a reward has been created/edited, the tool will output the reward id
17. Go to the "Rewards" folder, you'll find lots of .json files
18. Open any JSON file belonging to the reward you created
19. Copy the Reward ID you got from the program and paste it into "ID" and save the file
20. Redeem the reward on Twitch, now something should happen in-game

## Credits and Thanks
 - WaterKH - For the [Re:Write](https://github.com/WaterKH/ReWrite) inspiration and some help
 - [NobodyDaxian](https://www.twitch.tv/nobodydaxian) - Many tests, suggestions for improvement and bug hunting
