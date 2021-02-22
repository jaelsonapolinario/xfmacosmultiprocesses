using System;
using System.Threading.Tasks;

namespace XFMacOSMultiProcesses
{
    public interface ISecondaryService
    {
        Task StartNewProcessAsync();
    }
}
