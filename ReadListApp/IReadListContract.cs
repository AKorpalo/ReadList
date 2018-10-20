using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReadListApp
{
    [ServiceContract(Namespace = "MyCompany.com")]
    public interface IReadListContract
    {
        [OperationContract]
        List<ReadList> GetAllReadLists();

        [OperationContract]
        ReadList GetById(int id);

        [OperationContract]
        List<ReadList> FindByAuthorOrTitle(string search);

        [OperationContract]
        string InsertReadList(string authorName, string bookTitle, DateTime readingDate, int page, int rating);

        [OperationContract]
        string DeleteById(int id);

        [OperationContract]
        string UpdateReadList(ReadList newReadList);
    }
}
