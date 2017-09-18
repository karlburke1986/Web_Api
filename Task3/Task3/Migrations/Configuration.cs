namespace Task3.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Task3.Models.TextContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TextContext context)
        {
            var texts = new List<Text>
            {
                new Text { Message = "hello", NumberReceiver = 123456, NumberSender = 986452 },
                new Text { Message = "Hi", NumberReceiver = 567890, NumberSender = 394785812},
                new Text { Message = "Yoyo", NumberReceiver = 394091, NumberSender = 95029592 }
            };

            foreach(var item in texts)
            {
                Text t = new Text();
                t.Message = item.Message;
                t.NumberReceiver = item.NumberReceiver;
                t.NumberSender = item.NumberSender;

                context.Texts.Add(t);
            }

            context.SaveChanges();
        }
    }
}
