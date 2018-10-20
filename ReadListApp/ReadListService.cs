using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReadListApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ReadListService : IReadListContract
    {
        public string DeleteById(int id)
        {
            using (ReadListContext db = new ReadListContext())
            {
                ReadList readList = db.ReadLists.Find(id);
                if (readList != null)
                {
                    db.Entry(readList).State = EntityState.Deleted;
                    db.SaveChanges();
                    return "Delete successful!";
                }else return "Row with this id does not exist.";
            }
        }

        public List<ReadList> FindByAuthorOrTitle(string search)
        {
            using (ReadListContext db = new ReadListContext())
            {
                var d = from p in db.ReadLists
                    where p.AuthorName.ToLower().Contains(search.ToLower()) || p.BookTitle.ToLower().Contains(search.ToLower())
                    select p;
                return d.ToList();
            }
        }

        public List<ReadList> GetAllReadLists()
        {
            using (ReadListContext db = new ReadListContext())
            {
                return db.ReadLists.ToList();
            }
        }

        public ReadList GetById(int id)
        {
            using (ReadListContext db = new ReadListContext())
            {
                return db.ReadLists.Find(id);
            }
        }

        public string InsertReadList(string authorName, string bookTitle, DateTime readingDate, int page, int rating)
        {
            if (string.IsNullOrEmpty(authorName))
                return "Insert failed, because authorName should not be null or empty string.";
            if (string.IsNullOrEmpty(bookTitle))
                return "Insert failed, because bookTitle should not be null or empty string.";
            if (page <= 0)
                return "Insert failed, because book must have more pages than zero or less.";
            if (rating <= 0 || rating > 5)
                return "Insert failed, because rating must be more than one and less than five.";

            using (ReadListContext db = new ReadListContext())
            {
                ReadList readList = new ReadList(){AuthorName = authorName,
                                                   BookTitle = bookTitle,
                                                   ReadingDate = readingDate,
                                                   Page = page,
                                                   Rating = rating
                };
                db.ReadLists.Add(readList);
                db.SaveChanges();
                return "Insert successful!";
            }
        }

        public string UpdateReadList(ReadList newReadList)
        {
            using (ReadListContext db = new ReadListContext())
            {
                ReadList temp = db.ReadLists.Find(newReadList.Id);
                if (temp == null)
                    return "Update failed, because row with this id does not exist.";
                if (string.IsNullOrEmpty(newReadList.AuthorName))
                    return "Insert failed, because authorName should not be null or empty string.";
                if (string.IsNullOrEmpty(newReadList.BookTitle))
                    return "Insert failed, because bookTitle should not be null or empty string.";
                if (newReadList.Page <= 0)
                    return "Update failed, because book must have more pages than zero or less.";
                if (newReadList.Rating <= 0 || newReadList.Rating > 5)
                    return "Update failed, because rating must be more than one and less than five.";
                db.Entry(newReadList).State = EntityState.Modified;
                db.SaveChanges();
                return "Update successful!";
            }
        }
    }
}
