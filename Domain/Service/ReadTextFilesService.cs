using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Interface;

namespace Domain
{

    public class ReadTextFilesService: IReadTextFilesService
    {
        public List<Duplicate> ReadFile12(string filePth)
        {
            var exist = Directory.Exists(filePth);
            if (exist == false)
            {
                return null;
            }
            var duplicateVal = new List<Duplicate>();

            DirectoryInfo dir = new DirectoryInfo(filePth);
            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var result = new List<string[]>();

                var strings = File.ReadAllLines(file.FullName);
                var toHashSet = new HashSet<string>(strings);
                foreach (var item in toHashSet)
                {


                    var spilt = item.Split(" ");
                    if (spilt.Length > 1)
                    {
                        var str = spilt[0];
                        // ------>
                        var charsToRemove = new string[] { "-", ">", "." };
                        var dotCount = 0;

                        foreach (var c in str)
                        {

                            if (c == '.')
                            {
                               
                                dotCount++;
                            }
                          
                        }

                    



                        if (dotCount == 2)
                        {

                            result.Add(spilt);
                            var count = result.Count();
                            duplicateVal.Add(new Duplicate
                            {
                                Count = count,
                                FileName = file.FullName,
                                Name = file.Name
                            });
                        }



                    }
                }
            }


            return duplicateVal;


        }

        public  int GetNumberOfLogs10(string filePath, DateTime start, DateTime end)
        {
            DirectoryInfo dir = new DirectoryInfo(filePath);
            var count = dir.GetFiles().Where(x => x.CreationTime.Date >= start && x.CreationTime.Date <= end).Count();
            return count;
        }

        public  bool DeleteOfLogs11(string filePath, DateTime start, DateTime end)
        {
          var exist =  Directory.Exists(filePath);
            if (exist == false)
            {
                return false;
            }
            DirectoryInfo dir = new DirectoryInfo(filePath);
            var datas = dir.GetFiles().Where(x => x.CreationTime.Date >= start && x.CreationTime.Date <= end);
            foreach (var file in datas)
            {
                File.Delete(file.FullName);
            }
            return true;
        }

        public  int CountDuplicate13(string filePth)
        {
            var exist = Directory.Exists(filePth);
            if (exist == false)
            {
                return 0;
            }
            var count = 0;

            var strings = File.ReadAllLines(filePth);
            var originalCount = strings.Length;
            var toHashSet = new HashSet<string>(strings);
            var hashedCount = toHashSet.Count();
            count = originalCount - hashedCount;
            return count;
        }
        public  string[] SearchLogsPerDirectory14(string filePth)
        {
            var check = File.Exists(filePth);
            if (!check)
            {
                return null;
            }


            var strings = File.ReadAllLines(filePth);
            return strings;
        }

        public  List<FileProperty> SearchLogsPerSize15(string filePth, int startSize, int endSize)
        {
            var check = Directory.Exists(filePth);
            if (!check)
            {
                return null;
            }



            DirectoryInfo dir = new DirectoryInfo(filePth);
            var files = dir.GetFiles();
            var result = new List<FileProperty>();
            foreach (var item in files)
            {
                var size = item.Length;

                if (size >= startSize && size <= endSize)
                {
                    var strings = File.ReadAllLines(item.FullName);

                    result.Add(new FileProperty
                    {
                        Name = item.Name,
                        FileName = item.FullName,
                        Count = strings.Length,
                        Size = item.Length
                    });
                }


            }



            return result;
        }

        public  bool ArchiveLogsFromPeriod16(string filePath, DateTime start, DateTime end)
        {
            var check = Directory.Exists(filePath);
            if (!check)
            {
                return false;
            }
            DirectoryInfo dir = new DirectoryInfo(filePath);
            var dateFormat = (start.ToString("MM/dd/yyyy") + "-" + end.ToString("MM/dd/yyyy")).Replace('/', '_');
            string outputFile = $"{filePath}\\{dateFormat}";
            string filedir = $"{filePath}\\new";
            var files = dir.GetFiles().Where(x => x.CreationTime.Date >= start && x.CreationTime.Date <= end);

            var newDir = System.IO.Directory.CreateDirectory(filedir);
            foreach (var item in files)
            {
                System.IO.File.Move(item.FullName, newDir.FullName + "\\" + item.Name);
            }


            var datas = newDir.GetFiles();

            using (var archive = ZipFile.Open(outputFile + ".zip", ZipArchiveMode.Create))
            {
                foreach (var file in datas)
                {

                    archive.CreateEntryFromFile(file.FullName, Path.GetFileName(file.FullName));

                }

            }

            Directory.Delete(newDir.FullName, true);


            return true;
        }

        public  bool DeleterchiveLogsFromPeriod17(string filePath, DateTime start, DateTime end)
        {
            var check = Directory.Exists(filePath);
            if (!check)
            {
                return false;
            }

            DirectoryInfo dir = new DirectoryInfo(filePath);
            var subDirs = dir.GetDirectories().Where(x => x.CreationTime.Date >= start && x.CreationTime.Date <= end);

            foreach (var subDir in subDirs)
            {

                Directory.Delete(subDir.FullName, true);
            }

            return true;
        }
    }
}
