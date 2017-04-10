using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : StackSearcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            State<T> state = null;
            HashSet<State<T>> hashSet = new HashSet<State<T>>();
            AddToOpenList(searchable.GetInitialState());
            while (!IsEmpty())
            {
                state = PopOpenList();
                if (state.Equals(searchable.GetGoalState()))
                {
                    return GiveSolution<T>.BackTrace(state, this.GetNumberOfNodesEvaluated());
                }
                hashSet.Add(state);
                List<State<T>> succerssors = searchable.GetAllPossibleStates(state);
                foreach (State<T> i in succerssors)
                {
                    if (!hashSet.Contains(i))
                    {
                        searchable.UpdateCameFrom(i, state);
                        AddToOpenList(i);
                    }
                }
            }
            return null;
        }
    }
}
