using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Service.Interface
{
    public interface IPostService
    {
        Post Insert(Post obj);

        Post Update(Post obj);

        IList<Post> Select();

        Post Select(int id);
       
    }
}
