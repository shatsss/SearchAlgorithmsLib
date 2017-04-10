using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /*
     * the solution class.
     */
    public class Solution<T>
    {
        private List<State<T>> solutionList;
        private int numberOfStepst;
        private int numberOfStepsCalculate;

        public Solution()
        {
            this.solutionList = null;
            this.numberOfStepst = 0;
            this.numberOfStepsCalculate = 0;
        }

        public Solution(List<State<T>> listSolution, int number)
        {
            this.solutionList = listSolution;
            this.numberOfStepst = this.solutionList.Count() - 1;
            this.numberOfStepsCalculate = number;
        }
        public List<State<T>> GetSolution()
        {
            return solutionList;
        }
        public void SetSolution(List<State<T>> newSolution)
        {
            this.solutionList = newSolution;
        }
        public bool Equals(Solution<T> solution) // we overload Object's Equals method
        {
            return solutionList.Equals(solution.GetSolution());
        }
        public void PrintSolution()
        {
         //   Console.WriteLine(this.numberOfStepst);
            Console.WriteLine(this.numberOfStepsCalculate);
            /*foreach (State<T> i in this.solutionList)
             {
                 Console.WriteLine(i.ToString());
             }*/
        }
    }
}
