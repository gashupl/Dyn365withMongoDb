using System;
using System.Collections.Generic;
using System.Linq;
using MonkeyShock.DocumentDb.DataAccess;
using MonkeyShock.Dyn365.Entities;
using ISubjectsRepository = MonkeyShock.Dyn365.DataAccess.Repositories.ISubjectsRepository;

namespace MonkeyShock.Dyn365.DataImport.DataImport
{
    public class SubjectsDataImport : DataImportBase, IImportBase
    {
        private readonly ISubjectsRepository subjectDyn365Repository;

        public SubjectsDataImport(IDocDbUnitOfWork unitOfWork, ISubjectsRepository subjectDyn365Repository) : base(unitOfWork)
        {
            this.subjectDyn365Repository = subjectDyn365Repository;
        }

        public void Run()
        {
            List<Subject> subjects = this.unitOfWork.SubjectsRepository.GetAll();
            ImportSubjects(subjects, null);
        }

        public void ImportSubjects(List<Subject> subjects, Guid? parentSubject)
        {
            var subjectsToBeImported = subjects.Where<Subject>(s => s.ParentSubject?.Id == parentSubject).ToList<Subject>();
            subjectsToBeImported.ForEach(s =>
            {
                s.EntityState = null; 
                this.subjectDyn365Repository.Create(s);
                ImportSubjects(subjects, s.SubjectId); 

            });
        }
    }


}
