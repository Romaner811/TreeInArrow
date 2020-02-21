using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARow.Basic
{
    using IFace;

    public class ThreeInARowBasicGame
    {
        public static IBoard CreateBasicBoard(int width, int heigth)
        {
            return new BasicBoard(width, heigth, new BasicSlotFactory());
        }

        public static IEnumerable<IRule> GenerateStandartBasicRules()
        {
            return new IRule[]
            {
                // TODO: add rules!
            };
        }

        private readonly IBoard board;
        private readonly IEnumerable<IRule> rules;
        private readonly IInputManager input;

        private int currentRuleIdx;
        private IBehavior currentBehavior;

        public ThreeInARowBasicGame(
            IBoard board,
            IEnumerable<IRule> rules,
            IInputManager input
            )
        {
            this.board = board;
            this.rules = rules;
            this.input = input;

            this.currentRuleIdx = 0;
            this.currentBehavior = null;
        }

        // TODO: (optional) put rules into a round robin object.
        protected void NextRule()
        {
            this.currentRuleIdx++;
        }

        protected void ResetCurrentRule()
        {
            this.currentRuleIdx = 0;
        }

        
        protected void StepBehavior()
        {
            this.currentBehavior.Step();
            // did it finish?
            if (!this.currentBehavior.IsRunning)
            {
                // clean behavior
                this.currentBehavior = null;
            }
        }

        protected void HandleRule()
        {
            // execute the current rule, until it has no work.
            IRule currentRule = this.rules.ElementAt(this.currentRuleIdx);
            IBehavior ruleBehavior = currentRule.ProduceRelevantBehavior(this.board);
            
            // is the behavior empty?
            if (ruleBehavior == null)
            {
                this.NextRule();
            }
            else
            {
                // put behavior to execution
                this.currentBehavior = ruleBehavior;
            }
        }

        protected void HandleInput()
        {
            // get relevat user input
            IMove move = this.input.GetMove();
            if (move != null)
            {
                // create a behavior that is the reaction to the input
                IBehavior inputReaction = null;   // TODO: //>WIP
                // put behavior to execution
                this.currentBehavior = inputReaction;

                // we got a user input, and after it's behavior we should check all the rules again.
                // next time start from first rule.
                this.ResetCurrentRule();
            }
        }

        /* Imagine this Update method is the main game loop:
         *      game = new ThreeInARowGame(...);
         * 
         *      while (appIsRunning) {
         *          game.Update();
         *          Threading.Sleep(GetRemainingFrameDuration());
         *      }
         */
        public void Update()
        {
            // do you have a behavior to execute?
            if (this.currentBehavior == null)
            {
                this.StepBehavior();
                return;
            }

            // any rules should run?
            if (this.currentRuleIdx >= this.rules.Count())
            {
                this.HandleRule();
                return;
            }

            this.HandleInput();
        }
    }
}
