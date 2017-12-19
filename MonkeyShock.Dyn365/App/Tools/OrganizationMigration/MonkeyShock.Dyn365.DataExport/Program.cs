using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MonkeyShock.DocumentDb.DataAccess;
using MonkeyShock.Dyn365.DataAccess;
using MonkeyShock.Dyn365.DataExport.DataExports;
using MonkeyShock.Dyn365.Entities;
using MonkeyShock.Dyn365.Utilities.Configuration;
using SubjectsRepository = MonkeyShock.Dyn365.DataAccess.Repositories.SubjectsRepository;

namespace MonkeyShock.Dyn365.DataExport
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfigurationManager configManager = new AppConfigurationManager();
            ConfigurationReader configReader = new ConfigurationReader();
            string connectionString = configReader.GetServiceConfiguration(configManager);

            CrmServiceClient serviceClient = new CrmServiceClient(connectionString);

            RepositoriesFactory factory = new RepositoriesFactory(serviceClient);
            var subjectsRepository = factory.Get<SubjectsRepository>();

            var subjectsList = subjectsRepository.GetAllSubjects().ToList<Subject>(); 
            Console.WriteLine($"Retrieved subjects count: {subjectsList.Count}");

            var documentDbClient = new MongoClient();
            var documentDb = documentDbClient.GetDatabase("MphBackup");
            BsonClassMap.RegisterClassMap<EntityReference>();

            DocumentDbUnitOfWork unitOfWork = new DocumentDbUnitOfWork(documentDb); 
            new SubjectsDataExport(unitOfWork).Run(subjectsList);
            Console.ReadLine();

        }
    }
}
