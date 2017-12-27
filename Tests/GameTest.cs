﻿using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class GameTest {
        
        private Board board;
        private Game game;

        public GameTest() {
            this.board = new Board();
            WinConditions winConditions = new WinConditions();
            ComputerLogic computerLogic = new ComputerLogic(winConditions);
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            UI ui = new UI(io, validateInput);
            this.game = new Game(this.board, computerLogic, winConditions, ui);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 3, 5, 6, 8 })]
        [InlineData(new int[] { 6, 7, 8 })]
        public void ExpectMarkerToBePlaced(int[] moves) {
            int spacesAvailableBefore = this.board.GetAvailableSpaces().Count();

            foreach (int move in moves) {
                this.board.UpdateBoard(move);
            }
            int spacesAvailableAfter = this.board.GetAvailableSpaces().Count();

            Assert.NotEqual(spacesAvailableBefore, spacesAvailableAfter);
        }

    }
}
