namespace TransApp.Migrations
{
    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TransApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TransApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TransApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /*var vids = new List<Video>
            {
                new Video
                {
                    videoCategory = "Hasar",
                    videoName = "Hackers",
                    videoTime = DateTime.Parse("2013-03-03")
                },
                new Video
                {
                    videoCategory = "Hryllings",
                    videoName = "The Matrix",
                    videoTime = DateTime.Parse("2009-01-12")
                },
                new Video
                {
                    videoCategory = "Gaman",
                    videoName = "Hitchikers guide to the galaxy",
                    videoTime = DateTime.Parse("2010-10-23")
                },
                new Video
                {
                    videoCategory = "�vint�ra",
                    videoName = "Lord of the rings: Fellowship of the ring",
                    videoTime = DateTime.Parse("2006-01-01")
                },
                new Video
                {
                    videoCategory = "R�mant�k",
                    videoName = "P.S I love you",
                    videoTime = DateTime.Parse("2003-03-13")
                },
            
            };

            vids.ForEach(a => context.videos.Add(a));
            context.SaveChanges();

            var translations = new List<Translation>
            {
                new Translation
                {
                    vID = 1,
                    translationDescription = "Lorem ipsum",
                    translationName = "Hackers",
                    translationCategory = "Hasar",
                    translationText = "Lorem ipsum",
                    translationLanguage = "Enska",
                    translationTime = DateTime.Parse("2013-03-03")

                },
                new Translation
                {
                    vID = 1,
                    translationDescription = "Lorem ipsum Loreum",
                    translationText = "Lorem ipsum ipsum",
                    translationName = "Hackers",
                    translationCategory = "Hasar",
                    translationLanguage = "Franska",
                    translationTime = DateTime.Parse("2013-08-03")

                },
                 new Translation
                {
                    vID = 2,
                    translationDescription = "Lorem ipsum",
                    translationText = "Lorem ipsum",
                    translationName = "The Matrix",
                    translationCategory = "Hryllings",
                    translationLanguage = "Franska",
                    translationTime = DateTime.Parse("2013-03-03")

                },
                 new Translation
                {
                    vID = 3,
                    translationDescription = "Lorem ipsum",
                    translationText = "Lorem ipsum",
                    translationName = "Hitchikers guide to the galaxy",
                    translationCategory = "Gaman",
                    translationLanguage = "Enska",
                    translationTime = DateTime.Parse("2013-03-03")

                },
                 new Translation
                {
                    vID = 4,
                    translationDescription = "Lorem ipsum",
                    translationText = "Lorem ipsum",
                    translationName = "Lord of the rings: Fellowship of the ring",
                    translationCategory = "�vint�ra",
                    translationLanguage = "Enska",
                    translationTime = DateTime.Parse("2013-03-03")

                },
                 new Translation
                {
                    vID = 5,
                    translationDescription = "Lorem ipsum",
                    translationText = "Lorem ipsum",
                    translationName = "P.S I love you",
                    translationCategory = "R�mant�k",
                    translationLanguage = "�slenska",
                    translationTime = DateTime.Parse("2013-03-03")

                },
            };

            translations.ForEach(t => context.translations.Add(t));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment
                {
                    tID = 1,
                    userName = "Stef�n",
                    commentText = "Wow this is amazing",
                    commentTime = DateTime.Parse("2014-01-17")
                },
                new Comment
                {
                    tID = 1,
                    userName = "Stef�n",
                    commentText = "No I stand corrected this sux",
                    commentTime = DateTime.Parse("2014-02-17")
                },
                new Comment
                {
                    tID = 2,
                    userName = "Rikki",
                    commentText = "I think this is amazing",
                    commentTime = DateTime.Parse("2014-01-17")
                },
                new Comment
                {
                    tID = 2,
                    userName = "Rikki",
                    commentText = "Fluck you Rikki",
                    commentTime = DateTime.Parse("2014-03-17")
                },
                new Comment
                {
                    tID = 3,
                    userName = "Stef�n",
                    commentText = "HAHAHAHAHAH",
                    commentTime = DateTime.Parse("2014-01-17")
                },
                new Comment
                {
                    tID = 4,
                    userName = "Dan�el Brandur",
                    commentText = "Smuuuuu",
                    commentTime = DateTime.Parse("2013-01-17")
                },
                new Comment
                {
                    tID = 5,
                    userName = "Stef�n",
                    commentText = "Wow this is amazing",
                    commentTime = DateTime.Parse("2014-01-17")
                },
                new Comment
                {
                    tID = 3,
                    userName = "Kristj�n",
                    commentText = "�� fer �g bara heim og drep mig!",
                    commentTime = DateTime.Parse("2014-01-17")
                },
                new Comment
                {
                    tID = 3,
                    userName = "Kalli",
                    commentText = "�g er ekki miki� fyrir �etta",
                    commentTime = DateTime.Parse("2014-01-17")
                },
                new Comment
                {
                    tID = 2,
                    userName = "S�li",
                    commentText = "miiiuiuiui",
                    commentTime = DateTime.Parse("2014-01-17")
                },
            };

            comments.ForEach(c => context.comments.Add(c));
            context.SaveChanges();*/

            var req = new List<UserRequest>
            {
                new UserRequest{
                    userName = "Stef�n",
                    requestName = "James Bond",
                    requestText = "mig vantar hj�lp",
                    requestLanguage = "Enska",
                    likes = 8,
                    requestTime = DateTime.Parse("2014-02-28 15:00:00")
                },
                new UserRequest{
                    userName = "Rikki",
                    requestName = "Hobbit",
                    requestText = "Hall� mig vantar hj�lp",
                    requestLanguage = "Enska",
                    likes = 32,
                    requestTime = DateTime.Parse("2014-02-27 15:00:00")
                },
                new UserRequest{
                    userName = "Kristj�n",
                    requestName = "Men in Black",
                    requestText = "mig vantar hj�lp",
                    requestLanguage = "�slenska",
                    likes = 100,
                    requestTime = DateTime.Parse("2014-02-26 15:00:00")
                },
                new UserRequest{
                    userName = "Haf��r",
                    requestName = "Hobbit",
                    requestText = "mig vantar hj�lp",
                    requestLanguage = "Franska",
                    likes = 10,
                    requestTime = DateTime.Parse("2014-02-25 15:00:00")
                },
                new UserRequest{
                    userName = "S�li",
                    requestName = "Lord of the rings",
                    requestText = "what mig vantar hj�lp",
                    requestLanguage = "��ska",
                    likes = 2,
                    requestTime = DateTime.Parse("2014-02-24 15:00:00")
                },
            };

            req.ForEach(s => context.userRequest.Add(s));
            context.SaveChanges();
        }
    }
}
