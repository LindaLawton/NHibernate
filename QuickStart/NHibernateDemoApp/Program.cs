using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NHibernateDemoApp.Domain;
using NHibernateDemoApp.Mappings;
using System;
using System.Linq;

namespace NHibernateDemoApp
{

    // import Install-Package NHibernate
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = @"Server=.\sqlexpress;initial catalog=NHibernateTest;Integrated Security=true"; 
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });

            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<PersonMapping>();
            modelMapper.AddMapping<CarMapping>();

            var mapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mapping,"Test");
            var schema = new SchemaExport(configuration);
            
            //schema.Execute(true, true, false);   // Uncomment to create database

            var buildSessionFactory = configuration.BuildSessionFactory();
            using (var session = buildSessionFactory.OpenSession()) 
            using (var tx = session.BeginTransaction())
            {
                // Insert
                var person = new Person
                {
                    FirstName = "Linda",
                    LastName = "Lawton",
                    Address =  "Herningvej 108",
                    Car = new Car { Make = "Chevrolet", Model = "Camaro", Year = "1967" }
                };
                session.Save(person);

                Console.WriteLine(person);

                // Select
                var people = session.QueryOver<Person>().Where(p => p.FirstName == "Linda").List();
                Console.WriteLine(people);

                // Update
                people.FirstOrDefault().Car.Year = "1968";
                Console.WriteLine(people.FirstOrDefault());

                // Delete
                session.Delete(people);

                //var hold = session.QueryOver<Person>().Future();
                //var cars = session.QueryOver<Car>().Future();
                // Some time passes
                //foreach (var student in hold)
                //{
                //    Console.WriteLine(student);
                //}
              
                tx.Commit();
            }

            Console.ReadLine();
        }
    }
}
