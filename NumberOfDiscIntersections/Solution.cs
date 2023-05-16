namespace NumberOfDiscIntersections;

class Solution
{
    public static Int32 SolutionInit(Int32[] A)
    {
        Int32 N = A.Length;
        Int64[] startPoints = new Int64[N];
        Int64[] endPoints = new Int64[N];

        for (Int32 i = 0; i < N; i++)
        {
            startPoints[i] = (Int64)i - A[i];
            endPoints[i] = (Int64)i + A[i];
        }

        Array.Sort(startPoints);
        Array.Sort(endPoints);

        Int32 startPointIndex = 0;
        Int32 endPointIndex = 0;
        Int32 activeDiscs = 0;
        Int64 intersections = 0;

        while (startPointIndex < N)
        {
            if (startPoints[startPointIndex] > endPoints[endPointIndex])
            {
                activeDiscs--;
                endPointIndex++;
                continue;
            }

            intersections += activeDiscs;
            activeDiscs++;
            startPointIndex++;

            if (intersections > 10000000)
            {
                return -1;
            }
        }

        return (Int32)intersections;
    }
}