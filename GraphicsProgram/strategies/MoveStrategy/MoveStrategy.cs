﻿using GraphicsProgram.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram.strategies.MoveStrategy
{
    public class MoveStrategy : IMoveStrategy
    {
        public bool AppliesTo(string commandLine)
        {
            return commandLine.Equals(MoveState.Move);
        }

        public PenPosition MovePen(string line, PenPosition penStatus, Pen pen, Graphics G)
        {
            var splitCommand = line.Split();
            float X = 0;
            float Y = 0;

            try
            {
                var penX = int.Parse(splitCommand[1]);
                var penY = int.Parse(splitCommand[2]);

                if (penStatus.Enabled)
                {        
                    G.DrawLine(pen, Y, X, penX, penY);
                    X = penX;
                    Y = penY;
                }
                else if (penStatus.Enabled == false)
                {
                    X = penX;
                    Y = penY;
                }
                

                return new PenPosition
                {
                    X = penX,
                    Y = penY,
                };
            }
            catch (Exception)
            {
                throw new Exception("Unable to parse X & Y co-ordinates, please try again with two integers!");
            }
        }
    }
}
