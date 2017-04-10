using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    /*
     * abstract class implement ISearcher.
     */
    public abstract class StackSearcher<T> : ISearcher<T>
    {
        private Stack<State<T>> openList;
        private int evaluatedNodes;
        /*
         * c-tor of StackSearcher.
         */
        public StackSearcher()
        {
            openList = new Stack<State<T>>();
            evaluatedNodes = 0;
        }
        /*
         * add method.
         */
        public void AddToOpenList(State<T> state)
        {
            openList.Push(state);
        }
        /*
         * return if empty.
         */
        public bool IsEmpty()
        {
            if (this.openList.Count > 0)
            {
                return false;
            }
            return true;
        }
        /*
         * pop from the stack.
         */
        protected State<T> PopOpenList()
        {
            evaluatedNodes++;
            return openList.Pop();
        }
        /*
         * get the number of nodes evaluated.
         */
        public virtual int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        /*
         * abstract method- search algorithm.
         */
        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
