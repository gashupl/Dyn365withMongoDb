using System;
using System.Collections.Generic;
using MonkeyShock.DocumentDb.DataAccess;
using MonkeyShock.Dyn365.Entities;

namespace MonkeyShock.Dyn365.DataExport.DataExports
{
    public class SubjectsDataExport : DataExportBase
    {
        #region Constructors
        public SubjectsDataExport(DocumentDbUnitOfWork unitOfWork) : base(unitOfWork)
        {         
        } 
        #endregion

        public void Run(IEnumerable<Subject> subjectsList)
        {

            unitOfWork.SubjectsRepository.DeleteAll(); 

            Console.WriteLine("Inserting Dyn365 data to the local document db...");
            unitOfWork.SubjectsRepository.InsertMany(subjectsList);
            Console.WriteLine("Dyn365 data innsert ended");

            //var subjects = unitOfWork.SubjectsRepository.GetAll(); 
            //subjects.ForEach(s =>
            //{
            //    Console.WriteLine($"{s.Id} : {s.Title} : {s.ParentSubject?.Id}");

            //});
        }
    }
}
