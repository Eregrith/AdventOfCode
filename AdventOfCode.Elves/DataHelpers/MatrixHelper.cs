using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode.Elves.DataHelpers
{
    [Flags]
    public enum MatrixWrap
    {
        None = 0,
        WrapHorizontally = 1,
        WrapVertically = 2
    }

    public class MatrixHelper<TData>
    {
        public static string GetDisplayRectangle(TData[][] matrix, Rectangle rect) => GetDisplayRectangle(matrix, rect, MatrixWrap.None);
        public static string GetDisplayRectangle(TData[][] matrix, Rectangle rect, MatrixWrap wrap)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = rect.Y; y < rect.Y + rect.Height; y++)
            {
                for (int x = rect.X; x < rect.X + rect.Width; x++)
                {
                    if (x < 0 && !wrap.HasFlag(MatrixWrap.WrapHorizontally)
                        || y < 0 && !wrap.HasFlag(MatrixWrap.WrapVertically))
                        sb.Append(' ');
                    else
                        AppendElementAtXY(matrix, wrap, sb, y, x);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static void AppendElementAtXY(TData[][] matrix, MatrixWrap wrap, StringBuilder sb, int y, int x)
        {
            TData element;
            int ytarget = GetYTarget(matrix, wrap, y);
            int xtarget = GetXTarget(matrix, wrap, x, ytarget);
            element = matrix[ytarget][xtarget];
            sb.Append(element.ToString());
        }

        private static int GetXTarget(TData[][] matrix, MatrixWrap wrap, int x, int ytarget)
        {
            int xtarget;
            if (wrap.HasFlag(MatrixWrap.WrapHorizontally))
                xtarget = (x + matrix[ytarget].Length) % matrix[ytarget].Length;
            else
                xtarget = Math.Min(x, matrix[ytarget].Length);
            return xtarget;
        }

        private static int GetYTarget(TData[][] matrix, MatrixWrap wrap, int y)
        {
            int ytarget;
            if (wrap.HasFlag(MatrixWrap.WrapVertically))
                ytarget = (y + matrix.Length) % matrix.Length;
            else
                ytarget = Math.Min(y, matrix.Length);
            return ytarget;
        }
    }
}
