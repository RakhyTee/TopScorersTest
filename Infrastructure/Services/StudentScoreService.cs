using Domain;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentScoreService : IStudentScoreService
    {
        private readonly string _filePath;

        public StudentScoreService(string filePath)
        {
            _filePath = filePath;
        }

        private void ValidateFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentException("Invalid file", nameof(filePath));
            }

            if (Path.GetExtension(filePath)?.ToUpper() != ".CSV")
            {
                throw new ArgumentException("Invalid filr,  selected file is not a valid CSV file.", nameof(filePath));
            }
        }
        public IEnumerable<StudentData> GetStudentScores()
        {
            var readData = File.ReadLines(_filePath).Skip(1);
            Console.WriteLine("Reading data from file..." + readData.ToString());
            foreach(var lineOfData in readData)
            {
                var data = lineOfData.Split(',');

                //check for invalid line
                if(data.Length != 3 || !int.TryParse(data[2], out var score))
                {
                    Console.Error.WriteLine($"Invalid line: {data}");
                    continue;
                }

                yield return new StudentData
                {
                    FirstName = data[0],
                    SecondName = data[1],
                    Score = int.Parse(data[2])
                };
            }
           
        }
    }
}
