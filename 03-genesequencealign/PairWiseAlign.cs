using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticsLab
{
    class PairWiseAlign
    {
        public readonly int MATCH_COST = -3;
        public readonly int SUB_COST = 1;
        public readonly int ADD_COST = 5;
        public readonly int REMOVE_COST = 5;
        public readonly int NUM_OF_COLUMNS = 2;

        private int[,] alignment;
        private int[,] smAlignment;
        private int[,] nalignment;
        public BackPointer[,] pointers;

        /// <summary>
        /// Align only 5000 characters in each sequence.
        /// </summary>
        private int MaxCharactersToAlign = 5000; 

        /// <summary>
        /// this is the function you implement.
        /// </summary>
        /// <param name="sequenceA">the first sequence</param>
        /// <param name="sequenceB">the second sequence, may have length not equal to the length of the first seq.</param>
        /// <param name="resultTableSoFar">the table of alignment results that has been generated so far using pair-wise alignment</param>
        /// <param name="rowInTable">this particular alignment problem will occupy a cell in this row the result table.</param>
        /// <param name="columnInTable">this particular alignment will occupy a cell in this column of the result table.</param>
        /// <returns>the alignment score for sequenceA and sequenceB.  The calling function places the result in entry rowInTable,columnInTable
        /// of the ResultTable</returns>
        public int Align(GeneSequence sequenceA, GeneSequence sequenceB, ResultTable resultTableSoFar, int rowInTable, int columnInTable)
        {
            if (columnInTable < rowInTable)
            {
                return (int)resultTableSoFar.GetCell(columnInTable, rowInTable);
            }

            // get the first 5000 characters to align
            String compA = sequenceA.Sequence.Substring(0, ((sequenceA.Sequence.Length < MaxCharactersToAlign) ? sequenceA.Sequence.Length : MaxCharactersToAlign));
            String compB = sequenceB.Sequence.Substring(0, ((sequenceB.Sequence.Length < MaxCharactersToAlign) ? sequenceB.Sequence.Length : MaxCharactersToAlign));

            if (compA.Equals(compB))
            {
                return MATCH_COST * compA.Length;
            }

            // a place holder computation.  You'll want to implement your code here. 
            return alignmentScore(compA, compB);             
        }

        private int alignmentScore(String a, String b)
        {
            initializeSmArray(a, b);

            for (int i = 1; i <= a.Length; i++)
            {
                calculateSmAlignment(i, a, b);
                resetSmArray();
            }

            return smAlignment[a.Length, 1];
        }

        private void initializeSmArray(String a, String b)
        {
            smAlignment = new int[a.Length + 1, 2];
            smAlignment[0, 0] = 0;

            for (int i = 1; i <= a.Length; i++)
            {
                smAlignment[i, 0] = smAlignment[i - 1, 0] + REMOVE_COST;
            }

            for (int j = 1; j < NUM_OF_COLUMNS; j++)
            {
                smAlignment[0, j] = smAlignment[0, j - 1] + ADD_COST;
            }
        }

        private void resetSmArray()
        {
            for (int i = 0; i < smAlignment.GetLength(0); i++)
            {
                smAlignment[i, 0] = smAlignment[i, 1];
            }
        }

        private void calculateSmAlignment(int row, String a, String b)
        {
            int horizontal = smAlignment[row - 1, 1] + ADD_COST;
            int veritical = smAlignment[row, 0] + REMOVE_COST;
            int diagonal = (a[row - 1] == b[0]) ? smAlignment[row - 1, 0] + MATCH_COST : smAlignment[row - 1, 0] + SUB_COST;

            smAlignment[row, 1] = Math.Min(horizontal, Math.Min(veritical, diagonal));
        } 


        // EXTRACTION METHODS //
        private void initializeExArray(String a, String b)
        {
            pointers = new BackPointer[a.Length + 1, b.Length + 1];
            pointers[0, 0] = null;

            for (int i = 1; i <= a.Length; i++)
            {
                pointers[i, 0] = new BackPointer(PointerType.UP, i - 1, 0);
            }

            for (int j = 1; j <= b.Length; j++)
            {
                pointers[0, j] = new BackPointer(PointerType.LEFT, 0, j - 1);
            }
        }

        private void initializeArray(String a, String b)
        {
            alignment = new int[a.Length + 1, b.Length + 1];

            alignment[0, 0] = 0;
            pointers[0, 0] = null;

            for (int i = 1; i <= a.Length; i++)
            {
                alignment[i, 0] = alignment[i - 1, 0] + REMOVE_COST;
            }

            for (int j = 1; j <= b.Length; j++)
            {
                alignment[0, j] = alignment[0, j - 1] + ADD_COST;
            }
        }

        public void Extract(GeneSequence sequenceA, GeneSequence sequenceB, out String a_out, out String b_out)
        {

            String a = sequenceA.Sequence.Substring(0, ((sequenceA.Sequence.Length < 100) ? sequenceA.Sequence.Length : 100));
            String b = sequenceB.Sequence.Substring(0, ((sequenceB.Sequence.Length < 100) ? sequenceB.Sequence.Length : 100));

            // initialize
            initializeArray(a, b);
            initializeExArray(a, b);

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    calcuateAlignment(i, j, a, b);
                    calcuateExtraction(i, j, a, b);
                }
            }

            a_out = "";
            b_out = "";

            // get final pointer
            BackPointer current = pointers[a.Length, b.Length];

            while (current != null)
            {
                switch (current.Type)
                {
                    case PointerType.UP:
                        b_out += "-";
                        a_out += a[current.Row];
                        break;
                    case PointerType.LEFT:
                        a_out += "-";
                        b_out += b[current.Column];
                        break;
                    case PointerType.DIAGONAL:
                        a_out += a[current.Row];
                        b_out += b[current.Column];
                        break;
                    default:
                        break;
                }
                current = pointers[current.Row, current.Column];
            }

            Reverse(ref a_out);
            Reverse(ref b_out);
        }

        private void Reverse(ref String a)
        {
            String temp = "";
            for (int i = a.Length-1; i >= 0; i--)
            {
                temp += a[i];
            }
            a = temp;
        }

        private void calcuateAlignment(int row, int column, String a, String b)
        {
            int horizontal = alignment[row - 1, column] + ADD_COST;
            int veritical = alignment[row, column - 1] + REMOVE_COST;
            int diagonal = (a[row - 1] == b[column - 1]) ? alignment[row - 1, column - 1] + MATCH_COST : alignment[row - 1, column - 1] + SUB_COST;

            alignment[row, column] = Math.Min(horizontal, Math.Min(veritical, diagonal));
        }

        private void calcuateExtraction(int row, int column, String a, String b)
        {
            int horizontal = alignment[row - 1, column] + ADD_COST;
            int veritical = alignment[row, column - 1] + REMOVE_COST;
            int diagonal = (a[row - 1] == b[column - 1]) ? alignment[row - 1, column - 1] + MATCH_COST : alignment[row - 1, column - 1] + SUB_COST;

            if (Math.Min(veritical, diagonal) == diagonal && Math.Min(horizontal, diagonal) == diagonal)
            {
                pointers[row, column] = new BackPointer(PointerType.DIAGONAL, row - 1, column - 1);
            }
            else if (Math.Min(veritical, horizontal) == veritical)
            {
                pointers[row, column] = new BackPointer(PointerType.LEFT, row, column - 1);
            }
            else
            {
                pointers[row, column] = new BackPointer(PointerType.UP, row - 1, column);
            }

            alignment[row, column] = Math.Min(horizontal, Math.Min(veritical, diagonal));
        }
    }

    class BackPointer
    {
        private PointerType pointerType;
        private int row;
        private int column;

        public BackPointer(PointerType pointerType, int _row, int _column)
        {
            // TODO: Complete member initialization
            this.pointerType = pointerType;
            this.row = _row;
            this.column = _column;
        }

        public PointerType Type
        {
            get { return pointerType; }
            set { pointerType = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }
    }

    enum PointerType { UP, LEFT, DIAGONAL };
}
