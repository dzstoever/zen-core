namespace Zen.WinXL
{
    public interface IKingOfExamples
    {
        IRunnable LogDemo { get; set; }
        IRunnable DbDemo { get; set; }        
        IRunnable WcfDemo { get; set; }
        IRunnable WebDemo { get; set; }
        IRunnable WpfDemo { get; set; }
    }
}
