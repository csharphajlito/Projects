using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    static class Changer
    {
        private static int[] blockIndexes = generateBlockIndex();
        public static int[] actualPositionToIndexes(int actualPos) //row,column,block
        {
            int[] indexes = new int[3];

            indexes[0] = actualPos / 9;
            indexes[1] = actualPos % 9;
            indexes[2] = blockIndexes[actualPos];

            return indexes;
        }
        private static int[] generateBlockIndex()
        {
            int[] blockIndex = new int[81];
            int blockIndexNumber = 0;

            for (int i = 0; i < 3; ++i)
                for (int k = 0; k < 3; ++k)
                    for (int l = 0; l < 3; ++l)
                    {
                        if (i == 0)
                        {
                            for (int p = 0; p < 3; ++p)
                            {
                                blockIndex[blockIndexNumber] = l;
                                ++blockIndexNumber;
                            }
                        }
                        if (i == 1)
                        {
                            for (int p = 0; p < 3; ++p)
                            {
                                blockIndex[blockIndexNumber] = l + 3;
                                ++blockIndexNumber;
                            }
                        }
                        if (i == 2)
                        {
                            for (int p = 0; p < 3; ++p)
                            {
                                blockIndex[blockIndexNumber] = l + 6;
                                ++blockIndexNumber;
                            }
                        }
                    }

            return blockIndex;
        }
    }
}
