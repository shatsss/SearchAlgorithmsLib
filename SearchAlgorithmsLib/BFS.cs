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
        private Solution<T> backTrace(State<T> state)
        {
            Stack<State<T>> openStack = new Stack<State<T>>();
            List<State<T>> openList = new List<State<T>>();
            openStack.Push(state);
            while ((state = state.Parent) != null)
            {
                openStack.Push(state);
            }
            while (openStack.Count > 0)
            {
                openList.Add(openStack.Pop());
            }
            return new Solution<T>(openList, this.getNumberOfNodesEvaluated());
        }
        public override Solution<T> search(ISearchable<T> searchable)
        {
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                    return backTrace(n); // private method, back traces through the parents
                                         // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openContains(s))
                    {
                        addToOpenList(s);
                    }
                    else
                    {
                        float newDiraction = searchable.betterDiraction(n, s);
                        float prevDiraction = s.Cost;
                        if (newDiraction < prevDiraction)
                        {
                            if (!openContains(s))
                            {
                                addToOpenList(s);
                            }
                            else
                            {
                                updateItem(s, newDiraction);
                            }
                        }

                    }
                }
            }
            return null;
        }
    }

}
