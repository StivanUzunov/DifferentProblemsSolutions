namespace DevCampProblemSolution
{
    public interface ILayer
    {
        int[,] FillInTheFirstLayer(int m,int n);
        int[,] SecondLayerMaker(int[,] matrix);
        void PrintLayer(int[,] matrix);
    }
}
