﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEngine;
using EntityEngine.Components.TileComponents;
using EntityEngine.Components.Sprites;
using EntityEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace EntityEngine
{
    public class State
    {
        public enum ScreenState
        {
            LOADING_FILES, MAIN_PAGE, SETTINGS_MENU, WORLD_MAP, MAP_EDITOR, SHOP, DIALOGUE,
            SKIRMISH, BATTLING, BATTLE_FORECAST, BATTLE_RESOLUTION, SKIRMISH_PREPARATION, SKIRMISH_RESOLUTION
            //SELECTING_UNIT_ON_SKIRMISH_MAP, SELECTING_OPTIONS_FOR_SKIRMISH_UNITS
        }

        public enum SelectionState
        {
            SelectingUnit, SelectingMenuOptions, NoSelection
        }

        public enum BattleState
        {
            Attack, CounterAttack
        }
        public enum TurnState
        {
            AlliesTurn, EnemiesTurn
        }

        //  use this for selecting battles and stuff
        public enum MenuState
        {

        }

        public enum BattleStatus
        {
            NoStatus, Guarding
        }

        public static void Initialize()
        {
            State.screenState = State.ScreenState.WORLD_MAP;
            State.selectionState = State.SelectionState.NoSelection;
            State.battleState = State.BattleState.Attack;

            State.screenWidth = 0;
            State.screenHeight = 0;

            State.dialoguePosition = 0;//Which textbox you're in
            State.dialogueChoicePosition = 0;
            State.displayedDialogueMessage = "";

            State.dialogueLinePosition = 0;
            State.dialogueWordPosition = 0;
            State.dialogueCharacterPosition = 0;

            State.firstDialogueWord = "";
            State.lastTimeDialogueChecked = 0;
            State.messageBegin = false;
            State.currentDialogueMessage = new List<string>();

            State.originalHexClicked = null;

            State.currentAttacker = null;
            State.currentDefender = null;

            State.battleMessage = "";

            State.attackerBattleStatus = BattleStatus.NoStatus;
            State.defenderBattleStatus = BattleStatus.NoStatus;

            State.enemyMoveIndex = 0;
            State.firstTimeEnemyTurn = true;

            State.elapsedTimeForMove = 0;

            State.font = null;
        }

        public static int screenWidth = 0;
        public static int screenHeight = 0;

        public static BattleStatus attackerBattleStatus; //  can be states like "guarding", "healing", "cursed", etc
        public static BattleStatus defenderBattleStatus;

        public static float doubleClickSpeed = 300f;

        public static int menuPosition = 0;

        public static BattleState battleState;
        public static ScreenState screenState;
        public static SelectionState selectionState;
        public static TurnState turnState;

        public static string battleMessage;

        public static HexComponent originalHexClicked; //  used for selecting units

        public static UnitComponent currentAttacker;
        public static UnitComponent currentDefender;

        public static SpriteFont font;

        //public Node currentNode;

        public static int dialoguePosition = 0;
        public static int dialogueChoicePosition = 0;
        public static string displayedDialogueMessage = "";

        public static Texture2D dot;

        public static bool messageBegin = false;
        public static int dialogueLinePosition = 0;
        public static int dialogueWordPosition = 0;
        public static int dialogueCharacterPosition;
        public static string firstDialogueWord = "";
        public static List<string> currentDialogueMessage = new List<string>();

        public static int lastTimeDialogueChecked; // TODO

        public static int sumOfMoves = 0; //debugging

        public static int enemyMoveIndex = 0;

        public static float elapsedTimeForMove = 0;

        public static bool firstTimeEnemyTurn = true;

        //public static List<Unit> units;
    }


}
