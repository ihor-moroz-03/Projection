using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection
{
    class Projector
    {
        public byte[][,] Projections;

        public Projector(int[,,] model)
        {
            Projections = new byte[3][,];

            Projections[0] = new byte[model.GetLength(0), model.GetLength(1)];
            for (int i = 0; i < Projections[0].GetLength(0); ++i)
                for (int j = 0; j < Projections[0].GetLength(1); ++j)
                {
                    byte any = 0;
                    for (int k = 0; k < model.GetLength(2); ++k)
                    {
                        if (model[i, j, k] == 1)
                        {
                            any = 1;
                            break;
                        }
                    }
                    Projections[0][i, j] = any;
                }

            Projections[1] = new byte[model.GetLength(0), model.GetLength(2)];
            for (int i = 0; i < Projections[1].GetLength(0); ++i)
                for (int j = 0; j < Projections[1].GetLength(1); ++j)
                {
                    byte any = 0;
                    for (int k = 0; k < model.GetLength(1); ++k)
                    {
                        if (model[i, k, j] == 1)
                        {
                            any = 1;
                            break;
                        }
                    }
                    Projections[1][i, j] = any;
                }

            Projections[2] = new byte[model.GetLength(1), model.GetLength(2)];
            for (int i = 0; i < Projections[2].GetLength(0); ++i)
                for (int j = 0; j < Projections[2].GetLength(1); ++j)
                {
                    byte any = 0;
                    for (int k = 0; k < model.GetLength(0); ++k)
                    {
                        if (model[k, i, j] == 1)
                        {
                            any = 1;
                            break;
                        }
                    }
                    Projections[2][i, j] = any;
                }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < Projections[i].GetLength(0); ++j)
                {
                    for (int k = 0; k < Projections[i].GetLength(1); ++k)
                    {
                        result.Append($"{Projections[i][j, k]} ");
                    }
                    result.AppendLine();
                }

                result.Append("\n\n");
            }

            return result.ToString();
        }
    }
}
