using System;
using System.Collections.Generic;
using System.Text;


namespace SearchAlgorithmsLib
{
    /*
     * the class represent us the object we work with.
     * */
    public class State<T>
    {
        private T state;  // the state represented by a T
        private double cost;  // cost to reach this state (set by a setter)
        private State<T> cameFrom;  // the state we came from to this state (setter)
                                    //      private Position goalPos;

        public State(T state) // CTOR
        {
            this.state = state;
            this.cost = 100000000;
        }

        public override int GetHashCode()
        {
            return state.ToString().GetHashCode();
        }

        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return state.Equals(s.state);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as State<T>);
        }
        public float Cost
        {
            get;
            set;
        }
        public State<T> Parent
        {
            get;
            set;
        }
        //TODO change this position

        public T getPosition()
        {
            return this.state;
        }
        public override string ToString()
        {
            return state.ToString();
        }
        public static class StatePool
        {
            private static Dictionary<int, State<T>> pool = new Dictionary<int, State<T>>();
            public static State<T> GetState(T item)
            {
                if (!pool.ContainsKey(item.GetHashCode()))
                {
                    pool.Add(item.GetHashCode(), new State<T>(item));
                }
                return pool[item.GetHashCode()];
            }
        }
    }
}
