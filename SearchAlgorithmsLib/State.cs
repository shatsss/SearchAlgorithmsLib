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

        private State(T state) // CTOR
        {
            this.state = state;
        }
        /*
         * ovveride the get hashcode method.
         */
        public override int GetHashCode()
        {
            return String.Intern(state.ToString()).GetHashCode();
        }
        /*
         * overide the equals method.
         */
        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return state.Equals(s.state);
        }
        /*
         * overide the equals method.
         */
        public override bool Equals(object obj)
        {
            return Equals(obj as State<T>);
        }
        /*
         * Cost member.
         */
        public float Cost
        {
            get;
            set;
        }
        /*
         * where we come from.
         */
        public State<T> Parent
        {
            get;
            set;
        }
        /*
         * overide the equals method.
         */
        public static bool operator ==(State<T> left, State<T> right)
        {
            return Equals(left, right);
        }

        /*
         * overide not equals operator.
         */
        public static bool operator !=(State<T> left, State<T> right)
        {
            return !Equals(left, right);
        }

        /*
         * overide compareTo method.
         */
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            State<T> other = obj as State<T>;
            if (other != null)
                return this.Cost.CompareTo(other.Cost);
            else
                throw new ArgumentException();
        }
        /*
         * get the position of the state.
         */
        public T GetPosition()
        {
            return this.state;
        }
        /*
         * overide the toString of the function.
         */
        public override string ToString()
        {
            return state.ToString();
        }
        /*
         * inner class creates satets.
         */
        public static class StatePool
        {
            private static Dictionary<T, State<T>> pool = new Dictionary<T, State<T>>();
            /*
             * get the instance of the state and if we dont have it creates him.
             */
            public static State<T> GetState(T item)
            {
                if (!pool.ContainsKey(item))
                {
                    pool.Add(item, new State<T>(item));
                }
                return pool[item];
            }
        }
        /*
         * static method that returns comperator.
         */
        public static IComparer<State<T>> GetDefaultCostComparer()
        {
            return new DefaultCostComparer();
        }
        /*
         * private comperator of state.
         */
        private class DefaultCostComparer : IComparer<State<T>>
        {
            public int Compare(State<T> x, State<T> y)
            {
                float hefresh = x.Cost - y.Cost;
                if (hefresh > 0)
                {
                    return 1;
                }
                if (hefresh < 0)
                {
                    return -1;
                }
                return 0;
            }
        }

    }
}
