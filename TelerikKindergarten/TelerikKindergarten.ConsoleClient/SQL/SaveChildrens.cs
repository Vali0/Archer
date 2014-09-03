﻿namespace TelerikKindergarten.ConsoleClient.SQL
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Driver.Linq;
    using TelerikKindergarten.ConsoleClient.MongoDatabaseOperations;
    using TelerikKindergarten.Data;
    using TelerikKindergarten.SQL.Model;


   class SaveChildrens
    {
       public static void SeedChildrensToSQL(TelerikKindergartenData context, MongoDatabase mongoContext)
       {
           var groupsForTransfer = GetData.GetGroupsFromMongo(mongoContext);
           var childrenForTransfer = AddChildren(groupsForTransfer);

           foreach (var child in childrenForTransfer)
           {
               context.Children.Add(new Child()
               {
                   FirstName = child.LastName,
                   MiddleName = child.LastName,
                   LastName = child.LastName,
                   Address = child.Address,
                   AdmissionDate = child.AdmissionDate,
                   ConclusionDate = child.ConclusionDate,
                   GroupID = 10
               });
           }

           context.SaveChanges();
       }

       private static ICollection<Child> AddChildren(IQueryable<Group> groupsForTransfer)
       {
           var childs = new List<Child>();

           foreach (var group in groupsForTransfer)
           {
               foreach (var child in group.Children)
               {
                   child.Group = group;
                   childs.Add(child);
               }
           }

           return childs;
       }
    }
}