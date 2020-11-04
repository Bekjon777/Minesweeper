using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();
        public List<int> Neighbors(int index)
        {
            List<int> neighbors = new List<int>();
            //check four corners
            if (index == 0)
            {
                neighbors.Add(1);
                neighbors.Add(30);
                neighbors.Add(31);
            }
            else if (index == 29)
            {
                neighbors.Add(28);
                neighbors.Add(58);
                neighbors.Add(59);
            }
            else if (index == 450)
            {
                neighbors.Add(420);
                neighbors.Add(421);
                neighbors.Add(451);
            }
            else if (index == 479)
            {
                neighbors.Add(448);
                neighbors.Add(449);
                neighbors.Add(478);
            }
            //check upper row
            else if (index > 0 && index < 29)
            {
                neighbors.Add(index - 1);
                neighbors.Add(index + 1);
                neighbors.Add(index + 29);
                neighbors.Add(index + 30);
                neighbors.Add(index + 31);
            }
            //check left column
            else if (index > 0 && index < 450 && index % 30 == 0)
            {
                neighbors.Add(index - 30);
                neighbors.Add(index - 29);
                neighbors.Add(index + 1);
                neighbors.Add(index + 30);
                neighbors.Add(index + 31);
            }
            //check right column
            else if (index > 29 && index < 479 && index % 30 == 29)
            {
                neighbors.Add(index - 31);
                neighbors.Add(index - 30);
                neighbors.Add(index - 1);
                neighbors.Add(index + 29);
                neighbors.Add(index + 30);
            }
            //check bottom row
            else if (index > 450 && index < 479)
            {
                neighbors.Add(index - 1);
                neighbors.Add(index - 31);
                neighbors.Add(index - 30);
                neighbors.Add(index - 29);
                neighbors.Add(index + 1);
            }
            //check everywhere in the middle
            else
            {
                neighbors.Add(index - 1);
                neighbors.Add(index - 31);
                neighbors.Add(index - 30);
                neighbors.Add(index - 29);
                neighbors.Add(index + 1);
                neighbors.Add(index + 31);
                neighbors.Add(index + 30);
                neighbors.Add(index + 29);
            }
            return neighbors;
        }

        public void Instantiate()
        {
            for(int i=0; i<480; i++)
            {
                buttons.Add(new ButtonModel("blank"));
            }
            for(int i=0; i<99; i++)
            {
                buttons[random.Next(480)].Safety = "bomb";
            }
        }

        public void GiveStates()
        {
            for(int i=0; i<480; i++)
            {
                int counter = 0;
                if (buttons[i].Safety != "bomb")
                {
                    //check four corners
                    if (i == 0)
                    {
                        if (buttons[1].Safety == "bomb")
                            counter++;
                        if (buttons[30].Safety == "bomb")
                            counter++;
                        if (buttons[31].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    else if (i == 29)
                    {
                        if (buttons[28].Safety == "bomb")
                            counter++;
                        if (buttons[58].Safety == "bomb")
                            counter++;
                        if (buttons[59].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    else if (i == 450)
                    {
                        if (buttons[420].Safety == "bomb")
                            counter++;
                        if (buttons[421].Safety == "bomb")
                            counter++;
                        if (buttons[451].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    else if (i == 479)
                    {
                        if (buttons[448].Safety == "bomb")
                            counter++;
                        if (buttons[449].Safety == "bomb")
                            counter++;
                        if (buttons[478].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    //check upper row
                    else if (i > 0 && i < 29)
                    {
                        if (buttons[i - 1].Safety == "bomb")
                            counter++;
                        if (buttons[i + 29].Safety == "bomb")
                            counter++;
                        if (buttons[i + 30].Safety == "bomb")
                            counter++;
                        if (buttons[i + 31].Safety == "bomb")
                            counter++;
                        if (buttons[i + 1].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    //check left column
                    else if (i > 0 && i < 450 && i % 30 == 0)
                    {
                        if (buttons[i - 30].Safety == "bomb")
                            counter++;
                        if (buttons[i - 29].Safety == "bomb")
                            counter++;
                        if (buttons[i + 1].Safety == "bomb")
                            counter++;
                        if (buttons[i + 30].Safety == "bomb")
                            counter++;
                        if (buttons[i + 31].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    //check right column
                    else if (i > 29 && i < 479 && i % 30 == 29)
                    {
                        if (buttons[i - 31].Safety == "bomb")
                            counter++;
                        if (buttons[i - 30].Safety == "bomb")
                            counter++;
                        if (buttons[i - 1].Safety == "bomb")
                            counter++;
                        if (buttons[i + 29].Safety == "bomb")
                            counter++;
                        if (buttons[i + 30].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    //check bottom row
                    else if (i > 450 && i < 479)
                    {
                        if (buttons[i - 1].Safety == "bomb")
                            counter++;
                        if (buttons[i - 31].Safety == "bomb")
                            counter++;
                        if (buttons[i - 30].Safety == "bomb")
                            counter++;
                        if (buttons[i - 29].Safety == "bomb")
                            counter++;
                        if (buttons[i + 1].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                    //check everywhere in the middle
                    else
                    {
                        if (buttons[i - 31].Safety == "bomb")
                            counter++;
                        if (buttons[i - 30].Safety == "bomb")
                            counter++;
                        if (buttons[i - 29].Safety == "bomb")
                            counter++;
                        if (buttons[i - 1].Safety == "bomb")
                            counter++;
                        if (buttons[i + 1].Safety == "bomb")
                            counter++;
                        if (buttons[i + 29].Safety == "bomb")
                            counter++;
                        if (buttons[i + 30].Safety == "bomb")
                            counter++;
                        if (buttons[i + 31].Safety == "bomb")
                            counter++;
                        if (counter > 0)
                            buttons[i].Safety = counter.ToString();
                    }
                }
            }
        }

        public void OpenBlanks(int index)
        {
            List<int> neighbors = Neighbors(index);
            foreach (int neighbor in neighbors)
            {
                if (buttons[neighbor].Safety == "blank" && !buttons[neighbor].State)
                {
                    buttons[neighbor].State = true;
                    OpenBlanks(neighbor);
                }
                else
                {
                    buttons[neighbor].State = true;
                }
            }
        }

        public ActionResult Index()
        {
            buttons.Clear();
            Instantiate();
            GiveStates();
            return View("Index", buttons);
        }

        public bool GameIsWon()
        {
            int openBlanks = 0;
            foreach (ButtonModel button in buttons)
            {
                if (button.Safety != "bomb" && button.Safety != "exploded" && button.State == true)
                {
                    openBlanks++;
                }
            }
            if (openBlanks == 381)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public PartialViewResult HandleButtonClick(string mine)
        {
            int index = Int32.Parse(mine);
            if (!buttons[index].Flag)
            {
                buttons[index].State = !buttons[index].State;
                if (buttons[index].Safety == "blank")
                {
                    OpenBlanks(index);
                }
                else if (buttons[index].Safety == "bomb")
                {
                    buttons[0].Winner = 2;
                    buttons[index].Safety = "exploded";
                    foreach (ButtonModel button in buttons)
                    {
                        button.Game = false;
                        if (button.Safety == "bomb")
                        {
                            button.State = true;
                        }
                    }
                }
            }

            if (GameIsWon())
            {
                buttons[0].Winner = 3;
                foreach (ButtonModel button in buttons)
                {
                    button.Game = false;
                }
            }

            return PartialView("_GameTable", buttons);
        }

        public ActionResult HandleRightButtonClick(string mine)
        {
            int index = Int32.Parse(mine);
            buttons[index].Flag = !buttons[index].Flag;
            return PartialView("_GameTable", buttons);
        }
    }
}