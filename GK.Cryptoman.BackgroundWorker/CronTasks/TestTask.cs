using Coravel.Invocable;

namespace GK.Cryptoman.BackgroundWorker.CronTasks
{
    internal class TestTask : IInvocable
    {
        public async Task Invoke()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }
}
