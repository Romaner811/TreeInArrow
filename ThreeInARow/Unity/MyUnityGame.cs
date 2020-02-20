using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ThreeInARow.Unity
{
    using IFace;
    using Basic;

    class MyUnityGame
    {
        private IBoard board;
        private IEnumerable<IRule> rules;

        private int currentRuleIdx;
        private IBehavior currentBehavior;

        public MyUnityGame(
            int boardWidth,
            int boardHeigth,
            GameObject boardGameObject,
            GameObject slotPrefab,
            IEnumerable<GameObject> itemPrefabs
        )
        {
            this.board = new UnityBoard(
                boardGameObject,
                boardWidth, boardHeigth,
                new UnitySlotFactory(slotPrefab)
            );

            this.rules = new IRule[]
            {
                new GravityRule(),
                new ItemSpawnRule(new UnityItemFactory(itemPrefabs)),
            };

            this.currentRuleIdx = 0;
            this.currentBehavior = null;
        }

        private void NextRule()
        {
            this.currentRuleIdx = (this.currentRuleIdx + 1) % this.rules.Count();
        }

        public void Update()
        {
            if (this.currentBehavior != null)
            {
                if (this.currentBehavior.IsRunning)
                {
                    this.currentBehavior.Step();
                }
                else
                {
                    this.currentBehavior = null;
                    this.NextRule();
                }
            }
            else
            {
                IRule rule = this.rules[this.currentRuleIdx];

            }
        }
    }
}
