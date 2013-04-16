﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEngine;
using EntityEngine.Components.TileComponents;
using EntityEngine.Components.Sprites;
using EntityEngine.Input;

namespace EntityEngine
{
    public class State
    {
        public enum ScreenState
        {
            LOADING_FILES, MAIN_PAGE, SETTINGS_MENU, WORLD_MAP, MAP_EDITOR, SHOP, DIALOGUE,
            SKIRMISH, BATTLING, BATTLE_FORECAST, BATTLE_RESOLUTION,
            //SELECTING_UNIT_ON_SKIRMISH_MAP, SELECTING_OPTIONS_FOR_SKIRMISH_UNITS
        }

        public enum SelectionState
        {
            SelectingUnit, SelectingOptionsForSkirmishUnits, NoSelection
        }

        //Keeps track of which menu is displayed, if at all, for the units order
        //Things like "no order" dont have a menu so they dont get a state

        public static MenuState unitMenuState = MenuState.NONE;
        public enum MenuState
        {
            MOVING, ATTACK,SPELLS,ITEMS,NONE 
        }

        public static void Initialize()
        {
            State.screenState = State.ScreenState.WORLD_MAP;
            State.selectionState = State.SelectionState.NoSelection;
            State.dialoguePosition = 0;
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
        }

        public static int menuPosition = 0;

        public static ScreenState screenState;
        public static SelectionState selectionState;

        public static HexComponent originalHexClicked; //  used for selecting units

        //public Node currentNode;
        public static int dialoguePosition = 0;
        public static int dialogueChoicePosition = 0;
        public static string displayedDialogueMessage = "";

        public static bool messageBegin = false;
        public static int dialogueLinePosition = 0;
        public static int dialogueWordPosition = 0;
        public static int dialogueCharacterPosition;
        public static string firstDialogueWord = "";
        public static List<string> currentDialogueMessage = new List<string>();

        public static int lastTimeDialogueChecked; // TODO

        //public static List<Unit> units;
    }


}
