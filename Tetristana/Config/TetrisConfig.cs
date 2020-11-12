﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetristana.Config
{
    public enum Tetrominos
    {
        I, J, L, O, S, T, Z
    }

    public static class TetrisConfig
    {
        public static int BlockSize { get; set; } = 35;
        public static int BlockCountWidth { get; set; } = 10;
        public static int BlockCountHeight { get; set; } = 24;
        public static int StatsBoxWidth { get; set; } = 200;

        private static int _tmr_move_blocks_interval = 500;

        public static Timer tmr_move_blocks = new Timer()
        {
            Interval = _tmr_move_blocks_interval,
        };

        public static Dictionary<Keys, string> ControlsInstructions = new Dictionary<Keys, string>
        {
            {Keys.Left, "Move tetromino to the left" },
            {Keys.Right, "Move tetromino to the right" },
            {Keys.Up, "Rotate tetromino clockwise" },
            {Keys.Down, "Drop tetromino softly" },
        };

        public static Dictionary<Tetrominos, Color> TetrominoColors = new Dictionary<Tetrominos, Color>
        {
            {Tetrominos.I, Color.FromArgb(0, 240, 240) },
            {Tetrominos.J, Color.FromArgb(0, 0, 240) },
            {Tetrominos.L, Color.FromArgb(0, 240, 160) },
            {Tetrominos.O, Color.FromArgb(240, 240, 0) },
            {Tetrominos.S, Color.FromArgb(0, 216, 0) },
            {Tetrominos.T, Color.FromArgb(160, 0, 240) },
            {Tetrominos.Z, Color.FromArgb(240, 0, 0) },
        };

        public static void InitializeGame(Form form)
        {
            //init gui
            form.ClientSize = new System.Drawing.Size(BlockSize * BlockCountWidth + StatsBoxWidth, BlockSize * BlockCountHeight);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;

            //add seperator 
            Panel seperator = new Panel()
            {
                Width = 1,
                Height = getFieldHeight(),
                BackColor = Color.Gray,
                Left = getFieldWidth()
            };
            form.Controls.Add(seperator);

            //set initial title
            form.Text = "Tetristana";

            //add controls instructions
            Label controlsInstructions = new Label()
            {
                AutoSize = true,
                Text = getControlsInstructions(ControlsInstructions),
                Left = getFieldWidth() + 10,
                Top = getStatsBoxHeight() / 3 * 2,
            };
            form.Controls.Add(controlsInstructions);
        }

        static Func<int> getFieldWidth = () => BlockCountWidth * BlockSize;
        static Func<int> getFieldHeight = () => BlockCountHeight * BlockSize;

        static Func<int> getStatsBoxWidth = () => StatsBoxWidth;
        static Func<int> getStatsBoxHeight = () => BlockCountHeight * BlockSize;

        private static string getControlsInstructions(Dictionary<Keys, string> instructions)
        {
            string result = "";
            foreach (KeyValuePair<Keys, string> ins in instructions)
            {
                result += $"{ins.Key}:  {ins.Value}\n";
            }
            return result;
        }
    }
}
