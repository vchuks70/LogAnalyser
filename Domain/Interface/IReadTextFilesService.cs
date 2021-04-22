using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IReadTextFilesService
    {
        List<Duplicate> ReadFile12(string filePth);
        int GetNumberOfLogs10(string filePath, DateTime start, DateTime end);
        bool DeleteOfLogs11(string filePath, DateTime start, DateTime end);
        int CountDuplicate13(string filePth);
        string[] SearchLogsPerDirectory14(string filePth);
        List<FileProperty> SearchLogsPerSize15(string filePth, int startSize, int endSize);
        bool ArchiveLogsFromPeriod16(string filePath, DateTime start, DateTime end);
        bool DeleterchiveLogsFromPeriod17(string filePath, DateTime start, DateTime end);

    }
}
