using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoringandUpdatingTeacherRecords
{
    public class TeacherDataHandler
    {
        private string dataFilePath;

        public TeacherDataHandler(string filePath)
        {
            dataFilePath = filePath;
        }

        public List<Teacher> ReadTeacherData()
        {
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                using (StreamReader reader = new StreamReader(dataFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] teacherData = line.Split('|');
                        if (teacherData.Length == 4)
                        {
                            int id = int.Parse(teacherData[0]);
                            string name = teacherData[1];
                            string className = teacherData[2];
                            string section = teacherData[3];

                            Teacher teacher = new Teacher(id, name, className, section);
                            teachers.Add(teacher);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading teacher data: " + ex.Message);
            }

            return teachers;
        }

        public void SaveTeacherData(List<Teacher> teachers)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(dataFilePath))
                {
                    foreach (Teacher teacher in teachers)
                    {
                        writer.WriteLine($"{teacher.ID}|{teacher.Name}|{teacher.Class}|{teacher.Section}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving teacher data: " + ex.Message);
            }
        }
    }
}

