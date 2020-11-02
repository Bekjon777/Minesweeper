using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class ButtonModel
    {
        public string Safety { get; set; }
        public bool State { get; set; }
        public bool Flag { get; set; }
        public bool Game { get; internal set; }

        public ButtonModel(string safety, bool state = false, bool flag = false, bool game = true)
        {
            State = state;
            Safety = safety;
            Flag = flag;
            Game = game;
        }
    }
}