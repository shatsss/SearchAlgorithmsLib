using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public class BFS<T> : PrioritySearcher<T>
    {
        /*
         * BFS c-tor that create cost comperator.
         */
        public BFS() : base(State<T>.GetDefaultCostComparer()) { }
        /*
         * BFS c-tor that gets comperator.
         */
        public BFS(IComparer<State<T>> comparer) : base(comparer) { }

        public override Solution<T> Search(ISearchable<T> searchable)
        {
            AddToOpenList(searchable.GetInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = PopOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.GetGoalState()))
                    return GiveSolution<T>.BackTrace(n, this.GetNumberOfNodesEvaluated()); // private method, back traces through the parents
                
                List<State<T>> succerssors = searchable.GetAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s))
                    {
                        // If the current child state isn't in the open list.
                        if (!this.OpenContains(s))
                        {
                            searchable.UpdateCameFrom(s, n);
                            searchable.UpdateCost(s, n);
                            this.AddToOpenList(s);
                        }
                        // If the current child state exists in the open list.
                        else
                        {
                            bool checkBetterDirection = searchable.BetterDiraction(s, n);
                            if (checkBetterDirection)
                            {
                                searchable.UpdateCameFrom(s, n);
                                searchable.UpdateCost(s, n);
                                UpdateItem(s);
                            }
                        }
                    }
                }
            }
            return null;
        }
    }

}
