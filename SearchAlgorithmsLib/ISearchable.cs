using System;
using System.Collections.Generic;
using System.Text;


namespace SearchAlgorithmsLib
{
    public interface ISearchable<T>
    {
        State<T> GetInitialState();
        State<T> GetGoalState();
        List<State<T>> GetAllPossibleStates(State<T> s);
        bool BetterDiraction(State<T> state, State<T> state2);
        void UpdateCost(State<T> state, State<T> state2);
        void UpdateCameFrom(State<T> state, State<T> state2);
    }
}
