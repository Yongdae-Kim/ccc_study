using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HookingProgram
{
    class KeyTableMaker
    {
        private Hashtable keyTable = new Hashtable();


        public KeyTableMaker()
        {
            this.addToFunctionKeys();
            this.addToNumberKeys();
            this.addToArrowKeys();
            this.addToRightArithmeticKeys();
            this.addToEtcKeys();
            //need to modify when keyboard type changed
        }

        private void addToEtcKeys()
        {
            keyTable.Add("Oemtilde", " ` ");
            keyTable.Add("OemMinus", " - ");
            keyTable.Add("Oemplus", " = ");
            keyTable.Add("OemOpenBrackets", " [ ");
            keyTable.Add("Oem6", " ] ");
            // keyTable.Add("Oem5", "\");
            keyTable.Add("Oem1", " ; ");
            keyTable.Add("Oem7", " ' ");
            keyTable.Add("Oemcomma", " , ");
            keyTable.Add("OemPeriod", " . ");
            keyTable.Add("OemQuestion", " / ");
        }

        private void addToRightArithmeticKeys()
        {
            keyTable.Add("Add", " R+ ");
            keyTable.Add("Subtract", " R- ");
            keyTable.Add("Multiply", " R* ");
            keyTable.Add("Divide", " R/ ");
        }

        private void addToArrowKeys()
        {
            keyTable.Add("Up", " ↑ ");
            keyTable.Add("Down", " ↓ ");
            keyTable.Add("Right", " → ");
            keyTable.Add("Left", " ← ");
        }

        private void addToNumberKeys()
        {
            keyTable.Add("D1", "1");
            keyTable.Add("D2", "2");
            keyTable.Add("D3", "3");
            keyTable.Add("D4", "4");
            keyTable.Add("D5", "5");
            keyTable.Add("D6", "6");
            keyTable.Add("D7", "7");
            keyTable.Add("D8", "8");
            keyTable.Add("D9", "9");
            keyTable.Add("D0", "0");
        }

        private void addToFunctionKeys()
        {
            keyTable.Add("LControlKey", " LCtrl ");
            keyTable.Add("LShiftKey", " LShift ");
            keyTable.Add("Capital", " CapsLock ");
            keyTable.Add("Tab", " Tab ");
            keyTable.Add("Escape", " Esc ");
            keyTable.Add("LWin", " LWin ");
            keyTable.Add("Space", " Space ");
            keyTable.Add("Back", " Backspace ");
            keyTable.Add("KanaMode", " Korean/English ");
            keyTable.Add("HanjaMode", " Chinese ");
            keyTable.Add("RShiftKey", " RShift ");
            keyTable.Add("Return", " Enter ");
            keyTable.Add("Insert", " Insert ");
            keyTable.Add("Delete", " Delete ");
            keyTable.Add("Home", " Home ");
            keyTable.Add("End", " End ");
            keyTable.Add("PageUp", " PgUp ");
            keyTable.Add("Next", " PgDn "); //need to information "next"
            keyTable.Add("NumLock", " NumLock ");
        }

        public Hashtable getKeyTable() { return keyTable; }
    }
}
