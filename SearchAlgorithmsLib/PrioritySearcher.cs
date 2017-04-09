using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;
using SearchAlgorithmsLib;

namespace SearchAlgorithmsLib
{
    public abstract class PrioritySearcher<T> : ISearcher<T>
    {
        private SimplePriorityQueue<State<T>> openList;
        private int evaluatedNodes;
        public PrioritySearcher()
        {
            openList = new SimplePriorityQueue<State<T>>();
            evaluatedNodes = 0;
        }
        public void addToOpenList(State<T> state)
        {
            openList.Enqueue(state, (float)state.Cost);
        }
        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }
        public bool openContains(State<T> state)
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

        public virtual int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public void updateItem(State<T> state, float coast)
        {
            this.openList.UpdatePriority(state, coast);
        }
        public abstract Solution<T> search(ISearchable<T> searchable);

    }
}
