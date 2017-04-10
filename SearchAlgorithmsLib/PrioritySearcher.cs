using System;
using System.Collections.Generic;
using System.Text;
using Academy.Collections.Generic;

namespace SearchAlgorithmsLib
{
    public abstract class PrioritySearcher<T> : ISearcher<T>
    {
        private PriorityQueue<State<T>> openList;
        private int evaluatedNodes;

        public PrioritySearcher(IComparer<State<T>> comparer)
        {
            openList = new PriorityQueue<State<T>>(new List<State<T>>(), comparer);
            evaluatedNodes = 0;
        }
        public void AddToOpenList(State<T> state)
        {
            openList.Enqueue(state);
        }
        protected State<T> PopOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }
        public bool OpenContains(State<T> state)
        {
            foreach (State<T> s in this.openList)
            {
                if (state.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }
        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        // ISearcher’s methods:

        public virtual int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public void UpdateItem(State<T> newState)
        {
            List<State<T>> poppedStates = new List<State<T>>();

            // Pop all the states until you reach the state we wish to update.
            while (OpenListSize != 0 && openList.Peek() != newState)
            {
                poppedStates.Add(openList.Dequeue());
            }
            openList.Dequeue();
            openList.Enqueue(newState);
            foreach (State<T> s in poppedStates)
            {
                openList.Enqueue(s);
            }
        }
        public abstract Solution<T> Search(ISearchable<T> searchable);

    }
}
