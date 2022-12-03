using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algebra
{
    public class Expression
    {
        decimal? resultValue;
        string entryFormula;
        ExecutionTree executionTree;
        Dictionary<char, decimal> variableNamesToValues;

        public Expression(string formula)
        {
            if (!Formula.IsValid(formula)) throw new ArgumentException();

            this.entryFormula = formula;
            this.executionTree = new ExecutionTree(formula);
        }
        public decimal Value
        {
            get
            {
                if (!this.IsEvaluated()) throw new Exception();

                return resultValue.Value;
            }
        }

        public bool IsEvaluated()
        {
            bool result;
            if (resultValue == null)
            {
                result = false;
            }
            else result = true;

            return result;
        }
        public void Evaluate()
        {
            this.variableNamesToValues = Formula.CollectVariableValues(entryFormula);
            this.resultValue = EvaluateExecutionTree();
        }
        internal decimal EvaluateExecutionTree()
        {
            decimal result;

            Branch baseBranch = this.executionTree.BaseBranch;
            result = EvaluateBranch(baseBranch);

            return result;
        }
        internal decimal EvaluateBranch(Branch entryBranch)
        {
            decimal result;

            if (!entryBranch.IsPrimitive)
            {
                OperationType operation = entryBranch.Operation;
                Branch leftSubBranch;
                Branch rightSubBranch;
                decimal leftSubBranchValue;
                decimal rightSubBranchValue;

                Branch[] subBranches = entryBranch.GetSubBranches();

                switch (subBranches.Length)
                {
                    case 0:
                        throw new Exception();
                    case 1:
                        leftSubBranch = subBranches[0];
                        result = EvaluateBranch(leftSubBranch);
                        break;
                    case 2:
                        leftSubBranch = subBranches[0];
                        rightSubBranch = subBranches[1];
                        leftSubBranchValue = EvaluateBranch(leftSubBranch);
                        rightSubBranchValue = EvaluateBranch(rightSubBranch);
                        result = Number.CalculateOperation(operation,
                            leftSubBranchValue, rightSubBranchValue);
                        break;
                    default:
                        throw new Exception();
                }
            }
            else
            {
                Mononomial currentBranchPrimitiveMononomial =
                    Mononomial.ParsePrimitiveMononomial(entryBranch.SourceFormula);
                result = EvaluateMononomial(currentBranchPrimitiveMononomial);
            }
            return result;
        }
        internal decimal EvaluateMononomial(Mononomial mononomial)
        {
            decimal result=1m;

            decimal mononomialCoefficient = mononomial.Coefficient;
            result *= mononomialCoefficient;

            char[] variableNames = mononomial.GetVariableNamesArray();
            if (variableNames != null)
            {
                foreach (char variableName in variableNames)
                {
                    if (!variableNamesToValues.ContainsKey(variableName))
                    {
                        throw new ArgumentException();
                    }

                    char currentVariable = variableName;
                    decimal currentVariableValue = variableNamesToValues[currentVariable];
                    decimal currentVariablePower = mononomial.GetPower(currentVariable);

                    decimal exponentedVariable = CalculateDecimalPower(currentVariableValue, currentVariablePower);
                    result *= exponentedVariable;
                }
            }

            return result;
        }

        static decimal CalculateDecimalPower(decimal baseValue, decimal exponent)
        {
            decimal result;
            double tempDouble;

            double baseValueDouble = (double)baseValue;
            double exponentDouble = (double)exponent;

            tempDouble = Math.Pow(baseValueDouble, exponentDouble);
            result = (decimal)tempDouble;

            return result;
        }
    }
    public class ExecutionTree
    {
        decimal value;
        Branch baseBranch;
        Polynomial evaluation;
        bool isEvaluated;
        bool hasNumeralValue;

        decimal resultValue;

        SortedDictionary<char, double> variableValuePairs = new SortedDictionary<char, double>();

        public Branch BaseBranch { get => baseBranch; set => baseBranch = value; }
        public decimal Value { get => value; set => this.value = value; }

        public ExecutionTree(string entryFormula)
        {
            if(entryFormula==null)
            {
                throw new ArgumentException();
            }

            Branch newMember = new Branch(entryFormula);
            BaseBranch = newMember;
            this.isEvaluated = false;
            this.hasNumeralValue = false;
            evaluation = null;
            this.BreakDown();
        }
        public void BreakDown()
        {
            if (BaseBranch == null) throw new Exception();
            if (this.isEvaluated)
            {
                throw new Exception();
            }

            Queue<Branch> processingQueue = new Queue<Branch>();
            processingQueue.Enqueue(BaseBranch);
            while(processingQueue.Count>0)
            {
                Branch currentBranch = processingQueue.Dequeue();
                if (currentBranch.TryFork())
                {
                    Branch[] subBranches = currentBranch.GetSubBranches();
                    foreach (Branch branch in subBranches)
                    {
                        if (branch != null)
                        {
                            processingQueue.Enqueue(branch);
                        }
                    }
                }
            }
        }
    }
    public class Branch
    {
        string formula;
        bool isProcessed;
        OperationType operation;
        private bool isPrimitive;

        Mononomial mononomialValue;
        Branch subBranch1;
        Branch subBranch2;

        public OperationType Operation { get => operation; set => operation = value; }
        internal string SourceFormula { get => formula; set => formula = value; }
        public bool IsProcessed { get => isProcessed; set => isProcessed = value; }
        public bool IsPrimitive { get => isPrimitive; set => isPrimitive = value; }

        public Branch(string entryFormula)
        {
            this.IsProcessed = false;
            this.IsPrimitive = false;
            if (!Formula.IsValid(SourceFormula))
            {
                throw new ArgumentException();
            }
            this.SourceFormula = entryFormula;
        }
        public Branch(Mononomial entryMononomial)
        {
            this.IsProcessed = true;
            this.IsPrimitive = true;
            this.mononomialValue = entryMononomial;
        }
        public Branch(OperationType operation, Branch member1, Branch member2)
        {
            this.Operation = operation;
            this.subBranch1 = member1;
            this.subBranch2 = member2;
            this.IsProcessed = true;
        }

        public bool TryFork()
        {
            OperationType? operationType = null;
            Tuple<Branch, Branch> childBranches = null;

            bool executionStatus = false;
            bool childBranchesFound = false;
            string thisFormula = this.GetFormula();
            if (this.IsProcessed)
            {
                throw new Exception();
            }
            if (!Formula.IsValid(this.GetFormula()))
            {
                throw new ArgumentException();
            }

            string[] meristems = null;
            bool meristemsFound = false;

            if (IsBraceBound(thisFormula))
            {
                StringBuilder formulaCopy = new StringBuilder(this.GetFormula());
                if (formulaCopy.Length > 2)
                {
                    formulaCopy.Remove(0, 1);
                    formulaCopy.Remove(formulaCopy.Length - 1, 1);
                    string openedBracesString = formulaCopy.ToString();

                    Branch openedBracesBranch = new Branch(openedBracesString);
                    operationType = OperationType.Equality;
                    childBranches = new Tuple<Branch, Branch>(openedBracesBranch, null);
                    childBranchesFound = true;
                }
                else throw new Exception();
            }
            else
            {
                OperationGroup[] operationGroups = new OperationGroup[3]
                {OperationGroup.SumOrDifference,
                        OperationGroup.ProductOrQuotient,
                            OperationGroup.PowerOrRoot};
                OperationGroup? splitBasisOperationGroup = null;
                foreach (OperationGroup operationGroup in operationGroups)
                {
                    if (TrySplitFormulaIntoSections(thisFormula, operationGroup, out meristems))
                    {
                        splitBasisOperationGroup = operationGroup;
                        meristemsFound = true;
                        break;
                    }
                }
                if (meristemsFound)
                {
                    childBranches = CreateSubbranchesFromFormulaSectionsArray(meristems,
                        splitBasisOperationGroup.Value, out operationType);
                    if (childBranches != null)
                    {
                        childBranchesFound = true;
                    }
                    else throw new Exception();
                }
                else
                {
                    childBranchesFound = false;
                }
            }

            if (childBranchesFound == true)
            {
                if (operationType == null)
                {
                    throw new Exception();
                }
                this.subBranch1 = childBranches.Item1;
                this.subBranch2 = childBranches.Item2;
                this.IsProcessed = true;
                this.IsPrimitive = false;
                this.operation = operationType.Value;
                executionStatus = true;
            }
            else
            {
                this.IsPrimitive = true;
                this.IsProcessed = true;
                executionStatus = false;
            }
            return executionStatus;
        }
        public bool TrySplitFormulaIntoSections(string formula, OperationGroup operationGroup, out string[] formulaSections)
        {
            bool executionStatus;
            List<StringBuilder> sectionsFoundStringBuilderArray = new List<StringBuilder>();
            char[] separatorChars = GetOperationGroupChars(operationGroup);
            int[] separatorPositions = FindSeparatorPositionsInFormula(formula, separatorChars);
            string thisFormula = this.SourceFormula;
            
            
            List<StringBuilder> sectionList = new List<StringBuilder>();

            if (separatorPositions.Length > 0)
            {
                StringBuilder currentSection = new StringBuilder();
                for(int i=0; i < thisFormula.Length; i++)
                {
                    char currentChar = thisFormula[i];
                    if (separatorPositions.Contains(i))
                    {
                        sectionsFoundStringBuilderArray.Add(currentSection);
                        sectionsFoundStringBuilderArray.Add(new StringBuilder(Convert.ToString(currentChar)));
                        currentSection = new StringBuilder();
                    }
                    else currentSection.Append(currentChar);
                    if (i == thisFormula.Length - 1)
                    {
                        sectionsFoundStringBuilderArray.Add(currentSection);
                    }
                }
            }
            else
            {
                formulaSections = null;
                executionStatus = false;
            }

            if (sectionsFoundStringBuilderArray.Count > 0)
            {
                formulaSections = new string[sectionsFoundStringBuilderArray.Count];
                for (int i = 0; i < sectionsFoundStringBuilderArray.Count; i++)
                {
                    formulaSections[i] = Convert.ToString(sectionsFoundStringBuilderArray[i]);
                }
                executionStatus = true;
            }
            else
            {
                formulaSections = null;
                executionStatus = false;
            }

            return executionStatus;
        }
        public int[] FindSeparatorPositionsInFormula(string formula, char[] separatorChars)
        {
            List<int> separatorPositions = new List<int>();
            int[] resultArray;

            int openBraceNumber = 0;
            bool pointerIsBound = false;
            for (int i = 0; i < formula.Length; i++)
            {
                char currentChar = formula[i];

                if (currentChar == (char)'(')
                {
                    openBraceNumber++;
                    continue;
                }
                if (currentChar == (char)')')
                {
                    openBraceNumber--;
                    continue;
                }
                if (openBraceNumber > 0) pointerIsBound = true;
                else if (openBraceNumber < 0) throw new Exception();
                else pointerIsBound = false;

                if (pointerIsBound) continue;
                else
                {
                    if (separatorChars.Contains(currentChar) && i != 0)
                    {
                        separatorPositions.Add(i);
                    }
                }
            }
            resultArray = separatorPositions.ToArray();
            return resultArray;
        }
        static bool IsBraceBound(string formula)
        {
            int openBraceCounter = 0;
            for (int i = 0; i < formula.Length; i++)
            {
                if (openBraceCounter < 0) throw new ArgumentException();

                if (formula[i] == (char)'(')
                {
                    openBraceCounter++;
                    continue;
                }
                else if (formula[i] == (char)')')
                {
                    openBraceCounter--;
                    continue;
                }
                else
                {
                    if (openBraceCounter == 0)
                    {
                        return false;
                    }
                }
            }
            if (formula[0] == (char)'(' &&
                    formula[formula.Length - 1] == (char)')')
            {
                return true;
            }
            else return false;
        }

        public Branch[] GetSubBranches()
        {
            Branch[] subBranchesArray;
            List<Branch> subBranchesList = new List<Branch>();
            if (this.IsProcessed && !this.IsPrimitive)
            {

                if (subBranch1 != null) subBranchesList.Add(subBranch1);
                if (subBranch2 != null) subBranchesList.Add(subBranch2);
            }
            subBranchesArray = subBranchesList.ToArray();
            return subBranchesArray;
        }
        public Tuple<Branch, Branch> CreateSubbranchesFromFormulaSectionsArray(string[] formulaSections,
            OperationGroup operationGroup, out OperationType? operationType)
        {
            Tuple<Branch, Branch> resultTuple;
            Branch leftBranch;
            Branch rightBranch;

            int sectionsCount = formulaSections.Length;
            if (sectionsCount % 2 != 1)
            {
                throw new ArgumentException();
            }
            if (sectionsCount == 1)
            {
                string newBranchFormula = formulaSections[0];
                leftBranch = new Branch(newBranchFormula);
                rightBranch = null;
                operationType = null;
            }
            else
            {
                StringBuilder leftChildFormulaSB = new StringBuilder();
                for (int i = 0; i < sectionsCount-2; i++)
                {
                    leftChildFormulaSB.Append(formulaSections[i]);
                }
                leftBranch = new Branch(leftChildFormulaSB.ToString()) ;
                rightBranch = new Branch(formulaSections[sectionsCount - 1]);
                OperationType currentOperationType = GetOperationType(formulaSections[sectionsCount - 2]);
                operationType = currentOperationType;
            }
            resultTuple = new Tuple<Branch, Branch>(leftBranch, rightBranch);
            return resultTuple;
        }

        public char[] GetOperationGroupChars(OperationGroup operationGroup)
        {
            char[] separators;
            switch (operationGroup)
            {
                case OperationGroup.SumOrDifference:
                    separators = new char[] { (char)'+', (char)'-' };
                    break;
                case OperationGroup.ProductOrQuotient:
                    separators = new char[] { (char)'*', (char)'/' };
                    break;
                case OperationGroup.PowerOrRoot:
                    separators = new char[] { ((char)'^') };
                    break;
                default:
                    throw new Exception();
            }
            return separators;
        }
        public bool OperationBelongsToGroup(OperationType thisOperationType, OperationGroup operationGroup)
        {
            bool result;
            switch (operationGroup)
            {
                case OperationGroup.SumOrDifference:
                    switch (thisOperationType)
                    {
                        case OperationType.Sum:
                            result = true;
                            break;
                        case OperationType.Difference:
                            result = true;
                            break;
                        default:
                            result = false;
                            break;
                    }
                    break;
                case OperationGroup.ProductOrQuotient:
                    switch (thisOperationType)
                    {
                        case OperationType.Product:
                            result = true;
                            break;
                        case OperationType.Quotient:
                            result = true;
                            break;
                        default:
                            result = false;
                            break;
                    }
                    break;
                case OperationGroup.PowerOrRoot:
                    switch (thisOperationType)
                    {
                        case OperationType.Power:
                            result = true;
                            break;
                        default:
                            result = false;
                            break;
                    }
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
        public OperationType GetOperationType(char character)
        {
            OperationType resultOperationType;
            switch (character)
            {
                case '+':
                    resultOperationType = OperationType.Sum;
                    break;
                case '-':
                    resultOperationType = OperationType.Difference;
                    break;
                case '*':
                    resultOperationType = OperationType.Product;
                    break;
                case '/':
                    resultOperationType = OperationType.Quotient;
                    break;
                case '^':
                    resultOperationType = OperationType.Power;
                    break;
                default:
                    throw new ArgumentException();

            }
            return resultOperationType;
        }
        public OperationType GetOperationType(string entryString)
        {
            return GetOperationType(entryString[0]);
        }

        public string GetFormula()
        {
            return this.SourceFormula;
        }
    }
    public static class Formula
    {
        public static bool IsValid(string entryString)
        {
            return true;
        }
        public static bool IsLetter(char entryChar)
        {
            bool result;
            Regex letter = new Regex("[a-zA-Z]");

            if (letter.IsMatch((Convert.ToString(entryChar))))
            {
                result = true;
            }
            else result = false;
            return result;
        }
        public static bool IsDigit(char entryChar)
        {
            bool result;

            Regex digit = new Regex("[0-9]");
            if (digit.IsMatch(Convert.ToString(entryChar)))
            {
                result = true;
            }
            else result = false;
            return result;
        }

        public static Dictionary<char, decimal> CollectVariableValues(string entryFormula)
        {
            Dictionary<char, decimal> variablesToValues = new Dictionary<char, decimal>();
            HashSet<char> variableNames = new HashSet<char>();
            for(int i=0; i<entryFormula.Length; i++)
            {
                char currentChar = entryFormula[i];
                if (IsLetter(currentChar) && !variableNames.Contains(currentChar))
                {
                    variableNames.Add(currentChar);
                }
            }
            foreach(char variableName in variableNames)
            {
                bool variableEntered = false;
                while (variableEntered == false)
                {
                    decimal currentValue;
                    Console.WriteLine($"Enter the value of '{variableName}' variable:");

                    string entryString = Console.ReadLine();
                    if(Decimal.TryParse(entryString, out currentValue))
                    {
                        variableEntered = true;
                        variablesToValues[variableName] = currentValue;
                    }
                    else
                    {
                        Console.WriteLine("You did not enter a correct value.");
                    }
                }
            }
            return variablesToValues;
        }
    }

    public enum OperationType
    {
        Sum, Difference, Product, Quotient, Power, Equality
    }
    public enum OperationGroup
    {
        SumOrDifference, ProductOrQuotient, PowerOrRoot
    }

    public class Mononomial
    {
        decimal coefficient;
        Dictionary<char, decimal> variablesToPowers;

        public Mononomial(decimal coefficient, params Tuple<char, decimal>[] variablesAndPowersEntry)
        {
            this.coefficient = coefficient;
            HashSet<char> enteredCharsSet = new HashSet<char>();
            foreach(Tuple<char,decimal> tuple in variablesAndPowersEntry)
            {
                char currentChar = tuple.Item1;
                if (enteredCharsSet.Contains(currentChar))
                {
                    throw new ArgumentException();
                }
                enteredCharsSet.Add(currentChar);
            }

            foreach(Tuple<char, decimal> tuple in variablesAndPowersEntry)
            {
                char currentChar = tuple.Item1;
                decimal currentPower = tuple.Item2;
                this.variablesToPowers[currentChar] = currentPower;
            }
        }
        public Mononomial(decimal coefficient, char? variableName=null, decimal power=0)
        {
            this.Coefficient = coefficient;
            this.variablesToPowers = new Dictionary<char, decimal>();
            if (variableName != null)
            {
                this.variablesToPowers[variableName.Value] = power;
            }
        }
        public Mononomial(string entry)
        {
            
        }
        

        public decimal Coefficient { get => coefficient; set => coefficient = value; }
        public int VariablesNumber
        {
            get
            {
                return variablesToPowers.Count();
            }
        }

        public static Mononomial ParsePrimitiveMononomial(string entry)
        {
            Mononomial resultMononomial;

            int entryLength = entry.Length;
            if (!EntryIsValid(entry))
            {
                throw new ArgumentException();
            }
            decimal coefficient = 1m;
            char? variableName = null;

            int firstSignificantCharacterPosition;
            if (entry[0] == '-')
            {
                coefficient *= -1;
                firstSignificantCharacterPosition = 1;
            }
            else firstSignificantCharacterPosition = 0;


            char firstSignificantCharacter = entry[firstSignificantCharacterPosition];

            if (Formula.IsDigit(firstSignificantCharacter))
            {
                string digits = entry.Substring
                    (firstSignificantCharacterPosition,
                        entryLength - firstSignificantCharacterPosition);
                decimal coefficientMultiplier = decimal.Parse(digits);
                coefficient *= coefficientMultiplier;
            }
            else if (Formula.IsLetter(firstSignificantCharacter))
            {
                variableName = entry[firstSignificantCharacterPosition];
            }
            else throw new ArgumentException();

            resultMononomial = new Mononomial(coefficient, variableName, 1);
            return resultMononomial;

            bool EntryIsValid(string entry)
            {
                bool result;

                int firstSignificantCharacterPosition;
                int entryLength = entry.Length;

                try
                {
                    #region Validity Check
                    if (entryLength == 0)
                    {
                        throw new ArgumentException();
                    }
                    if (entry[0] == '-')
                    {
                        if (entryLength <= 1) throw new ArgumentException();
                        firstSignificantCharacterPosition = 1;
                    }
                    else firstSignificantCharacterPosition = 0;
                    char firstSignificantCharacter = entry[firstSignificantCharacterPosition];

                    if (Formula.IsLetter(firstSignificantCharacter))
                    {
                        if (entryLength > firstSignificantCharacterPosition + 1)
                        {
                            throw new ArgumentException();
                        }
                    }
                    else if (Formula.IsDigit(firstSignificantCharacter))
                    {
                        int periodCount = 0;
                        for (int i = firstSignificantCharacterPosition + 1; i < entryLength; i++)
                        {
                            if (periodCount > 1) throw new ArgumentException();
                            char currentChar = entry[i];

                            if (Formula.IsDigit(currentChar))
                            {
                                continue;
                            }
                            else if (currentChar == '.')
                            {
                                periodCount++;
                                if (i == entryLength - 1)
                                {
                                    throw new ArgumentException();
                                }
                            }
                            else throw new ArgumentException();
                        }
                    }
                    else throw new ArgumentException();

                    for (int i = firstSignificantCharacterPosition; i < entry.Length; i++)
                    {
                        char currentChar = entry[i];
                        if (currentChar == '-') throw new ArgumentException();
                    }
                    #endregion
                }

                catch (ArgumentException)
                {
                    result = false;
                    return result;
                }

                result = true;
                return result;
            }
        }
        public static Mononomial GetProduct(Mononomial mononomial1, Mononomial mononomial2)
        {
            Mononomial result;
            decimal resultCoefficient = mononomial1.Coefficient * mononomial2.Coefficient;
            Tuple<char, decimal>[] variablesToPowersResultArray;
            List<Tuple<char, decimal>> tempVariablesToPowersList = new List<Tuple<char, decimal>>();

            HashSet<char> combinedVariableSet = new HashSet<char>();
            combinedVariableSet.UnionWith(mononomial1.GetVariableNamesSet());
            combinedVariableSet.UnionWith(mononomial2.GetVariableNamesSet());

            foreach (char currentKey in combinedVariableSet)
            {
                decimal currentPower = 0;
                if (mononomial1.ContainsVariable(currentKey))
                {
                    decimal tempPowerMultiplicator = mononomial1.GetPower(currentKey);
                    currentPower += tempPowerMultiplicator;
                }
                if (mononomial2.ContainsVariable(currentKey))
                {
                    decimal tempPowerMultiplicator = mononomial2.GetPower(currentKey);
                    currentPower += tempPowerMultiplicator;
                }
                Tuple<char, decimal> newTuple = new Tuple<char, decimal>(currentKey, currentPower);
                tempVariablesToPowersList.Add(newTuple);
            }
            variablesToPowersResultArray = tempVariablesToPowersList.ToArray();

            result = new Mononomial(resultCoefficient, variablesToPowersResultArray);
            return result;
        }

        public char[] GetVariableNamesArray()
        {
            if (this.variablesToPowers == null)
            {
                return null;
            }

            List<char> variableNamesList = new List<char>();
            char[] resultArray;

            IEnumerator<KeyValuePair<char, decimal>> enumerator = this.variablesToPowers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                char currentChar = enumerator.Current.Key;
                variableNamesList.Add(currentChar);
            }
            resultArray = variableNamesList.ToArray();
            return resultArray;
        }
        public HashSet<char> GetVariableNamesSet()
        {
            HashSet<char> result = new HashSet<char>(this.GetVariableNamesArray());
            return result;
        }
        public bool ContainsVariable(char queryVariable)
        {
            if (this.variablesToPowers.ContainsKey(queryVariable)) return true;
            else return false;
        }
        public decimal GetPower(char queryVariable)
        {
            if (!this.ContainsVariable(queryVariable)) throw new ArgumentException();

            decimal result = variablesToPowers[queryVariable];
            return result;
        }
        }
    public class Polynomial
    {
        public Polynomial(Mononomial mononomial)
        {

        }
        public static Polynomial CalculateOperation(OperationType operationType, Tuple<Polynomial,
            Polynomial> memberTuple)
        {
            return null;
        }

    }
    public class Variable
    {

    }
    public class Number
    {
        public static decimal CalculateOperation(OperationType operation, decimal number1, decimal number2)
        {
            decimal result;

            switch (operation)
            {
                case OperationType.Sum:
                    result = number1 + number2;
                    break;
                case OperationType.Difference:
                    result = number1 - number2;
                    break;
                case OperationType.Product:
                    result = number1 * number2;
                    break;
                case OperationType.Quotient:
                    result = number1 / number2;
                    break;
                case OperationType.Power:
                    result = (decimal)Math.Pow((double)number1, (double)number2);
                    break;
                default:
                    throw new Exception();
                    break;
            }
            return result;
        }
    }

}
