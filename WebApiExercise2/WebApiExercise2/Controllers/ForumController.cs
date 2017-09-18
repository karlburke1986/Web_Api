using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExercise2.Models;

namespace WebApiExercise2.Controllers
{
    public class ForumController : ApiController
    {
        private static List<ForumPost> list = new List<ForumPost>();

        public IEnumerable<ForumPost> GetAll()
        {
            return list;
        }

        public ForumPost GetMessage(int ID)
        {
            ForumPost item = list.FirstOrDefault(i => i.ID == ID);
            if(item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return item;
            }
        }

        public void AddNewPost(UserPost post)
        {
            if(ModelState.IsValid)
            {
                ForumPost NewPost = new ForumPost();

                int id;

                if(list.Count == 0)
                {
                    id = 0;
                }
                else
                {
                    id = list.Count + 1;
                }

                NewPost.ID = id;
                NewPost.Date = DateTime.Now;
                NewPost.Post.Message = post.Message;
                NewPost.Post.Subject = post.Subject;

                list.Add(NewPost);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public IEnumerable<ForumPost>GetNewPosts()
        {
            List<ForumPost> temp = new List<ForumPost>(list);            

            int size = temp.Count();

            if(size == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else if(size < 5)
            {
                var items = temp.OrderByDescending(p => p.ID).Take(size);

                return items;             
            }
            
            return Enumerable.Reverse(list).Take(5);
        }
        
    }
}
