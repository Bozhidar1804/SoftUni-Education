﻿namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();


            DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                            .Select(s => new
                            {
                                SongName = s.Name,
                                Price = s.Price.ToString("f2"),
                                WriterName = s.Writer.Name
                            })
                            .OrderByDescending(s => s.SongName)
                            .ThenBy(s => s.WriterName)
                            .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                int songNumber = 1;
                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.WriterName}");
                    songNumber++;
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => new
                        {
                            PerformerFullName = $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                        })
                        .OrderBy(sp => sp.PerformerFullName)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer,
                    Duration = s.Duration
                        .ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            int songCount = 1;
            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{songCount}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Writer: {s.WriterName}");
                
                foreach (var p in s.Performers)
                {
                    sb.AppendLine($"---Performer: {p.PerformerFullName}");
                }
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer.Name}");
                sb.AppendLine($"---Duration: {s.Duration}");

                songCount++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
