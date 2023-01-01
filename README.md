# Go To The Point

## Introduction  
“Go to The Point” is a somatosensory game based on orienteering rules. It was implemented by Unity game editor and Arduino Leonardo.

<div align=center><img src="https://user-images.githubusercontent.com/61057370/199631685-8f1cf54f-fbb4-4cd4-b8d3-a6a0313ccc44.png" width="200" height="200" alt="ROOM"/></div>
  
## Design Goal
I produce “Go to The Point” to provide a way for players to exercise at home, and meanwhile, popularize orienteering as a type of sport. 

## Guide
Unity Editor version: 2020.3.25f1c1  
If you want to examine the scripts of the game, you can find programs under Assets/Scripts.
<div align=center><img src="https://user-images.githubusercontent.com/61057370/199633244-67b1874e-5388-4db2-a836-6896e7c95151.png" width="275" height="450" alt="ROOM"/></div>

## Code Desciption
Due to limited space, I only describe one important part of the code sample in this project. In the **RuleManger** folder, there are four scripts implementing the rule of orienteering in the game. I applied the concept of object-oriented programming, dividing the rule system into four different classes. Point class contains basic information about a control point, including name, order, and time (when the player reaches this point); RuleManager class loads control points in the scene into an array; Timer class contains functions for time record; TimerManager class controls the timer and corresponding UI contents. 

## Play 
If you want to play this game, please follow this address https://mark-zf.itch.io/go-to-the-point
