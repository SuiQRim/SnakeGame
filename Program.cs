﻿using SnakeGame.DataBase;
using SnakeGame.MenuPrefab;
using SnakeGame.Game;

Console.SetWindowSize(50,25);
Console.CursorVisible = false;
Console.Title = "Змейка";
Console.OutputEncoding = System.Text.Encoding.UTF8;

string computerId = Environment.MachineName; 
Observer observer = new ();
bool exist = observer.IsPlayerExist(computerId);

if (!exist)
{
    string text = "Введите никнейм";
    Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 2 - 2);
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
    string nickName = Console.ReadLine() ?? "SnakePlayer";
    observer.AddPlayer(computerId, nickName);

}

Player pforil = observer.GetPlayerByComputerId(computerId);

MainMenu menu = new (pforil);
menu.Start();

